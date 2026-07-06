#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Threading;
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Net;
using System.Xml.Linq;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.layoutdemos.wpf
{
    public class LoadedAction : TargetedTriggerAction<UserControl>
    {
        private DispatcherTimer timer;      
        protected override void Invoke(object parameter)
        {           
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();           
        }

        protected override void OnDetaching()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Tick -= new EventHandler(timer_Tick);
            }

            base.OnDetaching();
        }

        private TileViewItem tileItem;

        public TileViewItem TileItem
        {
            get
            {
                if (tileItem == null)
                {
                    tileItem = VisualUtils.FindAncestor(this.Target, typeof(TileViewItem)) as TileViewItem;
                }
                return tileItem;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                if (TileItem != null && TileItem.TileViewItemState == TileViewItemState.Maximized)
                {
                     TweetList.ItemsSource = GetSearchResults(SearchText);
                }
            }), DispatcherPriority.ApplicationIdle);
        }


        public ListBox TweetList
        {
            get { return (ListBox)GetValue(tweetsProperty); }
            set { SetValue(tweetsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for tweets.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty tweetsProperty =
            DependencyProperty.Register("TweetList", typeof(ListBox), typeof(LoadedAction), new UIPropertyMetadata(null));



        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(LoadedAction), new UIPropertyMetadata(null));

        

        public List<Tweet> GetSearchResults(string searchString)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://search.twitter.com/search.atom?lang=en&q={0}", searchString);
                WebClient client = new WebClient();
                List<Tweet> tweets = null;
                try
                {
                    XDocument doc = XDocument.Load(url);
                    XNamespace ns = "http://www.w3.org/2005/Atom";
                    tweets = (from item in doc.Descendants(ns + "entry")
                              select new Tweet
                              {
                                  Id = item.Element(ns + "id").Value,
                                  Published = DateTime.Parse(item.Element(ns + "published").Value),
                                  Title = item.Element(ns + "title").Value,
                                  Content = item.Element(ns + "content").Value,
                                  Link = (from XElement x in item.Descendants(ns + "link")
                                          where x.Attribute("type").Value == "text/html"
                                          select x.Attribute("href").Value).First(),
                                  Image = (from XElement x in item.Descendants(ns + "link")
                                           where x.Attribute("type").Value == "image/png"
                                           select x.Attribute("href").Value).First(),
                                  Author = new Author()
                                  {
                                      Name = item.Element(ns + "author").Element(ns + "name").Value,
                                      Uri = item.Element(ns + "author").Element(ns + "uri").Value
                                  }

                              }).ToList();


                }
                catch (Exception)
                {
                    // status.Text = "--no data connection--";
                }
                timer.Stop();
                return tweets;
            }
        }

    }
}
