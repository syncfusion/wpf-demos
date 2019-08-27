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

namespace BackStageSample
{
    internal class Info
    {
        private string heading;
        public string Heading
        {
            get
            {
                return heading;
            }
            set
            {
                heading = value;
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        private string buttonContent;
        public string ButtonContent
        {
            get
            {
                return buttonContent;
            }
            set
            {
                buttonContent = value;
            }
        }
        private string buttonIcon;
        public string ButtonIcon
        {
            get
            {
                return buttonIcon;
            }

            set
            {
                buttonIcon = value;
            }
        }
        
    }
}