#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GettingStarted_VisualStyles
{
    class NodeVM : Node
    {
        public NodeVM()
        {

        }
        private string _mText;

        [DataMember]
        public string Text
        {
            get { return _mText; }
            set { _mText = value; }
        }
        private string _mFill;

        [DataMember]
        public string Fill
        {
            get { return _mFill; }
            set { _mFill = value; }
        }
        private string _mcheck;

        [DataMember]
        public string ShapeType
        {
            get { return _mcheck; }
            set { _mcheck = value; }
        }


        public void Update()
        {
            string content = Text;
            Shape shape = this.Shape as Shape;
            TextBlock txtblock = new TextBlock();
            string fill = Fill;
            if (fill != null)
            {
                ShapeStyle = GetStyle(fill);
            }

            if (ShapeType == "Diamond")
            {
                txtblock.Margin = new Thickness(25);
            }
            if (ShapeType == "Card")
            {
                txtblock.Margin = new Thickness(10);
            }
        }
        //Style for Node
        private Style GetStyle(string fill)
        {
            Node node = this;
            string hex = fill;
            hex = hex.Replace("#", string.Empty);
            byte r = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, r, g, b));
            Style sty = new Style();
            sty.BasedOn = node.ShapeStyle;
            sty.TargetType = typeof(Path);
            sty.Setters.Add(new Setter(Path.FillProperty, myBrush));
            sty.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
            return sty;
        }
    }
}
