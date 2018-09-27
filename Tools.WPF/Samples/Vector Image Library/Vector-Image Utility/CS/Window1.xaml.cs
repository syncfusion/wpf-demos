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
using Microsoft.Win32;
using System.IO;
using System.Windows.Markup;
using System.Xml;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Resources;
using System.Collections;
using Syncfusion.VectorImages.WPF;

namespace VectorImageUtility
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        VisualBrush imgBrush = new VisualBrush();

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
            //SkinStorage.SetVisualStyle(this, "Office2010Blue");

        }

        /// <summary>
        /// Handles the Loaded event of the Window1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            Assembly asm = Assembly.GetAssembly(typeof(VectorImages));
            Stream stream = asm.GetManifestResourceStream(asm.GetName().Name + ".g.resources");
            using (ResourceReader reader = new ResourceReader(stream))
            {
                foreach (DictionaryEntry entry in reader)
                {

                    ResourceDictionary resourceDic = new ResourceDictionary();
                    resourceDic.Source = new Uri(string.Format("/Syncfusion.VectorImages.WPF;component/{0}", ((string)entry.Key).Replace(".baml", ".xaml")), UriKind.RelativeOrAbsolute);
                    this.Resources.MergedDictionaries.Add(resourceDic);

                    String category = ((string)entry.Key).Split(new char[] { '/' })[1];
                    category = category.Remove(category.IndexOf("."));

                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = category[0].ToString().ToUpper() + category.Substring(1);
                    this.comboSkinCategory.Items.Add(item);

                }
            }

            this.cboStretch.SelectedItem = this.cboStretch.Items[0];
            this.comboSkinCategory.SelectedItem = this.comboSkinCategory.Items[0];
        }

        /// <summary>
        /// Handles the Click event of the mnuSkins control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        

        /// <summary>
        /// Handles the SelectionChanged event of the comboSkinCategory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void comboSkinCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = this.comboSkinCategory.SelectedItem as ComboBoxItem;

            galleryGroup.Header = selectedItem.Content.ToString();

            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri(string.Format("/Syncfusion.VectorImages.WPF;component/Icons/{0}.xaml", selectedItem.Content.ToString()), UriKind.RelativeOrAbsolute);

            galleryGroup.Items.Clear();
            GalleryItem firstItem = null;
            foreach (string key in dictionary.Keys)
            {

                if (key.ToString() != "DeliveryReceipt/ReadReceipt")
                {
                    GalleryItem galleryitem = new GalleryItem();
                    if (firstItem == null)
                    {
                        firstItem = galleryitem;
                    }
                    galleryitem.Caption = key;
                    galleryitem.Description = "";
                    Image img = new Image();
                    img.Margin = new Thickness(2);
                    img.Source = (DrawingImage)dictionary[key];
                    galleryitem.Content = img;
                    galleryitem.Name = key;
                    galleryitem.ToolTip = key;
                    galleryGroup.Items.Add(galleryitem);
                }
            }
            if (firstItem != null)
            {
                firstItem.IsSelected = true;
                this.ImageSourceContent = this.Resources[firstItem.Name.ToString()] as ImageSource;               
                Image img = new Image();
                img.Source = this.ImageSourceContent;

                imgCanvas.Height = 100;
                imgCanvas.Width = 100;

                stOuter.Height = 100;
                stOuter.Width = 100;

                imgBorder.Height = 100;
                imgBorder.Width = 100;
              
                imgBrush.Visual = img;
                imgBorder.Fill = imgBrush;

                sliderHeight.Value = 100;
                sliderWidth.Value = 100;
                LoadXAML();
            }
            this.myGallery.UpdateLayout();
        }

        /// <summary>
        /// Handles the MouseClick event of the galleryGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private void galleryGroup_MouseClick(object sender, MouseButtonEventArgs e)
        {
            GalleryItem item = this.galleryGroup.SelectionStartItem as GalleryItem;

            if (item != null)
            {
                this.ImageSourceContent = this.Resources[item.Name.ToString()] as ImageSource;             
                Image img = new Image();
                img.Source = this.ImageSourceContent;

                imgCanvas.Height = 100;
                imgCanvas.Width = 100;

                stOuter.Height = 100;
                stOuter.Width = 100;

                imgBorder.Height = 100;
                imgBorder.Width = 100;
              
                imgBrush.Visual = img;
                imgBorder.Fill = imgBrush;

                sliderHeight.Value = 100;
                sliderWidth.Value = 100;
                LoadXAML();
            }
        }

        /// <summary>
        /// Handles the Click event of the menuItemSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void menuItemSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Image";
            saveFileDialog.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg,*.jpeg)|*.jpg;*.jpeg|Gif (*.gif)|*.gif|TIFF(*.tiff)|*.tiff|PNG(*.png)|*.png|WDP(*.wdp)|*.wdp|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                VectorImageUtil.SaveImage(saveFileDialog.FileName, imgCanvas);
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.TextChangedEventArgs"/> instance containing the event data.</param>
        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (IsDouble(txtBox.Text))
            {
                if (double.Parse(txtBox.Text) > 1000)
                {
                    MessageBox.Show("Value should not exceed 1000.", "VectorImage Utility", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                if (txtBox.Name.Equals("txtImageHeight"))
                {
                    stOuter.Height = double.Parse(txtBox.Text);
                    imgCanvas.Height = double.Parse(txtBox.Text);
                    imgBorder.Height = double.Parse(txtBox.Text);
                }
                else if (txtBox.Name.Equals("txtImageWidth"))
                {
                    stOuter.Width = double.Parse(txtBox.Text);
                    imgCanvas.Width = double.Parse(txtBox.Text);
                    imgBorder.Width = double.Parse(txtBox.Text);
                }
                e.Handled = true;
            }
            else
            {
                MessageBox.Show("Invalid Input. Please enter valid double value.", "VectorImage Utility", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = false;
            }

        }

        /// <summary>
        /// Handles KeyDown event of richTextBoxXaml control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBoxXaml_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
                ImportXaml();
        }

        /// <summary>
        /// Handles the Click event of the buttonExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export to XAML Format";
            saveFileDialog.Filter = "XAML(*.xaml)|*.xaml|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                VectorImageUtil.SaveXAML(saveFileDialog.FileName, this.ImageSourceContent);
            }
        }

        /// <summary>
        /// Handles SelectionChanged event of the cboStretch control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStretch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((cboStretch.SelectedItem as ComboBoxItem).Content.ToString())
            {
                case "Fill":
                    imgBrush.Stretch = Stretch.Fill;
                    break;
                case "None":
                    imgBrush.Stretch = Stretch.None;
                    break;
                case "Uniform":
                    imgBrush.Stretch = Stretch.Uniform;
                    break;
                case "UniformToFill":
                    imgBrush.Stretch = Stretch.UniformToFill;
                    break;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the sliderBoth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        private void sliderBoth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.imgBorder.Height += e.NewValue;
            this.imgBorder.Width += e.NewValue;

            this.stOuter.Height += e.NewValue;
            this.stOuter.Width += e.NewValue;

            this.imgCanvas.Height += e.NewValue;
            this.imgCanvas.Width += e.NewValue;
        }

        /// <summary>
        /// Determines whether the specified TXT is double.
        /// </summary>
        /// <param name="txt">The TXT.</param>
        /// <returns>
        /// 	<c>true</c> if the specified TXT is double; otherwise, <c>false</c>.
        /// </returns>
        bool IsDouble(string txt)
        {
            try
            {
                double.Parse(txt);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Loads the XAML.
        /// </summary>
        void LoadXAML()
        {
            StringBuilder outputString = new StringBuilder();
            richTextBoxXaml.Document.Blocks.Clear();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            XamlDesignerSerializationManager designSerialization = new XamlDesignerSerializationManager(XmlWriter.Create(outputString, settings));
            designSerialization.XamlWriterMode = XamlWriterMode.Expression;
            XamlWriter.Save(this.ImageSourceContent, designSerialization);
            richTextBoxXaml.Document.Blocks.Add(XAMLParser.GetFomattedXAML(outputString.ToString()));
            richTextBoxXaml.ScrollToHome();
            
        }

        /// <summary>
        /// Gets or sets the content of the image source.
        /// </summary>
        /// <value>The content of the image source.</value>
        public ImageSource ImageSourceContent
        {
            get;
            set;
        }

        /// <summary>
        /// Imports the Xaml contents.
        /// </summary>
        private void ImportXaml()
        {
            try
            {
                Visual visualElement = VectorImageUtil.ImportXaml(this.ImageSourceContent, richTextBoxXaml.Document);

                if (visualElement != null)
                {
					if(visualElement is Image)
                   		 ImageSourceContent = (visualElement as Image).Source;
                    imgBrush.Visual = visualElement;
                    imgBorder.Fill = imgBrush;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void menuItemImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledlg = new OpenFileDialog();
            openfiledlg.InitialDirectory = "c:\\";
            openfiledlg.Filter = "XAML(*.xaml)|*.xaml";
            openfiledlg.RestoreDirectory = true;
            if (openfiledlg.ShowDialog() == true)
            {
            
                System.IO.FileStream fStream;

                if (System.IO.File.Exists(openfiledlg.FileName))
                {              
                    fStream = new System.IO.FileStream(openfiledlg.FileName, System.IO.FileMode.OpenOrCreate);
                    richTextBoxXaml.Document.Blocks.Clear();
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.OmitXmlDeclaration = true;
                    XamlDesignerSerializationManager designSerialization = new XamlDesignerSerializationManager(XmlWriter.Create(fStream, settings));
                    designSerialization.XamlWriterMode = XamlWriterMode.Expression;
                    StreamReader sr = new StreamReader(fStream);
                    String str = sr.ReadToEnd();
                    richTextBoxXaml.Document.Blocks.Add(XAMLParser.GetFomattedXAML(str));
                    richTextBoxXaml.ScrollToHome();
                    fStream.Close();
                    ImportXaml();
                }

            }
        }

        private void importbutton_Click(object sender, RoutedEventArgs e)
        {
            ImportXaml();
        }

        private void importbutton_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F5)
                ImportXaml();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
