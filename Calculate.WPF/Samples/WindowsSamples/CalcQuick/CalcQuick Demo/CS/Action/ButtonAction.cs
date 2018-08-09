using System.Windows.Interactivity;
using Syncfusion.Windows.Shared;

namespace FirstSample.Action
{
    class ButtonAction : TargetedTriggerAction<ChromelessWindow>
    {
        protected override void Invoke(object parameter)
        {
            switch (((parameter as System.Windows.RoutedEventArgs).Source as System.Windows.Controls.Button).Name)
            {
                case "button6":
                    AlgebraicExpressions alg = new AlgebraicExpressions();
                    alg.Show();
                    this.Target.Hide();
                    break;
                case "button4":
                    AngleForm ang = new AngleForm();
                    ang.Show();
                    this.Target.Hide();
                    break;
                case "button5":
                    AutoAngleForm autoang = new AutoAngleForm();
                    autoang.Show();
                    this.Target.Hide();
                    break;
                case "button2":
                    AutoCalcForm autocalc = new AutoCalcForm();
                    autocalc.Show();
                    this.Target.Hide();
                    break;
                case "button1":
                    ManualCalcForm manual = new ManualCalcForm();
                    manual.Show();
                    this.Target.Hide();
                    break;
                case "button3":
                    MoreComplexForm more = new MoreComplexForm();
                    more.Show();
                    this.Target.Hide();
                    break;

            }
        }
    }
}
