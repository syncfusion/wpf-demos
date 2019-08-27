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
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Syncfusion.Presentation;
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Shared;

namespace ModifyAnimation
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
        }

        private void btnCreatePresn_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\..\Common\Data\Presentation\ShapeWithAnimation.pptx";
            IPresentation presentation = Presentation.Open(input);

            //Modify the existing animation
            ModifyAnimation(presentation);

            //Saves the presentation
            presentation.Save("ModifiedAnimation.pptx");
            if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                  MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {

                System.Diagnostics.Process.Start("ModifiedAnimation.pptx");
                this.Close();
            }
        }

        #region Modify Animation

        private void ModifyAnimation(IPresentation presentation)
        {
            //Retrieves the slide instance
            ISlide slide = presentation.Slides[0];
            //Retrieves the slide main sequence
            ISequence sequence = slide.Timeline.MainSequence;
            //Retrieves the existing animation effect from the main sequence
            IEffect loopEffect = sequence[0];
            //Change the type of the existing animation effect
            loopEffect.Type = EffectType.Bounce;
        }
        #endregion
		
		private void btnInputTemplate_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\..\Common\Data\Presentation\ShapeWithAnimation.pptx";
            IPresentation presentation = Presentation.Open(input);
            presentation.Save("ShapeWithAnimation.pptx");
            System.Diagnostics.Process.Start("ShapeWithAnimation.pptx");
        }	        
    }
}

