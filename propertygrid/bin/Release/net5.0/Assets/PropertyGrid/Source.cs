#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
    [Editor(typeof(string), typeof(TextBoxEditor))]
    [Editor(typeof(DateTime), typeof(DateTimeEditor))]
    [Editor(typeof(Gender), typeof(EnumComboEditor))]
    [Editor(typeof(Brush), typeof(BrushSelectorEditor))]
    [Editor(typeof(IEnumerable), typeof(ITypeItemsSourceControl))]
    [Editor(typeof(bool), typeof(CheckBoxEditor))]
    [Editor(typeof(long), typeof(IntegerTextBoxEditor))]
    [MaskAttribute(MaskAttribute.EmailId, "Email")]
    [Editor(typeof(double), typeof(DoubleTextBoxEditor))]
    [Editor(typeof(TimeSpan), typeof(TimeSpanEditor))]
    public class Person
    {
        public string EmployeeName { get; set; }

        public DateTime DOB { get; set; }

        public Gender Gender { get; set; }

        public Brush FavoriteColor { get; set; }

        public ObservableCollection<CustomerDetails> Customers { get; set; }

        public bool IsLicensed { get; set; }

        public long Mobile { get; set; }

        public string Email { get; set; }

        public double Rating { get; set; }

        public TimeSpan WorkedHours { get; set; }
    }
