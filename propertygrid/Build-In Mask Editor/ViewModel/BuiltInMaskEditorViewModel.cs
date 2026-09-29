using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace syncfusion.propertygriddemos.wpf
{
    public class BuiltInMaskEditorViewModel : NotificationObject
    {
        #region Properties
        private BuiltInMask builtInMask;

        public BuiltInMask BuiltInMask
        {
            get
            {
                return builtInMask;
            }
            set
            {
                builtInMask = value;
                this.RaisePropertyChanged(() => this.BuiltInMask);
            }
        }
        #endregion

        public BuiltInMaskEditorViewModel()
        {
            BuiltInMask = new BuiltInMask();
            BuiltInMask.AlphanumericMaskProperty="0ac53gd6X7";
            BuiltInMask.BinaryMaskProperty="0101101";
            BuiltInMask.CardNumberMaskProperty="9845183784636238";
            BuiltInMask.EmailIdMaskProperty="johnabc@";
            BuiltInMask.FractionMaskProperty="89/536";
            BuiltInMask.HexaDecimalMaskProperty="x120";
            BuiltInMask.IPv4MaskProperty="627813646358";
            BuiltInMask.IPv6MaskProperty="88258353252027232926925428247186";
            BuiltInMask.MobileNumberMaskProperty="456789356";
            BuiltInMask.NumberMaskProperty="-8728";
            BuiltInMask.OctalMaskProperty="/012";
            BuiltInMask.PositiveNumberMaskProperty="3721972";
            BuiltInMask.ProductKeyMaskProperty="HTY23OPY678GR56R01G564GH";
        }
    }
}