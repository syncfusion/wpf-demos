#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.SfSkinManager;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for ReceiptWindow.xaml
    /// </summary>
    public partial class ReceiptWindow : Window
    {
        public ReceiptWindow(string titleLine, string details, string themeName)
        {
            SfSkinManager.SetTheme(this, new Theme(themeName));
            InitializeComponent();

            // Title comes as: "#12345   •   Delivery today 01:29 PM–01:44 PM"
            var (orderId, eta) = SplitTitle(titleLine);
            OrderTitleText.Text = orderId;            // e.g., "#12345"
            EtaText.Text = eta;                // e.g., "Delivery today 01:29 PM–01:44 PM"

            // Details are the bullets: Items, Address, Contact, Payment, Total
            DetailsText.Text = details;

            // Parse values we want to reflect on the right card:
            var total = ExtractTotal(details);        // decimal? or string if parse fails
            GrandTotalValue.Text = total.Display;

            // (Optional) quick demo math: split a tax out if we parsed a number
            if (total.Value.HasValue)
            {
                // 5% of base as tax just for display demo
                var tax = Math.Round(total.Value.Value * 0.05m, 2);
                var baseAmount = total.Value.Value - tax;
                SubtotalValue.Text = $"₹{baseAmount:N2}";
                TaxValue.Text = $"₹{tax:N2}";
            }

            // Payment mode from the details bullets (line starts with "• Payment:")
            var pay = ExtractLine(details, "Payment");
            PaymentModeText.Text = string.IsNullOrWhiteSpace(pay) ? "—" : pay;

            // Tweak window title with order id
            this.Title = $"Receipt {orderId}";
        }

        private static (string OrderId, string Eta) SplitTitle(string title)
        {
            // Expected format: "#ID   •   ETA TEXT"
            var idx = title.IndexOf('•');
            if (idx >= 0)
            {
                var id = title.Substring(0, idx).Trim();
                var start = idx + 1;
                var eta = start < title.Length ? title.Substring(start).Trim() : string.Empty;
                return (id, eta);
            }
            return (title, string.Empty);
        }

        private static (decimal? Value, string Display) ExtractTotal(string details)
        {
            // Look for a line like: "• Total : ₹199" (allow spaces)
            var line = ExtractLine(details, "Total");
            if (!string.IsNullOrWhiteSpace(line))
            {
                // Extract digits and decimal separator
                var m = Regex.Match(line, @"₹\s*([0-9]+(?:\.[0-9]{1,2})?)");
                if (m.Success && decimal.TryParse(m.Groups[1].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v))
                {
                    return (v, $"₹{v:N2}");
                }
                // Fallback: show whatever we found on that line
                return (null, line.Replace("•", "").Trim());
            }
            return (null, "₹—");
        }

        private static string ExtractLine(string details, string key)
        {
            // Returns the full bullet line that starts with "• <key>"
            var lines = (details ?? string.Empty)
                        .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                        .Select(l => l.Trim());
            var match = lines.FirstOrDefault(l => l.StartsWith($"• {key}", StringComparison.OrdinalIgnoreCase));
            if (match == null) return string.Empty;

            // Return the text after the bullet (for clean display in badges)
            var idx = match.IndexOf(':');
            return idx > 0
                ? (idx + 1 < match.Length ? match.Substring(idx + 1).Trim() : string.Empty)
                : match;

        }

        private void OnCloseClick(object sender, RoutedEventArgs e) => Close();

        private void OnPrintClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new PrintDialog();
                if (dlg.ShowDialog() == true)
                {
                    // Print entire window surface for a quick demo print
                    dlg.PrintVisual(this.Content as Visual, this.Title);
                }
            }
            catch
            {
                MessageBox.Show("Printing failed or was canceled.",
                                "Print", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
