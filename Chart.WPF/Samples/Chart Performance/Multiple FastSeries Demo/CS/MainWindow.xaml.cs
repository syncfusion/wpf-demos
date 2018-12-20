#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Xml;
using System.Windows;
using Syncfusion.Windows.Chart;
using Syncfusion.Windows.SampleLayout;
using System.Diagnostics;

namespace MultipleFastSeriesDemo
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : SampleLayoutWindow
  {
    DateTime Start, end;
    XmlDocument doc;
    Stopwatch sw = new Stopwatch();

    public MainWindow()
    {
      InitializeComponent();
      Area1.LayoutUpdated += new EventHandler(Area1_LayoutUpdated);
  
      doc = new XmlDocument();
      doc.Load("..\\..\\XML\\Minimum.xml"); // Test file in local directory
    }

    void Area1_LayoutUpdated(object sender, EventArgs e)
    {
        text1.Text=sw.ElapsedMilliseconds.ToString()+" ms";
        sw.Stop();
    }

    // Button Click event
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        sw.Start();
      Area1.BeginInit();
      Start = DateTime.Now;

      // Get the Waveform node for the selected Group
      XmlNode xSelectedWafveforms = doc.SelectSingleNode(".//Points");

      
      int count = 1;

      Area1.BeginInit();
      foreach (XmlNode xnWaveform in xSelectedWafveforms.ChildNodes)
      {
          ChartSeries Series0 = new ChartSeries(ChartTypes.FastLine);
          Series0.Label = "Series " + count;
          Series0.BindingPathX = "X";
          Series0.BindingPathsY = new[] { "Y" };
          Series0.IsSortData = false;
          Series0.IsIndexed = false;
          Series0.EnableEffects = false;
          Series0.UseOptimization = true;
          Series0.Resolution = 10;
        Series0.DataSource = xnWaveform.SelectSingleNode("Point");
        chart1.Areas[0].Series.Add(Series0);
        count++;
      }
      
      Area1.EndInit();
      
      end=DateTime.Now;

      text2.Visibility = System.Windows.Visibility.Visible;
    //  MessageBox.Show(end.Subtract(Start).Seconds.ToString()+" "+count.ToString());
    }

    private void win_LayoutUpdated(object sender, EventArgs e)
    {
        
    }
  }
}
