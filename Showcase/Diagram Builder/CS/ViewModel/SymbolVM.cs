using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Syncfusion.UI.Xaml.Diagram.Stencil;
namespace DiagramBuilder.ViewModel
{
    public class SymbolVM : ISymbol
    {
            static Random r = new Random();

        public SymbolVM()
        {
            //if (r.Next(0, 10) < 5)
            //{
            //    AAA = "1";
            //}
            //else
            //{
            //    AAA = null;
            //}
        }

        public object Symbol
        {
            get;
            set;
        }

        //public object AAA { get; set; }

        public DataTemplate SymbolTemplate
        {
            get;
            set;
        }

        public string GroupName { get; set; }


        public ISymbol Clone()
        {
            return new SymbolVM()
            {
                Symbol = this.Symbol,
                SymbolTemplate = this.SymbolTemplate
            };
        }


        public object Key
        {
            get;
            set;
        }
    }


    public class SymbolCollection : ObservableCollection<object>
    {

    }
}
