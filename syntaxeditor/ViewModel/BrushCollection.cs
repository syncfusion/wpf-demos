#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Media;
using System.Reflection;
using System.Collections.ObjectModel;
using syncfusion.demoscommon.wpf;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Represents the Brush collection class
    /// </summary>
    public class BrushCollection :ObservableCollection<MyBrush>
    {
        /// <summary>
        /// Initializes the instance of <see cref="BrushCollection"/>class
        /// </summary>
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

    /// <summary>
    /// Reprsents the MyBrush class 
    /// </summary>
    public class MyBrush : NotificationObject
    {
        /// <summary>
        /// Maintains the name of the color
        /// </summary>
        private string _name;

        /// <summary>
        /// Maintains the brush
        /// </summary>
        private SolidColorBrush _brush;
        
        /// <summary>
        /// Gets or sets the color name
        /// </summary>
         public string Name
         {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// GEts or sets the brush to the choosen color
        /// </summary>
        public SolidColorBrush Brush
        {
            get
            {
                return _brush;
            }
            set
            {
                _brush = value;
                RaisePropertyChanged("Brush");
            }
        }

        /// <summary>
        /// Method to set the brush to the choosen color name
        /// </summary>
        /// <param name="name">Specifies the color naem</param>
        /// <param name="brush">Specifies the color brush</param>
        public MyBrush(string name, SolidColorBrush brush)
        {
            _name = name;
            _brush = brush;
            Color color = brush.Color;
        }
    }
}
