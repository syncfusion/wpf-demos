using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.PropertyGrid;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.propertygriddemos.wpf
{
    public class CategoryEditorViewModel : NotificationObject
    {       
        private ICommand loadCommand;

        public CategoryEditorViewModel()
        {
            loadCommand = new DelegateCommand<object>(InitilizeSettings);
        }

        public ICommand LoadCommand
        {
            get
            {
                return loadCommand;
            }
        }

        private void InitilizeSettings(object sender)
        {
            var propertygrid = sender as PropertyGrid;
            if (propertygrid == null)
                return;
            HideProperties(propertygrid, typeof(TextBlock));
        }

        private void HideProperties(PropertyGrid propertygrid, Type type)
        {
            var p = (PropertyDescriptorCollection)TypeDescriptor.GetProperties(type);
            foreach (PropertyDescriptor item in p)
            {
                if (item.Category == "Action" || item.Category == "Behavior" || item.Category == "Layout"
                    || item.Category == "Touch")
                {
                    propertygrid.HidePropertiesCollection.Add(item.Name);
                }
            }
        }
    }
}
