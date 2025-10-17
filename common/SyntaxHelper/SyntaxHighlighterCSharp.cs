using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace syncfusion.demoscommon.wpf
{
    public class SyntaxHighlighterCSharp
    {
        #region Local Variables

        private Regex codeRegex;
        private List<Run> codeParagraphGlobal;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the comment reg expression from Code Behind file.
        /// </summary>
        /// <value>The comment reg ex.</value>
        public string CommentRegEx
        {
            get { return @"/\*.*?\*/|//.*?(?=\r|\n)"; }
        }

        /// <summary>
        /// Gets the string reg expression from Code Behind file.
        /// </summary>
        /// <value>The string reg ex.</value>
        public string StringRegEx
        {
            get { return @"@?""""|@?"".*?(?!\\).""|''|'.*?(?!\\).'"; }
        }

        /// <summary>
        /// Gets the keywords from C# file.
        /// </summary>
        /// <value>The keywords.</value>
        public string Keywords
        {
            get
            {
                return "abstract as base bool break byte case catch char "
                + "checked class const continue decimal default delegate do double else "
                + "enum event explicit extern false finally fixed float for foreach goto "
                + "if implicit in int interface internal is lock long namespace new null "
                + "object operator out override partial params private protected public readonly "
                + "ref return sbyte sealed short sizeof stackalloc static string struct "
                + "switch this throw true try typeof uint ulong unchecked unsafe ushort "
                + "using value virtual void volatile where while yield";
            }
        }

        /// <summary>
        /// Gets the class keywords from C# file.
        /// </summary>
        /// <value>The class keywords.</value>
        public string ClassKeywords
        {
            get
            {
                string assemblyName = "mscorlib, System, System.IO, System.Drawing, PresentationCore, PresentationFramework,";

                string classWords = string.Empty;
                string[] assemblies = assemblyName.Split(',');
                foreach (string ass in assemblies)
                {
                    try
                    {
                        Assembly assembly = Assembly.Load(ass.Trim());
                        if (assembly != null)
                        {
                            var pubTypesQuery = from type in assembly.GetTypes()
                                                where type.IsPublic && !type.Name.Contains("`")
                                                select type;
                            foreach (var type in pubTypesQuery)
                            {
                                classWords += type.Name + " ";
                                //writer.Write(type.Name + " ");
                                //writer.Flush();
                            }
                        }
                    }
                    catch (Exception) { }
                }
                //writer.Close();
                return classWords.Trim();

            }
        }

        /// <summary>
        /// Gets all classes.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns></returns>
        List<string> GetAllClasses(string assemblyName)
        {
            List<string> namespaceList = new List<string>();
            List<string> returnList = new List<string>();
            try
            {

                Assembly asm = Assembly.Load(assemblyName);
                foreach (Type type in asm.GetTypes())
                    namespaceList.Add(type.Name);
                foreach (String className in namespaceList)
                    returnList.Add(className);
            }
            catch (Exception) { }
            return returnList;
        }

        /// <summary>
        /// Gets the preprocessors from C# file.
        /// </summary>
        /// <value>The preprocessors.</value>
        public string Preprocessors
        {
            get
            {
                return "#if #else #elif #endif #define #undef #warning #error #line #region #endregion #pragma";
            }
        }

        /// <summary>
        /// Gets or sets the code regex.
        /// </summary>
        /// <value>The code regex.</value>
		public Regex CodeRegex
        {
            get { return codeRegex; }
            set { codeRegex = value; }
        }

        /// <summary>
        /// Gets or sets the code paragraph global.
        /// </summary>
        /// <value>The code paragraph global.</value>
		public List<Run> CodeParagraphGlobal
        {
            get { return codeParagraphGlobal; }
            set { codeParagraphGlobal = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="SyntaxRichTextBoxCS"/> class.
        /// </summary>
        /// <param name="pro">The pro.</param>
        public SyntaxHighlighterCSharp()
        {
            Regex r;
            r = new Regex(@"\w+|-\w+|#\w+|@@\w+|#(?:\\(?:s|w)(?:\*|\+)?\w+)+|@\\w\*+");
            string regKeyword = r.Replace(Keywords, @"(?<=^|\W)$0(?=\W)");
            string classWord = r.Replace(ClassKeywords, @"(?<=^|\W)$0(?=\W)");
            string regPreproc = r.Replace(Preprocessors, @"(?<=^|\s)$0(?=\s|$)");
            r = new Regex(@" +");
            regKeyword = r.Replace(regKeyword, @"|");
            regPreproc = r.Replace(regPreproc, @"|");
            classWord = r.Replace(classWord, @"|");

            if (regPreproc.Length == 0)
                regPreproc = "(?!.*)_{37}(?<!.*)";

            StringBuilder regAll = new StringBuilder();
            regAll.Append("(");
            regAll.Append(CommentRegEx);
            regAll.Append(")|(");
            regAll.Append(StringRegEx);
            if (regPreproc.Length > 0)
            {
                regAll.Append(")|(");
                regAll.Append(regPreproc);
            }
            regAll.Append(")|(");
            regAll.Append(regKeyword);
            regAll.Append(")|(");
            regAll.Append(classWord);
            regAll.Append(")");

            RegexOptions caseInsensitive = true ? 0 : RegexOptions.IgnoreCase;
            CodeRegex = new Regex(regAll.ToString(), RegexOptions.Singleline | caseInsensitive);
            CodeParagraphGlobal = new List<Run>();
        }



        /// <summary>
        /// Matches the eval.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        public string MatchEval(Match match)
        {
            if (match.Groups[1].Success) //comment
            {
                StringReader reader = new StringReader(match.ToString());
                string line;
                StringBuilder sb = new StringBuilder();
                while ((line = reader.ReadLine()) != null)
                {
                    Run r = new Run(line);
                    r.Foreground = new SolidColorBrush(Color.FromRgb(0, 128, 0));

                    CodeParagraphGlobal.Add(r);
                }
                return "::::::";
            }
            else if (match.Groups[2].Success) //string literal
            {
                Run r = new Run(match.ToString());
                r.Foreground = new SolidColorBrush(Color.FromRgb(163, 21, 21));

                CodeParagraphGlobal.Add(r);
                return "::::::";
            }
            else if (match.Groups[3].Success) //preprocessor keyword
            {
                Run r = new Run(match.ToString());
                r.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));

                CodeParagraphGlobal.Add(r);
                return "::::::";
            }
            else if (match.Groups[4].Success) //keyword
            {
                Run r = new Run(match.ToString());
                r.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));

                CodeParagraphGlobal.Add(r);
                return "::::::";
            }
            else if (match.Groups[5].Success) //Class word
            {
                Run r = new Run(match.ToString());
                r.Foreground = new SolidColorBrush(Color.FromRgb(43, 145, 175));

                CodeParagraphGlobal.Add(r);
                return "::::::";
            }
            else
            {
                return "";
            }
        }

        public Paragraph FormatCode(string source)
        {
            Paragraph codeParagraph = new Paragraph();
            //replace special characters
            StringBuilder sb = new StringBuilder(source);
            //color the code
            source = codeRegex.Replace(sb.ToString(), new MatchEvaluator(this.MatchEval));
            //codeRegex.Replace(
            string[] characters = { "::::::" };

            string[] split = source.Split(characters, new StringSplitOptions());
            int currentChunk = 0;
            foreach (string code in split)
            {
                currentChunk++;
                Run r = new Run(code) { FontSize = 14, FontFamily = new FontFamily("Segoe UI") };
                codeParagraph.Inlines.Add(r);
                if ((currentChunk - 1) < codeParagraphGlobal.Count)
                {
                    codeParagraphGlobal[currentChunk - 1].FontFamily = new FontFamily("Segoe UI");
                    codeParagraphGlobal[currentChunk - 1].FontSize = 14;
                    codeParagraph.Inlines.Add(codeParagraphGlobal[currentChunk - 1]);
                }
            }
            return codeParagraph;
        }
        #endregion
    }
}
