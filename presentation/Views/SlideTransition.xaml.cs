#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
    /// Interaction logic for SlideTransition.xaml
    /// </summary>
    public partial class SlideTransition : DemoControl
    {
        public SlideTransition()
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
            string input = @"Assets\Presentation\Transition.pptx";

            using (IPresentation presentation = Presentation.Open(input))
            {
                //Method call to create slides
                CreateTransition(presentation);

                //Saves the presentation
                presentation.Save("Transition.pptx");
            }                

            if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Transition.pptx") { UseShellExecute = true };
                process.Start();
            }
        }
        # region Slide1
        private void CreateTransition(IPresentation presentation)
        {
            //Get the first slide from the presentation
            ISlide slide1 = presentation.Slides[0];

            // Add the 'Wheel' transition effect to the first slide
            slide1.SlideTransition.TransitionEffect = TransitionEffect.Wheel;

            // Get the second slide from the presentation
            ISlide slide2 = presentation.Slides[1];

            // Add the 'Checkerboard' transition effect to the second slide
            slide2.SlideTransition.TransitionEffect = TransitionEffect.Checkerboard;

            // Add the subtype to the transition effect
            slide2.SlideTransition.TransitionEffectOption = TransitionEffectOption.Across;

            // Apply the value to transition mouse on click parameter
            slide2.SlideTransition.TriggerOnClick = true;

            // Get the third slide from the presentation
            ISlide slide3 = presentation.Slides[2];

            // Add the 'Orbit' transition effect for slide
            slide3.SlideTransition.TransitionEffect = TransitionEffect.Orbit;

            // Add the speed for transition
            slide3.SlideTransition.Speed = TransitionSpeed.Fast;

            // Get the fourth slide from the presentation
            ISlide slide4 = presentation.Slides[3];

            // Add the 'Uncover' transition effect to the slide
            slide4.SlideTransition.TransitionEffect = TransitionEffect.Uncover;

            // Apply the value to advance on time for slide
            slide4.SlideTransition.TriggerOnTimeDelay = true;

            // Assign the advance on time value
            slide4.SlideTransition.TimeDelay = 5;

            // Get the fifth slide from the presentation
            ISlide slide5 = presentation.Slides[4];

            // Add the 'PageCurlDouble' transition effect to the slide
            slide5.SlideTransition.TransitionEffect = TransitionEffect.PageCurlDouble;

            // Add the duration value for the transition effect
            slide5.SlideTransition.Duration = 5;
        }
        #endregion			
	}
}

