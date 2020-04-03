#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RibbonSample
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {        

        private Storyboard myStoryboard;
        Timer timer = new Timer();
        /// <summary>
        /// constructor SplashScreen
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();         
           

            this.img.Source = new BitmapImage(new Uri("pack://application:,,,/RibbonSample;component/Images/screen.png", UriKind.Absolute));
            this.img1.Source = new BitmapImage(new Uri("pack://application:,,,/RibbonSample;component/Images/screen.png", UriKind.Absolute));
          
            this.Loaded += SplashScreen_Loaded;
         
            timer.Interval = 1000;
           
          
            timer.Elapsed += timer_Elapsed;
            timer.Start();

        }
     
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
        
        }

        void SplashScreen_Loaded(object sender, RoutedEventArgs e)
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

            myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 200;
            myDoubleAnimation.To = -800;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));

            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, this.Screen2.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Grid.WidthProperty));

            myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 140;
            myDoubleAnimation.To = this.Height;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));

            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, this.Screen2.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Grid.HeightProperty));

            myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = -400;
            myDoubleAnimation.To = this.Width;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
          
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, this.Screen1.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Grid.WidthProperty));

            myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 140;
            myDoubleAnimation.To = this.Height;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));

            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, this.Screen1.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Grid.HeightProperty));
           
            myStoryboard.Completed += myStoryboard_Completed;
            myStoryboard.Begin(this);           
         
        }

        void myStoryboard_Completed(object sender, EventArgs e)
        {
            Window1 ribbonWindow = new Window1();           
            ribbonWindow.WindowState = WindowState.Maximized;
            ribbonWindow.WindowStyle = WindowStyle.None;
            ribbonWindow.AllowsTransparency = true;
            ribbonWindow.Show();
            this.Close();        
        }
    }
}
