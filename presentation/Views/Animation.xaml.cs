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
    /// Interaction logic for Animation.xaml
    /// </summary>
    public partial class Animation : DemoControl
    {
        public Animation()
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
            string input = @"Assets\Presentation\Animation.pptx";
            using (IPresentation presentation = Presentation.Open(input))
            {
                //Method call to create slides
                CreateAnimation(presentation);

                //Saves the presentation
                presentation.Save("Animation.pptx");
            }

            if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
				System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Animation.pptx") { UseShellExecute = true };
                process.Start();
            }
        }
        # region Slide1
        private void CreateAnimation(IPresentation presentation)
        {
            //Get the slide from the presentation
            ISlide slide = presentation.Slides[0];

            //Access the animation sequence to create effects
            ISequence sequence = slide.Timeline.MainSequence;

            //Add motion path effect to the shape
            IEffect line1 = sequence.AddEffect(slide.Shapes[8] as IShape, EffectType.PathUp, EffectSubtype.None, EffectTriggerType.OnClick);
            IMotionEffect motionEffect = line1.Behaviors[0] as IMotionEffect;
            motionEffect.Timing.Duration = 1f;
            IMotionPath motionPath = motionEffect.Path;
            motionPath[1].Points[0].X = 0.00365f;
            motionPath[1].Points[0].Y = -0.27431f;

            //Add motion path effect to the shape
            IEffect line2 = sequence.AddEffect(slide.Shapes[3] as IShape, EffectType.PathDown, EffectSubtype.None, EffectTriggerType.WithPrevious);
            motionEffect = line2.Behaviors[0] as IMotionEffect;
            motionEffect.Timing.Duration = 0.75f;
            motionPath = motionEffect.Path;
            motionPath[1].Points[0].X = 0.00234f;
            motionPath[1].Points[0].Y = 0.43449f;

            //Add wipe effect to the shape
            IEffect wipe1 = sequence.AddEffect(slide.Shapes[1] as IShape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.AfterPrevious);
            wipe1.Behaviors[1].Timing.Duration = 1f;

            //Add fly effect to the shape
            IEffect fly1 = sequence.AddEffect(slide.Shapes[5] as IShape, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.AfterPrevious);
            fly1.Behaviors[1].Timing.Duration = 0.70f;
            fly1.Behaviors[2].Timing.Duration = 0.70f;

            ////Add wipe effect to the shape
            IEffect wipe2 = sequence.AddEffect(slide.Shapes[2] as IShape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.AfterPrevious);
            wipe2.Behaviors[1].Timing.Duration = 1f;

            ////Add fly effect to the shape
            IEffect fly2 = sequence.AddEffect(slide.Shapes[4] as IShape, EffectType.Fly, EffectSubtype.Right, EffectTriggerType.AfterPrevious);
            fly2.Behaviors[1].Timing.Duration = 0.70f;
            fly2.Behaviors[2].Timing.Duration = 0.70f;

            IEffect fly3 = sequence.AddEffect(slide.Shapes[6] as IShape, EffectType.Fly, EffectSubtype.Top, EffectTriggerType.AfterPrevious);
            fly3.Behaviors[1].Timing.Duration = 1.50f;
            fly3.Behaviors[2].Timing.Duration = 1.50f;

            ////Add flay effect to the shape
            IEffect fly4 = sequence.AddEffect(slide.Shapes[7] as IShape, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.AfterPrevious);
            fly4.Behaviors[1].Timing.Duration = 0.50f;
            fly4.Behaviors[2].Timing.Duration = 0.50f;
        }
        #endregion			
	}
}

