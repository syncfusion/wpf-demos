#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
public class PropertyList
{
    public ObservableCollection<Customers> ObservableCollectionProperty { get; set; }
    public ReadOnlyCollection<Customers> ReadOnlyCollectionProperty { get; }
    public List<Customers> ListProperty { get; set; }
    public int IntProperty { get; set; }
    public int? NullableIntProperty { get; set; }
    public double DoubleProperty { get; set; }
    public double? NullableDoubleProperty { get; set; }
    public bool BoolProperty { get; set; }
    public bool? NullableBoolProperty { get; set; }
    public Gender EnumProperty { get; set; }
    public Gender? NullableEnumProperty { get; set; }
    public DateTime DateTimeProperty { get; set; }
    public DateTime? NullableDateTimeProperty { get; set; }
    public TimeSpan TimeSpanProperty { get; set; }
    public TimeSpan? NullableTimeSpanProperty { get; set; }
    public char CharProperty { get; set; }
    public string StringProperty { get; set; }
    public Brush BrushProperty { get; set; }
    public Color ColorProperty { get; set; }
    public Color? NullableColorProperty { get; set; }
    public decimal DecimalProperty { get; set; }
    public decimal? NullableDecimalProperty { get; set; }
    public long LongProperty { get; set; }
    public long? NullableLongProperty { get; set; }
    public Point PointProperty { get; set; }
    public Point? NullablePointProperty { get; set; }
}