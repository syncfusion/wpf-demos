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
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media;
using Syncfusion.Windows.Chart;
using System.Windows.Data;
using System.Globalization;

namespace SimpleExponentialAverage
{
    public class TechnicalIndicatorData
    {
        public DateTime TimeStamp
        {
            get;
            set;
        }
        public double High
        {
            get;
            set;
        }
        public double Low
        {
            get;
            set;
        }
        public double Last
        {
            get;
            set;
        }
        public double Open
        {
            get;
            set;
        }
        public double Volume
        {
            get;
            set;
        }
    }
    
    public class DataCollection : ObservableCollection<TechnicalIndicatorData>
    {
        private const int pricesCount = 100;
        public List<TechnicalIndicatorData> datalist = new List<TechnicalIndicatorData>();
        public DataCollection()
        {
            datalist = this.GetPricesFromCSVFile("..\\..\\Data\\msft.csv", pricesCount);        
        }

        public List<TechnicalIndicatorData> GetPricesFromCSVFile(string fileName, int count)
        {
            char[] comma = new char[] { ',' };
            char[] slashN = new char[] { '\n' };
            List<TechnicalIndicatorData> list = new List<TechnicalIndicatorData>();
            string s = File.ReadAllText(fileName);
            string[] lines = s.Split(slashN);
            bool firstLine = true;
            string[] values;
            //int count = lines.Count() - 2;            
            TechnicalIndicatorData priceInfo;
            int index = 0;
            foreach (string line in lines)
            {
                if (count != -1 && index >= count)
                    break;                
                if (!firstLine)
                {
                    values = line.Split(comma);
                    if (values.GetLength(0) > 5)
                    {
                        priceInfo = new TechnicalIndicatorData()
                        {
                            TimeStamp = DateTime.Parse(values[0], CultureInfo.InvariantCulture),
                            Open = double.Parse(values[1]),
                            High = double.Parse(values[2]),
                            Low = double.Parse(values[3]),
                            Last = double.Parse(values[4]),
                            Volume = double.Parse(values[5])
                        };
                        list.Insert(index, priceInfo);
                        index++;
                    }
                }
                else
                {
                    firstLine = false;
                }
            }
            return list;
        }
    }
    
    /// <summary>
    /// Encapsulates the properties needed to define a particular graph displayed on the chart.
    /// </summary>
    [Serializable]
    public class ChartLayer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ChartLayer()
        {
            YAxisFormat = "F2";
            LayerIndicatorName = "";
            ParmString = "";
        }

        /// <summary>
        /// A field holding the string with the character used to delimit the <see cref="ParmString"/> values.
        /// The default value is comma (,).
        /// </summary>
        public static string ListSeparator = ",";

        /// <summary>
        /// Parses the delimited ParmString into an object array.
        /// </summary>
        /// <returns>The parm array</returns>
        public object[] ParmStringToParms()
        {
            object[] parms = null;
            if (ParmString != null && ParmString.Length > 0)
            {
                string[] a = ParmString.Split(new char[] { ListSeparator[0] });
                parms = new object[a.GetLength(0)];
                int k = 0;
                foreach (string val in a)
                {
                    object o = "";
                    int i;
                    double d;
                    bool b;
                    if (int.TryParse(val, out i))
                    {
                        o = i;
                    }
                    else if (double.TryParse(val, out d))
                    {
                        o = d;
                    }
                    else if (bool.TryParse(val, out b))
                    {
                        o = b;
                    }
                    parms[k] = o;
                    k++;
                }
            }

            return parms;
        }

        /// <summary>
        /// Sets the ParmString property to be a delimited string
        /// reflecting the contents of the object array.
        /// </summary>
        /// <param name="parms"></param>
        public void ParmsToParmString(object[] parms)
        {
            string s = "";
            if (parms != null)
            {
                foreach (object o in parms)
                {
                    if (s.Length > 0)
                    {
                        s += ListSeparator;
                    }
                    if (o != null)
                        s += o.ToString();
                }
            }
            ParmString = s;
        }

        private double strokeThickness = 1d;
        /// <summary>
        /// Gets or sets the thickness of the pen that draws this layer.
        /// </summary>
        public double StrokeThickness
        {
            get
            {
                return strokeThickness;
            }
            set
            {
                strokeThickness = value;
            }
        }

        private Color strokeColor = Colors.Black;
        /// <summary>
        /// Gets or sets the Color of the solid brush that drawa this layer.
        /// </summary>
        public Color StrokeColor
        {
            get
            {
                return strokeColor;
            }
            set
            {
                strokeColor = value;
            }
        }

        /// <summary>
        /// Gets of sets the format for the Y axis labels for the graph represented by this ChartLayer object.
        /// </summary>
        public string YAxisFormat { get; set; }

        /// <summary>
        /// Gets or sets the primary indicator name that is being displayed in this layer.
        /// </summary>       
        public string LayerIndicatorName { get; set; }

        /// <summary>
        /// A delimited string holding the the parameter values for this indicator.
        /// </summary>
        public string ParmString { get; set; }

        /// <summary>
        /// Gets or sets the Visibility state of a displayed note for this chart layer.
        /// </summary>
        /// <remarks>
        /// The content of the displayed note is set via the <see cref="Note"/> property.
        /// </remarks>
        public NoteVisibilityState NoteVisibility { get; set; }

        private string note = null;
        /// <summary>
        /// Gets or sets the string contents of a displayed note for this chart layer.
        /// </summary>
        /// <remarks>
        /// You control the visibility of this note on the chart by setting the <see cref="NoteVisibility"/>
        /// property. The default content for this note is the LayerIndicatorName plus the ParmString.
        /// </remarks>
        public string Note
        {
            get
            {
                if (note == null)
                {
                    note = LayerIndicatorName + " " + ParmString;
                }
                return note;
            }
            set
            {
                note = value;
            }
        }
    }

    #region NoteVisibilityState

    /// <summary>
    /// Specifies the visibility state of ChartLayer Notes.
    /// </summary>
    public enum NoteVisibilityState
    {
        /// <summary>
        /// Indicates the state is set from the TAHostControl.NoteVisibility setting.
        /// </summary>
        Default,
        /// <summary>
        /// Indicates the note is not seen.
        /// </summary>
        Hidden,
        /// <summary>
        /// Indicates a triangular glyph is displayed which opens int a tooltip when moused over.
        /// </summary>
        Collapsed,
        /// <summary>
        /// Indicates the note is always visible.
        /// </summary>
        Opened
    }
    #endregion

    #region IValueConverters

    #region DateAxisFontsizeConverter
    /// <summary>
    /// Used to control the Fontsize on the date axis labels.
    /// </summary>
    public class DateAxisFontsizeConverter : IValueConverter
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DateAxisFontsizeConverter()
        {
            Fontsize = 12d; //default size
        }

        /// <summary>
        /// Gets or sets the desired Fontsize.
        /// </summary>
        public double Fontsize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Fontsize;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region DateAxisConverter
    /// <summary>
    /// Used to provide text for date axis labels through various format strings.
    /// </summary>
    public class DateAxisConverter : IValueConverter
    {
        /// <summary>
        /// Gets or sets the PriceInfo collection.
        /// </summary>
        public List<TechnicalIndicatorData> Prices { get; set; }

        private bool isFixedRange = false;

        public bool IsFixedRange
        {
            get { return isFixedRange; }
            set { isFixedRange = value; }
        }

        private int startIndex = 0;

        public int StartIndex
        {
            get { return startIndex; }
            set { startIndex = value; }
        }

        DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        /// <summary>
        /// Gets or sets the format string for the normal label display.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the format string used for labels that mark a major time change (days for intraday data and years for daily data).
        /// </summary>
        public string MajorFormat { get; set; }

        /// <summary>
        /// Gets or sets the Fontsize for the displayed font.
        /// </summary>
        public double Fontsize { get; set; }

        bool isIntraDayData = true;
        /// <summary>
        /// Gets or sets whether the MajorFormat is applied for day changes (intraday data). If false, the data is assumed to be daily.
        /// The default value is true.
        /// </summary>
        public bool IsIntraDayData
        {
            get { return isIntraDayData; }
            set { isIntraDayData = value; }
        }


        DateTime lastMajorDate = DateTime.MinValue;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            {
                int index;

                if (value != null && (int.TryParse(value.ToString(), out index)))
                {
                    //   Console.Write("{0}  {1}   ", startIndex, index);

                    index -= this.startIndex;
                    //   Console.WriteLine("  {0}   ", index);
                    if (Prices == null || index < 0 || index >= Prices.Count)
                        return null;
                    if (index >= 0 && index < Prices.Count)
                    {
                        if (MajorFormat != null && MajorFormat.Length > 0 && (index == 0 ||
                            ((IsIntraDayData && Prices[index].TimeStamp.Date != lastMajorDate)
                             || (!IsIntraDayData && Prices[index].TimeStamp.Year != lastMajorDate.Year))))
                        {
                            lastMajorDate = Prices[index].TimeStamp.Date;
                            //  Console.WriteLine("X  " + Prices[index].TimeStamp.ToString(MajorFormat));
                            return Prices[index].TimeStamp.ToString(MajorFormat);
                        }
                        // Console.WriteLine("  " + Prices[index].TimeStamp.ToString(Format));
                        return Prices[index].TimeStamp.ToString(Format);
                    }
                }
                return value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
    #endregion

    #region YAxisConverter
    /// <summary>
    /// Used to provide the label values for the vertical axis. (Needed to allow control of Fontsize.)
    /// </summary>
    public class YAxisConverter : IValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region YAxisWidthConverter
    /// <summary>
    /// Used to control the common width of the YAxis on all the stacked charts (so XAxis real estate matches among all charts.)
    /// </summary>
    public class YAxisWidthConverter : IValueConverter
    {
        private double widthAxisWidth = 50d;
        /// <summary>
        /// Gets or sets the common YAxis width.
        /// </summary>
        public double WidthAxisWidth
        {
            get
            {
                return widthAxisWidth;
            }

            set
            {
                widthAxisWidth = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return WidthAxisWidth;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion    

    #endregion

    public class DateSorter : IComparer<TechnicalIndicatorData>
    {
        #region IComparer<TechnicalIndicatorData> Members

        public int Compare(TechnicalIndicatorData x, TechnicalIndicatorData y)
        {
            if (x == null && y == null)
                return 0;
            else if (x == null)
                return -1;
            else if (y == null)
                return 1;
            else
                return x.TimeStamp.CompareTo(y.TimeStamp);
        }

        #endregion
    }

}
