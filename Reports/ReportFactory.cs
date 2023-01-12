using DevExpress.XtraReports.UI;

namespace PrintShopDesigns.Reports
{
        public static class ReportsFactory
        {
            public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
            {
                ["MaterialsReport"] = () => new MaterialsReport()
            };
        }
}
