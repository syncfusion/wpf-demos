#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace GettingStarted_2008
{
    /// <summary>
    /// Represents the model class
    /// </summary>
    public class Document
    {
        private string m_name;

        /// <summary>
        /// Gets or sets the name of the document.
        /// </summary>
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

    }
}
