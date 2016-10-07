Option Explicit On 
Option Strict On
Option Compare Text

Imports System
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Xml.Serialization
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Utilities
Imports Microsoft.SharePoint.WebPartPages
Imports Microsoft.Web.UI.WebControls

<DefaultProperty(""), ToolboxData("<{0}:Builder runat=server></{0}:Builder>"), XmlRoot(Namespace:="SPSSimpleToolbar")> _
Public Class Builder
    Inherits Microsoft.SharePoint.WebPartPages.WebPart

    Private WithEvents objToolbar As Toolbar
    Private objBoldButton As ToolbarCheckButton
    Private objItalicButton As ToolbarCheckButton
    Private objUnderlineButton As ToolbarCheckButton
    Private objNameListButton As New ToolbarDropDownList
    Private objSizeListButton As New ToolbarDropDownList
    Private objText As TextBox

    Protected Overrides Sub CreateChildControls()

        'Create parent toolbar
        objToolbar = New Toolbar
        With objToolbar
            .AutoPostBack = True
            .Width = New Unit(100, UnitType.Percentage)
        End With

        'Create font style buttons
        objBoldButton = New ToolbarCheckButton
        With objBoldButton
            .ImageUrl = "/_layouts/1033/images/bold.gif"
            .ID = "BoldButton"
        End With
        objToolbar.Items.Add(objBoldButton)

        objItalicButton = New ToolbarCheckButton
        With objItalicButton
            .ImageUrl = "/_layouts/1033/images/italic.gif"
            .ID = "ItalicButton"
        End With
        objToolbar.Items.Add(objItalicButton)

        objUnderlineButton = New ToolbarCheckButton
        With objUnderlineButton
            .ImageUrl = "/_layouts/1033/images/rteundl.gif"
            .ID = "UnderlineButton"
        End With
        objToolbar.Items.Add(objUnderlineButton)

        'Create font name list
        objNameListButton = New ToolbarDropDownList
        With objNameListButton
            .Items.Add("Arial")
            .Items.Add("Courier")
            .ID = "NameList"
        End With
        objToolbar.Items.Add(objNameListButton)

        'Create font size list
        objSizeListButton = New ToolbarDropDownList
        With objSizeListButton
            .Items.Add("8")
            .Items.Add("9")
            .Items.Add("10")
            .Items.Add("11")
            .Items.Add("12")
            .ID = "SizeList"
        End With
        objToolbar.Items.Add(objSizeListButton)

        Controls.Add(objToolbar)

        'Create TextArea
        objText = New TextBox
        With objText
            .TextMode = TextBoxMode.MultiLine
            .Width = New Unit(100, UnitType.Percentage)
            .Height = New Unit(200, UnitType.Pixel)
            .Columns = 40
            .Rows = 10
        End With

        Controls.Add(objText)

    End Sub

    Protected Overrides Sub RenderWebPart(ByVal output As System.Web.UI.HtmlTextWriter)

      With objText
        .Font.Bold = objBoldButton.Selected
        .Font.Italic = objItalicButton.Selected
        .Font.Underline = objUnderlineButton.Selected
        .Font.Name = objNameListButton.SelectedItem.ToString
        .Font.Size = New FontUnit(CInt(objSizeListButton.SelectedItem.ToString))
      End With

        objToolbar.RenderControl(output)
        objText.RenderControl(output)

    End Sub

End Class
