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
using System.Threading.Tasks;

namespace syncfusion.richtextboxdemos.wpf
{
    public class DocumentManager
    {
        #region Fields
        /// <summary>
        /// To hold the text of the document loaded for summarization process.
        /// </summary>
        private string documentText;

        /// <summary>
        /// Occurs when the document text is changed.
        /// </summary>
        public event EventHandler DocumentTextChanged;
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets the text of the document loaded.
        /// </summary>
        public string DocumentText
        {
            get
            {
                return documentText;
            }
            set
            {
                if (documentText != value)
                {
                    documentText = value;
                    OnDocumentTextChanged();
                }
            }
        }
        #endregion

        #region Implementation
        /// <summary>
        /// Raises the DocumentTextChanged event when the document text is changed.
        /// </summary>
        protected virtual void OnDocumentTextChanged()
        {
            if (DocumentTextChanged != null)
            {
                DocumentTextChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Loads and holds loaded document text for summarization.
        /// </summary>
        /// <param name="text">The text of the loaded document.</param>
        public void LoadText(string text)
        {
            DocumentText = text;
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Releases resources by clearing the document text and unsubscribing events.
        /// </summary>
        public void Dispose()
        {
            documentText = null;
            DocumentTextChanged = null;
        }
        #endregion
    }
}
