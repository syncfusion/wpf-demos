using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Syncfusion.Presentation;
using Syncfusion.OfficeChartToImageConverter;
using Syncfusion.Windows.Shared;

namespace PPTXToImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();			
            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\..\Common\Images\Presentation\ppt_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\Presentation\App.ico");
            this.txtFile.Text = "Syncfusion Presentation.pptx";
            this.txtFile.Tag = @"..\..\..\..\..\..\..\Common\Data\Presentation\Syncfusion Presentation.pptx";
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
            openFileDialog1.InitialDirectory = Path.GetFullPath(@"..\..\..\..\..\..\..\Common\Data\Presentation\");
            openFileDialog1.FileName = "";
			openFileDialog1.Filter = "PowerPoint Presentations|*.pptx";
            Nullable<bool> result = openFileDialog1.ShowDialog();

            //Get the selected file name and display in a TextBox
            if (result == true)
            {
                this.txtFile.Text = openFileDialog1.SafeFileName;
                this.txtFile.Tag = openFileDialog1.FileName;
            }
        }


        private void btnCreateImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Opens the specified presentation
                IPresentation presentation = Presentation.Open(txtFile.Tag.ToString());

                int i = 1;
                string path = null;
                presentation.ChartToImageConverter = new ChartToImageConverter();
                presentation.ChartToImageConverter.ScalingMode = Syncfusion.OfficeChart.ScalingMode.Best;
                //Gets all the slides in presentation and manipulates one by one
                foreach (ISlide slide in presentation.Slides)
                {
                    //Converts slide to image
                    using (Image image = Image.FromStream(slide.ConvertToImage(Syncfusion.Drawing.ImageFormat.Emf)))
                    {
                        //Gets the file name without extension from the textbox.
                        string name = Path.GetFileNameWithoutExtension(txtFile.Tag.ToString());
                        string fileName = Path.GetFullPath("../../Output/") + name;
                        Directory.CreateDirectory(fileName);
                        fileName = fileName + "/" + name + i++ + ".png";

                        //Saves the image
                        image.Save(fileName);
                        if (i == 2)
                            path = fileName;
                    }
                }
                if (System.Windows.MessageBox.Show("Do you want to view the converted images?", "PPTX To Image",
                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start(path);
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show("This file could not be converted, please contact Syncfusion Direct-Trac system at http://www.syncfusion.com/support/default.aspx for any queries. ", "OOPS..Sorry!",
                    MessageBoxButton.OK);
                this.Close();
            }
        }		
    }
}
          
