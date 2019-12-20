#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
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
using System.Runtime.InteropServices;
using System.Windows.Media.Animation;
using System.IO;

namespace DockingManagerTouchDemo_2010
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        [DllImport("uxtheme.dll", EntryPoint = "#95")]
        public static extern uint GetImmersiveColorFromColorSetEx(uint dwImmersiveColorSet, uint dwImmersiveColorType, bool bIgnoreHighContrast, uint dwHighContrastCacheMode);
        [DllImport("uxtheme.dll", EntryPoint = "#96")]
        public static extern uint GetImmersiveColorTypeFromName(IntPtr pName);
        [DllImport("uxtheme.dll", EntryPoint = "#98")]
        public static extern int GetImmersiveUserColorSetPreference(bool bForceCheckRegistry, bool bSkipCheckOnFail);

        private Storyboard myStoryboard;
        string path = Environment.CurrentDirectory;
        string loaclpath;
        DocumentContainer DocumentContainer1 = null;
        public MainWindow()
        {
            InitializeComponent();


            try
            {

                uint colourdword = GetImmersiveColorFromColorSetEx((uint)GetImmersiveUserColorSetPreference(false, false), GetImmersiveColorTypeFromName(Marshal.StringToHGlobalUni("ImmersiveStartSelectionBackground")), false, 0);
                Color colour = Color.FromArgb((byte)((0xFF000000 & colourdword) >> 24), (byte)(0x000000FF & colourdword),
                    (byte)((0x0000FF00 & colourdword) >> 8), (byte)((0x00FF0000 & colourdword) >> 16));
                this.Screen1.Background = new SolidColorBrush(colour);
                this.Screen2.Background = new SolidColorBrush(colour);
            }
            catch (Exception)
            {
            }
             loaclpath = Directory.GetParent(path).ToString();
#if NETCORE
            string[] filePath = loaclpath.Split('\\');
            string removeString = filePath[filePath.Length - 1];
            string loaclpath1 = loaclpath.Replace("bin\\" + removeString, "Images\\screen1.png");
            string localpath2 = loaclpath.Replace("bin\\" + removeString, "Images\\screen1.png");
#else
            string loaclpath1 = loaclpath.Replace("bin", "Images\\screen1.png");
            string localpath2 = loaclpath.Replace("bin", "Images\\screen1.png");
#endif
            this.img.Source = new BitmapImage(new Uri(loaclpath1, UriKind.Absolute));
             this.img1.Source = new BitmapImage(new Uri(localpath2, UriKind.Absolute));
        

            this.Loaded += MainWindow_Loaded;

            this.Activated += MainWindow_Activated;
            DocumentContainer1 = dockingManager1.DocContainer as DocumentContainer;
            DocumentContainer1.Loaded += DocumentContainer1_Loaded;
            DocumentContainer1.ActiveDocumentChanged += new PropertyChangedCallback(DocumentContainer1_ActiveDocumentChanged);
            dockingManager1.TouchDown += dockingManager1_TouchDown;
        }

        void dockingManager1_TouchDown(object sender, TouchEventArgs e)
        {
            if (this.combo != null && this.combo.IsDropDownOpen)
             {
                  this.combo.IsDropDownOpen = false;
             }
        }

        void DocumentContainer1_Loaded(object sender, RoutedEventArgs e)
        {
            TabPanelAdv tabpanel = VisualUtils.FindDescendant(sender as Visual, typeof(TabPanelAdv)) as TabPanelAdv;
            if (tabpanel != null)
            {
                Button prevbutton = tabpanel.Template.FindName("PART_PrevTab", tabpanel) as Button;
                Button nextbutton = tabpanel.Template.FindName("PART_NextTab", tabpanel) as Button;
                if (prevbutton != null)
                {
                    ToolTipService.SetShowOnDisabled(prevbutton, true);
                    prevbutton.ToolTip = "Previous";
                }
                if (nextbutton != null)
                {
                    ToolTipService.SetShowOnDisabled(nextbutton, true);
                    nextbutton.ToolTip = "Next";
                }
            }
        }

        private void DocumentContainer1_ActiveDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            loaclpath = Directory.GetParent(path).ToString();
            string[] filePath = loaclpath.Split('\\');
            string removeString = filePath[filePath.Length - 1];

            if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "Beijing")
            {
                ConditionToNight.Text = "Showers Clear";
                ConditionTomoNight.Text = "Showers Late";
                TemperatureToNight.Text = "29";
                TemperatureTomoNight.Text = "28";
#if NETCORE
                String WeatherTomoNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\showerClear.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\Showers Late.jpg");
#else
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\showerClear.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\Showers Late.jpg");
#endif
                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);
            }
            else if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "Madagascar")
            {
                ConditionToNight.Text = "Light Showers";
                ConditionTomoNight.Text = "Rain";
                TemperatureToNight.Text = "22";
                TemperatureTomoNight.Text = "25";
#if NETCORE
                String WeatherTomoNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\Rain.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\rainy1.png");
#else
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\Rain.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\rainy1.png");
#endif
                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);
            }
            else if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "Newyork")
            {
                ConditionToNight.Text = "Partly Cloudy";
                ConditionTomoNight.Text = "Mostly Cloudy";
                TemperatureToNight.Text = "26";
                TemperatureTomoNight.Text = "27";
#if NETCORE
                String WeatherTomoNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\Mostly Cloudy.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\Partly Cloudy.png");
#else
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\Mostly Cloudy.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\Partly Cloudy.png");
#endif

                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);
            }
            else if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "London")
            {
                ConditionToNight.Text = "Thunder";
                ConditionTomoNight.Text = "Thunderstorms";
                TemperatureToNight.Text = "20";
                TemperatureTomoNight.Text = "22";
#if NETCORE
                String WeatherTomoNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\Scattered Thunderstorms.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\Thunderstorms.png");
#else
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\Scattered Thunderstorms.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\Thunderstorms.png");
#endif
                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);
            }
            else if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "Brussels")
            {
                ConditionToNight.Text = "Rain";
                ConditionTomoNight.Text = "Light Showers";
                TemperatureToNight.Text = "26";
                TemperatureTomoNight.Text = "25";
#if NETCORE
                String WeatherTomoNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\Rain.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\rainy1.png");
#else
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\Rain.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\rainy1.png");
#endif
                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);

            }
            else if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "New Delhi")
            {
                ConditionToNight.Text = "Partly Cloudy";
                ConditionTomoNight.Text = "Mostly Cloudy";
                TemperatureToNight.Text = "23";
                TemperatureTomoNight.Text = "24";
#if NETCORE
                String WeatherTomoNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\Mostly Cloudy.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\Partly Cloudy.png");
#else
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\Mostly Cloudy.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\Partly Cloudy.png");
#endif
                WeatherReport(WeatherTomoNightimgpath, WeatherToNightimgpath);

            }
            else if (DocumentContainer1.ActiveDocument != null && DocumentContainer.GetHeader(DocumentContainer1.ActiveDocument).ToString() == "Chennai")
            {
                ConditionToNight.Text = "Light Showers";
                ConditionTomoNight.Text = "Showers Clear";
                TemperatureToNight.Text = "23";
                TemperatureTomoNight.Text = "24";
#if NETCORE
                String WeatherTomoNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\showerClear.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin\\" + removeString, "Images\\rainy1.png");
#else
                String WeatherTomoNightimgpath = loaclpath.Replace("bin", "Images\\showerClear.png");
                String WeatherToNightimgpath = loaclpath.Replace("bin", "Images\\rainy1.png");
#endif
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

        void MainWindow_Activated(object sender, EventArgs e)
        {
           
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            StackPanel myPanel = new StackPanel();
            myPanel.Margin = new Thickness(10);

            Rectangle myRectangle = new Rectangle();
            myRectangle.Name = "myRectangle";
            this.RegisterName(myRectangle.Name, myRectangle);
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            myRectangle.Fill = Brushes.Blue;

            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1.0;
            myDoubleAnimation.To = 0.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.2));



            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, this.Screen2.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Grid.OpacityProperty));

           // myStoryboard.Begin(this);



            myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 200;
            myDoubleAnimation.To = -800;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));

            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, this.Screen2.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Grid.WidthProperty));

          //  myStoryboard.Begin(this);


            myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 140;
            myDoubleAnimation.To = this.splasscreen.Height;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));

            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, this.Screen2.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Grid.HeightProperty));


           // myStoryboard.Begin(this);




            myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = -400;
            myDoubleAnimation.To = this.splasscreen.ActualWidth;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, this.Screen1.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Grid.WidthProperty));

          //  myStoryboard.Begin(this);



            myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 140;
            myDoubleAnimation.To = this.splasscreen.ActualHeight;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));

            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, this.Screen1.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Grid.HeightProperty));


            myStoryboard.Completed += myStoryboard_Completed;
            myStoryboard.Begin(this);


       
           

            
        }

        void rainfallstoryboard_Completed(object sender, EventArgs e)
        {
            storyboard.Begin(this);
        }

        void storyboard_Completed(object sender, EventArgs e)
        {
            DoubleAnimation doubleAnimation1 = new DoubleAnimation();
            doubleAnimation1.From = 0.0;
            doubleAnimation1.To = 5.0;
            doubleAnimation1.Duration = new Duration(TimeSpan.FromSeconds(2));
            doubleAnimation1.AutoReverse = true;

            rainfallstoryboard.Children.Add(doubleAnimation1);
            Storyboard.SetTargetName(doubleAnimation1, this.temperature.Name);
            Storyboard.SetTargetProperty(doubleAnimation1, new PropertyPath(Grid.OpacityProperty));
          
            
            rainfallstoryboard.Begin(this);
        }
        Storyboard storyboard = new Storyboard();
        Storyboard rainfallstoryboard = new Storyboard();
        void myStoryboard_Completed(object sender, EventArgs e)
        {
            this.mainscreen.Visibility = System.Windows.Visibility.Visible;
            this.splasscreen.Visibility = System.Windows.Visibility.Collapsed;
            this.combo.SelectedIndex = 8;

       

            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0.0;
            doubleAnimation.To = 5.0;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
            doubleAnimation.AutoReverse = true;


            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetName(doubleAnimation, this.rainfall.Name);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Grid.OpacityProperty));

            storyboard.Completed += storyboard_Completed;
            rainfallstoryboard.Completed += rainfallstoryboard_Completed;
            storyboard.Begin(this);

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SkinStorage.SetVisualStyle(this, ((sender as ComboBoxAdv).SelectedItem as ComboBoxItemAdv).Content.ToString());
        }
    }
}
