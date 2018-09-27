using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;

namespace TabControlTouchDemo
{
    public class MainWindowBehavior :Behavior<MainWindow>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += (sender, e) =>
                {
                    if (e.Source.GetType() == typeof(MainWindow))
                        AssociatedObject.DragMove();
                };

            MainWindow mainwindow = AssociatedObject as MainWindow;
            if (mainwindow != null)
            {
                mainwindow.Loaded += (sender2, e2) =>
                    {
                        mainwindow.combo.SelectionChanged += (sender3, e3) =>
                        {
                            SkinStorage.SetVisualStyle(AssociatedObject, ((sender3 as ComboBoxAdv).SelectedItem as ComboBoxItemAdv).Content.ToString());
                        };
                    };
            }
        }
    }
}
