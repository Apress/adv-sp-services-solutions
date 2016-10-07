Private Sub FillTree(ByVal objParentNode As TreeNode)

    'Get sub webs
    Dim objService As New MyService.Webs
    objService.Url = objParentNode.Tag.ToString & "/_vti_bin/Webs.asmx"
    objService.Credentials = CredentialCache.DefaultCredentials
    Dim objWebNodes As XmlNode = objService.GetWebCollection()

    'Add these webs to the tree and recursively call this routine
    For Each objWebNode As XmlNode In objWebNodes
        Dim objChildNode As New TreeNode
        objChildNode.Text = objWebNode.Attributes("Title").Value
        objChildNode.Tag = objWebNode.Attributes("Url").Value
        objParentNode.Nodes.Add(objChildNode)
        FillTree(objChildNode)
    Next

End Sub
