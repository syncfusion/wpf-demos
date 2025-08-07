#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using syncfusion.demoscommon.wpf;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for ModifyAnimation.xaml
    /// </summary>
    public partial class ModifyAnimation : DemoControl
    {        
        public ModifyAnimation()
        {
            InitializeComponent();
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        private void btnCreatePresn_Click(object sender, EventArgs e)
        {
            string input = @"Assets\Presentation\ShapeWithAnimation.pptx";

            using (IPresentation presentation = Presentation.Open(input))
            {
                //Modify the existing animation
                ModifyAnimation1(presentation);

                //Saves the presentation
                presentation.Save("ModifiedAnimation.pptx");
            }
                
            if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                  MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("ModifiedAnimation.pptx") { UseShellExecute = true };
                process.Start();
            }
        }

        #region Modify Animation

        private void ModifyAnimation1(IPresentation presentation)
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
            string input = @"Assets\Presentation\ShapeWithAnimation.pptx";

            IPresentation presentation = Presentation.Open(input);
            presentation.Save("ShapeWithAnimation.pptx");

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo("ShapeWithAnimation.pptx") { UseShellExecute = true };
            process.Start();
        }	        
    }
}

