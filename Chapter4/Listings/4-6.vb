Private strTrail As String = ""

Protected Overrides Sub RenderWebPart(ByVal output As System.Web.UI.HtmlTextWriter)

    Try

        Dim objWeb As SPWeb = SPControl.GetContextWeb(Context)
        strTrail = objWeb.Title
        BuildTrail(objWeb)
        output.Write(strTrail)

    Catch x As Exception
        strTrail += "<p>" & x.Message & "</p><br>"
    End Try

End Sub

Private Sub BuildTrail(ByVal objWeb As SPWeb)

    Try

        If objWeb.IsRootWeb = False Then
            'Show the Parent Web
            strTrail = _
            "<a href='" & objWeb.ParentWeb.Url & "'>" _
            & objWeb.ParentWeb.Title _
            & "</a><img src='/_layouts/images/blk_rgt.gif'>" & strTrail

            'Recurse
            BuildTrail(objWeb.ParentWeb)
        End If

    Catch x As Exception
        strTrail += "<p>" & x.Message & "</p><br>"
    End Try

End Sub
