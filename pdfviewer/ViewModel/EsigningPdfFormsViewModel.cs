#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Resources;

namespace syncfusion.pdfviewerdemos.wpf
{
    public class EsigningPdfFormsViewModel 
    {
        private Stream m_documentStream;

        /// <summary>
        /// Initializes a new instance of the <see cref="EsigningPdfFormsViewModel"/> class.
        /// </summary>
        public EsigningPdfFormsViewModel()
        {
            m_documentStream = GetFileStream("eSign_filling.pdf");
            this.Employees = new ObservableCollection<Employee>();
            
            Employees.Add(new Employee
            {
                Name = "Andrew Fuller",               
                ProfilePicture=GetFileStream("profile1.png"),
                Mail = "andrew@mycompany.com",
                BorderColor = true,
                
            });
            Employees.Add(new Employee
            {
                Name = "Anne Dodsworth",
                ProfilePicture=GetFileStream("profile2.png"),
                Mail = "anne@mycompany.com",
                BorderColor = false,
                              
            });
        }

        /// <summary>
        /// Gets or sets the document path.
        /// </summary>
        public Stream DocumentStream
        {
            get
            {
                return m_documentStream;
            }
            set
            {
                m_documentStream = value;
            }
        }
        /// <summary>
        /// Gets or sets the collection of Employees.
        /// </summary>
        public ObservableCollection<Employee> Employees { get; set; }

        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfviewerdemos.wpf;component/Assets/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
    }

    /// <summary>
    /// Class to represent the details of the Employees
    /// </summary>
    public class Employee
    {
        public string Name { get; set; }
        public Stream ProfilePicture { get; set; }
        public string Mail { get; set; }
        public bool BorderColor { get; set; }

    }
}
