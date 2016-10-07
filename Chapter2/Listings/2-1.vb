Private Const SHAREPOINT_ROOT As String = "http://myserver/"

Private Sub FillList()

    'List all of the word documents in SharePoint
    Dim strConnection As String = "Integrated Security=SSPI;" & _
    "Initial Catalog=MyContentDatabase;Data Source=MySQLServer;"

    Dim strSQL As String = "SELECT CONVERT(nvarchar(36), Id) AS ID," & _
    " '" & SHAREPOINT_ROOT & "' + DirName + '/' + LeafName AS Name " & _
    "FROM dbo.Docs " & _
    "WHERE (LeafName NOT LIKE 'template%') AND " & _
    "LeafName LIKE '%.doc' " & _
    "ORDER BY DirName, LeafName"

    Try

        Dim objDataset As New DataSet("root")

        'Run Query
        With New SqlDataAdapter
            .SelectCommand = New SqlCommand(strSQL, _
            New SqlConnection(strConnection))
            .Fill(objDataset, "Docs")
        End With

        'Fill List
        lstDocs.DataSource = objDataset.Tables("Docs")
        lstDocs.DisplayMember = "Name"
        lstDocs.ValueMember = "ID"

    Catch x As Exception
        MsgBox(x.Message, MsgBoxStyle.Exclamation)
    End Try

End Sub
