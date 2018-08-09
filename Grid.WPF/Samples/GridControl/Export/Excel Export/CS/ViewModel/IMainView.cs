
namespace ExcelExport.ViewModel
{
    public interface IMainView
    {
        void Initialize();
        void FillData();
        void ExportFullRange();
        void ExportSelectedRange();
        void ExportWithChart();
        void ExportUsingEngine();
    }
}
