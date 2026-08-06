using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.ImageEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.imageeditordemos.wpf
{
    public class BannerCreatorViewModel : NotificationObject
    {
        public ICommand CropCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                RaisePropertyChanged("IsEnabled");
            }
        }

        private int index;
        public int SelectedIndex
        {
            get { return index; }
            set
            {
                index = value;
                RaisePropertyChanged("SelectedIndex");
            }
        }


        public BannerCreatorViewModel()
        {
            SelectedIndex = 6;
            IsEnabled = false;
            CropCommand = new DelegateCommand(new Action<object>(PerformCrop));
            CancelCommand = new DelegateCommand(new Action<object>(PerformCancel));
        }


        private void PerformCancel(object obj)
        {
            var imageEditor = obj as SfImageEditor;
            if (imageEditor == null) return;
            imageEditor.ToggleCropping();
            SelectedIndex = 6;
        }

        private void PerformCrop(object obj)
        {
            var imageEditor = obj as SfImageEditor;
            if (imageEditor == null) return;
            imageEditor.Crop(new Rect());
            SelectedIndex = 6;
        }

    }
}