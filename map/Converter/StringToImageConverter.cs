namespace syncfusion.mapdemos.wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// The class represents name to image conversion.
    /// </summary>
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string name)
            {
                // Your logic to return the image based on the name and address.
                if (name == "Mount Sinai Hospital")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_1.jpg", UriKind.Relative));
                else if (name == "NewYork-Presbyterian Hospital")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_2.jpg", UriKind.Relative));
                else if (name == "NYU Langone Health")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_3.jpg", UriKind.Relative));
                else if (name == "Lenox Hill Hospital")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_4.jpg", UriKind.Relative));
                else if (name == "Bellevue Hospital Center")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_5.jpg", UriKind.Relative));
                else if (name == "Mount Sinai West")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_6.jpg", UriKind.Relative));
                else if (name == "Mount Sinai Beth Israel")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_7.jpg", UriKind.Relative));
                else if (name == "Hospital for Special Surgery")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_1.jpg", UriKind.Relative));
                else if (name == "Memorial Sloan Kettering Cancer Center")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_2.jpg", UriKind.Relative));
                else if (name == "New York Eye and Ear Infirmary of Mount Sinai")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_3.jpg", UriKind.Relative));
                else if (name == "St. Luke's Roosevelt Hospital Center")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_4.jpg", UriKind.Relative));
                else if (name == "Bronx-Lebanon Hospital Center")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_5.jpg", UriKind.Relative));
                else if (name == "Jamaica Hospital Medical Center")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_6.jpg", UriKind.Relative));
                else if (name == "Flushing Hospital Medical Center")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_7.jpg", UriKind.Relative));
                else if (name == "Kings County Hospital Center")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_1.jpg", UriKind.Relative));
                else if (name == "The Brown Palace Hotel and Spa")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_2.jpg", UriKind.Relative));
                else if (name == "Hyatt Regency Denver at Colorado Convention Center")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_3.jpg", UriKind.Relative));
                else if (name == "The Ritz-Carlton, Denver")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_4.jpg", UriKind.Relative));
                else if (name == "Kimpton Hotel Born")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_5.jpg", UriKind.Relative));
                else if (name == "The Oxford Hotel")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_6.jpg", UriKind.Relative));
                else if (name == "Hotel Teatro")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_7.jpg", UriKind.Relative));
                 else if (name == "Le Méridien Denver Downtown")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_1.jpg", UriKind.Relative));
                 else if (name == "JW Marriott Denver Cherry Creek")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_2.jpg", UriKind.Relative));
                 else if (name == "Halcyon, a hotel in Cherry Creek")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_3.jpg", UriKind.Relative));
                 else if (name == "Kimpton Hotel Monaco Denver")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_4.jpg", UriKind.Relative));
                 else if (name == "Four Seasons Hotel Denver")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_5.jpg", UriKind.Relative));
                 else if (name == "The Crawford Hotel")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_6.jpg", UriKind.Relative));
                 else if (name == "The Maven Hotel at Dairy Block")
                    return new BitmapImage(new Uri("/syncfusion.mapdemos.wpf;component/Assets/Map/Images/hospital_7.jpg", UriKind.Relative));

            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
