#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.treegriddemos.wpf
{
    public class FileInfoModel : NotificationObject
    {
        string _shortName;
        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public string ShortName
        {
            get
            {
                return _shortName;
            }
            set
            {
                _shortName = value;
                RaisePropertyChanged("ShortName");
            }
        }

        DateTime _dataModified;
        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>The date modified.</value>
        public DateTime DateModified
        {
            get
            {
                return _dataModified;
            }
            set
            {
                _dataModified = value;
                RaisePropertyChanged("DateModified");
            }
        }

        string _fileType;
        /// <summary>
        /// Gets or sets the type of the file.
        /// </summary>
        /// <value>The type of the file.</value>
        public string FileType
        {
            get
            {
                return _fileType;
            }
            set
            {
                _fileType = value;
                RaisePropertyChanged("FileType");
            }
        }

        string size;
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public string Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                RaisePropertyChanged("Size");
            }
        }

        string _totalSize;
        /// <summary>
        /// Gets or sets the total size.
        /// </summary>
        /// <value>The total size.</value>
        public string TotalSize
        {
            get
            {
                return _totalSize;
            }
            set
            {
                _totalSize = value;
                RaisePropertyChanged("TotalSize");
            }
        }

        string _totalFreeSpace;
        /// <summary>
        /// Gets or sets the total free space.
        /// </summary>
        /// <value>The total free space.</value>
        public string TotalFreeSpace
        {
            get
            {
                return _totalFreeSpace;
            }
            set
            {
                _totalFreeSpace = value;
                RaisePropertyChanged("TotalFreeSpace");
            }
        }

        double _percentofFreeSpace;
        /// <summary>
        /// Gets or sets the percentof free space.
        /// </summary>
        /// <value>The percentof free space.</value>
        public double PercentofFreeSpace
        {
            get
            {
                return _percentofFreeSpace;
            }
            set
            {
                _percentofFreeSpace = value;
                RaisePropertyChanged("PercentofFreeSpace");
            }
        }

        string _fullName;
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
                RaisePropertyChanged("FullName");
            }
        }

        DateTime _dateCreated;
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        public DateTime DateCreated
        {
            get
            {
                return _dateCreated;
            }
            set
            {
                _dateCreated = value;
                RaisePropertyChanged("DateCreated");
            }
        }

        FileAttributes _attributes;
        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>The attributes.</value>
        public FileAttributes Attributes
        {
            get
            {
                return _attributes;
            }
            set
            {
                _attributes = value;
                RaisePropertyChanged("DateCreated");
            }
        }

        DateTime _dateAccessed;
        /// <summary>
        /// Gets or sets the date accessed.
        /// </summary>
        /// <value>The date accessed.</value>
        public DateTime DateAccessed
        {
            get
            {
                return _dateAccessed;
            }
            set
            {
                _dateAccessed = value;
                RaisePropertyChanged("DateAccessed");
            }
        }
    }
}
