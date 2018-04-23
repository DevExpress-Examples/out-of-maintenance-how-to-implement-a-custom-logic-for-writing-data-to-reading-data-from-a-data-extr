Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.XtraEditors

Namespace Dashboard_CustomExtractDriver
    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            ExtractDriverStorage.DefaultDriver = New ExtractEncryptionDriver()

            Dim sqlDataSource As New DashboardSqlDataSource()
            sqlDataSource.DataProcessingMode = DataProcessingMode.Client
            Dim connectionParams As New Access2007ConnectionParameters("..\..\Data\Northwind.accdb", "")
            sqlDataSource.ConnectionParameters = connectionParams

            Dim selectQuery As SelectQuery = SelectQueryFluentBuilder.AddTable("Invoices").
                SelectColumns("ExtendedPrice", "Quantity", "OrderDate", "ProductName").Build("Query 1")
            sqlDataSource.Queries.Add(selectQuery)
            sqlDataSource.Fill()

            Dim extractDataSource As New DashboardExtractDataSource()
            extractDataSource.ExtractSourceOptions.DataSource = sqlDataSource
            extractDataSource.ExtractSourceOptions.DataMember = "Query 1"
            extractDataSource.FileName = ".\InvoicesExtract.dat"
            extractDataSource.UpdateExtractFile()

            Dim dashboard As New Dashboard()
            dashboard.DataSources.Add(extractDataSource)

            Dim pivot As New PivotDashboardItem()
            pivot.DataSource = extractDataSource
            pivot.Values.AddRange(New Measure("ExtendedPrice"), New Measure("Quantity"))
            pivot.Columns.Add(New Dimension("OrderDate", DateTimeGroupInterval.Year))
            pivot.Rows.Add(New Dimension("ProductName"))
            dashboard.Items.Add(pivot)

            dashboardViewer1.Dashboard = dashboard
        End Sub
    End Class
End Namespace
