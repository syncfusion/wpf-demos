#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapgriddemos.wpf
{
    using System;
    using System.Collections.Generic;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using System.Windows.Media;
    using System.Reflection;
    using System.Windows;
    using Microsoft.Win32;
    using System.Windows.Media.Imaging;
    using System.Windows.Controls;
    using Syncfusion.Windows.Shared;
    using System.Linq;

    /// <summary>
    /// Interaction logic for OlapGrid view.
    /// </summary>
    public class AppearanceViewModel : NotificationObject, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        private DelegateCommand<object> browseButtonCmd;
        private DelegateCommand<object> expanderVisibilityCommand;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AppearanceViewModel"/> class.
        /// </summary>
        public AppearanceViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = KPIModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = KPIModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.SetCurrentReport(OlapReport());
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the grid data manager.
        /// </summary>
        /// <value>The grid data manager.</value>
        public OlapDataManager GridDataManager
        {
            get { return olapDataManager; }
            set { olapDataManager = value; }
        }

        /// <summary>
        /// Gets the color list.
        /// </summary>
        /// <value>The color list.</value>
        public List<string> ColorList
        {
            get { return GetColors(); }
        }

        /// <summary>
        /// Gets the value cell alignments.
        /// </summary>
        /// <value>The value cell alignments.</value>
        public IEnumerable<string> ValueCellAlignments
        {
            get
            {
                return Enum<HorizontalAlignment>.GetNames();
            }
        }

        /// <summary>
        /// Gets the font weight list.
        /// </summary>
        /// <value>The font weight list.</value>
        public FontWeight[] FontWeightList
        {
            get
            {
                return new[] { FontWeights.Regular, FontWeights.Bold };
            }
        }

        /// <summary>
        /// Gets the font list.
        /// </summary>
        /// <value>The font list.</value>
        public ICollection<FontFamily> FontList
        {
            get
            {
                return Fonts.SystemFontFamilies;
            }
        }

        /// <summary>
        /// Gets or sets the browse command.
        /// </summary>
        /// <value>The browse command.</value>
        public DelegateCommand<object> BrowseCommand
        {
            get
            {
                browseButtonCmd = browseButtonCmd ?? new DelegateCommand<object>(this.BrowseImage);
                return browseButtonCmd;
            }
            set
            {
                browseButtonCmd = value;
            }
        }

        /// <summary>
        /// Gets or sets the expander visibility command.
        /// </summary>
        /// <value>The expander visibility command.</value>
        public DelegateCommand<object> ExpanderVisibilityCommand
        {
            get
            {
                expanderVisibilityCommand = expanderVisibilityCommand ?? new DelegateCommand<object>(ToggleExpanderVisibility);
                return expanderVisibilityCommand;
            }
            set { expanderVisibilityCommand = value; }
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets the colors.
        /// </summary>
        /// <returns></returns>
        internal List<string> GetColors()
        {
            List<string> colorList = new List<string>();
            Type brush = typeof(Brushes);
            foreach (MemberInfo info in brush.GetMembers())
            {
                if (info is PropertyInfo)
                {
                    PropertyInfo pi = info as PropertyInfo;
                    colorList.Add(pi.Name);
                }
            }
            return colorList;
        }

        /// <summary>
        /// Toggles the expander visibility.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void ToggleExpanderVisibility(object parameter)
        {
            if (parameter is bool && this.GridDataManager != null && this.GridDataManager.CurrentReport != null)
            {
                this.GridDataManager.CurrentReport.ShowExpanders = (bool)parameter;
                this.GridDataManager.NotifyElementModified();
            }
        }

        /// <summary>
        /// Browses the image.
        /// </summary>
        /// <param name="parm">The parm.</param>
        private void BrowseImage(object parm)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "BackGround files (*.jpg)|*.jpg|(*.png)|*.png|(*.gif)|*.gif";
            if (ofd.ShowDialog() == true)
            {
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = new BitmapImage(new Uri(ofd.FileName, UriKind.RelativeOrAbsolute));
                ((Button)parm).Tag = myBrush;
            }
        }

        /// <summary>
        /// Creates the OlapReport.
        /// </summary>
        /// <returns></returns>
        private OlapReport OlapReport()
        {
            OlapReport olapReport1 = new OlapReport();
            olapReport1.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Name for the Dimension Element
            dimensionElementColumn.Name = "Customer";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            MeasureElements measureElementColumn = new MeasureElements();
            //Specifying the Name for the Measure Element
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Product";
            dimensionElementRow.AddLevel("Product Categories", "Category");
            DimensionElement dimensionElementRow1 = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow1.Name = "Date";
            dimensionElementRow1.AddLevel("Fiscal", "Fiscal Year");
            //Adding Column Members
            olapReport1.CategoricalElements.Add(dimensionElementColumn);
            //Adding Measure Element
            olapReport1.CategoricalElements.Add(measureElementColumn);
            //Adding Row Members
            olapReport1.SeriesElements.Add(dimensionElementRow);
            olapReport1.SeriesElements.Add(dimensionElementRow1);

            return olapReport1;
        }

        private void Dispose(bool disposing)
        {
            if (disposing && olapDataManager != null)
                olapDataManager.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// Generic enumeration class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Enum<T>
    {
        /// <summary>
        /// Gets the names.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetNames()
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("Type '" + type.Name + "' is not an enum");

            return
              (from field in
                   type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
               where field.IsLiteral
               select field.Name).ToList();
        }
    }
}
