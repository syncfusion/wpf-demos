#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace TreeContextMenuDemo
{
    public class ViewModel : NotificationObject
    {

        public ViewModel()
        {
            Models = new ObservableCollection<IFileItem>();
            Folder mod = new Folder() { Caption = "Windows Explorer" };

            Folder mainmodel1 = new Folder() { Caption = "My Computer", Parent = mod };

            Folder model1 = new Folder() { Caption = "Music", Parent = mainmodel1 };
            Folder model2 = new Folder() { Caption = "Videos", Parent = mainmodel1 }; ;
            File model3 = new File() { Caption = "Wallpaper.png", Parent = mainmodel1 };
            File model4 = new File() { Caption = "Banner.png", Parent = mainmodel1 };

            mainmodel1.SubFolders.Add(model1);
            mainmodel1.SubFolders.Add(model2);
            mainmodel1.SubFolders.Add(model3);
            mainmodel1.SubFolders.Add(model4);
            Folder mainmodel2 = new Folder() { Caption = "My Network Places", Parent = mod };

            Folder model5 = new Folder() { Caption = "Sever", Parent = mainmodel2 };
            Folder model6 = new Folder() { Caption = "My Folders", Parent = mainmodel2 };
            File model7 = new File() { Caption = "Image1.png", Parent = mainmodel2 };
            File model8 = new File() { Caption = "Image2.png", Parent = mainmodel2 };

            mainmodel2.SubFolders.Add(model5);
            mainmodel2.SubFolders.Add(model6);
            mainmodel2.SubFolders.Add(model7);
            mainmodel2.SubFolders.Add(model8);
            Folder mainmodel3 = new Folder() { Caption = "Favourites", Parent = mod };

            File model9 = new File() { Caption = "Image3.png", Parent = mainmodel3 };
            File mode20 = new File() { Caption = "Image4.png", Parent = mainmodel3 };
            File mode21 = new File() { Caption = "Image5.png", Parent = mainmodel3 };

            mainmodel3.SubFolders.Add(model9);
            mainmodel3.SubFolders.Add(mode20);
            mainmodel3.SubFolders.Add(mode21);

            mod.SubFolders.Add(mainmodel1);
            mod.SubFolders.Add(mainmodel2);
            mod.SubFolders.Add(mainmodel3);

          
            Models.Add(mod);
        }

        private ObservableCollection<IFileItem> models;

        public ObservableCollection<IFileItem> Models
        {
            get { return models; }
            set { models = value; }
        }



        
    }


    public class BooleanToVisibilityConverter : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter != null && parameter.Equals("TEXTBOX"))
            {
                if ((bool)value)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            else
            {
                if ((bool)value)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
