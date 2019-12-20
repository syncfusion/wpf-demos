#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Tools;
using System.Globalization;
using System.Threading;
using Syncfusion.Windows.Shared;


namespace LookAndFeel
{  
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
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
        
        public Window1()
        {
            InitializeComponent();
            InitializeLog();
			//Update tooltip for special days
			this.firstCalendarEdit.MouseMove += FirstCalendarEdit_MouseMove; ;

		}

		private void FirstCalendarEdit_MouseMove(object sender, MouseEventArgs e)
		{
			Date day1 = new Date(2018, 1, 12);
			Date day2 = new Date(2018, 1, 15);
			Date day3 = new Date(2018, 2, 4);
			Date day4 = new Date(2018, 2, 14);
			Date day5 = new Date(2018, 12, 2);
			Date day6 = new Date(2018, 3, 8);
			Date day7 = new Date(2018, 3, 21);
			Date day8 = new Date(2018, 3, 24);
			Date day9 = new Date(2018, 4, 7);
			Date day10 = new Date(2018, 4, 22);
			Date day11 = new Date(2018, 5, 1);
			Date day12 = new Date(2018, 5, 31);
			Date day13 = new Date(2018, 6, 5);
			Date day14 = new Date(2018, 6, 14);
			Date day15 = new Date(2018, 6, 21);
			Date day16 = new Date(2018, 7, 1);
			Date day17 = new Date(2018, 8, 6);
			Date day18 = new Date(2018, 8, 19);
			Date day19 = new Date(2018, 8, 29);
			Date day20 = new Date(2018, 9, 15);
			Date day21 = new Date(2018, 9, 16);
			Date day22 = new Date(2018, 9, 27);
			Date day23 = new Date(2018, 10, 9);
			Date day24 = new Date(2018, 10, 16);
			Date day25 = new Date(2018, 11, 5);
			Date day26 = new Date(2018, 11, 14);
			Date day27 = new Date(2018, 12, 1);
			Date day28 = new Date(2018, 12, 22);
			Date day29 = new Date(2018, 12, 25);
		
			if (day1 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "National Youth Day";
				firstCalendarEdit.SetToolTip(day1, toolTip);
			}
			if (day2 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Army Day";
				firstCalendarEdit.SetToolTip(day2, toolTip);
			}
			if (day3 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Cancer Day";
				firstCalendarEdit.SetToolTip(day3, toolTip);
			}
			if (day4 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Valentine Day";
				firstCalendarEdit.SetToolTip(day4, toolTip);
			}
			if (day5 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Pollution Prevention Day";
				firstCalendarEdit.SetToolTip(day5, toolTip);
			}
			if (day6 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "International Women�s Day";
				firstCalendarEdit.SetToolTip(day6, toolTip);
			}
			if (day7 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Forestry Day";
				firstCalendarEdit.SetToolTip(day7, toolTip);
			}
			if (day8 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Day for Water";
				firstCalendarEdit.SetToolTip(day8, toolTip);
			}
			if (day9 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Health Day";
				firstCalendarEdit.SetToolTip(day9, toolTip);
			}
			if (day10 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Earth Day";
				firstCalendarEdit.SetToolTip(day10, toolTip);
			}
			if (day11 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Workers� Day";
				firstCalendarEdit.SetToolTip(day11, toolTip);
			}
			if (day12 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Anti-tobacco Day";
				firstCalendarEdit.SetToolTip(day12, toolTip);
			}
			if (day13 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Environment Day";
				firstCalendarEdit.SetToolTip(day13, toolTip);
			}
			if (day14 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Blood Donor Day";
				firstCalendarEdit.SetToolTip(day14, toolTip);
			}
			if (day15 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "International day of yoga";
				firstCalendarEdit.SetToolTip(day15, toolTip);
			}
			if (day16 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Doctor�s Day";
				firstCalendarEdit.SetToolTip(day16, toolTip);
			}
			if (day17 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Hiroshima Day";
				firstCalendarEdit.SetToolTip(day17, toolTip);
			}
			if (day18 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Photography Day";
				firstCalendarEdit.SetToolTip(day18, toolTip);
			}
			if (day19 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "National Sports Day";
				firstCalendarEdit.SetToolTip(day19, toolTip);
			}
			if (day20 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Engineer's Day";
				firstCalendarEdit.SetToolTip(day20, toolTip);
			}
			if (day21 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Ozone Day";
				firstCalendarEdit.SetToolTip(day21, toolTip);
			}
			if (day22 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Tourism Day";
				firstCalendarEdit.SetToolTip(day22, toolTip);
			}
			if (day23 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Post Office Day";
				firstCalendarEdit.SetToolTip(day23, toolTip);
			}
			if (day24 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Food Day";
				firstCalendarEdit.SetToolTip(day24, toolTip);
			}
			if (day25 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Tsunami Day";
				firstCalendarEdit.SetToolTip(day25, toolTip);
			}
			if (day26 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Children�s Day";
				firstCalendarEdit.SetToolTip(day26, toolTip);
			}
			if (day27 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World AIDS Day";
				firstCalendarEdit.SetToolTip(day27, toolTip);
			}
			if (day28 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "National Mathematics Day";
				firstCalendarEdit.SetToolTip(day28, toolTip);
			}
			if (day29 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Christmas";
				firstCalendarEdit.SetToolTip(day29, toolTip);
			}
		}

		/// <summary>
		/// Initialization while creating object
		/// </summary>   

		public void InitializeLog()
        {           
            //Setting the Culture for the CalendarEdit control
            firstCalendarEdit.Culture = new CultureInfo(Thread.CurrentThread.CurrentCulture.LCID);
            //Subscribe DateStyles property Changed event
            firstCalendarEdit.DateStylesChanged +=new PropertyChangedCallback(firstCalendarEdit_DateStylesChanged);
           //Subscribe DayCellsStyle property Changed event
             firstCalendarEdit.DayCellsStyleChanged +=new PropertyChangedCallback(firstCalendarEdit_DayCellsStyleChanged);
            //Subscribe DayNameCellsStyle property Changed event
             firstCalendarEdit.DayNameCellsStyleChanged +=new PropertyChangedCallback(firstCalendarEdit_DayNameCellsStyleChanged);
             //Subscribe ColorChanged property Changed event for the Color Edit control
            colorEditor.ColorChanged += new PropertyChangedCallback(colorEditor_ColorChanged);
            //Subscribe Value property Changed event for the Slider Control
            slider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(slider_ValueChanged);
        }

        private void AddLog(string eventlog)
        {
            
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Slider Value changing event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
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
        /// 
        public void dcBackRadio(object sender, RoutedEventArgs e)
        {
            dcBackgroundBackup = new SolidColorBrush(colorEditor.Color);
        }

        /// <summary>
        /// In this method we set the Daycell BorderBrush
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public void dcBorRadio(object sender, RoutedEventArgs e)
        {
            dcBorderBackup = new SolidColorBrush(colorEditor.Color);
        }

        /// <summary>
        /// in this method we set the DayNameCell BorderBrush.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public void dncBorRadio(object sender, RoutedEventArgs e)
        {
            dncBorderBackup = new SolidColorBrush(colorEditor.Color);
        }

        /// <summary>
        /// In this method we set the DayNameCell Background.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public void dncBackRadio(object sender, RoutedEventArgs e)
        {
            dncBackgroundBackup = new SolidColorBrush(colorEditor.Color);
        }

        /// <summary>
        /// In this method we set the DayNameCell Border Thickness.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

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
        /// 
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
        /// 
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
        /// 

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
        /// 
        
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
            firstCalendarEdit.DayCellsStyle = s;
        }
        /// <summary>
        /// In this method we change the DayNameCell styles are changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        

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
            firstCalendarEdit.DayNameCellsStyle = s1;
        }

        /// <summary>
        /// In this method we set the various appearance
        /// related properties to CalendarEdit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        

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
    
        #region Events

        /// <summary>
        /// DayNameCellStyle changing event.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        
        void firstCalendarEdit_DayNameCellsStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddLog("DayNameCellStyleChanged");             
        }

        /// <summary>
        /// DateCellStyle changing event.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>

        void firstCalendarEdit_DayCellsStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {            
                AddLog("DayCellStyleChanged");                          
        }

        /// <summary>
        /// DateStyle Changing event.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>


        void firstCalendarEdit_DateStylesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddLog("DateStyleChanged");                       
        }
        
#endregion      
}    

}

