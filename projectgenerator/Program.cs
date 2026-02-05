#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

class Program
{
    #region Fields and Constants

    /// <summary>
    /// Stores all the unique target frameworks found
    /// </summary>
    private static List<string> frameworks = new List<string>();

    /// <summary>
    /// Stores all the unique suffix of of the target frameworks
    /// </summary>
    private static readonly HashSet<string> AllframeworkSuffix = new HashSet<string>();

    #endregion

    #region Main Execution Flow

    /// <summary>
    /// The main entry point of the application
    /// </summary>
    /// <param name="args">arguements</param>
    static void Main(string[] args)
    {
        string currentDirectory = AppContext.BaseDirectory;
        string rootPath = Path.GetFullPath(Path.Combine(currentDirectory, "..", "..", "..", ".."));
        Console.WriteLine(rootPath);

        string[] extensions = { "*.targets", "*.csproj", "*.sln" };
        string[] excludeProject = { "ProjectGenerator", "syncfusion.samplebrowser.wpf_store", "syncfusion.samplebrowser.wpf_test", "JSONGenerator", "package-reference-utility" };
        
        var projectFiles = new List<string>();
        var csProjectFiles = new List<string>();
        var sbCsProjectFiles = new List<string>();
        var slnFiles = new List<string>();
        var sbSlnFiles = new List<string>();
        var excludedNames = new HashSet<string>(excludeProject.Where(s => !string.IsNullOrWhiteSpace(s)), StringComparer.OrdinalIgnoreCase);

        bool isExcluded(string path)
        {
            string fileName = Path.GetFileNameWithoutExtension(path);
            if(excludedNames.Contains(fileName)) return true;

            var segments = path.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
            return segments.Any(segment => excludedNames.Any(excluded => segment.Contains(excluded, StringComparison.OrdinalIgnoreCase)));
        }

        foreach (string extension in extensions)
        {
            projectFiles.AddRange(Directory.GetFiles(rootPath, extension, SearchOption.AllDirectories).Where(p => !isExcluded(p)));
        }

        Console.WriteLine("****** Phase 1: CLean Project Files *********");
        CleanProject(projectFiles, false);

        if (projectFiles.Count == 0)
        {
            Console.WriteLine("No projects Found");
        }

        csProjectFiles = Directory.GetFiles(rootPath, "*.csproj", SearchOption.AllDirectories).Where(p => !isExcluded(p)).ToList();
        slnFiles = Directory.GetFiles(rootPath, "*.sln", SearchOption.AllDirectories).Where(p => !isExcluded(p)).ToList();
        var generatedProjects = new List<ProjectInfo>();

        Console.WriteLine("****** Phase 2: Generating New Project Files *********");
        foreach (string file in csProjectFiles)
        {
            generatedProjects.AddRange(ProjectFileChanges(file));
        }

        Console.WriteLine("****** Phase 3: Generating New Solution Files *********");
        if (generatedProjects.Any() && slnFiles.Any())
        {
            var solutionGroups = generatedProjects.GroupBy(proj => proj.OriginalSolutionPath);

            foreach (var solution in solutionGroups)
            {
                string originalSolutionPath = solution.Key;
                if (originalSolutionPath == null) continue;

                string targetSolutionFile = slnFiles.FirstOrDefault(sln => Path.GetFullPath(sln).Equals(Path.GetFullPath(originalSolutionPath), StringComparison.OrdinalIgnoreCase));

                if (targetSolutionFile != null)
                {
                    foreach (var projInfo in solution)
                    {
                        if (string.IsNullOrEmpty(projInfo.NewSolutionPath))
                        {
                            DuplicateSolutionFile(targetSolutionFile, projInfo, projInfo.suffix);
                            projInfo.NewSolutionPath = Path.Combine(Path.GetDirectoryName(targetSolutionFile),
                                $"{Path.GetFileNameWithoutExtension(originalSolutionPath)}{projInfo.suffix}{Path.GetExtension(originalSolutionPath)}");
                        }

                        SolutionFileChanges(projInfo.NewSolutionPath, solution.Where(p => p.NewSolutionPath == projInfo.NewSolutionPath).ToList());
                    }
                }
                else
                {
                    Console.WriteLine($"   -> Warning: Original solution file: {Path.GetFileName(originalSolutionPath)} not found");
                }
            }
        }
        else if (!slnFiles.Any())
        {
            Console.WriteLine("---- Phase 3: Skipping Solution Files ----");
        }

        Console.WriteLine("---- Phase 4: Removing Olap Project and Solution Files from Core projects ----");
        sbCsProjectFiles = Directory.GetFiles(rootPath, "*.csproj", SearchOption.AllDirectories).Where(p => p.Contains("syncfusion.samplebrowser.wpf")).ToList();
        foreach (string file in sbCsProjectFiles)
        {
            RemoveOlapReferencesFromCsproj(file);
        }

        sbSlnFiles = Directory.GetFiles(rootPath, "*.sln", SearchOption.AllDirectories).Where(p => p.Contains("syncfusion.samplebrowser.wpf")).ToList();
        foreach (string file in sbSlnFiles)
        {
            RemoveOlapProjectsFromSolution(file);
        }

        Console.WriteLine("****************** Processing Complete *******************");
        Console.WriteLine("---- Phase 5: Removing SDK Style Project and Solution Files ----");
        CleanProject(projectFiles, true);

#if !DEBUG
        Environment.Exit(0);
#endif
    }

    #endregion

    #region ProjectFile Processing

    /// <summary>
    /// The processing of the .csproject file finds .targets file, reads framework and generated the suffixed .csproj and .targets file 
    /// </summary>
    /// <param name="projectFilePath">Absolute path of the source .csproj file path</param>
    /// <returns>A list of newly created ProjectInfo objects for the generated projects file.</returns>
    static List<ProjectInfo> ProjectFileChanges(string projectFilePath) { 
        var newProjects = new List<ProjectInfo>();

        Console.WriteLine($"Processing Source project: {Path.GetFileName(projectFilePath)}");
        try
        {
            var projectDocument = XDocument.Load(projectFilePath);
            XNamespace ns = projectDocument.Root?.GetDefaultNamespace() ?? "";

            var importElement = projectDocument.Descendants(ns + "Import").FirstOrDefault(elem => elem.Attribute("Project")?.Value.EndsWith(".targets") ?? false);
            if (importElement == null) return newProjects;

            string originalImportPath = importElement.Attribute("Project").Value;
            string targetFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(projectFilePath), originalImportPath));
            if (!File.Exists(targetFilePath)) return newProjects;

            var (frameworksList, targetsDoc) = GetFrameworksFromTargets(targetFilePath);
            //if (!frameworksList.Any()) return newProjects;

            foreach (var framework in frameworksList)
            {
                if (!frameworks.Contains(framework))
                {
                    frameworks.Add(framework);
                }
            }

            Console.WriteLine($"  Found Frameworks: {string.Join(", ", frameworks)}");
            foreach (var framework in frameworks)
            {
                string suffix = FrameworkSuffix(framework);

                string newTargetsFileName = TargetFileChanges(targetFilePath, suffix, framework, targetsDoc, ns);

                var newProject = ProjectFileChanges(projectFilePath, suffix, originalImportPath, newTargetsFileName);
                if (newProject != null)
                {
                    newProject.OriginalSolutionPath = FindOriginalSln(projectFilePath);
                    newProjects.Add(newProject);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"    --> Error processing file: {Path.GetFileName(projectFilePath)} :", ex.Message);
        }

        return newProjects;
    }

    /// <summary>
    /// Creates a new suffixed .csproj file by copying an original file, updating its AssemblyName,
    /// Import path, and ProjectReferences.
    /// </summary>
    /// <param name="originalPath">The path to the original .csproj file.</param>
    /// <param name="suffix">The suffix to append (e.g., "_Net80").</param>
    /// <param name="originalImportPath">The original Include path for the .targets file from the .csproj.</param>
    /// <param name="newTargetsFileName">The filename of the newly generated .targets file.</param>
    /// <returns>A ProjectInfo object for the newly created .csproj, or null if an error occurs.</returns>
    static ProjectInfo ProjectFileChanges(string originalPath, string suffix, string originalImportPath, string newTargetsFileName)
    {
        var document = XDocument.Load(originalPath);
        var ns = document.Root?.GetDefaultNamespace() ?? "";

        var importElement = document.Descendants(ns + "Import").FirstOrDefault(el => el.Attribute("Project")?.Value == originalImportPath);
        if (importElement != null)
        {
            importElement.SetAttributeValue("Project", originalImportPath.Replace(Path.GetFileName(originalImportPath), newTargetsFileName));
        }

        var projectReferenceElement = document.Descendants(ns + "ProjectReference");
        foreach (var projectReference in projectReferenceElement)
        {
            string currentInclude = projectReference.Attribute("Include")?.Value;
            if (currentInclude != null && currentInclude.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase))
            {
                string projectDirectory = Path.GetDirectoryName(originalPath);
                string referenceFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(projectDirectory), originalPath));

                if(!currentInclude.Contains("_Net", StringComparison.OrdinalIgnoreCase))
                {
                    string refenceProjectDirectory = Path.GetDirectoryName(currentInclude)?.Replace("\\", "/") ?? "";
                    string refenceProjectFileName = Path.GetFileName(currentInclude);
                    string refenceProjectBaseName = Path.GetFileNameWithoutExtension(currentInclude);
                    string refenceProjectExtension = Path.GetExtension(currentInclude);

                    string referenceProjectInclude = refenceProjectDirectory == "" ? $"{refenceProjectBaseName}{suffix}{refenceProjectExtension}" :
                        Path.Combine(refenceProjectDirectory, $"{refenceProjectBaseName}{suffix}{refenceProjectExtension}").Replace("\\", "/");

                    projectReference.Attribute("Include").Value = referenceProjectInclude;
                }
            }
        }

        string newFileName = $"{Path.GetFileNameWithoutExtension(originalPath)}{suffix}{Path.GetExtension(originalPath)}";
        string newFilePath = Path.Combine(Path.GetDirectoryName(originalPath), newFileName);

        document.Save(newFilePath);
        Console.WriteLine($"    -> Created Project File: {newFileName}");

        return new ProjectInfo(originalPath, newFilePath, string.Empty, string.Empty, suffix);
    }

    #endregion

    #region Solution File Processing

    /// <summary>
    /// Updates a solution file to include the newly generated projects. If a suffixed solution
    /// file doesn't exist, it's created by copying the original. It then modifies the project
    /// entries within that solution file instance.
    /// </summary>
    /// <param name="solutionFileName">The path to the target SLN file (can be original or newly created suffixed version).</param>
    /// <param name="projectsForThisSolution">A list of ProjectInfo objects relevant to this solution file.</param>
    static void SolutionFileChanges(string solutionFileName, List<ProjectInfo> projectInfos)
    {
        Console.WriteLine($"Updating Solution Files ");

        string slnText = File.ReadAllText(solutionFileName);
        string[] slnLines = slnText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var updatedLines = slnLines.ToList();
        string projectFilename = string.Empty;
        string projectSuffix = string.Empty;
        bool changesMade = false;

        // Create a mapping from original project *path* to its generated counterpart's suffix
        var projectSuffixMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var projectInfo in projectInfos)
        {
            // We need the suffix applied. The suffix is usually "_" followed by capitalized framework.
            string baseName = Path.GetFileNameWithoutExtension(projectInfo.SourcePath);
            string generatedFileName = Path.GetFileName(projectInfo.NewPath);
            projectFilename = generatedFileName;
            string suffix = "";
            if (generatedFileName.Contains("_") && generatedFileName.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase))
            {
                suffix = generatedFileName.Substring(baseName.Length, generatedFileName.Length - baseName.Length - ".csproj".Length);
            }

            if (!string.IsNullOrEmpty(suffix))
            {
                projectSuffixMap[projectInfo.SourcePath] = suffix;
            }
        }

        var originalProjectGuids = new Dictionary<string, string>();

        // --- Process Project Blocks ---
        for (int i = 0; i < updatedLines.Count; i++)
        {
            string line = updatedLines[i];

            // Regex to capture the critical parts of a project definition line
            // Project("{GUID}") = "ProjectName", "ProjectPath", "{ProjectGUID}"
            var projectMatch = Regex.Match(line, @"^Project\(""(.*?)""\)\s+=\s+""(.*?)""\s*,\s*""(.*?)""\s*,\s*""(.*?)""$");

            if (projectMatch.Success)
            {
                string projectTypeGuid = projectMatch.Groups[1].Value;
                string projectName = projectMatch.Groups[2].Value;
                string projectPath = projectMatch.Groups[3].Value;
                string projectGuid = projectMatch.Groups[4].Value;

                if (!projectPath.Contains(".csproj")) continue;

                // Resolve the actual file path to compare with our source paths
                string currentProjectPathResolved = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(solutionFileName), projectPath));

                // Check if this project entry corresponds to one of our source projects that was duplicated
                if (projectSuffixMap.TryGetValue(currentProjectPathResolved, out string suffix))
                {
                    projectSuffix = suffix;
                    originalProjectGuids[currentProjectPathResolved] = projectGuid; // Store original GUID

                    string newProjectName = projectName + suffix;
                    // Construct the new path, maintaining relative path structure if possible
                    string newProjectPath = Path.Combine(Path.GetDirectoryName(projectPath) ?? "", Path.GetFileName(projectFilename)).Replace("\\", "/");

                    // Reconstruct the line
                    string newLine = $"Project(\"{projectTypeGuid}\") = \"{newProjectName}\", \"{newProjectPath}\", \"{projectGuid}\"";
                    updatedLines[i] = newLine;
                    changesMade = true;
                    Console.WriteLine($"  -> Updated Project Line: '{projectName}' -> '{newProjectName}'");
                }
                else
                {
                    string newProjectName = projectName + projectSuffix;
                    // Construct the new path, maintaining relative path structure if possible
                    string newProjectPath = Path.Combine(Path.GetDirectoryName(projectPath) ?? "", Path.GetFileName(newProjectName)).Replace("\\", "/");

                    // Reconstruct the line
                    string newLine = $"Project(\"{projectTypeGuid}\") = \"{newProjectName}\", \"{newProjectPath}{Path.GetExtension(projectPath)}\", \"{projectGuid}\"";
                    updatedLines[i] = newLine;
                    changesMade = true;
                    Console.WriteLine($"  -> Updated Project Line: '{projectName}' -> '{newProjectName}'");
                }
            }
        }

        int configSectionStartIndex = -1;
        int configSectionEndIndex = -1;
        for (int i = 0; i < updatedLines.Count; i++)
        {
            if (updatedLines[i].Contains("ProjectConfigurationPlatforms"))
            {
                configSectionStartIndex = i;
                // Find the end of this section (usually marked by the next global section or EndGlobal)
                for (int j = i + 1; j < updatedLines.Count; j++)
                {
                    if (updatedLines[j].TrimStart().StartsWith("EndGlobalSection"))
                    {
                        configSectionEndIndex = j;
                        break;
                    }
                }
                break;
            }
        }

        if (configSectionStartIndex != -1 && configSectionEndIndex != -1)
        {
            for (int i = configSectionStartIndex; i <= configSectionEndIndex; i++)
            {
                string line = updatedLines[i];

                // Check lines like: {GUID}.{Configuration}.{Platform} = {GUID}
                var configMatch = Regex.Match(line, $@"^(\s*){{([A-F0-9-]{{36}})}}.(.*?)\s+=\s+{{([A-F0-9-]{{36}})}}$");

                if (configMatch.Success)
                {
                    string indent = configMatch.Groups[1].Value;
                    string originalGuid = configMatch.Groups[2].Value;
                    string configPlatform = configMatch.Groups[3].Value;
                    string linkedGuid = configMatch.Groups[4].Value;
                    string sourceProjectPathOfTheGuid = null;
                    foreach (var kvp in originalProjectGuids)
                    {
                        if (kvp.Value.Equals(originalGuid, StringComparison.OrdinalIgnoreCase))
                        {
                            sourceProjectPathOfTheGuid = kvp.Key;
                            break;
                        }
                    }
                }
            }
        }

        // Write the modified text back to the solution file
        if (changesMade)
        {
            File.WriteAllLines(solutionFileName, updatedLines);
            Console.WriteLine("  -> Solution file updated successfully.");
        }
        else
        {
            Console.WriteLine("  -> No changes needed for this solution file.");
        }
    }

    #endregion

    #region Helper Methods

   /// <summary>
   /// Remove the Olap references from the CsProject
   /// </summary>
   /// <param name="projectFilePath">Project file path for SB</param>
    static void RemoveOlapReferencesFromCsproj(string projectFilePath)
    {
        try
        {
            var doc = XDocument.Load(projectFilePath);
            XNamespace ns = doc.Root?.GetDefaultNamespace() ?? "";

            var refs = doc.Descendants(ns + "ProjectReference").ToList();
            bool changed = false;

            foreach (var pr in refs)
            {
                var include = pr.Attribute("Include")?.Value ?? string.Empty;

                bool isOlap = include.IndexOf("syncfusion.olap", StringComparison.OrdinalIgnoreCase) >= 0;
                bool isNewerFramework = AllframeworkSuffix.Any(s =>
                    include.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0);
                bool isNet462 = include.IndexOf("_Net462", StringComparison.OrdinalIgnoreCase) >= 0;

                if (isOlap && isNewerFramework && !isNet462)
                {
                    pr.Remove();
                    changed = true;
                    Console.WriteLine($"    -> Removed OLAP reference from: {Path.GetFileName(projectFilePath)} -> {include}");
                }
            }

            if (changed)
            {
                doc.Save(projectFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"    --> Error cleaning OLAP references in: {Path.GetFileName(projectFilePath)}: {ex.Message}");
        }
    }

    /// <summary>
    /// Remove the Olap references from the Solution Projects
    /// </summary>
    /// <param name="solutionFilePath">Solution file path for the SB</param>
    static void RemoveOlapProjectsFromSolution(string solutionFilePath)
    {
        try
        {
            var lines = File.ReadAllLines(solutionFilePath).ToList();
            var removedGuids = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            bool changed = false;

            // Remove matching Project blocks
            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                var m = Regex.Match(line, @"^Project\(""(.*?)""\)\s+=\s+""(.*?)""\s*,\s*""(.*?)""\s*,\s*""({[A-F0-9\-]{36}})""$", RegexOptions.IgnoreCase);
                if (!m.Success) continue;

                string projName = m.Groups[2].Value;   // e.g., syncfusion.olapclientdemos.wpf_lib_Net80
                string projPath = m.Groups[3].Value;   // relative path
                string projGuid = m.Groups[4].Value;   // {GUID}

                bool isOlap = projName.IndexOf("syncfusion.olap", StringComparison.OrdinalIgnoreCase) >= 0
                              || projPath.IndexOf("syncfusion.olap", StringComparison.OrdinalIgnoreCase) >= 0;

                bool isNewerFramework = AllframeworkSuffix.Any(s =>
                    projName.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    projPath.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0);

                bool isNet462 = projName.IndexOf("_Net462", StringComparison.OrdinalIgnoreCase) >= 0
                                || projPath.IndexOf("_Net462", StringComparison.OrdinalIgnoreCase) >= 0;

                if (isOlap && isNewerFramework && !isNet462)
                {
                    // Remove the entire Project block (Project ... EndProject)
                    int j = i + 1;
                    while (j < lines.Count && !lines[j].StartsWith("EndProject", StringComparison.Ordinal))
                        j++;
                    if (j < lines.Count) j++; // include EndProject

                    lines.RemoveRange(i, j - i);
                    removedGuids.Add(projGuid);
                    changed = true;
                    Console.WriteLine($"    -> Removed OLAP project from solution: {projName} ({projGuid})");

                    i--; // stay at same index after removal
                }
            }

            // Remove config and nesting lines referencing removed GUIDs
            if (removedGuids.Count > 0)
            {
                int before = lines.Count;
                lines.RemoveAll(l => removedGuids.Any(g => l.IndexOf(g, StringComparison.OrdinalIgnoreCase) >= 0));
                if (lines.Count != before) changed = true;
            }

            if (changed)
            {
                File.WriteAllLines(solutionFilePath, lines);
                Console.WriteLine($"    -> Cleaned solution: {Path.GetFileName(solutionFilePath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"    --> Error cleaning solution: {Path.GetFileName(solutionFilePath)}: {ex.Message}");
        }
    }

    /// <summary>
    /// Creates a new single-framework .targets file by copying and modifying an original multi-targeted .targets file.
    /// </summary>
    /// <param name="originalPath">The path to the original .targets file.</param>
    /// <param name="suffix">The suffix to append (e.g., "_Net80").</param>
    /// <param name="framework">The specific target framework for this new file (e.g., "net8.0").</param>
    /// <param name="originalDoc">The loaded XDocument of the original .targets file.</param>
    /// <param name="ns">The XML namespace of the original .targets file.</param>
    /// <returns>The filename of the newly created .targets file.</returns>
    static string TargetFileChanges(string originalPath, string suffix, string framework, XDocument originalDoc, XNamespace ns)
    {
        string newFileName = $"{Path.GetFileNameWithoutExtension(originalPath)}{suffix}{Path.GetExtension(originalPath)}";
        string newFilePath = Path.Combine(Path.GetDirectoryName(originalPath), newFileName);
        if (!File.Exists(newFilePath))
        {
            var documentCopy = new XDocument(originalDoc);
            var elementToReplace = documentCopy.Descendants(ns + "TargetFrameworks").FirstOrDefault();
            if (elementToReplace != null)
            {
                elementToReplace.ReplaceWith(new XElement(ns + "TargetFrameworks", framework));
            }

            var importElement = documentCopy.Descendants(ns + "Import").FirstOrDefault(elem => elem.Attribute("Project")?.Value.EndsWith(".targets") ?? false);
            if (importElement != null)
            {
                string originalImportPath = importElement.Attribute("Project").Value;
                string newProjectName = originalImportPath.Replace(".targets", $"{suffix}.targets");
                importElement.SetAttributeValue("Project", originalImportPath.Replace(Path.GetFileName(originalImportPath), newProjectName));
            }

            documentCopy.Save(newFilePath);
            Console.WriteLine($"    -> Created Target File: {newFileName}");
        }
        return newFileName;
    }

    /// <summary>
    /// Loads an MSBuild-based project or targets file, parses it as XML, and extracts
    /// </summary>
    /// <param name="path">The absolute path to the .targets or .csproj file to process.</param>
    /// <returns>
    /// A tuple containing:
    /// <term>A <see cref="List{string}"/> of target frameworks found. list will be empty if no framework elements are found or if parsing fails.</item>
    /// </item>
    /// <item> <term>The loaded <see cref="XDocument"/> of the file, allowing further XML manipulation if needed.</term> </item>
    /// </list>
    /// </returns>
    private static (List<string> frameworks, XDocument doc) GetFrameworksFromTargets(string path)
    {
        var doc = XDocument.Load(path);
        var ns = doc.Root?.GetDefaultNamespace() ?? "";
        var frameworkElement = doc.Descendants(ns + "TargetFrameworks").FirstOrDefault();
        if (frameworkElement != null && !string.IsNullOrEmpty(frameworkElement.Value))
        {
            return (frameworkElement.Value.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(f => f.Trim()).ToList(), doc);
        }
        return (new List<string>(), doc);
    }

    /// <summary>
    /// Creates a clean, capitalized suffix from a target framework moniker (TFM).
    /// It extracts the core framework part (e.g., "net8.0" -> "Net80") and any platform prefix (e.g., "windows"). The resulting suffix is prefixed with an underscore.
    /// Examples:
    /// - "net8.0-windows10.0.19041.0" -> "_Net80"
    /// - "net462" -> "_Net462"
    /// - "net8.0" -> "_Net80"
    /// </summary>
    /// <param name="framework">The target framework moniker string.</param>
    /// <returns>A string representing the suffixed framework, prefixed with an underscore, or an empty string if the input is null or empty.</returns>
    private static string FrameworkSuffix(string framework)
    {
        if (string.IsNullOrEmpty(framework))
            return string.Empty;

        string[] parts = framework.Split(new[] { '-' }, 2);
        string coreFramework = parts[0].Replace(".", "");

        if (coreFramework.EndsWith("00", StringComparison.OrdinalIgnoreCase))
        {
            coreFramework = coreFramework.Substring(0, coreFramework.Length - 1);
        }

        string firstWordCaptilize = char.ToUpper(coreFramework[0]) + coreFramework.Substring(1);
        if (!firstWordCaptilize.Contains("462"))
        {
            AllframeworkSuffix.Add(firstWordCaptilize);
        }
        return $"_{firstWordCaptilize}";
    }

    /// <summary>
    /// Creates a suffixed copy of a solution file using a provided suffix.
    /// This method copies the original solution file to a new path derived from the suffix
    /// and updates the corresponding <see cref="ProjectInfo.NewSolutionPath"/> property.
    /// </summary>
    /// <param name="originalSolutionPath">The absolute path to the original solution file (.sln).</param>
    /// <param name="projectInfo">The <see cref="ProjectInfo"/> object containing details about the original project and the desired suffix.</param>
    /// <param name="suffix">The suffix string to append to the solution filename (e.g., "_Net80").</param>
    static void DuplicateSolutionFile(string originalSolutionPath, ProjectInfo projectInfo, string suffix) { 
        try
        {
            string directory = Path.GetDirectoryName(originalSolutionPath);
            string newSolutionFileName = $"{Path.GetFileNameWithoutExtension(originalSolutionPath)}{suffix}{Path.GetExtension(originalSolutionPath)}";
            string newSolutionFilePath = Path.Combine(directory, newSolutionFileName);

            File.Copy(originalSolutionPath, newSolutionFilePath, true);
            projectInfo.NewSolutionPath = newSolutionFilePath;
            Console.WriteLine($" ---> Created Solution File: {newSolutionFileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"    --> Error Creating solution file: {Path.GetFileName(suffix)} :", ex.Message);
        }
    }

    /// <summary>
    /// Searches for a solution file (.sln) by traversing up the directory tree from the given project file's location. It stops and returns the path of the first .sln file found.
    /// </summary>
    /// <param name="projectFilePath">The path to the project file (.csproj) from which to start the search.</param>
    /// <returns>
    /// The absolute path to the first .sln file found, or <c>null</c> if no solution file is found in the hierarchy.
    /// </returns>
    public static string FindOriginalSln(string projectFilePath)
    {
        string currentDirectory = Path.GetDirectoryName(projectFilePath);
        string projectName = Path.GetFileNameWithoutExtension(projectFilePath);
        while (!string.IsNullOrEmpty(currentDirectory))
        {
            var slnFiles = Directory.GetFiles(currentDirectory, "*.sln", SearchOption.TopDirectoryOnly);

            if (slnFiles.Any())
            {
                string matchingSolution = slnFiles.FirstOrDefault(sln => Path.GetFileNameWithoutExtension(sln).Equals(projectName, StringComparison.OrdinalIgnoreCase));
                if (matchingSolution != null) { 
                    return matchingSolution;
                }
                return slnFiles.First();
            }

            currentDirectory = Path.GetDirectoryName(currentDirectory);
        }

        return null;
    }
    #endregion

    #region Clean the project

    /// <summary>
    /// Iterates through a list of project-related file paths and deletes any files. that match the predefined pattern for generated files.
    /// This is used to clean up previous runs of the generation process.
    /// </summary>
    /// <param name="projectFiles">A list of absolute file paths to .csproj, .targets, or .sln files to potentially clean.</param>
    static void CleanProject(List<string> projectFiles, bool isSDKProjectRemoved)
    {
        foreach (string file in projectFiles)
        {
            bool isOlapSample = Path.GetFileName(file).Contains("olap", StringComparison.OrdinalIgnoreCase);
            if (!isSDKProjectRemoved && Path.GetFileName(file).Contains("_Net", StringComparison.OrdinalIgnoreCase))
            {
                DeleteFile(file);
            }
            else if (isSDKProjectRemoved && !Path.GetFileName(file).Contains("_Net", StringComparison.OrdinalIgnoreCase) && !isOlapSample)
            {
                DeleteFile(file);
            } 
            else if (isSDKProjectRemoved && isOlapSample)
            {
                if (!Path.GetFileName(file).Contains("_Net462", StringComparison.OrdinalIgnoreCase))
                {
                    DeleteFile(file);
                }
                else
                {
                    continue;
                }
            }
        }
    }

    /// <summary>
    /// Method to Delete the file
    /// </summary>
    /// <param name="file">path of the file</param>
    static void DeleteFile(string file)
    {
        try
        {
            File.Delete(file);
            Console.WriteLine($"    --> Deleted project File: {Path.GetFileName(file)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Deleting file: {Path.GetFileName(file)}: {ex.Message}");
        }
    }

    #endregion
}

/// <summary>
/// Represents information about a project file
/// </summary>
/// <param name="sourcePath">Including its original source path</param>
/// <param name="newPath">Including its new source path</param>
/// <param name="originalSolutionPath">the original associated solution file</param>
/// <param name="newSolutionPath">the new generated associated solution file</param>
/// <param name="suffix"> newly generated suffixed version</param>
public class ProjectInfo(string sourcePath, string newPath, string originalSolutionPath, string newSolutionPath, string suffix)
{
    public string SourcePath { get; } = sourcePath;
    public string NewPath { get; } = newPath;
    public string OriginalSolutionPath { get; set; } = originalSolutionPath;
    public string NewSolutionPath { get; set; } = newSolutionPath;
    public string suffix { get; } = suffix;
}