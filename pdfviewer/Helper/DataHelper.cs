#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.pdfviewerdemos.wpf
{
    internal class DataHelper
    {
        // Example XFDF data to illustrate how it can be used in the application while AI get an exception.
        internal string UserDetail1 = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<xfdf xml:space=\"preserve\" xmlns=\"http://ns.adobe.com/xfdf/\">\r\n  <fields>\r\n    <field name=\"name\">\r\n      <value>John</value>\r\n    </field>\r\n    <field name=\"email\">\r\n      <value>john123@gmail.com</value>\r\n    </field>\r\n    <field name=\"gender\">\r\n      <value>Male</value>\r\n    </field>\r\n    <field name=\"dob\">\r\n      <value>Feb/20/2005</value>\r\n    </field>\r\n    <field name=\"state\">\r\n      <value>Alaska</value>\r\n    </field>\r\n    <field name=\"newsletter\">\r\n      <value>On</value>\r\n    </field>\r\n    <field name=\"courses\">\r\n      <value>Machine Learning</value>\r\n    </field>\r\n  </fields>\r\n  <f href=\"\" />\r\n</xfdf>";

        internal string UserDetail2 = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<xfdf xml:space=\"preserve\" xmlns=\"http://ns.adobe.com/xfdf/\">\r\n  <fields>\r\n    <field name=\"name\">\r\n      <value>S David</value>\r\n    </field>\r\n    <field name=\"email\">\r\n      <value>David123@gmail.com</value>\r\n    </field>\r\n    <field name=\"gender\">\r\n      <value>Male</value>\r\n    </field>\r\n    <field name=\"dob\">\r\n      <value>Mar/15/2003</value>\r\n    </field>\r\n    <field name=\"state\">\r\n      <value>New York</value>\r\n    </field>\r\n    <field name=\"newsletter\">\r\n      <value>On</value>\r\n    </field>\r\n    <field name=\"courses\">\r\n      <value>Digital Marketing</value>\r\n    </field>\r\n  </fields>\r\n  <f href=\"\" />\r\n</xfdf>";

        internal string UserDetail3 = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<xfdf xml:space=\"preserve\" xmlns=\"http://ns.adobe.com/xfdf/\">\r\n  <fields>\r\n    <field name=\"name\">\r\n      <value>Alice</value>\r\n    </field>\r\n    <field name=\"email\">\r\n      <value>alice456@gmail.com</value>\r\n    </field>\r\n    <field name=\"gender\">\r\n      <value>Female</value>\r\n    </field>\r\n    <field name=\"dob\">\r\n      <value>Jul/15/1998</value>\r\n    </field>\r\n    <field name=\"state\">\r\n      <value>Texas</value>\r\n    </field>\r\n    <field name=\"newsletter\">\r\n      <value>Off</value>\r\n    </field>\r\n    <field name=\"courses\">\r\n      <value>Cloud Computing</value>\r\n    </field>\r\n  </fields>\r\n  <f href=\"\" />\r\n</xfdf>";
    }
}
