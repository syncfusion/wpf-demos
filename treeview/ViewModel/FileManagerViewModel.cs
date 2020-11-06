#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.treeviewdemos.wpf
{
    public class FileManagerViewModel  
    {
        #region Fields

        private ObservableCollection<FileManager> imageNodeInfo;

        public object Item { get; set; }

        BitmapImage folderIcon = new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/treeview_folder.png", UriKind.Relative));
        BitmapImage pictureIcon = new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/treeview_pic.png", UriKind.Relative));
        BitmapImage videoIcon = new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/treeview_video.png", UriKind.Relative));
        BitmapImage wordIcon = new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/treeview_word.png", UriKind.Relative));
        BitmapImage mp3Icon = new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/treeview_mp3.png", UriKind.Relative));
        BitmapImage pdfIcon = new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/treeview_pdf.png", UriKind.Relative));
        BitmapImage zipIcon = new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/treeview_zip.png", UriKind.Relative));
        BitmapImage pptIcon = new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/treeview_ppt.png", UriKind.Relative));
        BitmapImage exeIcon = new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/treeview_exe.png", UriKind.Relative));

        #endregion

        #region Constructor

        public FileManagerViewModel()
        {
            this.Folders = GetFiles();
            this.ImageNodeInfo = GenerateSource();
            GenerateListViewData();
        }

        #endregion

        #region Properties

        public ObservableCollection<Folder> Folders { get; set; }

        public ObservableCollection<FileManager> ImageNodeInfo
        {
            get { return imageNodeInfo; }
            set { this.imageNodeInfo = value; }
        }

        public ObservableCollection<Folder> ListViewCollection { get; set; }

        #endregion

        #region Generate Source

        private ObservableCollection<FileManager> GenerateSource()
        {
            var nodeImageInfo = new ObservableCollection<FileManager>();

            var doc = new FileManager() { FileName = "Documents", ImageIcon = folderIcon, Visibility = Visibility.Collapsed};
            var download = new FileManager() { FileName = "Downloads", ImageIcon = folderIcon, Visibility = Visibility.Collapsed };
            var mp3 = new FileManager() { FileName = "Music", ImageIcon = folderIcon, Visibility = Visibility.Collapsed };
            var pictures = new FileManager() { FileName = "Pictures", ImageIcon = folderIcon, Visibility = Visibility.Collapsed };
            var video = new FileManager() { FileName = "Videos", ImageIcon = folderIcon, Visibility = Visibility.Collapsed };

            var pollution = new FileManager() { FileName = "Environmental Pollution.docx", FileDescription = "A holistic examination of environmental pollution, from its sources to its effects on flora, fauna, and humans.", ImageIcon = this.wordIcon };
            var globalWarming = new FileManager() { FileName = "Global Warming.ppt", FileDescription = "Global warming is the long-term rise of the Earth’s average temperature. It is driving dramatic changes in climate patterns around the globe.", ImageIcon = this.pptIcon };
            var sanitation = new FileManager() { FileName = "Sanitation.docx", FileDescription = "Sanitation is a an important aspect of public health policy. One of its primary purposes is to treat wastewater so that any pollutants are eliminated, thereby reducing negative environmental impacts.", ImageIcon = this.wordIcon };
            var socialNetwork = new FileManager() { FileName = "Social Network.pdf", FileDescription = "A model for investigating the structure and relationships between individuals and groups across social, political, and economic strata.", ImageIcon = this.mp3Icon };
            var youthEmpower = new FileManager() { FileName = "Youth Empowerment.pdf", FileDescription = "Methods for developing and encouraging self-actualization in young people. Teaching young people that barriers to their ability to create change are illusory.", ImageIcon = this.pdfIcon };

            var games = new FileManager() { FileName = "Game.exe", FileDescription = "Games are competitive activities conducted with an agreed-upon set of rules. Games with two participants usually result in a distinct winner and loser, but can sometimes result in a tie. When more than two players engage in a game, the results are often ranked from the top performer to the worst.", ImageIcon = this.exeIcon};
            var tutorials = new FileManager() { FileName = "Tutorials.zip", FileDescription = "A tutorial is a practical guide for introducing someone to a topic they are unfamiliary with.", ImageIcon = this.zipIcon };
            var typeScript = new FileManager() { FileName = "TypeScript.7z", FileDescription = "TypeScript is a superset of JavaScript created by Microsoft. ", ImageIcon = this.zipIcon };
            var uiGuide = new FileManager() { FileName = "UI-Guide.pdf", FileDescription = "The UI designers guide provides useful resources, tools, tutorials, and even a little inspiration.", ImageIcon = this.pdfIcon };

            var song = new FileManager() { FileName = "Gouttes", FileDescription = "Formally speaking, a song is a musical composition intended to be sung by the human voice. In common usage, the term can be applied to virtually any piece of music, vocal or otherwise.", ImageIcon = this.mp3Icon };

            var camera = new FileManager() { FileName = "Camera Roll", FileDescription = "Camera pictures", ImageIcon = this.folderIcon };
            var stone = new FileManager() { FileName = "Stone.jpg", FileDescription = "A stone is a mass of hard, compacted mineral. Not to be confused with a rock.", ImageIcon = this.pictureIcon };
            var wind = new FileManager() { FileName = "Wind.jpg", FileDescription = "Wind is the flow of gases. Wind is mostly the movement of air.", ImageIcon = this.pictureIcon };

            var img0 = new FileManager() { FileName = "WIN_20160726_094117.JPG", FileDescription = "Image file", ImageIcon = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle0.png", UriKind.Relative)) };
            var img1 = new FileManager() { FileName = "WIN_20160726_094118.JPG", FileDescription = "Image file", ImageIcon = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle1.png", UriKind.Relative)) };

            var video1 = new FileManager() { FileName = "Natural World.mp4", FileDescription = "Video file: Need an escape? Watch this video in 4K UHD and experience natural phenomena like rivers, strams, lakes, birds, meadows, and more.", ImageIcon = this.videoIcon };
            var video2 = new FileManager() { FileName = "Wildlife.mpeg", FileDescription = "Video file: Marvel at the wondrous world of animals from the comfort of your home.", ImageIcon = this.videoIcon };

            doc.SubFiles = new ObservableCollection<FileManager>
            {
                pollution,
                globalWarming,
                sanitation,
                socialNetwork,
                youthEmpower
            };

            download.SubFiles = new ObservableCollection<FileManager>
            {
                games,
                tutorials,
                typeScript,
                uiGuide
            };

            mp3.SubFiles = new ObservableCollection<FileManager>
            {
                song
            };

            pictures.SubFiles = new ObservableCollection<FileManager>
            {
                camera,
                stone,
                wind
            };
            camera.SubFiles = new ObservableCollection<FileManager>
            {
                img0,
                img1
            };

            video.SubFiles = new ObservableCollection<FileManager>
            {
                video1,
                video2
            };

            Item = camera;
            nodeImageInfo.Add(doc);
            nodeImageInfo.Add(download);
            nodeImageInfo.Add(mp3);
            nodeImageInfo.Add(pictures);
            nodeImageInfo.Add(video);
            return nodeImageInfo;
        }

        private ObservableCollection<Folder> GetFiles()
        {
            var nodeImageInfo = new ObservableCollection<Folder>();
            var doc = new Folder() { FileName = "Documents", ImageIcon = folderIcon };
            var download = new Folder() { FileName = "Downloads", ImageIcon = folderIcon };
            var mp3 = new Folder() { FileName = "Music", ImageIcon = folderIcon };
            var pictures = new Folder() { FileName = "Pictures", ImageIcon = folderIcon };
            var video = new Folder() { FileName = "Videos", ImageIcon = folderIcon };

            var pollution = new File() { FileName = "Environmental Pollution.docx", ImageIcon = this.wordIcon};
            var globalWarming = new File() { FileName = "Global Warming.ppt", ImageIcon = this.pptIcon};
            var sanitation = new File() { FileName = "Sanitation.docx", ImageIcon = this.wordIcon };
            var socialNetwork = new File() { FileName = "Social Network.pdf", ImageIcon = this.pdfIcon };
            var youthEmpower = new File() { FileName = "Youth Empowerment.pdf", ImageIcon = this.pdfIcon };

            var games = new File() { FileName = "Game.exe", ImageIcon = this.exeIcon };
            var tutorials = new File() { FileName = "Tutorials.zip", ImageIcon = this.zipIcon };
            var typeScript = new File() { FileName = "TypeScript.7z", ImageIcon = this.zipIcon };
            var uiGuide = new File() { FileName = "UI-Guide.pdf", ImageIcon = this.pdfIcon };

            var song = new File() { FileName = "Gouttes", ImageIcon = this.mp3Icon };

            var camera = new File() { FileName = "Camera Roll", ImageIcon = folderIcon };
            var stone = new File() { FileName = "Stone.jpg", ImageIcon = this.pictureIcon };
            var wind = new File() { FileName = "Wind.jpg", ImageIcon = this.pictureIcon };

            var img0 = new SubFile() { FileName = "WIN_20160726_094117.JPG", ImageIcon = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle6.png", UriKind.Relative)) };
            var img1 = new SubFile() { FileName = "WIN_20160726_094118.JPG", ImageIcon = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle5.png", UriKind.Relative)) };

            var video1 = new File() { FileName = "Natural World.mp4", ImageIcon = videoIcon };
            var video2 = new File() { FileName = "Wildlife.mpeg", ImageIcon = videoIcon };

            doc.Files = new ObservableCollection<File>
            {
                pollution,
                globalWarming,
                sanitation,
                socialNetwork,
                youthEmpower
            };

            download.Files = new ObservableCollection<File>
            {
                games,
                tutorials,
                typeScript,
                uiGuide
            };

            mp3.Files = new ObservableCollection<File>
            {
                song
            };

            pictures.Files = new ObservableCollection<File>
            {
                camera,
                stone,
                wind
            };
            camera.SubFiles = new ObservableCollection<SubFile>
            {
                img0,
                img1
            };

            video.Files = new ObservableCollection<File>
            {
                video1,
                video2
            };

            nodeImageInfo.Add(doc);
            nodeImageInfo.Add(download);
            nodeImageInfo.Add(mp3);
            nodeImageInfo.Add(pictures);
            nodeImageInfo.Add(video);

            return nodeImageInfo;
        } 

        private void GenerateListViewData()
        {
            var folders = new ObservableCollection<Folder>();
            

            folders.Add(new Folder() { FileName = "Desktop", ImageIcon = folderIcon });
            folders.Add(new Folder() { FileName = "Movies", ImageIcon = folderIcon });
            folders.Add(new Folder() { FileName = "Albums", ImageIcon = folderIcon });
            folders.Add(new Folder() { FileName = "Files", ImageIcon = folderIcon });
            folders.Add(new Folder() { FileName = "Camera Roll", ImageIcon = folderIcon });
            folders.Add(new Folder() { FileName = "Gouttes", ImageIcon = this.mp3Icon });
            folders.Add(new Folder() { FileName = "Nature.jpg", ImageIcon = pictureIcon });
            folders.Add(new Folder() { FileName = "Cloud.jpg", ImageIcon = pictureIcon });
            folders.Add(new Folder() { FileName = "WIN_20160726_094127.JPG", ImageIcon = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle1.png", UriKind.Relative)) });
            folders.Add(new Folder() { FileName = "WIN_20160726_094128.JPG", ImageIcon = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle0.png", UriKind.Relative)) });
            folders.Add(new Folder() { FileName = "Natural World.mp4", ImageIcon = videoIcon });
            folders.Add(new Folder() { FileName = "Wildlife.mpeg", ImageIcon = videoIcon });

            this.ListViewCollection = folders;
        } 

        #endregion

    }
}
