using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.Model
{
    class Symbols : ISymbol
    {
        public Symbols()
        {

        }

        public object Symbol
        {
            get;
            set;
        }

        public object Key
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public DataTemplate SymbolTemplate
        {
            get;
            set;
        }

        public string GroupName { get; set; }

        public IEnumerable<string> SearchTags
        {
            get;
            set;
        }

        public DiagramMenu Menu
        {
            get;
            set;
        }
        //Get ISymbol
        public ISymbol Clone()
        {
            return new Symbols()
            {
                Symbol = this.Symbol,
                SymbolTemplate = this.SymbolTemplate,
                Key = this.Key
            };
        }

    }
}
