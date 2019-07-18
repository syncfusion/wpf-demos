#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using Syncfusion.Windows.Chart;

namespace ZoomingAndScrolling
{
    

    public class ProductList
    {
        public ProductList()
        {
            this.ZoomingModel=new ObservableCollection<Product>();
            this.ZoomingModel.Add(new Product(){Id="1", XValue=1850, YValue=0, ZValue=-0.36});
            this.ZoomingModel.Add(new Product(){Id="2", XValue=1852, YValue=-0.29, ZValue=-0.36});
            this.ZoomingModel.Add(new Product(){Id="3", XValue=1852, YValue=-0.29, ZValue=-0.36});
            this.ZoomingModel.Add(new Product(){Id="4", XValue=1853, YValue=-0.34, ZValue=-0.36});
            this.ZoomingModel.Add(new Product(){Id="5", XValue=1854, YValue=-0.31, ZValue=-0.37});
            this.ZoomingModel.Add(new Product(){Id="6", XValue=1855, YValue=-0.32, ZValue=-0.38});
            this.ZoomingModel.Add(new Product(){Id="7", XValue=1856, YValue=-0.41, ZValue=-0.39});
            this.ZoomingModel.Add(new Product(){Id="8", XValue=1857, YValue=-0.5, ZValue=-0.4});        
            this.ZoomingModel.Add(new Product(){Id="9", XValue=1855, YValue=-0.51, ZValue=-0.41});
            this.ZoomingModel.Add(new Product(){Id="10", XValue=1858, YValue=-0.51, ZValue=-0.41});        
            this.ZoomingModel.Add(new Product(){Id="11", XValue=1859, YValue=-0.35, ZValue=-0.41});
            this.ZoomingModel.Add(new Product(){Id="12", XValue=1860, YValue=-0.37, ZValue=-0.41});        
            this.ZoomingModel.Add(new Product(){Id="13", XValue=1861, YValue=-0.41, ZValue=-0.41});          
            this.ZoomingModel.Add(new Product(){Id="14", XValue=1862, YValue=-0.57, ZValue=-0.4});        
            this.ZoomingModel.Add(new Product(){Id="15", XValue=1863, YValue=-0.32, ZValue=-0.39});                  
            this.ZoomingModel.Add(new Product(){Id="16", XValue=1864, YValue=-0.52, ZValue=-0.38});        
            this.ZoomingModel.Add(new Product(){Id="17", XValue=1865, YValue=-0.3, ZValue=-0.37});                 
            this.ZoomingModel.Add(new Product(){Id="18", XValue=1866, YValue=-0.3, ZValue=-0.35});        
            this.ZoomingModel.Add(new Product(){Id="19", XValue=1867, YValue=-0.33, ZValue=-0.34});         
            this.ZoomingModel.Add(new Product(){Id="20", XValue=1868, YValue=-0.29, ZValue=-0.33});        
            this.ZoomingModel.Add(new Product(){Id="21", XValue=1869, YValue=-0.31, ZValue=-0.33});                            
            this.ZoomingModel.Add(new Product(){Id="22", XValue=1870, YValue=-0.3, ZValue=-0.32});        
            this.ZoomingModel.Add(new Product(){Id="23", XValue=1871, YValue=-0.34, ZValue=-0.32});        
            this.ZoomingModel.Add(new Product(){Id="24", XValue=1872, YValue=-0.26, ZValue=-0.32});        
            this.ZoomingModel.Add(new Product(){Id="25", XValue=1873, YValue=-0.33, ZValue=-0.31});       
            this.ZoomingModel.Add(new Product(){Id="26", XValue=1874, YValue=-0.4, ZValue=-0.3});        
            this.ZoomingModel.Add(new Product(){Id="27", XValue=1875, YValue=-0.42, ZValue=-0.29});       
            this.ZoomingModel.Add(new Product(){Id="28", XValue=1876, YValue=-0.04, ZValue=-0.27});        
            this.ZoomingModel.Add(new Product(){Id="29", XValue=1877, YValue=-0.09, ZValue=-0.26});      
            this.ZoomingModel.Add(new Product(){Id="30", XValue=1878, YValue=-0.02, ZValue=-0.25});        
            this.ZoomingModel.Add(new Product(){Id="31", XValue=1879, YValue=-0.27, ZValue=-0.25});      
            this.ZoomingModel.Add(new Product(){Id="32", XValue=1880, YValue=-0.26, ZValue=-0.25});      
            this.ZoomingModel.Add(new Product(){Id="33", XValue=1881, YValue=-0.24, ZValue=-0.26});      
            this.ZoomingModel.Add(new Product(){Id="34", XValue=1882, YValue=-0.25, ZValue=-0.27});      
            this.ZoomingModel.Add(new Product(){Id="35", XValue=1883, YValue=-0.3, ZValue=-0.29});      
            this.ZoomingModel.Add(new Product(){Id="36", XValue=1884, YValue=-0.38, ZValue=-0.3});                
            this.ZoomingModel.Add(new Product(){Id="37", XValue=1885, YValue=-0.36, ZValue=-0.32});      
            this.ZoomingModel.Add(new Product(){Id="38", XValue=1886, YValue=-0.28, ZValue=-0.33});      
            this.ZoomingModel.Add(new Product(){Id="39", XValue=1887, YValue=-0.39, ZValue=-0.34});      
            this.ZoomingModel.Add(new Product(){Id="40", XValue=1888, YValue=-0.34, ZValue=-0.35});      
            
            this.ZoomingModel.Add(new Product(){Id="41", XValue=1889, YValue=-0.19, ZValue=-0.36});      
            this.ZoomingModel.Add(new Product(){Id="42", XValue=1890, YValue=-0.24, ZValue=-0.36});      
            this.ZoomingModel.Add(new Product(){Id="43", XValue=1891, YValue=-0.43, ZValue=-0.37});      
            this.ZoomingModel.Add(new Product(){Id="44", XValue=1855, YValue=-0.38, ZValue=-0.39});      
            this.ZoomingModel.Add(new Product(){Id="45", XValue=1892, YValue=-0.48, ZValue=-0.39});      
            this.ZoomingModel.Add(new Product(){Id="46", XValue=1893, YValue=-0.51, ZValue=-0.39});      
            this.ZoomingModel.Add(new Product(){Id="47", XValue=1894, YValue=-0.44, ZValue=-0.37});      
            this.ZoomingModel.Add(new Product(){Id="48", XValue=1895, YValue=-0.42, ZValue=-0.36});      
            this.ZoomingModel.Add(new Product(){Id="49", XValue=1896, YValue=-0.21, ZValue=-0.36});      
            this.ZoomingModel.Add(new Product(){Id="50", XValue=1897, YValue=-0.24, ZValue=-0.35});      
            this.ZoomingModel.Add(new Product(){Id="51", XValue=1898, YValue=-0.43, ZValue=-0.35});      
            this.ZoomingModel.Add(new Product(){Id="52", XValue=1900, YValue=-0.31, ZValue=-0.36});      
            this.ZoomingModel.Add(new Product(){Id="53", XValue=1901, YValue=-0.22, ZValue=-0.36});      
            this.ZoomingModel.Add(new Product(){Id="54", XValue=1902, YValue=-0.43, ZValue=-0.4});      
            this.ZoomingModel.Add(new Product(){Id="55", XValue=1903, YValue=-0.51, ZValue=-0.42});      
            this.ZoomingModel.Add(new Product(){Id="56", XValue=1904, YValue=-0.55, ZValue=-0.44});                
            this.ZoomingModel.Add(new Product(){Id="57", XValue=1905, YValue=-0.41, ZValue=-0.45});      
            this.ZoomingModel.Add(new Product(){Id="58", XValue=1906, YValue=-0.33, ZValue=-0.47});      
            this.ZoomingModel.Add(new Product(){Id="59", XValue=1907, YValue=-0.51, ZValue=-0.48});      
            this.ZoomingModel.Add(new Product(){Id="60", XValue=1908, YValue=-0.56, ZValue=-0.49});      
            this.ZoomingModel.Add(new Product(){Id="61", XValue=1909, YValue=-0.56, ZValue=-0.49});      
            this.ZoomingModel.Add(new Product(){Id="62", XValue=1910, YValue=-0.55, ZValue=-0.49});      
            this.ZoomingModel.Add(new Product(){Id="63", XValue=1911, YValue=-0.58, ZValue=-0.48});      
            this.ZoomingModel.Add(new Product(){Id="64", XValue=1912, YValue=-0.49, ZValue=-0.46});      
            this.ZoomingModel.Add(new Product(){Id="65", XValue=1913, YValue=-0.49, ZValue=-0.44});      
            this.ZoomingModel.Add(new Product(){Id="66", XValue=1914, YValue=-0.31, ZValue=-0.43});      
            this.ZoomingModel.Add(new Product(){Id="67", XValue=1915, YValue=-0.21, ZValue=-0.41});      
            this.ZoomingModel.Add(new Product(){Id="68", XValue=1916, YValue=-0.43, ZValue=-0.39});      
            this.ZoomingModel.Add(new Product(){Id="69", XValue=1917, YValue=-0.51, ZValue=-0.38});      
            this.ZoomingModel.Add(new Product(){Id="70", XValue=1918, YValue=-0.39, ZValue=-0.37});      
            this.ZoomingModel.Add(new Product(){Id="71", XValue=1919, YValue=-0.33, ZValue=-0.36});      
            this.ZoomingModel.Add(new Product(){Id="72", XValue=1920, YValue=-0.31, ZValue=-0.35});      
            this.ZoomingModel.Add(new Product(){Id="73", XValue=1921, YValue=-0.26, ZValue=-0.34});      
            this.ZoomingModel.Add(new Product(){Id="74", XValue=1922, YValue=-0.38, ZValue=-0.32});      
            this.ZoomingModel.Add(new Product(){Id="75", XValue=1923, YValue=-0.35, ZValue=-0.31});      
            this.ZoomingModel.Add(new Product(){Id="76", XValue=1924, YValue=-0.36, ZValue=-0.3});      
            this.ZoomingModel.Add(new Product(){Id="77", XValue=1925, YValue=-0.27, ZValue=-0.29});      
            this.ZoomingModel.Add(new Product(){Id="76", XValue=1926, YValue=-0.16, ZValue=-0.27});      
            this.ZoomingModel.Add(new Product(){Id="78", XValue=1926, YValue=-0.16, ZValue=-0.27});      
            this.ZoomingModel.Add(new Product(){Id="79", XValue=1927, YValue=-0.25, ZValue=-0.26});      
            this.ZoomingModel.Add(new Product(){Id="80", XValue=1928, YValue=-0.26, ZValue=-0.25});      
            this.ZoomingModel.Add(new Product(){Id="81", XValue=1929, YValue=-0.38, ZValue=-0.23});      
            this.ZoomingModel.Add(new Product(){Id="82", XValue=1930, YValue=-0.17, ZValue=-0.22});      
            this.ZoomingModel.Add(new Product(){Id="83", XValue=1931, YValue=-0.12, ZValue=-0.21});      
            this.ZoomingModel.Add(new Product(){Id="84", XValue=1932, YValue=-0.16, ZValue=-0.19});      
            this.ZoomingModel.Add(new Product(){Id="85", XValue=1933, YValue=-0.3, ZValue=-0.17});      
            this.ZoomingModel.Add(new Product(){Id="86", XValue=1934, YValue=-0.16, ZValue=-0.15});      
            this.ZoomingModel.Add(new Product(){Id="87", XValue=1935, YValue=-0.18, ZValue=-0.13});      
            this.ZoomingModel.Add(new Product(){Id="88", XValue=1936, YValue=-0.15, ZValue=-0.1});      
            this.ZoomingModel.Add(new Product(){Id="89", XValue=1937, YValue=-0.03, ZValue=-0.08});      
            this.ZoomingModel.Add(new Product(){Id="89", XValue=1938, YValue=-0.01, ZValue=-0.06});      
            this.ZoomingModel.Add(new Product(){Id="90", XValue=1939, YValue=0, ZValue=-0.04});     
            this.ZoomingModel.Add(new Product(){Id="91", XValue=1940, YValue=-0.02, ZValue=-0.02});      
            this.ZoomingModel.Add(new Product(){Id="92", XValue=1941, YValue=0.08, ZValue=-0.02});     
            this.ZoomingModel.Add(new Product(){Id="93", XValue=1942, YValue=-0.03, ZValue=-0.02});      
            this.ZoomingModel.Add(new Product(){Id="94", XValue=1943, YValue=0.03, ZValue=-0.04});     
            this.ZoomingModel.Add(new Product(){Id="95", XValue=1944, YValue=0.12, ZValue=-0.05});      
            this.ZoomingModel.Add(new Product(){Id="96", XValue=1945, YValue=-0.01, ZValue=-0.08});     
            this.ZoomingModel.Add(new Product(){Id="97", XValue=1946, YValue=-0.21, ZValue=-0.1});
            this.ZoomingModel.Add(new Product(){Id="98", XValue=1947, YValue=-0.02, ZValue=-0.13});     
            this.ZoomingModel.Add(new Product(){Id="99", XValue=1948, YValue=-0.2, ZValue=-0.15});
            this.ZoomingModel.Add(new Product(){Id="100", XValue=1949, YValue=-0.021, ZValue=-0.16});     
            this.ZoomingModel.Add(new Product(){Id="101", XValue=1950, YValue=-0.31, ZValue=-0.17});
            this.ZoomingModel.Add(new Product(){Id="102", XValue=1951, YValue=-0.17, ZValue=-0.18});     
            this.ZoomingModel.Add(new Product(){Id="103", XValue=1952, YValue=-0.07, ZValue=-0.18});
            this.ZoomingModel.Add(new Product(){Id="104", XValue=1953, YValue=-0.03, ZValue=-0.17});     
            this.ZoomingModel.Add(new Product(){Id="105", XValue=1954, YValue=-0.25, ZValue=-0.17});
            this.ZoomingModel.Add(new Product(){Id="106", XValue=1955, YValue=-0.28, ZValue=-0.16});     
            this.ZoomingModel.Add(new Product(){Id="107", XValue=1956, YValue=-0.35, ZValue=-0.15});
            this.ZoomingModel.Add(new Product(){Id="108", XValue=1957, YValue=-0.07, ZValue=-0.14});     
            this.ZoomingModel.Add(new Product(){Id="109", XValue=1958, YValue=-0.01, ZValue=-0.13});
            this.ZoomingModel.Add(new Product(){Id="110", XValue=1959, YValue=-0.07, ZValue=-0.11});     
            this.ZoomingModel.Add(new Product(){Id="111", XValue=1960, YValue=-0.12, ZValue=-0.11});          
            this.ZoomingModel.Add(new Product(){Id="112", XValue=1961, YValue=-0.02, ZValue=-0.1});     
            this.ZoomingModel.Add(new Product(){Id="113", XValue=1962, YValue=-0.02, ZValue=-0.11});     
            this.ZoomingModel.Add(new Product(){Id="114", XValue=1963, YValue=0, ZValue=-0.11});     
            this.ZoomingModel.Add(new Product(){Id="115", XValue=1964, YValue=0.03, ZValue=-0.12});    
            this.ZoomingModel.Add(new Product(){Id="116", XValue=1965, YValue=-0.22, ZValue=-0.12});     
            this.ZoomingModel.Add(new Product(){Id="117", XValue=1966, YValue=-0.15, ZValue=-0.13});    
            this.ZoomingModel.Add(new Product(){Id="118", XValue=1967, YValue=-0.15, ZValue=-0.12});     
            this.ZoomingModel.Add(new Product(){Id="119", XValue=1968, YValue=-0.16, ZValue=-0.12});    
            this.ZoomingModel.Add(new Product(){Id="120", XValue=1969, YValue=-0.01, ZValue=-0.11});     
            this.ZoomingModel.Add(new Product(){Id="121", XValue=1970, YValue=-0.07, ZValue=-0.11});    
            this.ZoomingModel.Add(new Product(){Id="122", XValue=1971, YValue=-0.19, ZValue=-0.1});     
            this.ZoomingModel.Add(new Product(){Id="123", XValue=1972, YValue=-0.06, ZValue=-0.1});              
            this.ZoomingModel.Add(new Product(){Id="124", XValue=1973, YValue=-0.08, ZValue=-0.1});     
            this.ZoomingModel.Add(new Product(){Id="125", XValue=1974, YValue=-0.21, ZValue=-0.09});               
            this.ZoomingModel.Add(new Product(){Id="126", XValue=1975, YValue=-0.17, ZValue=-0.8});     
            this.ZoomingModel.Add(new Product(){Id="127", XValue=1976, YValue=-0.25, ZValue=-0.07});              
            this.ZoomingModel.Add(new Product(){Id="128", XValue=1977, YValue=-0.02, ZValue=-0.05});     
            this.ZoomingModel.Add(new Product(){Id="129", XValue=1978, YValue=-0.06, ZValue=-0.03});              
            this.ZoomingModel.Add(new Product(){Id="130", XValue=1979, YValue=-0.05, ZValue=-0.01});     
            this.ZoomingModel.Add(new Product(){Id="131", XValue=1980, YValue=-0.08, ZValue=-0.02});             
            this.ZoomingModel.Add(new Product(){Id="132", XValue=1981, YValue=-0.12, ZValue=-0.03});     
            this.ZoomingModel.Add(new Product(){Id="133", XValue=1982, YValue=-0.01, ZValue=-0.04});               
            this.ZoomingModel.Add(new Product(){Id="134", XValue=1983, YValue=-0.18, ZValue=-0.05});     
            this.ZoomingModel.Add(new Product(){Id="135", XValue=1984, YValue=-0.02, ZValue=-0.07});     
            this.ZoomingModel.Add(new Product(){Id="136", XValue=1985, YValue=-0.04, ZValue=0.08});     
            this.ZoomingModel.Add(new Product(){Id="137", XValue=1986, YValue=0.03, ZValue=0.09});               
            this.ZoomingModel.Add(new Product(){Id="138", XValue=1987, YValue=0.18, ZValue=0.11});     
            this.ZoomingModel.Add(new Product(){Id="139", XValue=1988, YValue=0.18, ZValue=0.12});                
            this.ZoomingModel.Add(new Product(){Id="138", XValue=1989, YValue=0.1, ZValue=0.14});     
            this.ZoomingModel.Add(new Product(){Id="139", XValue=1990, YValue=0.25, ZValue=0.15});               
            this.ZoomingModel.Add(new Product(){Id="142", XValue=1991, YValue=0.21, ZValue=0.16});     
            this.ZoomingModel.Add(new Product(){Id="143", XValue=1992, YValue=0.06, ZValue=0.18});    
            this.ZoomingModel.Add(new Product(){Id="144", XValue=1993, YValue=0.11, ZValue=0.19});     
            this.ZoomingModel.Add(new Product(){Id="145", XValue=1994, YValue=0.17, ZValue=0.22});              
            this.ZoomingModel.Add(new Product(){Id="146", XValue=1995, YValue=0.28, ZValue=0.24});     
            this.ZoomingModel.Add(new Product(){Id="147", XValue=1996, YValue=0.14, ZValue=0.27});     
            this.ZoomingModel.Add(new Product(){Id="148", XValue=1997, YValue=0.35, ZValue=0.3});     
            this.ZoomingModel.Add(new Product(){Id="149", XValue=1998, YValue=0.55, ZValue=0.35});               
            this.ZoomingModel.Add(new Product(){Id="150", XValue=1999, YValue=0.3, ZValue=0.35});     
            this.ZoomingModel.Add(new Product(){Id="151", XValue=2000, YValue=0.27, ZValue=0.37});              
            this.ZoomingModel.Add(new Product(){Id="152", XValue=2001, YValue=0.41, ZValue=0.39});     
            this.ZoomingModel.Add(new Product(){Id="153", XValue=2002, YValue=0.46, ZValue=0.41});    
            this.ZoomingModel.Add(new Product(){Id="152", XValue=2003, YValue=0.47, ZValue=0.42});     
            this.ZoomingModel.Add(new Product(){Id="153", XValue=2004, YValue=0.45, ZValue=0.42});    
            this.ZoomingModel.Add(new Product(){Id="154", XValue=2005, YValue=0.47, ZValue=0.42});     
            this.ZoomingModel.Add(new Product(){Id="155", XValue=2006, YValue=0.45, ZValue=0.42});    
            this.ZoomingModel.Add(new Product(){Id="156", XValue=2005, YValue=0.48, ZValue=0.43});     
            this.ZoomingModel.Add(new Product(){Id="157", XValue=2006, YValue=0.42, ZValue=0.43});    
            this.ZoomingModel.Add(new Product(){Id="158", XValue=2007, YValue=0.4, ZValue=0.42});                                    
        }

        public ObservableCollection<Product> ZoomingModel { set; get; }
        public Array VisibilityCollection
        {
            get { return Enum.GetValues(typeof(Visibility)); }
        }
    }


    public class RangeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DoubleRange Range = (DoubleRange)value;
            DoubleRange RangeValue = new DoubleRange(Math.Round(Range.Start, 3), Math.Round(Range.End, 3));
            return RangeValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
    public class BoolToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible ? true : false;
        }
    }
}
