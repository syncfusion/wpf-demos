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

namespace syncfusion.navigationdemos.wpf
{
	public class NavigationDrawerViewModel : NotificationObject
	{

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
			for (int i = 0; i < 10; i++)
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
