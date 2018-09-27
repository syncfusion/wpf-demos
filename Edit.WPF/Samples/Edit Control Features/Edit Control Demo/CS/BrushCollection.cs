using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Reflection;
using System.Collections.ObjectModel;

namespace EditDemo
{
    public class BrushCollection : ObservableCollection<MyBrush>
    {
        public BrushCollection()
            : base()
        {
            Type type = typeof(Brushes);
            foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                if (propertyInfo.PropertyType == typeof(SolidColorBrush))
                    Add(new MyBrush(propertyInfo.Name, (SolidColorBrush)propertyInfo.GetValue(null, null)));
            }
        }
    }
    public class MyBrush
    {
        string _name;
        SolidColorBrush _brush;
        public MyBrush()
        {
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public SolidColorBrush Brush
        {
            get
            {
                return _brush;
            }
            set
            {
                _brush = value;
            }
        }
        public MyBrush(string name, SolidColorBrush brush)
        {
            _name = name;
            _brush = brush;
            Color color = brush.Color;
        }

    }
}
