Private Function GetAreaByURL( _
ByVal strURL As String, ByVal objAreas As AreaCollection) As Area

    Try

        Dim objReturnArea As Area = Nothing

        'Find the Area matching the given URL
        For Each objSubArea As Area In objAreas
            If objSubArea.AreaTemplate = "SPSTOPIC" AndAlso _
            strURL.IndexOf(objSubArea.WebUrl) = 0 Then
                objReturnArea = objSubArea
                Exit For
            Else
                Dim objSubSubArea = GetAreaByURL(strURL, objSubArea.Areas)
                If Not (objSubSubArea Is Nothing) Then
                    objReturnArea = objSubSubArea
                    Exit For
                End If
            End If
        Next

        Return objReturnArea

    Catch x As Exception
        Return Nothing
    End Try

End Function
