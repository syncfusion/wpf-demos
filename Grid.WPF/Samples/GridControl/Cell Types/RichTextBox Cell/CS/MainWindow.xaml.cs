#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;

namespace RichTextBoxCellDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            InitGrid();
            SetRowHeightColumnWidth();
            this.grid.Model.Options.CopyPasteOption = CopyPaste.CutText | CopyPaste.PasteText | CopyPaste.CopyText;
            this.grid.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            this.grid.Model.QueryCellInfo += new Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventHandler(Model_QueryCellInfo);
        }

        void SetRowHeightColumnWidth()
        {
            this.grid.Model.RowHeights.DefaultLineSize = 55;
            this.grid.Model.RowHeights[0] = 25;
            this.grid.Model.ColumnWidths[0] = 20;
            this.grid.Model.ColumnWidths[1] = 25;
            this.grid.Model.ColumnWidths[2] = 35;
            this.grid.Model.ColumnWidths[3] = 700;
            this.grid.Model.ColumnWidths[4] = 78;
            this.grid.Model.ColumnWidths[5] = 135;
            this.grid.Model.ColumnWidths[7] = 35;
        }

        void Model_QueryCellInfo(object sender, Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs e)
        {
            e.Style.ReadOnly = true;
        }

        private void InitGrid()
        {
            this.grid.Model.RowCount = 17;
            this.grid.Model.ColumnCount = 8;
            this.grid.Model.Options.ListBoxSelectionMode = GridSelectionMode.MultiExtended;
            this.grid.Model.Options.ShowCurrentCell = false;
            this.grid.Model[0, 3].CellValue = "From / Subject / Received Date";
            this.grid.Model[0, 4].CellValue = "Size";
            this.grid.Model[0, 5].CellValue = "Categories";
            this.grid.Model[0, 6].CellValue = "Folder";
            this.grid.Model[0, 7].CellValue = "Flag";
            this.grid.Model.TableStyle.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.grid.Model.TableStyle.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            this.grid.Model.ColStyles[3].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            MailDataCollection collections = new MailDataCollection();
            for (int i = 1; i <= 16; i++)
            {
                MailData data = collections[i - 0];
                this.grid.Model[i, 1].CellType = "RichText";
                this.grid.Model[i, 1].CellValue = data.Important;
                this.grid.Model[i, 2].CellType = "RichText";
                this.grid.Model[i, 2].CellValue = data.IsRead;
                this.grid.Model[i, 3].CellType = "RichText";
                this.grid.Model[i, 3].CellValue = data.Subject;
                this.grid.Model[i, 4].CellValue = data.Size.ToString() + " KB";
                this.grid.Model[i, 5].CellType = "RichText";
                this.grid.Model[i, 5].CellValue = data.Categories;
                this.grid.Model[i, 6].CellValue = data.Folder;
                this.grid.Model[i, 7].CellType = "RichText";
                this.grid.Model[i, 7].CellValue = data.Flagged;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.grid.ShowPrintDialog();
        }
    }

    public partial class MailDataCollection : ObservableCollection<MailData>
    {
        public ObservableCollection<OutlookData> Outlookcontent = new ObservableCollection<OutlookData>();

        public MailDataCollection()
        {
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "Steven@ymail.com", Important = true, IsRead = false, Folder = "Draft", Categories = "Red Category", Received = DateTime.Now.Subtract(new TimeSpan(1, 1, 1, 1)), Size = 6, Subject = "Microsoft Visual Studio2010 Launch/DevConnections, Las Vegas, NV    " });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "James@yahoo.com", Important = false, IsRead = true, Folder = "Inbox", Categories = "Green Category", Received = DateTime.Now.Subtract(new TimeSpan(1, 1, 1, 1)), Size = 27, Subject = "WPF 4: Custom Command and Command Parameter for TextBox using Prism 4" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "Smith@yahoo.com", Important = false, IsRead = true, Folder = "Sharepoint", Categories = "Blue Category", Received = DateTime.Now, Size = 7, Subject = "Crew Wraps Up Busy Day of Cargo Transfers, Spacewalk Preps" });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "Johndav@gmail.com", Important = true, IsRead = true, Folder = "Sharepoint", Categories = "Red Category", Received = DateTime.Now, Size = 713, Subject = "Multitasking on Windows Phone–Yes, no or kinda?" });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "david@ymail.com", Important = true, IsRead = true, Folder = "Silverlight", Categories = "Red Category", Received = DateTime.Now, Size = 37, Subject = "Silverlight in the Azure Cloud" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "Mariarb@rediff.com", Important = false, IsRead = false, Folder = "Silverlight", Categories = "Blue Category", Received = DateTime.Now, Size = 57, Subject = "Weekly Article Digest 07/11/2011.." });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "james@hotmail.com", Important = true, IsRead = false, Folder = "DeletedItems", Categories = "Green Category", Received = DateTime.Now, Size = 45, Subject = "WCF RIA Services: Strategies for Handling Your Domain Context" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "david1971@rediff.com", Important = true, IsRead = false, Folder = "DeletedItems", Categories = "Orange Category", Received = DateTime.Now, Size = 87, Subject = "Creating a 2 Node SQL Server 2008 Virtual Cluster Part 2 (SQLServerCentral 7/12/2011)" });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "kelvin@yahoo.com", Important = true, IsRead = false, Folder = "SentItems", Categories = "Yellow Category", Received = DateTime.Now, Size = 19, Subject = "Building a detailed About page for your Windows Phone application" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "mary@rediff.com", Important = true, IsRead = false, Folder = "Inbox", Categories = "Red Category", Received = DateTime.Now, Size = 17, Subject = "Creating a horizontally scrolling list in Windows Phone 7" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "thomas@gmail.com", Important = true, IsRead = false, Folder = "Inbox", Categories = "Green Category", Received = DateTime.Now, Size = 71, Subject = "Rapidly Develop Windows Phone Apps with PowerPoint" });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "mark@yahoo.com", Important = false, IsRead = true, Folder = "Inbox", Categories = "Blue Category", Received = DateTime.Now.Subtract(new TimeSpan(1, 1, 1, 1)), Size = 11, Subject = "Silverlight 4.0: Duplex Communication over Http using PollingDuplexHttpBinding" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "Steven@ymail.com", Important = true, IsRead = false, Folder = "Draft", Categories = "Green Category", Received = DateTime.Now.Subtract(new TimeSpan(1, 1, 1, 1)), Size = 32, Subject = "Windows Phone 7 (Mango) Tutorial - 21 - Small Demo of Accelerometer Application " });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "James@yahoo.com", Important = false, IsRead = true, Folder = "Inbox", Categories = "Yellow Category", Received = DateTime.Now.Subtract(new TimeSpan(1, 1, 1, 1)), Size = 38, Subject = "Microsoft Visual Studio2010 Launch/DevConnections, Las Vegas, NV    " });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "Smith@yahoo.com", Important = false, IsRead = true, Folder = "Sharepoint", Categories = "Blue Category", Received = DateTime.Now, Size = 5, Subject = "Workaround For Crash In Performance Profiling Tools for WPF" });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "Johndav@gmail.com", Important = true, IsRead = true, Folder = "Sharepoint", Categories = "Red Category", Received = DateTime.Now, Size = 12, Subject = "Nokia's first Windows Phone: images and video, codenamed 'Sea Ray'" });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "david@ymail.com", Important = true, IsRead = true, Folder = "Silverlight", Categories = "Red Category", Received = DateTime.Now, Size = 7, Subject = "Play Media files with the MediaPlayerLauncher in Windows Phone 7." });

            foreach (OutlookData outlookData in Outlookcontent)
            {
                MailData maildata = new MailData();
                OutlookData data = outlookData;
                if (data.Important)
                {
                    BitmapImage bi = new BitmapImage(new Uri(@"..\..\Images\Important.png", UriKind.Relative));
                    Image image = new Image();
                    image.Source = bi;
                    InlineUIContainer container = new InlineUIContainer(image);
                    Paragraph paragraph = new Paragraph();
                    paragraph.Inlines.Add(new LineBreak());
                    paragraph.Inlines.Add(container);
                    FlowDocument flowdoc = new FlowDocument(paragraph);
                    maildata.Important = flowdoc;
                }
                else
                {
                    maildata.Important = new FlowDocument();
                }
                Image image2 = new Image();
                image2.Source = data.IsRead ? new BitmapImage(new Uri(@"..\..\Images\ReadMail.png", UriKind.Relative)) : new BitmapImage(new Uri(@"..\..\Images\UnreadMail.png", UriKind.Relative));

                InlineUIContainer container2 = new InlineUIContainer(image2);
                Paragraph paragraph2 = new Paragraph();
                paragraph2.Inlines.Add(new LineBreak());
                paragraph2.Inlines.Add(container2);
                var flowdoc2 = new FlowDocument(paragraph2);
                maildata.IsRead = flowdoc2;

                FlowDocument fd = new FlowDocument();
                Paragraph ph = new Paragraph();
                Run email1 = new Run(data.FromAddress.ToString());
                if (!data.IsRead)
                    email1.FontWeight = FontWeights.Bold;
                if (data.Flagged)
                    email1.Foreground = new SolidColorBrush(Colors.Red);
                ph.Inlines.Add(email1);
                ph.Inlines.Add(new LineBreak());
                Run run2 = new Run(data.Subject);
                run2.FontWeight = FontWeights.Light;
                run2.FontStyle = FontStyles.Italic;
                ph.Inlines.Add(run2);
                ph.Inlines.Add(new LineBreak());
                Run run3 = new Run((data).Received.Date.ToString());
                run3.Foreground = new SolidColorBrush(Colors.Green);
                ph.Inlines.Add(run3);
                fd.Blocks.Add(ph);
                maildata.Subject = fd;
                maildata.Size = data.Size;
                maildata.Folder = data.Folder;
                var image3 = new Image();
                image3.Source = data.Flagged ? new BitmapImage(new Uri(@"..\..\Images\Flagged.png", UriKind.Relative)) : new BitmapImage(new Uri(@"..\..\Images\UnFlagged.png", UriKind.Relative));

                var container3 = new InlineUIContainer(image3);
                var paragraph3 = new Paragraph();
                paragraph3.Inlines.Add(new LineBreak());
                paragraph3.Inlines.Add(container3);
                var flowdoc3 = new FlowDocument(paragraph3);
                maildata.Flagged = flowdoc3;

                var categorie = new FlowDocument();
                var paragraph4 = new Paragraph();
                var run4 = new Run(data.Categories);
                paragraph4.Inlines.Add(run4);
                categorie.Blocks.Add(paragraph4);
                maildata.Categories = categorie;
                this.Add(maildata);
            }
        }
    }

    public partial class OutlookData : INotifyPropertyChanged
    {
        private bool _Important;
        private bool _IsRead;
        private string _FromAddress;
        private string _Subject;
        private DateTime _Received;
        private int _Size;
        private bool _Flagged;
        private string _Categories;
        private string _Folder;

        public OutlookData()
        {

        }
        public bool Important
        {
            get
            {
                return this._Important;
            }
            set
            {
                this._Important = value;
                this.RaisePropertyChanged("Important");
            }
        }

        public string Categories
        {
            get
            {
                return this._Categories;
            }
            set
            {
                this._Categories = value;
                this.RaisePropertyChanged("Categories");
            }
        }

        public string Folder
        {
            get
            {
                return this._Folder;
            }
            set
            {
                this._Folder = value;
                this.RaisePropertyChanged("Folder");
            }
        }

        public bool IsRead
        {
            get
            {
                return this._IsRead;
            }
            set
            {
                this._IsRead = value;
                this.RaisePropertyChanged("IsRead");
            }
        }

        public string FromAddress
        {
            get
            {
                return this._FromAddress;
            }
            set
            {
                this._FromAddress = value;
                this.RaisePropertyChanged("FromAddress");
            }
        }

        public string Subject
        {
            get
            {
                return this._Subject;
            }
            set
            {
                this._Subject = value;
                this.RaisePropertyChanged("Subject");
            }
        }

        public DateTime Received
        {
            get
            {
                return this._Received;
            }
            set
            {
                this._Received = value;
                this.RaisePropertyChanged("Received");
            }
        }

        public int Size
        {
            get
            {
                return this._Size;
            }
            set
            {
                this._Size = value;
                this.RaisePropertyChanged("Size");
            }
        }

        public bool Flagged
        {
            get
            {
                return this._Flagged;
            }

            set
            {
                this._Flagged = value;
                this.RaisePropertyChanged("Flagged");
            }
        }

        #region INotifyPropertyChanged Members

        private void RaisePropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    public partial class MailData : INotifyPropertyChanged
    {
        private FlowDocument _Important;
        private FlowDocument _IsRead;
        private FlowDocument _Subject;
        private int _Size;
        private FlowDocument _Flagged;
        private FlowDocument _Categories;
        private string _Folder;

        public MailData()
        {

        }
        public FlowDocument Important
        {
            get
            {
                return this._Important;
            }
            set
            {
                this._Important = value;
                this.RaisePropertyChanged("Important");
            }
        }

        public FlowDocument Categories
        {
            get
            {
                return this._Categories;
            }
            set
            {
                this._Categories = value;
                this.RaisePropertyChanged("Categories");
            }
        }

        public string Folder
        {
            get
            {
                return this._Folder;
            }
            set
            {
                this._Folder = value;
                this.RaisePropertyChanged("Folder");
            }
        }

        public FlowDocument IsRead
        {
            get
            {
                return this._IsRead;
            }
            set
            {
                this._IsRead = value;
                this.RaisePropertyChanged("IsRead");
            }
        }



        public FlowDocument Subject
        {
            get
            {
                return this._Subject;
            }
            set
            {
                this._Subject = value;
                this.RaisePropertyChanged("Subject");
            }
        }


        public int Size
        {
            get
            {
                return this._Size;
            }
            set
            {
                this._Size = value;
                this.RaisePropertyChanged("Size");
            }
        }

        public FlowDocument Flagged
        {
            get
            {
                return this._Flagged;
            }

            set
            {
                this._Flagged = value;
                this.RaisePropertyChanged("Flagged");
            }
        }

        #region INotifyPropertyChanged Members

        private void RaisePropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

}
