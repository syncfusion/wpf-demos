#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.gridcontroldemos.wpf
{
    public interface IExcelExport
    {
        void Initialize();
        void FillData();
        void ExportFullRange();
        void ExportSelectedRange();
        void ExportWithChart();
        void ExportUsingEngine();
    }
}
