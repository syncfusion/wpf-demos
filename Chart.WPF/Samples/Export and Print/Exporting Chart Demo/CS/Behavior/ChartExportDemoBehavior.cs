#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Interactivity;
using System.Xml;
using System.Windows.Markup;
using Microsoft.Win32;


namespace ChartExport
{
    class ChartExportDemoBehavior:Behavior<Window1>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.Copytoclip.Click += new System.Windows.RoutedEventHandler(Copytoclip_Click);
            this.AssociatedObject.Savebtn.Click += new System.Windows.RoutedEventHandler(Savebtn_Click);
        }

        void Savebtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string C_imageFilesFilter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg,*.jpeg)|*.jpg;*.jpeg|Gif (*.gif)|*.gif|TIFF(*.tiff)|*.tiff|PNG(*.png)|*.png|WDP(*.wdp)|*.wdp|Xps file (*.xps)|*.xps|All files (*.*)|*.*";
            saveFileDialog.Filter = C_imageFilesFilter;

            if (saveFileDialog.ShowDialog() == true)
            {
                this.AssociatedObject.Chart1.Save(saveFileDialog.FileName);
            }
        }

        void Copytoclip_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.Chart1.CopyToClipboard();
        }

        public static String XamlWriterFormatted(Object uie)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };
            XamlDesignerSerializationManager dsm = new XamlDesignerSerializationManager(XmlWriter.Create(sb, settings));
            dsm.XamlWriterMode = XamlWriterMode.Expression;
            XamlWriter.Save(uie, dsm);
            return sb.ToString();
        }

    }
}
