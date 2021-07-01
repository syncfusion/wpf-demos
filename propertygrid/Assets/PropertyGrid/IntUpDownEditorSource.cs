#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
public class IntUpDownEditor : ITypeEditor {
    UpDown intUpDown;
    public void Attach(PropertyViewItem property, PropertyItem info)
    {
        var binding = new Binding("Value") {
            Mode = BindingMode.TwoWay,
            Source = info,
            ValidatesOnExceptions = true,
            ValidatesOnDataErrors = true
        }; 
        BindingOperations.SetBinding(intUpDown, UpDown.ValueProperty, binding);
        intUpDown.IsEnabled = true;
    }
    public object Create(PropertyInfo propertyInfo)
    {
        intUpDown = new UpDown() {
            ApplyZeroColor = false,
            NumberDecimalDigits = 0,
            BorderThickness = new Thickness(0)
        };
        if (propertyInfo.Name == "Age") {
            intUpDown.MinValue = 25;
            intUpDown.MaxValue = 100;
        }
        else if (propertyInfo.Name == "Experience") {
            intUpDown.MinValue = 5;
            intUpDown.MaxValue = 80;
        }
        return intUpDown;
    }
    public void Detach(PropertyViewItem property) {
    }
}

