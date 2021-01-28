#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.NavigationDrawer;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.navigationdemos.wpf
{
	public class NavigationDrawerViewModel : NotificationObject
	{
        private object selectedItem;
        public object SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }
        public ObservableCollection<MusicModel> Items { get; set; }

        private Position position = Position.Left;

		public Position SlidePosition
		{
			get { return position; }
			set { position = value; RaisePropertyChanged("SlidePosition"); }
		}

		private Transition transition = Transition.SlideOnTop;

		public Transition SlideTransition
		{
			get { return transition; }
			set { transition = value; RaisePropertyChanged("SlideTransition"); }
		}

		string[] MonthArray = new string[]
		{
			"Jan",
			"Jan",
			"Mar",
			"Apr",
			"May",
			"May",
			"May",
			"June",
			"July",
			"Sep",
			"Sep"
		};

		Random random = new Random();
		public MenuCollectionModel getItem(string item, Geometry icon)
		{
			int randomValue = 0; 
			MenuCollectionModel mCollection = new MenuCollectionModel();
			mCollection.MessageContent = new ObservableCollection<Message>();
			for (int i = 0; i < 5; i++)
			{
				if (item == "Follow up")
				{
					if (i % 4 != 0)
						continue;
				}

				if (item == "Sent mail")
				{
					if (i % 4 != 0)
						continue;
				}


				if (item == "Trash ")
				{
					if (i % 3 == 0)
						continue;
				}

				randomValue = random.Next(0, 9);
				Message message = new Message();
				message.Sender = sender[i];
				message.Date = MonthArray[i] + " " + (i + 7).ToString();
                
				if (item != "Inbox")
                {
                    randomValue = random.Next(0, 29);
                    message.Subject = subject[randomValue];
                    message.Content = textContent[randomValue];
                }
                else
				{
					randomValue = i;
					message.Subject = subject[randomValue];
					message.Content = textContent[randomValue];
                }

				if (item == "Inbox" && i < 7)
				{
					message.SubjectColor = new SolidColorBrush(Color.FromRgb(43, 87, 154));
					message.FontAttribute = FontWeights.Bold;
				}
				else
				{
					message.SubjectColor = new SolidColorBrush(Color.FromRgb(84, 86, 89));
					message.FontAttribute = FontWeights.Normal;
				}

				mCollection.MessageContent.Add(message);
			}

			mCollection.MenuItem = item;
			mCollection.PathData = icon;
			return mCollection;
		}


		ObservableCollection<string> sender = new ObservableCollection<string>();
		ObservableCollection<string> subject = new ObservableCollection<string>();
		ObservableCollection<string> textContent = new ObservableCollection<string>();

		ObservableCollection<MenuCollectionModel> menuCollection;
		public NavigationDrawerViewModel()
		{
            Items = new ObservableCollection<MusicModel>();
            ObservableCollection<MusicModel> SubItems2 = new ObservableCollection<MusicModel>();
            SubItems2.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image3.png", Item = "Shane Codd", Header = "Get out my head" });
            SubItems2.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image4.png", Item = "Meduza", Header = "Paradise" });
            SubItems2.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image5.png", Item = "Selena Gomez", Header = "Feel me" });
            ObservableCollection<MusicModel> SubItems3 = new ObservableCollection<MusicModel>();
            SubItems3.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image1.png", Item = "Liam Gallagher", Header = "All you're dreaming of" });
            SubItems3.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image2.png", Item = "Nathan Dawe", Header = "No time for tears" });
            SubItems3.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image6.png", Item = "Harry Styles", Header = "Golden" });
            SubItems3.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image10.png", Item = "Gary Barlow", Header = "Incredible" });
            SubItems3.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image11.png", Item = "The Weeknd", Header = "Blinding lights" });
            ObservableCollection<MusicModel> SubItems = new ObservableCollection<MusicModel>();
            SubItems.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image7.png", Header = "Top Hits" });
            SubItems.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image8.png", Header = "New Releases" });
            SubItems.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image9.png", Header = "Favourites" });
            ObservableCollection<MusicModel> SubItems1 = new ObservableCollection<MusicModel>();
            SubItems1.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image1.png", Item = "Liam Gallagher", Header = "All you're dreaming of" });
            SubItems1.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image2.png", Item = "Nathan Dawe", Header = "No time for tears" });
            SubItems1.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image3.png", Item = "Shane Codd", Header = "Get out my head" });
            SubItems1.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image4.png", Item = "Meduza", Header = "Paradise" });
            SubItems1.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image5.png", Item = "Selena Gomez", Header = "Feel me" });
            SubItems1.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image6.png", Item = "Harry Styles", Header = "Golden" });
            SubItems1.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image10.png", Item = "Gary Barlow", Header = "Incredible" });
            SubItems1.Add(new MusicModel() { Icon = "/syncfusion.demoscommon.wpf;component/Assets/Music/Image11.png", Item = "The Weeknd", Header = "Blinding lights" });
            Items.Add(new MusicModel()
            {
                Item = "Explore",
                Path = new Path()
                {
                    Width = 16,
                    Height = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Data = Geometry.Parse("M6.0033803,5.705333 L7.0853577,8.4971852 9.9112849,10.241092 8.6573143,7.3392491 z M5.0022244,4.0000064 C5.0918167,4.0004316 5.1818919,4.0249844 5.2623992,4.0744188 L9.3152895,6.5702889 C9.4033003,6.6242869 9.4722991,6.7032812 9.5132833,6.7982774 L11.459255,11.302037 C11.545252,11.502027 11.492244,11.735016 11.327239,11.879006 11.233247,11.959003 11.117252,12.000002 11.00025,12.000002 10.909249,12.000002 10.818278,11.976001 10.737256,11.926004 L6.4163659,9.2601452 C6.3233503,9.2021494 6.252368,9.1161518 6.2133675,9.0151591 L4.5334113,4.6813889 C4.4563866,4.4803993 4.5154063,4.2534102 4.6804113,4.1164165 4.7726429,4.0387974 4.8870345,3.9994598 5.0022244,4.0000064 z M8,1 C4.14,1 1,4.1409999 1,8 1,11.86 4.14,15 8,15 11.859,15 15,11.86 15,8 15,4.1409999 11.859,1 8,1 z M8,0 C12.411,0 16,3.5889999 16,8 16,12.411 12.411,16 8,16 3.589,16 0,12.411 0,8 0,3.5889999 3.589,0 8,0 z"),
                    Fill = new SolidColorBrush(Colors.Black),
                    Stretch = Stretch.Fill,
                }
            ,
                SubItems = SubItems
            });
            Items.Add(new MusicModel()
            {
                Item = "My music",
                Path = new Path()
                {
                    Width = 16,
                    Height = 14.7,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Data = Geometry.Parse("M2.5,10.701 C1.6729736,10.701 1,11.373997 1.0000001,12.201 1,13.027996 1.6729736,13.701 2.5,13.701 3.3269958,13.701 4,13.027996 4,12.201 L3.9999866,12.200474 3.9980443,12.123936 C3.9577868,11.332592 3.3011522,10.701 2.5,10.701 z M13.499987,8.7009979 C12.672987,8.7009979 11.999987,9.373998 11.999987,10.200998 11.999987,11.027998 12.672987,11.700998 13.499987,11.700998 14.326986,11.700998 14.999987,11.027998 14.999987,10.200998 14.999987,9.373998 14.326986,8.7009979 13.499987,8.7009979 z M14.515357,1.0003309 C14.481983,0.99951458 14.446487,1.0020571 14.408987,1.0089951 L5.4099865,2.6579952 C5.1719866,2.700995 4.9999866,2.9079952 4.9999866,3.1489954 L4.9999866,4.7396889 14.999987,2.9069619 14.999987,1.5009947 C14.999987,1.2969952 14.886987,1.1729946 14.819986,1.1159945 14.764736,1.0704947 14.659975,1.0038691 14.515357,1.0003309 z M14.477699,0.00021648407 C14.835276,-0.0058488846 15.181299,0.11561966 15.459987,0.3479948 15.802987,0.63499451 15.999987,1.0549946 15.999987,1.5009947 L15.999987,10.200997 C15.999987,11.579998 14.877987,12.700998 13.499987,12.700998 12.120987,12.700998 10.999987,11.579998 10.999987,10.200998 10.999987,8.822998 12.120987,7.7009981 13.499987,7.7009981 14.059799,7.7009981 14.577362,7.8861719 14.994612,8.1984568 L14.999987,8.2026836 14.999987,3.9231343 4.9999866,5.755861 4.9999866,12.200465 5,12.201 C5,13.579998 3.8779907,14.701 2.5,14.701 1.1209717,14.701 0,13.579998 0,12.201 0,10.822994 1.1209717,9.7010002 2.5,9.7010002 3.0598087,9.7010002 3.5773706,9.8861731 3.9946208,10.198457 L3.9999866,10.202677 3.9999866,3.1489954 C3.9999866,2.4249949 4.5169868,1.8049951 5.2289867,1.6749945 L14.228987,0.02499485 C14.312049,0.0098075867 14.395182,0.0016155243 14.477699,0.00021648407 z"),
                    Fill = new SolidColorBrush(Colors.Black),
                    Stretch = Stretch.Fill,
                },
                SubItems = SubItems1
            });
            Items.Add(new MusicModel()
            {
                Item = "Recommended",
                Path = new Path()
                {
                    Width = 14,
                    Height = 14,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Data = Geometry.Parse("M11.5,10 C11.224,10 11,10.225 11,10.5 L11,13 11.5,13 C12.327,13 13,12.327 13,11.5 L13,10 z M1.0000133,9.9999933 L1.0000133,11.499993 C1.0000133,12.327004 1.672987,12.999993 2.5000133,12.999993 L3.0000133,12.999993 3.0000133,10.499993 C3.0000133,10.224999 2.7750072,9.9999933 2.5000133,9.9999933 z M7,0 C10.859,0 14,3.1409998 14,7 L14,9.4999999 14,10 14,11.5 C14,12.879 12.878,14 11.5,14 L10.5,14 C10.224,14 10,13.776 10,13.5 L10,10.5 C10,9.6729999 10.673,8.9999999 11.5,8.9999999 L13,8.9999999 13,7 C13,3.691 10.309,1 7,1 3.691,1 0.99999999,3.691 0.99999993,7 L0.99999993,8.9999934 2.5000133,8.9999934 C3.3270092,8.9999933 4.0000133,9.6729975 4.0000133,10.499993 L4.0000133,13.499993 C4.0000133,13.775994 3.7760143,13.999993 3.5000133,13.999993 L2.5000133,13.999993 C1.120985,13.999993 1.3340759E-05,12.879006 1.335144E-05,11.499993 L1.335144E-05,10 0,7 C1.0681106E-08,3.1409998 3.1400001,0 7,0 z"),
                    Fill = new SolidColorBrush(Colors.Black),
                    Stretch = Stretch.Fill,
                },
                SubItems = SubItems2
            });
            Items.Add(new MusicModel()
            {
                Item = "Recent Playlist",
                Path = new Path()
                {
                    Width = 15,
                    Height = 15,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Data = Geometry.Parse("M6.9990103,3.0000041 L7.9990076,3.0000041 7.9990076,7.270998 11.32401,10.121002 10.674018,10.880004 6.9990103,7.7310042 z M7.5,1 C3.9160001,1 1,3.916 1,7.5 1,11.084 3.9160001,14 7.5,14 11.084,14 14,11.084 14,7.5 14,3.916 11.084,1 7.5,1 z M7.5,0 C11.636,0 15,3.3640001 15,7.5 15,11.636 11.636,15 7.5,15 3.3640001,15 0,11.636 0,7.5 0,3.3640001 3.3640001,0 7.5,0 z"),
                    Fill = new SolidColorBrush(Colors.Black),
                    Stretch = Stretch.Fill,
                },
                SubItems = SubItems3
            });
            Items.Add(new MusicModel()
            {
                Item = "Radio",
                Path = new Path()
                {
                    Width = 16,
                    Height = 15.4,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Data = Geometry.Parse("M2.5,11.472009 L6.5,11.472009 C6.776,11.472009 7,11.696009 7,11.972009 7,12.248009 6.776,12.472009 6.5,12.472009 L2.5,12.472009 C2.224,12.472009 2,12.248009 2,11.972009 2,11.696009 2.224,11.472009 2.5,11.472009 z M2.5,8.4720092 L6.5,8.4720092 C6.776,8.4720092 7,8.6960092 7,8.9720092 7,9.2480091 6.776,9.4720092 6.5,9.4720092 L2.5,9.4720092 C2.224,9.4720092 2,9.2480091 2,8.9720092 2,8.6960092 2.224,8.4720092 2.5,8.4720092 z M11.000013,8.4720025 C9.8960094,8.4720025 9.0000134,9.3690057 9.0000134,10.472003 9.0000134,11.576006 9.8960094,12.472003 11.000013,12.472003 12.10301,12.472003 13.000013,11.576006 13.000013,10.472003 13.000013,9.3690057 12.10301,8.4720025 11.000013,8.4720025 z M11.000013,7.4720025 C12.654005,7.4720025 14.000013,8.8180108 14.000013,10.472003 14.000013,12.126009 12.654005,13.472003 11.000013,13.472003 9.3459911,13.472003 8.0000134,12.126009 8.0000134,10.472003 8.0000134,8.8180108 9.3459911,7.4720025 11.000013,7.4720025 z M1.5,6.4720092 C1.2290001,6.4720091 1,6.6560091 1,6.872009 L1,14.073009 C1,14.289009 1.2290001,14.472009 1.5,14.472009 L14.5,14.472009 C14.771,14.472009 15,14.289009 15,14.073009 L15,6.872009 C15,6.6560091 14.771,6.4720091 14.5,6.4720092 z M12.877348,0.00054502487 C13.071978,-0.0085949898 13.261545,0.097710133 13.351547,0.28444672 13.47155,0.53342915 13.365548,0.83140802 13.116541,0.9513998 L3.6977077,5.4720092 14.5,5.4720092 C15.327,5.4720092 16,6.1000091 16,6.872009 L16,14.073009 C16,14.844009 15.327,15.472009 14.5,15.472009 L1.5,15.472009 C0.67299986,15.472009 0,14.844009 0,14.073009 L0,6.872009 C0,6.148259 0.59150362,5.5510716 1.346869,5.4792504 L1.3769317,5.4771099 12.684531,0.049463272 C12.747032,0.019465446 12.812471,0.0035915375 12.877348,0.00054502487 z"),
                    Fill = new SolidColorBrush(Colors.Black),
                    Stretch = Stretch.Fill,
                },
                SubItems = SubItems
            });
            SelectedItem = Items[0];
            menuCollection = new ObservableCollection<MenuCollectionModel>();
            sender.Add("Adriana");
            sender.Add("Daleyza");
            sender.Add("Kyle");
            sender.Add("Victoriya");
            sender.Add("Steve");
            sender.Add("Briley");
            sender.Add("Maci");
            sender.Add("Zariah");
            sender.Add("Mckenna");
            sender.Add("Miranda");

			subject.Add("Goto Meeting");
			subject.Add("FW: Status Update");
			subject.Add("Greetings! Congrats");
			subject.Add("Report Monitor");
			subject.Add("News Letter");
			subject.Add("Conference about Latest Technology");
			subject.Add("RE: Status Update");
			subject.Add("Success! Report Automation");
			subject.Add("Monthly Reports Documents");
			subject.Add("Meeting Confirmation");

			subject.Add("Goto Meeting");
			subject.Add("FW: Status Update");
			subject.Add("Greetings! Congrats");
			subject.Add("Report Monitor");
			subject.Add("News Letter");
			subject.Add("Conference about Latest Technology");
			subject.Add("RE: Status Update");
			subject.Add("Success! Report Automation");
			subject.Add("Monthly Reports Documents");
			subject.Add("Meeting Confirmation");
			subject.Add("Goto Meeting");
			subject.Add("FW: Status Update");
			subject.Add("Greetings! Congrats");
			subject.Add("Report Monitor");
			subject.Add("News Letter");
			subject.Add("Conference about Latest Technology");
			subject.Add("RE: Status Update");
			subject.Add("Success! Report Automation");
			subject.Add("Monthly Reports Documents");
			subject.Add("Meeting Confirmation");

			textContent.Add("Join meeting to discuss about daily status, workflow, pending work and improve process");
			textContent.Add("Hi, Please find the today's status");
			textContent.Add("Hi, Congrats you have won the raffle");
			textContent.Add("Do not reply, Please find the attachment. Attachment have the full details of monitor report with timing");
			textContent.Add("Hi, Please find the attached news letter");
			textContent.Add("Hi, We are scheduled a meeting");
			textContent.Add("Thanks for the status report");
			textContent.Add("Do not reply, Automation result will update soon");
			textContent.Add("Hi, All documents are reviewed");
			textContent.Add("Thanks for scheduling the meeting");
			textContent.Add("Join meeting to discuss about daily status, workflow, pending work and improve process");
			textContent.Add("Hi, Please find the today's status");
			textContent.Add("Hi, Congrats you have won the raffle");
			textContent.Add("Do not reply, Please find the attachment. Attachment have the full details of monitor report with timing");
			textContent.Add("Hi, Please find the attached news letter");
			textContent.Add("Hi,We are scheduled a conference meeting");
			textContent.Add("Thanks for the status report");
			textContent.Add("Do not reply, Automation result will update soon");
			textContent.Add("Hi, All documents are reviewed");
			textContent.Add("Thanks for scheduling the meeting");
			textContent.Add("Join meeting to discuss about daily status, workflow, pending work and improve process");
			textContent.Add("Hi, Please find the today's status");
			textContent.Add("Hi, Congrats you have won the raffle");
			textContent.Add("Do not reply, Please find the attachment. Attachment have the full details of monitor report with timing");
			textContent.Add("Hi, Please find the attached news letter");
			textContent.Add("Hi,We are scheduled a conference meeting");
			textContent.Add("Thanks for the status report");
			textContent.Add("Do not reply, Automation result will update soon");
			textContent.Add("Hi, All documents are reviewed");
			textContent.Add("Thanks for scheduling the meeting");

			menuCollection.Add(getItem("Inbox", Geometry.Parse("M32.032381, 16.445429 L25.410999, 23 22.598995, 23 15.853724, 16.561278 3.4150009, 29 44.586115, 29z M2.0000003, 3.3371553 L2.0000003, 27.587 14.406845, 15.180154z M46.000002, 2.6187388 L33.45355, 15.038597 46.000002, 27.585888z M3.4950623, 2.0000003 L23.399998, 21 24.589001, 21 43.782564, 2.0000003z M0, 0 L48.000002, 0 48.000002, 31 0, 31z")));
			menuCollection.Add(getItem("Starred", Geometry.Parse("M25.085007,5.9780004 L20.577011,18.675001 6.3710022,18.675001 17.92601,26.723001 13.423004,40.314001 25.085007,32.191999 36.977005,40.473997 33.332001,26.723001 43.999008,18.675001 29.593002,18.675001z M25.085007,0 L31.005005,16.675001 49.970001,16.675001 35.609009,27.51 40.307007,45.230001 25.085007,34.629999 9.6340027,45.389997 15.559006,27.51 0,16.675001 19.165009,16.675001z")));
			menuCollection.Add(getItem("Sent mail", Geometry.Parse("M42.128046,6.7269681 L18.53705,30.317964 25.278003,43.798z M40.380997,5.6460154 L4.6410007,23.1 17.108567,28.918443z M47.383005,0 L25.364002,48.443 16.582001,30.878999 0,23.141z")));
			menuCollection.Add(getItem("Drafts", Geometry.Parse("M6.9999996,48.353 L19,48.353 19,50.353 6.9999996,50.353z M6.9999996,42.353 L32,42.353 32,44.353 6.9999996,44.353z M6.9999996,36.353 L32,36.353 32,38.353 6.9999996,38.353z M6.4999996,30.353 L31.5,30.353 31.5,32.353 6.4999996,32.353z M25.523109,22.610376 L24.94,25.014999 27.461736,24.549429z M0,15.853 L23,15.853 23,17.853 1.9999989,17.853 1.9999989,54.853 37,54.853 37,21.853 39,21.853 39,56.853 0,56.853z M40.953857,5.9638548 L26.382576,20.641725 29.510826,23.770661 44.083183,9.0931849z M44.058998,2.8360004 L42.362705,4.5447035 45.492099,7.6741037 47.184002,5.9699993 z M44.055,0 L50.004001,5.9659996 30.003,26.115 22.271,27.542999 24.065,20.137z")));
			menuCollection.Add(getItem("All mail", Geometry.Parse("M12,32.999999 L26,32.999999 26,34.999999 12,34.999999z M14,14.999999 C7.3830004,14.999999 2.0000005,20.382998 2.0000005,26.999999 L2.0000005,41.999999 34,41.999999 34,26.999999 C34,20.382998 28.617001,14.999999 22,14.999999z M45.499996,7.9999983 L45.499996,14.999998 43.499996,14.999998 43.499996,11.999999 37.099997,16.799998 35.900997,15.199999z M33.739992,1.9999998 C31.497988,1.9999998 29.336,2.6739995 27.489992,3.9479995 L14.382671,12.999999 22,12.999999 C29.720001,12.999999 36,19.279999 36,26.999999 L36,40.808894 48.999996,29.543002 48.999996,9.0000007 C48.999996,5.1409991 45.859009,1.9999998 42,1.9999998z M33.739992,2.2737368E-13 L42,2.2737368E-13 C46.962978,-4.79037E-07 50.999996,4.036999 50.999996,9.0000007 L50.999996,30.457003 36,43.457003 36,43.999999 19,43.999999 19,51.999999 17.000001,51.999999 17.000001,43.999999 0,43.999999 0,26.999999 C0,20.7275 4.1457815,15.405624 9.8412797,13.630439 L10.028968,13.574487 26.352999,2.302 C28.535982,0.79599917 31.089998,-4.79037E-07 33.739992,2.2737368E-13z")));
			menuCollection.Add(getItem("Trash", Geometry.Parse("M17,12 L19,12 19,42 17,42z M10.998,11.933997 L12.998014,41.934002 11.002,42.067001 9.0019855,12.066998z M25.002001,10.935999 L26.998014,11.064999 24.997999,42.065002 23.001986,41.936001z M4.0514956,7.9999995 L5.9510078,46 30.048996,46 31.948509,7.9999995z M13,2.0000002 C11.897,2 11,2.8959999 11,3.9999998 L11,6 25,6 25,3.9999998 C25,2.8959999 24.103001,2 23,2.0000002z M13,0 L23,0 C25.205999,0 27,1.7950001 27,3.9999998 L27,6 36,6 36,7.9999995 33.951481,7.9999995 31.950994,48 4.0490093,48 2.048521,7.9999995 0,7.9999995 0,6 9,6 9,3.9999998 C9,1.7950001 10.794,0 13,0z")));
			menuCollection.Add(getItem("Spam", Geometry.Parse("M33.671003,29.293001 L39.214003,34.835998 44.757002,29.293001 46.171,30.707 40.628,36.25 46.171,41.792999 44.757002,43.207 39.214003,37.664001 33.671003,43.207 32.257002,41.792999 37.800001,36.25 32.257002,30.707z M38.964003,24 C32.347002,24 26.964003,29.382999 26.964003,36 26.964003,42.617 32.347002,48 38.964003,48 45.581003,48 50.964003,42.617 50.964003,36 50.964003,29.382999 45.581003,24 38.964003,24z M38.964003,22 C46.684,22 52.964003,28.28 52.964003,36 52.964003,43.720001 46.684,50 38.964003,50 31.244001,50 24.964003,43.720001 24.964003,36 24.964003,28.28 31.244001,22 38.964003,22z M3.9279995,2 L18.473,22 25.454998,22 39.999994,2z M0,0 L43.927996,0 26.964003,23.324888 26.964003,25.452001 C26.203001,26.317001 25.527002,27.257 24.964003,28.271002 L24.964003,24 18.964003,24 18.964003,41.446003 24.964003,45.196003 24.964003,43.729004 C25.526001,44.744003 26.203001,45.683002 26.964003,46.548004 L26.964003,48.805004 16.964003,42.555004 16.964003,23.324899z")));
			menuCollection.Add(getItem("Follow up", Geometry.Parse("M37.744994,26.363999 L39.193995,27.742999 36.316247,30.765999 47.690001,30.765999 47.690001,32.765999 35.971558,32.765999 39.283995,36.246001 37.834994,37.625 32.430992,31.946999z M10.791008,12.499 L12.240009,13.878 3.7795773,22.765999 30.690001,22.765999 30.690001,24.765999 3.6482124,24.765999 12.240009,33.792002 10.791008,35.171004 0,23.835001z M29.636997,0 L31.085993,1.3789999 27.861747,4.7659996 40.690001,4.7659996 40.690001,6.7659998 28.209764,6.7659998 31.174993,9.8820009 29.725997,11.261001 24.323013,5.5830005z")));

		}

		public ObservableCollection<MenuCollectionModel> MenuCollection
        {
            get
            {
                return menuCollection;
            }

            set
            {
                menuCollection = value;
            }
        }
    }

}
