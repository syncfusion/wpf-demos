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

    public object Create(PropertyDescriptor PropertyDescriptor)
    {
        throw new NotImplementedException();
    }


    public bool ShouldPropertyGridTryToHandleKeyDown(Key key)
    {
        return false;
    }
    public void Detach(PropertyViewItem property) {
    }
}

