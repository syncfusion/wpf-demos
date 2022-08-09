#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.Windows.Controls.Gantt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace syncfusion.ganttdemos.wpf
{
     public class ExportToImageBehavior : Behavior<ExportToImage>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.ExportBtn.Click += ExportBtn_Click;
        }

        /// <summary>
        /// Handles the Click event of the ExportBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void ExportBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RenderTargetBitmap bmp;
            BitmapEncoder bitmapEncoder;
            int width;

            GanttControl Gantt = this.AssociatedObject.TabControl.SelectedContent as GanttControl;

            //Extract the GanttChart region from GanttControl.
            ScrollViewer chart = Gantt.FindName<ScrollViewer>("PART_ScheduleViewScrollViewer");

            ComboBoxItem item = AssociatedObject.ExpOption.SelectedValue as ComboBoxItem;
            if (item.Content.ToString() == "Full Region")
            {
                //Measure the total size of the Gantt Rendered. 
                Gantt.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                Gantt.Arrange(new Rect(new Size(Gantt.DesiredSize.Width, Gantt.DesiredSize.Height)));
                bmp = new RenderTargetBitmap(
                   (int)Gantt.DesiredSize.Width, (int)Gantt.DesiredSize.Height, 96, 96, PixelFormats.Default);
            }
            else
            {
                bmp = new RenderTargetBitmap(
                  (int)Gantt.ActualWidth, (int)Gantt.ActualHeight, 96, 96, PixelFormats.Default);
            }

            //Rendering the Chart region of the GanttControl to BitMap
            bmp.Render(chart);

            //Getting the size of GanttGrid
            width = (int)(Gantt.DesiredSize.Width - chart.ActualWidth);

            //The bitmap will contain the empty space of GanttGrid. To remove that we Cropping the GanttGrid space from image using CroppedBitmap
            CroppedBitmap crpBmp = new CroppedBitmap(bmp, new Int32Rect(width, 0, (int)chart.ActualWidth, (int)chart.ActualHeight));


            bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(crpBmp));

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = "Untitled";
            saveFileDialog.DefaultExt = "png";
            saveFileDialog.Filter = "PNG Files (*.png)|*.png|Jpeg Files (*.jpg)|*.jpg|Bitmap Files (*.bmp)|*.bmp|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == true)
            {
                using (Stream stream = saveFileDialog.OpenFile())
                {
                    bitmapEncoder.Save(stream);
                    stream.Close();
                    // Commented this line as facing issue in core project while open the saved image
                    //System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.ExportBtn.Click -= ExportBtn_Click;
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
    }
}
