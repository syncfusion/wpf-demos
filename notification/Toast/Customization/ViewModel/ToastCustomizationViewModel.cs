#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Syncfusion.SfSkinManager;

namespace syncfusion.notificationdemos.wpf
{
    internal class ToastCustomizationViewModel
    {


        private sealed class RelayCommand : ICommand
        {
            private readonly Action<object> _exec;
            private readonly Func<object, bool> _can;
            public RelayCommand(Action<object> exec, Func<object, bool> can = null)
            {
                _exec = exec; _can = can;
            }
            public bool CanExecute(object parameter) => _can?.Invoke(parameter) ?? true;
            public void Execute(object parameter) => _exec(parameter);
            public event EventHandler CanExecuteChanged { add { } remove { } }
        }

        // --- Exposed commands for the toast action buttons ---
        public ICommand TrackOrderCommand { get; }
        public ICommand ViewReceiptCommand { get; }

        public ToastCustomizationViewModel()
        {
            TrackOrderCommand = new RelayCommand(OnTrackOrder);
            ViewReceiptCommand = new RelayCommand(OnViewReceipt);
        }

        private void OnTrackOrder(object parameter)
        {
            // parameter will be the toast item if we pass CommandParameter="{Binding}"
            // We'll extract a friendly id from Title if available.
            var (orderId, eta) = ExtractOrderInfo(parameter);
            var status = "• Rider reached restaurant\n• Order picked up\n• Arriving in ~12 mins";
            MessageBox.Show(
                $"Tracking {orderId}\nETA: {eta}\n\n{status}",
                "Live tracking",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }


        private void OnViewReceipt(object parameter)
        {
            var (title, message) = ReadToastStrings(parameter);
            // Title contains "#12345   •   Delivery today 12:50 PM–01:05 PM"
            // Message contains only bullets (items, address, contact, payment, total)
            var owner = Application.Current?.Windows.OfType<Window>()
                             .FirstOrDefault(w => w.IsActive);
            var theme = SfSkinManager.GetTheme(owner);
            var win = new ReceiptWindow(title, message, theme.ThemeName) { Owner = owner };
            win.ShowDialog();
        }

        private static (string title, string message) ReadToastStrings(object toastItem)
        {
            string title = string.Empty, message = string.Empty;
            if (toastItem != null)
            {
                var t = toastItem.GetType();
                title = t.GetProperty("Title")?.GetValue(toastItem) as string ?? string.Empty;
                message = t.GetProperty("Message")?.GetValue(toastItem) as string ?? string.Empty;
            }
            return (title, message);
        }


        // Utility: best-effort extraction of order no. and header/ETA from the toast item
        private static (string orderId, string eta) ExtractOrderInfo(object toastItem)
        {
            // We avoid referencing Syncfusion types directly to keep VM loosely coupled.
            // We’ll use reflection to read common properties Title and Header if present.
            string id = "#<unknown>";
            string header = "<unknown>";

            if (toastItem != null)
            {
                var t = toastItem.GetType();
                var titleProp = t.GetProperty("Title");
                var headerProp = t.GetProperty("Header");
                var titleVal = titleProp?.GetValue(toastItem) as string;
                var headerVal = headerProp?.GetValue(toastItem) as string;

                if (!string.IsNullOrWhiteSpace(titleVal)) id = titleVal;
                if (!string.IsNullOrWhiteSpace(headerVal)) header = headerVal;
            }
            return (id, header);
        }
    }
}
