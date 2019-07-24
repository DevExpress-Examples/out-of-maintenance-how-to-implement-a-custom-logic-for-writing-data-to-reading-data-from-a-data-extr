using DevExpress.DashboardCommon;
using DevExpress.DataAccess.Excel;
using DevExpress.XtraEditors;
using System;

namespace Dashboard_CustomExtractDriver
{
    public partial class Form1 : XtraForm {
        const string extractFileNamePattern = "\"Extract_\"yyyyMMddHHmmssfff\".dat\"";
        public Form1()
        {
            InitializeComponent();
            ExtractDriverStorage.DefaultDriver = new ExtractEncryptionDriver();

            DashboardExtractDataSource extractDataSource = new DashboardExtractDataSource();
            extractDataSource.ExtractSourceOptions.DataSource = CreateExcelDataSource();
            extractDataSource.FileName = DateTime.Now.ToString(extractFileNamePattern);
            extractDataSource.UpdateExtractFile();

            dashboardViewer1.Dashboard = CreateDashboard(extractDataSource);
        }

        private static Dashboard CreateDashboard(DashboardExtractDataSource extractDataSource)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.DataSources.Add(extractDataSource);
            PivotDashboardItem pivot = new PivotDashboardItem();
            pivot.DataSource = extractDataSource;
            pivot.Values.AddRange(new Measure("Extended Price"), new Measure("Quantity"));
            pivot.Columns.Add(new Dimension("OrderDate", DateTimeGroupInterval.Year));
            pivot.Rows.Add(new Dimension("ProductName"));
            dashboard.Items.Add(pivot);
            return dashboard;
        }

        private static DashboardExcelDataSource CreateExcelDataSource()
        {
            DashboardExcelDataSource excelDataSource = new DashboardExcelDataSource()
            {
                FileName = @"Data\SalesPerson.xlsx",
                SourceOptions = new ExcelSourceOptions()
                {
                    ImportSettings = new ExcelWorksheetSettings("Data")
                }
            };
            excelDataSource.Fill();
            return excelDataSource;
        }
    }
}
