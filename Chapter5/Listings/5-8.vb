Public WriteOnly Property Data() As System.Xml.XmlNode Implements _
Microsoft.InformationBridge.Framework.Interfaces.IRegion.Data

    Set(ByVal Value As System.Xml.XmlNode)

        'Save XML input
        Dim objData As XmlNode = Value

        'Display values
        If objData("Name") Is Nothing Then
            lblName.Text = String.Empty
        Else
            lblName.Text = objData("Name").InnerText
        End If
        If objData("Address1") Is Nothing Then
            lblAddress1.Text = String.Empty
        Else
            lblAddress1.Text = objData("Address1").InnerText
        End If
        If objData("Address2") Is Nothing Then
            lblAddress2.Text = String.Empty
        Else
            lblAddress2.Text = objData("Address2").InnerText
        End If
        If objData("City") Is Nothing Then
            lblCityStateZip.Text = String.Empty
        Else
            lblCityStateZip.Text = objData("City").InnerText
        End If
        If Not (objData("State") Is Nothing) Then
            lblCityStateZip.Text += ", " & objData("State").InnerText
        End If
        If Not (objData("Zip") Is Nothing) Then
            lblCityStateZip.Text += " " & objData("Zip").InnerText
        End If
     End Set
End Property
