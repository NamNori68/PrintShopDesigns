using DevExpress.Blazor.Reporting.Controllers;
using DevExpress.Blazor.Reporting.Internal.Services;

namespace PrintShopDesigns_Reports.Controllers {
    public class DownloadExportResultController : DownloadExportResultControllerBase {
        public DownloadExportResultController(ExportResultStorage exportResultStorage) : base(exportResultStorage) {
        }
    }
}