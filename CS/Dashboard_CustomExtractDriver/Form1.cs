using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;

namespace Dashboard_CustomExtractDriver {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();
            ExtractDriverStorage.DefaultDriver = new ExtractEncryptionDriver();

            DashboardSqlDataSource sqlDataSource = new DashboardSqlDataSource();
            sqlDataSource.DataProcessingMode = DataProcessingMode.Client;
            Access2007ConnectionParameters connectionParams = new Access2007ConnectionParameters(@"..\..\Data\Northwind.accdb", "");
            sqlDataSource.ConnectionParameters = connectionParams;

            SelectQuery selectQuery = SelectQueryFluentBuilder
                .AddTable("Invoices")
                .SelectColumns("ExtendedPrice", "Quantity", "OrderDate", "ProductName")
                .Build("Query 1");
            sqlDataSource.Queries.Add(selectQuery);
            sqlDataSource.Fill();   

            DashboardExtractDataSource extractDataSource = new DashboardExtractDataSource();
            extractDataSource.ExtractSourceOptions.DataSource = sqlDataSource;
            extractDataSource.ExtractSourceOptions.DataMember = "Query 1";
            extractDataSource.FileName = @".\InvoicesExtract.dat";
            extractDataSource.UpdateExtractFile();

            Dashboard dashboard = new Dashboard();
            dashboard.DataSources.Add(extractDataSource);

            PivotDashboardItem pivot = new PivotDashboardItem();
            pivot.DataSource = extractDataSource;
            pivot.Values.AddRange(new Measure("ExtendedPrice"), new Measure("Quantity"));
            pivot.Columns.Add(new Dimension("OrderDate", DateTimeGroupInterval.Year));
            pivot.Rows.Add(new Dimension("ProductName"));  
            dashboard.Items.Add(pivot);

            dashboardViewer1.Dashboard = dashboard;
        }
    }
}
