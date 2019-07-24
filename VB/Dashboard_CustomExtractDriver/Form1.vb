Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.Excel
Imports DevExpress.XtraEditors
Imports System

Namespace Dashboard_CustomExtractDriver
	Partial Public Class Form1
		Inherits XtraForm

		Private Const extractFileNamePattern As String = """Extract_""yyyyMMddHHmmssfff"".dat"""
		Public Sub New()
			InitializeComponent()
			ExtractDriverStorage.DefaultDriver = New ExtractEncryptionDriver()

			Dim extractDataSource As New DashboardExtractDataSource()
			extractDataSource.ExtractSourceOptions.DataSource = CreateExcelDataSource()
			extractDataSource.FileName = Date.Now.ToString(extractFileNamePattern)
			extractDataSource.UpdateExtractFile()

			dashboardViewer1.Dashboard = CreateDashboard(extractDataSource)
		End Sub

		Private Shared Function CreateDashboard(ByVal extractDataSource As DashboardExtractDataSource) As Dashboard
			Dim dashboard As New Dashboard()
			dashboard.DataSources.Add(extractDataSource)
			Dim pivot As New PivotDashboardItem()
			pivot.DataSource = extractDataSource
			pivot.Values.AddRange(New Measure("Extended Price"), New Measure("Quantity"))
			pivot.Columns.Add(New Dimension("OrderDate", DateTimeGroupInterval.Year))
			pivot.Rows.Add(New Dimension("ProductName"))
			dashboard.Items.Add(pivot)
			Return dashboard
		End Function

		Private Shared Function CreateExcelDataSource() As DashboardExcelDataSource
			Dim excelDataSource As New DashboardExcelDataSource() With {
				.FileName = "Data\SalesPerson.xlsx", .SourceOptions = New ExcelSourceOptions() With {.ImportSettings = New ExcelWorksheetSettings("Data")}
			}
			excelDataSource.Fill()
			Return excelDataSource
		End Function
	End Class
End Namespace
