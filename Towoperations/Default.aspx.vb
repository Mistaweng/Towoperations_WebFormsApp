Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'Load up the initial list of items
        Dim strConn As String = ConfigurationManager.ConnectionStrings("tow_conn").ConnectionString
        Dim objConn As New SqlClient.SqlConnection(strConn)
        Dim dst As New DataSet()
        Dim strSQL As String = "Select * From tow_jobs order by CalledInBy;"
        Dim dpt As New SqlClient.SqlDataAdapter(strSQL, objConn)
        dpt.Fill(dst, "ttmpTowJobs")
        Dim tblData As DataTable = dst.Tables("ttmpTowJobs")
        gvmMain.DataSource = tblData
        gvmMain.DataBind()
        objConn.Close()
        tblData.Dispose()
        dpt.Dispose()
        objConn.Dispose()


    End Sub
End Class