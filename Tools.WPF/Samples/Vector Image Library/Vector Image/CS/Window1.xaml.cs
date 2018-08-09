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
using System.Windows.Media.Animation;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Tools;
using Syncfusion.Windows.Shared;

namespace VectorImage
{

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        #region PrivateMembers

        /// <summary>
        /// Private Members
        /// </summary>

        int previndex, nextindex, index;
        double rectheight, rectwidth;
        GalleryGroup gallerygroup;

        string finance_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/Finance.xaml";
        string banking_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/Banking.xaml";
        string medical_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/Medical.xaml";
        string outlook_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/Outlook2007Icons.xaml";
        string computer_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/Computer.xaml";
        string education_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/Education.xaml";
        string ecommerce_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/E-Commerce.xaml";

        string Flags_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/Flags.xaml";
        string Food_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/Food.xaml";
        string Multimedia_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/Multimedia.xaml";
        string Weather_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/Weather.xaml";
        string Construction_Key = @"/Syncfusion.VectorImages.WPF;component/Icons/Construction.xaml";





        ResourceDictionary financedictionary = new ResourceDictionary();
        ResourceDictionary bankingdictionary = new ResourceDictionary();
        ResourceDictionary medicaldictionary = new ResourceDictionary();
        ResourceDictionary outlookdictionary = new ResourceDictionary();
        ResourceDictionary computerdictionary = new ResourceDictionary();
        ResourceDictionary educationdictionary = new ResourceDictionary();
        ResourceDictionary ecommercedictionary = new ResourceDictionary();


        ResourceDictionary flagsdictionary = new ResourceDictionary();
        ResourceDictionary fooddictionary = new ResourceDictionary();
        ResourceDictionary multimediadictionary = new ResourceDictionary();
        ResourceDictionary weatherdictionary = new ResourceDictionary();
        ResourceDictionary constructiondictionary = new ResourceDictionary();

        string gallerytype;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for window1.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            InitializeLog();
            EventLog();
        }

        /// <summary>
        /// Initializes the log.
        /// </summary>

        public void InitializeLog()
        {
            previndex = nextindex = index = 0;
            financedictionary.Source = new Uri(finance_Key, UriKind.RelativeOrAbsolute);
            bankingdictionary.Source = new Uri(banking_Key, UriKind.RelativeOrAbsolute);
            medicaldictionary.Source = new Uri(medical_Key, UriKind.RelativeOrAbsolute);
            outlookdictionary.Source = new Uri(outlook_Key, UriKind.RelativeOrAbsolute);
            computerdictionary.Source = new Uri(computer_Key, UriKind.RelativeOrAbsolute);
            educationdictionary.Source = new Uri(education_Key, UriKind.RelativeOrAbsolute);
            ecommercedictionary.Source = new Uri(ecommerce_Key, UriKind.RelativeOrAbsolute);
            
            flagsdictionary.Source = new Uri(Flags_Key, UriKind.RelativeOrAbsolute);
            fooddictionary.Source = new Uri(Food_Key, UriKind.RelativeOrAbsolute);
            multimediadictionary.Source = new Uri(Multimedia_Key, UriKind.RelativeOrAbsolute);
            weatherdictionary.Source = new Uri(Weather_Key, UriKind.RelativeOrAbsolute);
            constructiondictionary.Source = new Uri(Construction_Key, UriKind.RelativeOrAbsolute);

        }

        /// <summary>
        /// Events the log.
        /// </summary>

        public void EventLog()
        {
            // Subscribe the Loaded event raised
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
        }

        #endregion

        #region Events

        /// <summary>
        /// Handles the Loaded event of the Window1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            LoadImages(financedictionary, Finance);
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Loads the images.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="ggroup">The ggroup.</param>
        private void LoadImages(ResourceDictionary resource, GalleryGroup ggroup)
        {
            ggroup.Items.Clear();

            foreach (string key in resource.Keys)
            {

                if (key.ToString() != "DeliveryReceipt/ReadReceipt")
                {
                    GalleryItem galleryitem = new GalleryItem();
                    galleryitem.Caption = key;
                    galleryitem.Description = "";
                    Image img = new Image();
                    img.Margin = new Thickness(5);
                    img.Source = (DrawingImage)resource[key];
                    galleryitem.Content = img;
                    galleryitem.Name = key;
                    galleryitem.ToolTip = key;
                    ggroup.Items.Add(galleryitem);
                }
            }
        }


        /// <summary>
        /// Handles the MouseDoubleClick event of the galgrpPhotos control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private void galgrpPhotos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationLeft.IsEnabled = true;
            NavigationRight.IsEnabled = true;
            mycanvas.Visibility = Visibility.Visible;
            checkEnableMagnifier.IsChecked = false;
            GalleryGroup ga = sender as GalleryGroup;
            GalleryItem gi = (GalleryItem)ga.SelectionStartItem;
            gallerygroup = ga;
            index = ga.SelectionStartIndex;
            mycanvas.Width = window1.ActualWidth - 170;
            mycanvas.Height = window1.ActualHeight - 200;
            canvas_border.Width = mycanvas.Width + 10;
            canvas_border.Height = mycanvas.Height + 10;

            RectangleImage.Width = mycanvas.Width - 330;
            RectangleImage.Height = mycanvas.Height - 120;

            RectangleImage.Source = this.Resources[gi.Name.ToString()] as ImageSource;
            if (gi.Name.ToString() == "TranscationFee")
                canvastxt.Text = "TransactionFee";
            else
                canvastxt.Text = gi.Name.ToString();
            canvasclose.Visibility = Visibility.Visible;
            rectheight = RectangleImage.Height;
            rectwidth = RectangleImage.Width;

            sliderimageSize.Maximum = rectheight;

            sliderimageSize.Value = 185;
            RectangleImage.Height = sliderimageSize.Value;
            RectangleImage.Width = sliderimageSize.Value;
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mycanvas.Visibility = Visibility.Collapsed;
            canvasclose.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// Handles the SelectionChanged event of the cmb_GalleryType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cmb_GalleryType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmb_GalleryType.SelectedItem != null)
            {
                gallerytype = cmb_GalleryType.SelectedItem.ToString();
                gallerytype = gallerytype.Substring(gallerytype.IndexOf(": ") + 2);
                // Load Finance Icons 
                if (gallerytype.ToString().Equals("Finance"))
                {
                    Finance.Visibility = Visibility.Visible;
                    Banking.Visibility = Visibility.Collapsed;
                    Medical.Visibility = Visibility.Collapsed;
                    Outlook.Visibility = Visibility.Collapsed;
                    Computer.Visibility = Visibility.Collapsed;
                    ECommerce.Visibility = Visibility.Collapsed;
                    Education.Visibility = Visibility.Collapsed;
                    
                    Food.Visibility = Visibility.Collapsed;
                    Flag.Visibility = Visibility.Collapsed;
                    MultiMedia.Visibility = Visibility.Collapsed;
                    Construction.Visibility = Visibility.Collapsed;
                    Weather.Visibility = Visibility.Collapsed;

                    

                    if (description != null)
                        description.Text = "Displays Finance-based images. Double-click the icons to view the larger image.";
                    LoadImages(financedictionary, Finance);
                }
                // Load Banking Icons 
                else if (gallerytype.ToString().Equals("Banking"))
                {
                    Finance.Visibility = Visibility.Collapsed;
                    Banking.Visibility = Visibility.Visible;
                    Medical.Visibility = Visibility.Collapsed;
                    Outlook.Visibility = Visibility.Collapsed;
                    Computer.Visibility = Visibility.Collapsed;
                    ECommerce.Visibility = Visibility.Collapsed;
                    Education.Visibility = Visibility.Collapsed;
                    Food.Visibility = Visibility.Collapsed;
                    Flag.Visibility = Visibility.Collapsed;
                    MultiMedia.Visibility = Visibility.Collapsed;
                    Construction.Visibility = Visibility.Collapsed;
                    Weather.Visibility = Visibility.Collapsed;

                    if (description != null)
                        description.Text = "Displays Banking-based images. Double-click the icons to view the larger image.";
                    LoadImages(bankingdictionary, Banking);
                }
                // Load Medical Icons 
                else if (gallerytype.Equals("Medical"))
                {
                    Finance.Visibility = Visibility.Collapsed;
                    Banking.Visibility = Visibility.Collapsed;
                    Medical.Visibility = Visibility.Visible;
                    Outlook.Visibility = Visibility.Collapsed;
                    Computer.Visibility = Visibility.Collapsed;
                    ECommerce.Visibility = Visibility.Collapsed;
                    Education.Visibility = Visibility.Collapsed;
                    Food.Visibility = Visibility.Collapsed;
                    Flag.Visibility = Visibility.Collapsed;
                    MultiMedia.Visibility = Visibility.Collapsed;
                    Construction.Visibility = Visibility.Collapsed;
                    Weather.Visibility = Visibility.Collapsed;


                    if (description != null)
                        description.Text = "Displays Medical-based images.Double-click the icons to view the larger image.";
                    LoadImages(medicaldictionary, Medical);
                }

                // Load Outlook2007 Icons 

                else if (gallerytype.Equals("Outlook2007"))
                {
                    Finance.Visibility = Visibility.Collapsed;
                    Banking.Visibility = Visibility.Collapsed;
                    Outlook.Visibility = Visibility.Visible;
                    Medical.Visibility = Visibility.Collapsed;
                    Computer.Visibility = Visibility.Collapsed;
                    ECommerce.Visibility = Visibility.Collapsed;
                    Education.Visibility = Visibility.Collapsed;
                    Food.Visibility = Visibility.Collapsed;
                    Flag.Visibility = Visibility.Collapsed;
                    MultiMedia.Visibility = Visibility.Collapsed;
                    Construction.Visibility = Visibility.Collapsed;
                    Weather.Visibility = Visibility.Collapsed;


                    if (description != null)
                        description.Text = "Displays Outlook2007-based images. Double-click the icons to view the image in larger size.";
                    LoadImages(outlookdictionary, Outlook);
                }
                // Load Computer Icons 
                else if (gallerytype.Equals("Computer"))
                {
                    Finance.Visibility = Visibility.Collapsed;
                    Banking.Visibility = Visibility.Collapsed;
                    Medical.Visibility = Visibility.Collapsed;
                    Outlook.Visibility = Visibility.Collapsed;
                    Computer.Visibility = Visibility.Visible;
                    ECommerce.Visibility = Visibility.Collapsed;
                    Education.Visibility = Visibility.Collapsed;
                    Food.Visibility = Visibility.Collapsed;
                    Flag.Visibility = Visibility.Collapsed;
                    MultiMedia.Visibility = Visibility.Collapsed;
                    Construction.Visibility = Visibility.Collapsed;
                    Weather.Visibility = Visibility.Collapsed;

                    if (description != null)
                        description.Text = "Displays Computer-based images. Double-click the icons to view the image in larger size.";
                    LoadImages(computerdictionary, Computer);
                }
                // Load Education Icons 
                else if (gallerytype.Equals("Education"))
                {
                    Finance.Visibility = Visibility.Collapsed;
                    Banking.Visibility = Visibility.Collapsed;
                    Medical.Visibility = Visibility.Collapsed;
                    Outlook.Visibility = Visibility.Collapsed;
                    Computer.Visibility = Visibility.Collapsed;
                    ECommerce.Visibility = Visibility.Collapsed;
                    Education.Visibility = Visibility.Visible;
                    Food.Visibility = Visibility.Collapsed;
                    Flag.Visibility = Visibility.Collapsed;
                    MultiMedia.Visibility = Visibility.Collapsed;
                    Construction.Visibility = Visibility.Collapsed;
                    Weather.Visibility = Visibility.Collapsed;

                    if (description != null)
                        description.Text = "Displays Education-based images. DoubleClick to view the image in larger size.";
                    LoadImages(educationdictionary, Education);
                }
                // Load E-commerce Icons 
                else if (gallerytype.Equals("ECommerce"))
                {
                    Finance.Visibility = Visibility.Collapsed;
                    Banking.Visibility = Visibility.Collapsed;
                    Medical.Visibility = Visibility.Collapsed;
                    Outlook.Visibility = Visibility.Collapsed;
                    Computer.Visibility = Visibility.Collapsed;
                    ECommerce.Visibility = Visibility.Visible;
                    Education.Visibility = Visibility.Collapsed;
                    Food.Visibility = Visibility.Collapsed;
                    Flag.Visibility = Visibility.Collapsed;
                    MultiMedia.Visibility = Visibility.Collapsed;
                    Construction.Visibility = Visibility.Collapsed;
                    Weather.Visibility = Visibility.Collapsed;
                    if (description != null)
                        description.Text = "Displays ECommerce-based images. DoubleClick to view the image in larger size.";
                    LoadImages(ecommercedictionary, ECommerce);
                }

                else if (gallerytype.Equals("Food"))
                {
                    Finance.Visibility = Visibility.Collapsed;
                    Banking.Visibility = Visibility.Collapsed;
                    Medical.Visibility = Visibility.Collapsed;
                    Outlook.Visibility = Visibility.Collapsed;
                    Computer.Visibility = Visibility.Collapsed;
                    ECommerce.Visibility = Visibility.Collapsed;
                    Education.Visibility = Visibility.Collapsed;
                    Food.Visibility = Visibility.Visible;
                    Flag.Visibility = Visibility.Collapsed;
                    MultiMedia.Visibility = Visibility.Collapsed;
                    Construction.Visibility = Visibility.Collapsed;
                    Weather.Visibility = Visibility.Collapsed;

                    if (description != null)
                        description.Text = "Displays Food-based images. DoubleClick to view the image in larger size.";
                    LoadImages(fooddictionary, Food);
                }

                else if (gallerytype.Equals("Flag"))
                {
                    Finance.Visibility = Visibility.Collapsed;
                    Banking.Visibility = Visibility.Collapsed;
                    Medical.Visibility = Visibility.Collapsed;
                    Outlook.Visibility = Visibility.Collapsed;
                    Computer.Visibility = Visibility.Collapsed;
                    ECommerce.Visibility = Visibility.Collapsed;
                    Education.Visibility = Visibility.Collapsed;
                    Food.Visibility = Visibility.Collapsed;
                    Flag.Visibility = Visibility.Visible;
                    MultiMedia.Visibility = Visibility.Collapsed;
                    Construction.Visibility = Visibility.Collapsed;
                    Weather.Visibility = Visibility.Collapsed;

                    if (description != null)
                        description.Text = "Displays Flag-based images. DoubleClick to view the image in larger size.";
                    LoadImages(flagsdictionary, Flag);
                }

                else if (gallerytype.Equals("MultiMedia"))
                {
                    Finance.Visibility = Visibility.Collapsed;
                    Banking.Visibility = Visibility.Collapsed;
                    Medical.Visibility = Visibility.Collapsed;
                    Outlook.Visibility = Visibility.Collapsed;
                    Computer.Visibility = Visibility.Collapsed;
                    ECommerce.Visibility = Visibility.Collapsed;
                    Education.Visibility = Visibility.Collapsed;
                    Food.Visibility = Visibility.Collapsed;
                    Flag.Visibility = Visibility.Collapsed;
                    MultiMedia.Visibility = Visibility.Visible;
                    Construction.Visibility = Visibility.Collapsed;
                    Weather.Visibility = Visibility.Collapsed;

                    if (description != null)
                        description.Text = "Displays MultiMedia images. DoubleClick to view the image in larger size.";
                    LoadImages(multimediadictionary, MultiMedia);
                }

                else if (gallerytype.Equals("Construction"))
                {
                    Finance.Visibility = Visibility.Collapsed;
                    Banking.Visibility = Visibility.Collapsed;
                    Medical.Visibility = Visibility.Collapsed;
                    Outlook.Visibility = Visibility.Collapsed;
                    Computer.Visibility = Visibility.Collapsed;
                    ECommerce.Visibility = Visibility.Collapsed;
                    Education.Visibility = Visibility.Collapsed;
                    Food.Visibility = Visibility.Collapsed;
                    Flag.Visibility = Visibility.Collapsed;
                    MultiMedia.Visibility = Visibility.Collapsed;
                    Construction.Visibility = Visibility.Visible;
                    Weather.Visibility = Visibility.Collapsed;

                    if (description != null)
                        description.Text = "Displays Construction images. DoubleClick to view the image in larger size.";
                    LoadImages(constructiondictionary, Construction);
                }

                else if (gallerytype.Equals("Weather"))
                {
                    Finance.Visibility = Visibility.Collapsed;
                    Banking.Visibility = Visibility.Collapsed;
                    Medical.Visibility = Visibility.Collapsed;
                    Outlook.Visibility = Visibility.Collapsed;
                    Computer.Visibility = Visibility.Collapsed;
                    ECommerce.Visibility = Visibility.Collapsed;
                    Education.Visibility = Visibility.Collapsed;
                    Food.Visibility = Visibility.Collapsed;
                    Flag.Visibility = Visibility.Collapsed;
                    MultiMedia.Visibility = Visibility.Collapsed;
                    Construction.Visibility = Visibility.Collapsed;
                    Weather.Visibility = Visibility.Visible;

                    if (description != null)
                        description.Text = "Displays Weather-based images. DoubleClick to view the image in larger size.";
                    LoadImages(weatherdictionary, Weather);
                }

                // Load All Icons 
                else
                {
                    Finance.Visibility = Visibility.Visible;
                    Banking.Visibility = Visibility.Visible;
                    Medical.Visibility = Visibility.Visible;
                    Outlook.Visibility = Visibility.Visible;
                    Computer.Visibility = Visibility.Visible;
                    ECommerce.Visibility = Visibility.Visible;
                    Education.Visibility = Visibility.Visible;

                    LoadImages(medicaldictionary, Medical);
                    LoadImages(outlookdictionary, Outlook);
                    LoadImages(computerdictionary, Computer);
                    LoadImages(bankingdictionary, Banking);
                    LoadImages(financedictionary, Finance);
                    LoadImages(educationdictionary, Education);
                    LoadImages(ecommercedictionary, ECommerce);
                    LoadImages(weatherdictionary, Weather);
                    LoadImages(constructiondictionary, Construction);
                    LoadImages(multimediadictionary, MultiMedia);
                    LoadImages(fooddictionary, Food);
                    LoadImages(flagsdictionary, Flag);



                    if (description != null)
                        description.Text = "Displays the All images. Double-click the icons to view the image in larger size.";

                }
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the window1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.SizeChangedEventArgs"/> instance containing the event data.</param>
        private void window1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            mycanvas.Width = window1.ActualWidth - 170;
            mycanvas.Height = window1.ActualHeight - 200;
            canvas_border.Width = mycanvas.Width + 10;
            canvas_border.Height = mycanvas.Height + 10;
            RectangleImage.Width = mycanvas.Width - 330;
            RectangleImage.Height = mycanvas.Height - 120;
            sliderimageSize.ToolTip = sliderimageSize.Value.ToString();
            RectangleImage.Width = rectwidth;
            RectangleImage.Height = rectheight;
            sliderimageSize.Maximum = rectheight;
            RectangleImage.Height = sliderimageSize.Value;
            RectangleImage.Width = sliderimageSize.Value;
        }

        /// <summary>
        /// Handles the MouseLeave event of the imageborder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/> instance containing the event data.</param>
        private void imageborder_MouseLeave(object sender, MouseEventArgs e)
        {
            magnifier1.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Handles the MouseMove event of the Finance control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/> instance containing the event data.</param>
        private void Finance_MouseMove(object sender, MouseEventArgs e)
        {
            GalleryGroup ga = sender as GalleryGroup;
            GalleryItem gi = (GalleryItem)ga.SelectionStartItem;
            gi.ToolTip = gi.Name.ToString();
        }


        /// <summary>
        /// Handles the Click event of the Previous control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            NavigationRight.IsEnabled = true;
            index = index - 1;
            if (index >= 0)
            {
                galleryitemdisplay(index);
            }
            else
            {
                index = 0;
                NavigationLeft.IsEnabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the Next control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NavigationLeft.IsEnabled = true;
            index = index + 1;
            if (index <= gallerygroup.Items.Count - 1)
            {
                galleryitemdisplay(index);
            }
            else
            {
                index = gallerygroup.Items.Count - 1;
                NavigationRight.IsEnabled = false;
            }
        }
        /// <summary>
        /// Galleryitemdisplays the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        public void galleryitemdisplay(int index)
        {
            mycanvas.Visibility = Visibility.Visible;

            if (gallerygroup != null)
            {
                GalleryItem gi = (GalleryItem)gallerygroup.Items[index];
                mycanvas.Width = window1.ActualWidth - 170;
                mycanvas.Height = window1.ActualHeight - 200;
                canvas_border.Width = mycanvas.Width + 10;
                canvas_border.Height = mycanvas.Height + 10;

                RectangleImage.Width = mycanvas.Width - 330;
                RectangleImage.Height = mycanvas.Height - 120;

                RectangleImage.Source = this.Resources[gi.Name.ToString()] as ImageSource;
                canvastxt.Text = gi.Name.ToString();
                canvasclose.Visibility = Visibility.Visible;

                RectangleImage.Height = sliderimageSize.Value;
                RectangleImage.Width = sliderimageSize.Value;

            }
            else
                mycanvas.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Handles the MouseMove event of the sliderTargetSize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/> instance containing the event data.</param>
        private void sliderTargetSize_MouseMove(object sender, MouseEventArgs e)
        {
            sliderTargetSize.ToolTip = sliderTargetSize.Value.ToString();
        }

        /// <summary>
        /// Handles the ValueChanged event of the sliderimageSize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        private void sliderimageSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                RectangleImage.Height = sliderimageSize.Value;
                RectangleImage.Width = sliderimageSize.Value;
                sliderimageSize.ToolTip = sliderimageSize.Value.ToString();

            }
            catch { }
        }

        /// <summary>
        /// Handles the MouseMove event of the sliderimageSize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/> instance containing the event data.</param>
        private void sliderimageSize_MouseMove(object sender, MouseEventArgs e)
        {
            sliderimageSize.ToolTip = sliderimageSize.Value.ToString();
        }

        /// <summary>
        /// Handles the 1 event of the sliderTargetSize_ValueChanged control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        private void sliderTargetSize_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (magnifier1 != null)
                magnifier1.ZoomFactor = sliderTargetSize.Value;
        }

        /// <summary>
        /// Handles the MouseMove event of the RectangleImage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/> instance containing the event data.</param>
        private void RectangleImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (checkEnableMagnifier.IsChecked == true)
                magnifier1.Visibility = Visibility.Visible;
            else
                magnifier1.Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}
