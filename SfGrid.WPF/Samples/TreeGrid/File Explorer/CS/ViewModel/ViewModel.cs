#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer
{
    public class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.DriveDetails = this.GetRootDrives();
        }

        private List<FileInfoModel> _driveDetails;
        /// <summary>
        /// Get or set the DriveDetails
        /// </summary>
        public List<FileInfoModel> DriveDetails
        {
            get { return _driveDetails; }
            set { _driveDetails = value; }
        }
        /// <summary>
        /// Gets the root drives.
        /// </summary>
        /// <returns></returns>
        public List<FileInfoModel> GetRootDrives()
        {
            List<FileInfoModel> drives = new List<FileInfoModel>();
            foreach (string s in Directory.GetLogicalDrives())
            {
                try
                {
                    drives.Add(Infomodel(s));
                }
                catch (Exception) { }
            }
            return drives;
        }
        /// <summary>
        /// Used to get ChildFolder Content of Particular folder
        /// </summary>
        /// <param name="fileNodeItem"></param>
        /// <returns></returns>
        public List<FileInfoModel> GetChildFolderContent(FileInfoModel fileNodeItem)
        {
            List<FileInfoModel> children = new List<FileInfoModel>();

            string folder = fileNodeItem.FullName;

            try
            {
                FileInfo fi = new FileInfo(folder);
                if ((fi.Attributes & FileAttributes.Directory) != (FileAttributes)0)
                {
                    DirectoryInfo di = new DirectoryInfo(folder);
                    // Skip Recycle Bin, System Volume Information etc.
                    if (di.Parent != null && (di.Attributes & FileAttributes.Hidden) != (FileAttributes)0
                        || (int)di.Attributes == -1)
                    {
                        //skip...
                    }
                    else
                    {
                        foreach (string s2 in Directory.GetDirectories(folder))
                        {
                            FileInfo fi2 = new FileInfo(s2);
                            if ((fi2.Attributes & FileAttributes.Hidden) != (FileAttributes)0)
                                continue;
                            children.Add(Infomodel(s2));
                        }
                        foreach (string s2 in Directory.GetFiles(folder))
                        {
                            FileInfo fi2 = new FileInfo(s2);
                            if ((fi2.Attributes & FileAttributes.Hidden) != (FileAttributes)0)
                                continue;
                            children.Add(Infomodel(s2));
                        }
                    }
                }
            }
            catch { }
            return children;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FileInfoModel"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public FileInfoModel Infomodel(string path)
        {
            FileInfoModel model = new FileExplorer.FileInfoModel();
            FileInfo fi = new FileInfo(path);
            model.FullName = Path.GetFullPath(path);
            model.ShortName = Path.GetFileNameWithoutExtension(path);
            if (model.ShortName == "")
            {
                model.ShortName = path;
                model.FileType = "Drive";
                System.IO.DriveInfo di = new System.IO.DriveInfo(path);
                model.TotalSize = (di.TotalSize / 1073741824).ToString();
                var freeSpace = (double.Parse(di.TotalFreeSpace.ToString()) / 1073741824);
                model.TotalFreeSpace = (Math.Round(freeSpace, 1)).ToString();
                model.PercentofFreeSpace = 100 - ((double.Parse(model.TotalFreeSpace) / double.Parse(model.TotalSize)) * 100);
            }
            else
            {
                if ((fi.Attributes & FileAttributes.Directory) != 0)
                {
                    model.FileType = "Directory";
                }
                else
                {
                    model.Size = fi.Length.ToString() + "Kb";
                    model.FileType = Path.GetExtension(path);
                }
            }
            model.DateModified = fi.LastWriteTime;
            model.DateAccessed = fi.LastAccessTime;
            model.DateCreated = fi.CreationTime;
            model.Attributes = fi.Attributes;
            return model;
        }
    }
}
