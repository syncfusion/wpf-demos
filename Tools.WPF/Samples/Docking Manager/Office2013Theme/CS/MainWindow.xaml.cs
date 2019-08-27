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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls.Primitives;

namespace Office2013ThemeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DocumentContainer1 = dockingManager1.DocContainer as DocumentContainer;
            DocumentContainer1.Loaded += DocumentContainer1_Loaded;
            DocumentContainer1.ActiveDocumentChanged +=new PropertyChangedCallback(DocumentContainer1_ActiveDocumentChanged);
            DocumentContainer1.TabGroupEnabled = false;
            DocumentContainer1.ShowTabItemContextMenu = false;
        }

        void DocumentContainer1_Loaded(object sender, RoutedEventArgs e)
        {
           TabPanelAdv tabpanel = VisualUtils.FindDescendant(sender as Visual, typeof(TabPanelAdv)) as TabPanelAdv;
           if (tabpanel != null)
           {
               ToggleButton menubutton = tabpanel.Template.FindName("PART_MenuButton", tabpanel) as ToggleButton;
               ToggleButton closebutton = tabpanel.Template.FindName("PART_CloseButton", tabpanel) as ToggleButton;
               if (menubutton != null)
               {
                   ToolTipService.SetShowOnDisabled(menubutton, true);
                   menubutton.ToolTip = "Context Menu";
               }
               if (closebutton != null)
               {
                   ToolTipService.SetShowOnDisabled(closebutton, true);
                   closebutton.ToolTip = "Close";
               }
           }
        }
        DocumentContainer DocumentContainer1 = null;
       string path = Environment.CurrentDirectory;
       string loaclpath;
       private void DocumentContainer1_ActiveDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           loaclpath = Directory.GetParent(path).ToString();
          
            if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "Beijing")
            {                
                ConditionToNight.Text = "Showers Clear";
                ConditionTomoNight.Text = "Showers Late";
                TemperatureToNight.Text = "29";
                TemperatureTomoNight.Text = "28";   
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\Showers _ Clear.jpg");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\Showers Late.jpg");       
                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);  
            }
            else if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "Madagascar")
            {                
                ConditionToNight.Text = "Light Showers";
                ConditionTomoNight.Text = "Rain";
                TemperatureToNight.Text = "22";
                TemperatureTomoNight.Text = "25"; 
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\Rain.jpg");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\Light Showers.jpg");              
                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);  
            }
            else if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "Newyork")
            {
                ConditionToNight.Text = "Partly Cloudy";
                ConditionTomoNight.Text = "Mostly Cloudy";
                TemperatureToNight.Text = "26";
                TemperatureTomoNight.Text = "27";   
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\Mostly Cloudy.jpg");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\Partly Cloudy.jpg");
                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);  
            }
            else if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "London")
            {
                 ConditionToNight.Text = "Thunderstorms";
                ConditionTomoNight.Text = "Scattered Thunderstorms";
                TemperatureToNight.Text = "20";
                TemperatureTomoNight.Text = "22"; 
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\Scattered Thunderstorms.jpg");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\Thunderstorms.jpg");
                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);  
            }
            else if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "Brussels")
            {
                ConditionToNight.Text = "Rain";
                ConditionTomoNight.Text = "Light Showers";
                TemperatureToNight.Text = "26";
                TemperatureTomoNight.Text = "25"; 
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\Rain.jpg");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\Light Showers.jpg");               
                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);
              
            }
            else if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "New Delhi")
            {
                ConditionToNight.Text = "Partly Cloudy";
                ConditionTomoNight.Text = "Mostly Cloudy";
                TemperatureToNight.Text = "23";
                TemperatureTomoNight.Text = "24";
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\Mostly Cloudy.jpg");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\Partly Cloudy.jpg");
                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);
                
            }
            else if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "Chennai")
            {
                ConditionToNight.Text = "Light Showers";
                ConditionTomoNight.Text = "Showers Clear";
                TemperatureToNight.Text = "23";
                TemperatureTomoNight.Text = "24";
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\Showers _ Clear.jpg");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\Light Showers.jpg");
                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);
            }
             
        }
        private void WeatherReport(String WeatherTomoNightimgpath, String WeatherToNightimgpath)
        {
            BitmapImage WeatherTomoNightimg = new BitmapImage();
            WeatherTomoNightimg.BeginInit();  
            WeatherTomoNightimg.UriSource = new Uri(WeatherTomoNightimgpath);
            WeatherTomoNightimg.EndInit();
            WeatherTomoNight.Source = WeatherTomoNightimg;
            BitmapImage WeatherToNightimg = new BitmapImage();
            WeatherToNightimg.BeginInit();            
            WeatherToNightimg.UriSource = new Uri(WeatherToNightimgpath);
            WeatherToNightimg.EndInit();
            WeatherToNight.Source = WeatherToNightimg;
        }
    }
}