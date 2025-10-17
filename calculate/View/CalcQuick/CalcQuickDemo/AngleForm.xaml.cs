using System.Windows;
using Syncfusion.Windows.Shared;

namespace syncfusion.calculatedemos.wpf
{
    /// <summary>
    /// Interaction logic for AngleForm.xaml
    /// </summary>
    public partial class AngleForm : ChromelessWindow
    {
        #region Constructor

        public AngleForm()
        {
            InitializeComponent();
        }

        #endregion

        #region API Definition

        //Initialize Calculator
        CalcQuick calculator = new CalcQuick();

        #endregion

        #region Event Handler

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Let the calculator know the values / formulas 
            //by using an indexer on the calculator object.
            //Here we are using the text box names as the indexer keys
            //provided to the calculator object. This is not required.
            //The only restrictions for the indexer key values are that they 
            //unique nonempty strings.
            this.calculator["Angle"] = this.Angle.Text;
            this.calculator["cosTB"] = this.cosTB.Text;
            this.calculator["sinTB"] = this.sinTB.Text;

            //Mark the calculator dirty:
            this.calculator.SetDirty();

            //Now as the values are retrieved from the calculator, they
            //will be the newly calculated values.
            this.cosTB.Text = this.calculator["cosTB"];
            this.sinTB.Text = this.calculator["sinTB"];
        }
        #endregion      
    }
}
