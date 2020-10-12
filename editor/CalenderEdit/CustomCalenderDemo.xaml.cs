#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Globalization;
using System.Threading;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class CustomCalenderDemo : DemoControl
    {
        #region Private Members
        /// <summary>
        /// DayCell Background.
        /// </summary>
        Brush dcBackgroundBackup;
        /// <summary>
        /// Day Cell Border Brush.
        /// </summary>1
        Brush dcBorderBackup;
        /// <summary>
        /// DayNameCell Background.
        /// </summary>
        Brush dncBackgroundBackup;
        /// <summary>
        /// DayNameCell BorderBrush.
        /// </summary>
        Brush dncBorderBackup;
        /// <summary>
        /// DayCell BorderThickness.
        /// </summary>
        double dcBorThickValue;
        /// <summary>
        /// DayNameCell BorderThickness.
        /// </summary>
        double dncBorThickValue;
        /// <summary>
        /// DayCell CornerRadius.
        /// </summary>
        double dcCornerValue;
        /// <summary>
        /// DayNameCell CornerRadius.
        /// </summary>
        double dncCornerValue;

        #endregion

        #region Constructor

        /// <summary>
        /// Contructor for window1.
        /// </summary>

        public CustomCalenderDemo()
        {
            InitializeComponent();
        }

        public CustomCalenderDemo(string themename) : base(themename)
        {
            InitializeComponent();
            InitializeLog();
        }

        /// <summary>
        /// Initialization while creating object
        /// </summary>   

        public void InitializeLog()
        {
            //Setting the Culture for the CalendarEdit control
            calendarEdit.Culture = new CultureInfo(Thread.CurrentThread.CurrentCulture.LCID);
            //Subscribe ColorChanged property Changed event for the Color Edit control
            colorEditor.ColorChanged += new PropertyChangedCallback(colorEditor_ColorChanged);
            //Subscribe Value property Changed event for the Slider Control
            slider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(slider_ValueChanged);
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Slider Value changing event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Changing Corner Radius and Border Thickness of the cells
            if (dncCor.IsChecked.Equals(true))
            {
                dncCornerValue = slider.Value;
                daynamecellstylechange();

            }
            else if (dncBorThick.IsChecked.Equals(true))
            {
                dncBorThickValue = slider.Value;
                daynamecellstylechange();
            }
            else if (dcCor.IsChecked.Equals(true))
            {
                dcCornerValue = slider.Value;
                daycellstylechange();
            }
            else if (dcBorThick.IsChecked.Equals(true))
            {
                dcBorThickValue = slider.Value;
                daycellstylechange();
            }
        }

        /// <summary>
        /// In this method we set the DayCellbackground.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dcBackRadio(object sender, RoutedEventArgs e)
        {
            dcBackgroundBackup = new SolidColorBrush(colorEditor.Color);
        }

        /// <summary>
        /// In this method we set the Daycell BorderBrush
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dcBorRadio(object sender, RoutedEventArgs e)
        {
            dcBorderBackup = new SolidColorBrush(colorEditor.Color);
        }

        /// <summary>
        /// in this method we set the DayNameCell BorderBrush.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dncBorRadio(object sender, RoutedEventArgs e)
        {
            dncBorderBackup = new SolidColorBrush(colorEditor.Color);
        }

        /// <summary>
        /// In this method we set the DayNameCell Background.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dncBackRadio(object sender, RoutedEventArgs e)
        {
            dncBackgroundBackup = new SolidColorBrush(colorEditor.Color);
        }

        /// <summary>
        /// In this method we set the DayNameCell Border Thickness.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dncBorThickRadio(object sender, RoutedEventArgs e)
        {
            dncBorThickValue = slider.Value;
            dncBorThick.IsChecked = true;
        }

        /// <summary>
        /// In this method we set the DayNameCell Corner Radius.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dncCornerRadio(object sender, RoutedEventArgs e)
        {
            dncCornerValue = slider.Value;
            dncCor.IsChecked = true;
        }

        /// <summary>
        /// In this method we set the DayCell Border thickness.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dcBorThickRadio(object sender, RoutedEventArgs e)
        {
            dcBorThickValue = slider.Value;
            dcBorThick.IsChecked = true;
        }

        /// <summary>
        /// In this method we set the DayCell Corner Radius.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dcCornerRadio(object sender, RoutedEventArgs e)
        {
            dcCornerValue = slider.Value;
            dcCor.IsChecked = true;
        }

        /// <summary>
        /// In this method we change the DayCell styles are changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void daycellstylechange()
        {
            // For DayCell Custom
            Style s = new Style();
            DayCell fx = new DayCell();
            s.TargetType = fx.GetType();
            Setter sett = new Setter(DayCell.BackgroundProperty, dcBackgroundBackup);
            Setter sett1 = new Setter(DayCell.BorderBrushProperty, dcBorderBackup);
            Setter sett2 = new Setter(DayCell.BorderThicknessProperty, new Thickness(dcBorThickValue));
            Setter sett3 = new Setter(Border.CornerRadiusProperty, new CornerRadius(dcCornerValue));
            s.Setters.Add(sett);
            s.Setters.Add(sett1);
            s.Setters.Add(sett2);
            s.Setters.Add(sett3);
            calendarEdit.DayCellsStyle = s;
        }

        /// <summary>
        /// In this method we change the DayNameCell styles are changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void daynamecellstylechange()
        {
            //For DayCelName Custom
            Style s1 = new Style();
            DayNameCell fx1 = new DayNameCell();
            s1.TargetType = fx1.GetType();
            Setter sett = new Setter(DayNameCell.BackgroundProperty, dncBackgroundBackup);
            Setter sett1 = new Setter(DayNameCell.BorderBrushProperty, dncBorderBackup);
            Setter sett2 = new Setter(DayNameCell.BorderThicknessProperty, new Thickness(dncBorThickValue));
            Setter sett3 = new Setter(Border.CornerRadiusProperty, new CornerRadius(dncCornerValue));
            s1.Setters.Add(sett);
            s1.Setters.Add(sett1);
            s1.Setters.Add(sett2);
            s1.Setters.Add(sett3);
            calendarEdit.DayNameCellsStyle = s1;
        }

        /// <summary>
        /// In this method we set the various appearance
        /// related properties to CalendarEdit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void colorEditor_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Changing Calendar Edit Style
            if (dncBack.IsChecked == true)
            {
                dncBackgroundBackup = new SolidColorBrush(colorEditor.Color);
                daynamecellstylechange();
            }
            else if (dncBor.IsChecked == true)
            {
                dncBorderBackup = new SolidColorBrush(colorEditor.Color);
                daynamecellstylechange();
            }
            else if (dcBack.IsChecked == true)
            {
                dcBackgroundBackup = new SolidColorBrush(colorEditor.Color);
                daycellstylechange();
            }
            else if (dcBor.IsChecked == true)
            {
                dcBorderBackup = new SolidColorBrush(colorEditor.Color);
                daycellstylechange();
            }
        }
        #endregion
    }
}
