using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.spellcheckerdemo.wpf
{

    public class SpellCheckerViewModel : NotificationObject
    {
        public SfSpellChecker SpellChecker
        {
            get;
            set;
        }

        public IEditorProperties Editor
        {
            get;
            set;
        }

        public SpellCheckerViewModel()
        {
            SpellChecker = new SfSpellChecker();
        }
    }
}