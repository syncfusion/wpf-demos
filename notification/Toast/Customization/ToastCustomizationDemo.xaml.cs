#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.SfToastNotification;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for ToastCustomizationDemo.xaml
    /// </summary>
    public partial class ToastCustomizationDemo : DemoControl
    {
        public ToastCustomizationDemo()
        {
            InitializeComponent();
            this.DataContext = new ToastCustomizationViewModel();

            // Recalculate subtotal when controls change
            FoodCombo.SelectionChanged += (s, e) => UpdateSubtotal();
            QtyBox.TextChanged += (s, e) => UpdateSubtotal();
            AddonExtraCheese.Checked += (s, e) => UpdateSubtotal();
            AddonExtraCheese.Unchecked += (s, e) => UpdateSubtotal();
            AddonSpicy.Checked += (s, e) => UpdateSubtotal();
            AddonSpicy.Unchecked += (s, e) => UpdateSubtotal();
            AddonCutlery.Checked += (s, e) => UpdateSubtotal();
            AddonCutlery.Unchecked += (s, e) => UpdateSubtotal();

            UpdateSubtotal();
        }

        // ---- Helpers -------------------------------------------------------

        private (string ItemName, decimal UnitPrice) GetSelectedFood()
        {
            var content = (FoodCombo.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Item";
            // Expect format: "<name> — $<price>" or legacy "— ₹<price>". Safely parse.
            var dashIndex = content.LastIndexOf('—');
            var name = dashIndex > 0 ? content.Substring(0, dashIndex).Trim() : content;
            decimal price = 0m;
            var dollarIdx = content.LastIndexOf('$');
            var rupeeIdx = content.LastIndexOf('₹');
            if (dollarIdx >= 0)
            {
                var priceStr = content.Substring(dollarIdx + 1).Trim();
                decimal.TryParse(priceStr, NumberStyles.Number, CultureInfo.InvariantCulture, out price);
            }
            else if (rupeeIdx >= 0)
            {
                var priceStr = content.Substring(rupeeIdx + 1).Trim();
                decimal.TryParse(priceStr, NumberStyles.Number, CultureInfo.InvariantCulture, out price);
            }
            return (name, price);
        }

        private int ParseQty()
        {
            if (int.TryParse(QtyBox.Text, out var q) && q > 0) return q;
            return 1;
        }

        private decimal ComputeSubtotal()
        {
            var (name, price) = GetSelectedFood();
            var qty = ParseQty();
            decimal addons = 0m;
            if (AddonExtraCheese.IsChecked == true) addons += 2.50m;
            if (AddonSpicy.IsChecked == true) addons += 0.75m;
            // Cutlery free
            return (price * qty) + addons;
        }

        private void UpdateSubtotal()
        {
            SubtotalText.Text = $"${ComputeSubtotal():0.00}";
        }

        private static string PaymentMethodString(bool upi, bool card, bool cod)
        {
              if (upi) return "PayPal";
            if (card) return "Card";
              return "Cash";
        }

        private static Brush TryBrush(string code, string fallback)
        {
            try
            {
                return (Brush)new BrushConverter().ConvertFromString(code);
            }
            catch
            {
                return (Brush)new BrushConverter().ConvertFromString(fallback);
            }
        }

        // ---- Actions -------------------------------------------------------

        private void OnPayClick(object sender, RoutedEventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(NameBox.Text)
                || string.IsNullOrWhiteSpace(PhoneBox.Text)
                || string.IsNullOrWhiteSpace(AddressBox.Text)
                || string.IsNullOrWhiteSpace(CityBox.Text)
                || string.IsNullOrWhiteSpace(PincodeBox.Text))
            {
                MessageBox.Show("Please fill in Name, Phone, Address, City and ZIP.", "Missing info", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Compose order data
            var (itemName, unitPrice) = GetSelectedFood();
            var qty = ParseQty();
            var extras = new StringBuilder();
            if (AddonExtraCheese.IsChecked == true) extras.Append(" + extra cheese");
            if (AddonSpicy.IsChecked == true) extras.Append(" + spicy");
            if (AddonCutlery.IsChecked == true) extras.Append(" + eco cutlery");

            var subtotal = ComputeSubtotal();
            var orderId = DateTime.Now.ToString("HHmmss", CultureInfo.InvariantCulture); // simple demo order no.

            // ETA window (e.g., 30–45 mins)
            var start = DateTime.Now.AddMinutes(30);
            var end = DateTime.Now.AddMinutes(45);

            // Build the multiline message that our ContentTemplate will display nicely
            // Use bullet-like separators for readability
            var sb = new StringBuilder();
            sb.AppendLine($"• Items : {itemName} ×{qty}{extras}");
            sb.AppendLine($"• Address: {AddressBox.Text}, {CityBox.Text} {PincodeBox.Text}");
            sb.AppendLine($"• Contact: {NameBox.Text} ({PhoneBox.Text})");
            sb.AppendLine($"• Payment: {PaymentMethodString(PayUPI.IsChecked == true, PayCard.IsChecked == true, PayCOD.IsChecked == true)}");
            sb.AppendLine($"• Total : ${subtotal:0.00}");

            // Create toast
            var options = new ToastOptions
            {
                Title =$"Order #{orderId}\n" + $"Delivery today {start:hh:mm tt}–{end:hh:mm tt}",
                Header = string.Empty,
                Message = sb.ToString(),
                Mode = ToastMode.Window,
                ShowCloseButton = false,
                ShowActionButtons = true,
                PreventAutoClose = true,
               
                TitleTemplate = (DataTemplate)TryFindResource("TitleTemplate_OrderConfirm"),
                ContentTemplate = (DataTemplate)TryFindResource("ContentTemplate_OrderConfirm"),
                CloseButtonTemplate = (DataTemplate)TryFindResource("CloseButtonTemplate_Fluent"),
               
            };
            List<ToastAction> actions = new System.Collections.Generic.List<ToastAction>
            {
                // Capture title/header/message so callbacks can forward the toast item to VM commands
                new ToastAction("Track order", "track"){ Callback = () => OnToastActionClicked("track", options.Title, options.Header, options.Message) },
                new ToastAction("View receipt", "view"){ Callback = () => OnToastActionClicked("view", options.Title, options.Header, options.Message) },
                new ToastAction("Dismiss", "dismiss"){ Callback = () => OnToastActionClicked("dismiss", options.Title, options.Header, options.Message) }
            };
            options.Actions = actions;


            SfToastNotification.Show(this, options);
        }

        private void OnResetClick(object sender, RoutedEventArgs e)
        {
            FoodCombo.SelectedIndex = 0;
            QtyBox.Text = "1";
            AddonExtraCheese.IsChecked = false;
            AddonSpicy.IsChecked = false;
            AddonCutlery.IsChecked = false;

            NameBox.Text = string.Empty;
            PhoneBox.Text = string.Empty;
            AddressBox.Text = string.Empty;
            CityBox.Text = "Springfield, IL";
            PincodeBox.Text = "62704";

            PayUPI.IsChecked = true;
            PayCard.IsChecked = false;
            PayCOD.IsChecked = false;

            UpdateSubtotal();
        }

        // Route action clicks (from ToastAction Arguments) to ViewModel commands
        private void OnToastActionClicked(string actionKey, string title = null, string header = null, string message = null)
        {
            try
            {
                if (string.IsNullOrEmpty(actionKey))
                    return;

                var vm = this.DataContext as ToastCustomizationViewModel;
                // Build a lightweight toast item object with Title/Header/Message so VM can reflect over it
                var toastItem = new { Title = title, Header = header, Message = message } as object;
                switch (actionKey.ToLowerInvariant())
                {
                    case "track":
                        vm?.TrackOrderCommand?.Execute(toastItem);
                        break;
                    case "view":
                        vm?.ViewReceiptCommand?.Execute(toastItem);
                        break;
                    case "close":
                    case "dismiss":
                        SfToastNotification.CloseAll();
                        break;
                }
            }
            catch
            {
            }
        }

    }
}
