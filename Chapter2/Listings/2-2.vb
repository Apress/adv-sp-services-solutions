'Set up the database connection
Dim strConnection As String = "Integrated Security=SSPI;" & _
                              "Initial Catalog=MyContentDatabase;" & _
                              "Data Source=MySQLServer;"
Dim strSQL As String = "SELECT Content FROM dbo.Docs " & _
                       "WHERE Id = '{046921FB-448F-47DA-87DF-1BCC8B85DEAA}'"
Dim objConnection As New SqlConnection(strConnection)
Dim objCommand As New SqlCommand(strSQL, objConnection)
Dim objReader As SqlDataReader

'Create a file name
Dim strDesktop As String = _
System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
Dim strFile As String = strDesktop & "\FileName.doc"

'Create a filesteam
Dim objStream As New FileStream(strFile, FileMode.OpenOrCreate, _
                               FileAccess.Write)
Dim objWriter As New BinaryWriter(objStream)

'Set up the buffer to receive the byte data
Dim intSize As Integer = 8192
Dim bytBuffer(intSize - 1) As Byte
Dim lngIndex As Long
Dim lngReturn As Long

Try

    'Open the connection
    objConnection.Open()
    objReader = objCommand.ExecuteReader(CommandBehavior.SequentialAccess)

    Do While objReader.Read

        lngIndex = 0

        'Read first chunk into the buffer
        lngReturn = objReader.GetBytes(0, lngIndex, bytBuffer, 0, intSize)

        Do While lngReturn = intSize

            'Write out the chunk
            objWriter.Write(bytBuffer)
            objWriter.Flush()

            'Get next chunk
            lngIndex += intSize
            lngReturn = objReader.GetBytes(0, lngIndex, bytBuffer, 0, intSize)

        Loop

        'Write the last chunk to the file
        objWriter.Write(bytBuffer)
        objWriter.Flush()

        'Close the stream
        objWriter.Close()
        objStream.Close()

    Loop

    MsgBox("Content placed on your desktop.", MsgBoxStyle.Information)

Catch x As Exception
    MsgBox(x.Message, MsgBoxStyle.Exclamation)

Finally
    objReader.Close()
    objStream = Nothing
    objConnection.Close()

End Try
