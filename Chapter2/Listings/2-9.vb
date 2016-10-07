Dim objService As New MyService.Lists
objService.Url = "http://Server_Name/Site_Path/_vti_bin/Lists.asmx"
objService.Credentials = System.Net.CredentialCache.DefaultCredentials

Dim objDocument As New XmlDocument

Dim objQuery As XmlNode
objQuery = objDocument.CreateNode(XmlNodeType.Element, "Query", "")
objQuery.InnerXml = "<OrderBy><FieldRef Name='Title'></FieldRef></OrderBy>"

Dim objFields As XmlNode
objFields = objDocument.CreateNode(XmlNodeType.Element, "ViewFields", "")
objFields.InnerXml = "<FieldRef Name='Title'/>"

Dim objCAML As XmlNode
objCAML = objService.GetListItems _
(MyLists.SelectedItem.ToString, Nothing, objQuery, objFields, Nothing, Nothing)

For Each objNode As XmlNode In objCAML.ChildNodes(1).ChildNodes
    If Not (objNode.Attributes Is Nothing) AndAlso _
            Not (objNode.Attributes("ows_Title") Is Nothing) Then
        MyDocs.Items.Add(objNode.Attributes("ows_Title").Value)
    End If
Next

