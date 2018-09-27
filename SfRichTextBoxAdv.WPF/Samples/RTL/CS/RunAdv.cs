using Syncfusion.Windows.Controls.RichTextBoxAdv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
#if !Framework3_5
using System.Linq;
using System.Threading.Tasks;
#endif

namespace DocumentEditor
{
    /// <summary>
    /// The RunAdv class
    /// </summary>
    public class RunAdv : Run
    {
        #region Properties
        /// <summary>
        /// Gets or sets the run text.
        /// </summary>
        /// <value>
        /// The run text.
        /// </value>
        public string RunText
        {
            get
            {
                return (string)GetValue(RunTextProperty);
            }
            set
            {
                SetValue(RunTextProperty, value);
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RunAdv"/> class.
        /// </summary>
        public RunAdv()
        {
        }
        #endregion

        #region Static Dependency Properties
        // Using a DependencyProperty as the backing store for RunText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RunTextProperty = DependencyProperty.Register("RunText", typeof(string), typeof(RunAdv), new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnRunTextChanged)));
        #endregion

        #region Static Events
        /// <summary>
        /// Called when [run text changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnRunTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RunAdv runadv = d as RunAdv;
            runadv.OnRunTextChanged(e);
        }
        /// <summary>
        /// Raises the <see cref="E:RunTextChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void OnRunTextChanged(DependencyPropertyChangedEventArgs e)
        {
            base.Text = (string)e.NewValue;
        }
        #endregion
    }
}
