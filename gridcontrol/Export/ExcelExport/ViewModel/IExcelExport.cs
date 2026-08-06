
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
