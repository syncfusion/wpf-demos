#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.PdfViewer;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Resources;

namespace syncfusion.pdfviewerdemos.wpf
{
    public class SilentPrintingViewModel
    {
        #region Private Members
        private PdfDocumentView pdfViewer;
        ICommand m_printCommand;
        # endregion

        public SilentPrintingViewModel()
        {
            pdfViewer = new PdfDocumentView();
            Uri uriResource = new Uri("/syncfusion.pdfviewerdemos.wpf;component/Assets/EmpDetails.pdf", UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            pdfViewer.Load(streamResourceInfo.Stream);
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }
        }

        public ICommand PrintCommand
        {
            get
            {
                if (m_printCommand == null)
                {
                    m_printCommand = new DelegateCommand<Window>(Print);
                }
                return m_printCommand;
            }
        }

        #region Helper Methods

        void Print(Window window)
        {
            pdfViewer.Print();
            if (MessageBox.Show("Do you want to close the window?", "Silent Printing",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                if (window != null)
                    window.Close();
                pdfViewer.Unload(true);
            }
        }
        #endregion
    }
}
