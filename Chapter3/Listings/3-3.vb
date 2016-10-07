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
Imports Microsoft.SharePoint.WebControls
Imports Microsoft.Web.UI.WebControls

<DefaultProperty(""), ToolboxData("<{0}:Builder runat=server></{0}:Builder>"), XmlRoot(Namespace:="SPSTabbedMembers")> _
Public Class Builder
    Inherits Microsoft.SharePoint.WebPartPages.WebPart

    Private WithEvents objTabStrip As TabStrip
    Private WithEvents objMultiPage As MultiPage
    Private lstReaders As ListBox
    Private lstContributors As ListBox
    Private lstAdministrators As ListBox

    Protected Overrides Sub CreateChildControls()

        'TabStrip
        objTabStrip = New TabStrip
        With objTabStrip
            .ID = "MemberTabs"
            .Font.Size = New FontUnit(FontSize.Small)
        End With
        Controls.Add(objTabStrip)

        'MultiPage
        objMultiPage = New MultiPage
        With objMultiPage
            .ID = "MemberPages"
            .Font.Size = New FontUnit(FontSize.Small)
        End With
        objTabStrip.TargetID = objMultiPage.ID
        Controls.Add(objMultiPage)

        'Tabs
        Dim objTab As New Tab
        With objTab
            .Text = "Readers"
        End With
        objTabStrip.Items.Add(objTab)

        Dim objSeparator As New TabSeparator
        With objSeparator
            .Text = "|"
        End With
        objTabStrip.Items.Add(objSeparator)

        objTab = New Tab
        With objTab
            .Text = "Contributors"
        End With
        objTabStrip.Items.Add(objTab)

        objSeparator = New TabSeparator
        With objSeparator
            .Text = "|"
        End With
        objTabStrip.Items.Add(objSeparator)

        objTab = New Tab
        With objTab
            .Text = "Administrators"
        End With
        objTabStrip.Items.Add(objTab)

        'Pages
        lstReaders = New ListBox
        With lstReaders
            .Width = New Unit(100, UnitType.Percentage)
            .Font.Size = New FontUnit(FontSize.Small)
        End With

        Dim objPage As New PageView
        With objPage
            .Controls.Add(lstReaders)
        End With
        objMultiPage.Controls.Add(objPage)

        lstContributors = New ListBox
        With lstContributors
            .Width = New Unit(100, UnitType.Percentage)
            .Font.Size = New FontUnit(FontSize.Small)
        End With

        objPage = New PageView
        With objPage
            .Controls.Add(lstContributors)
        End With
        objMultiPage.Controls.Add(objPage)

        lstAdministrators = New ListBox
        With lstAdministrators
            .Width = New Unit(100, UnitType.Percentage)
            .Font.Size = New FontUnit(FontSize.Small)
        End With

        objPage = New PageView
        With objPage
            .Controls.Add(lstAdministrators)
        End With
        objMultiPage.Controls.Add(objPage)

    End Sub

    Protected Overrides Sub RenderWebPart(ByVal output As System.Web.UI.HtmlTextWriter)

        Dim objSite As SPSite = SPControl.GetContextSite(Context)
        Dim objWeb As SPWeb = objSite.OpenWeb

        'Add Readers
        For Each objUser As SPUser In objWeb.Roles.Item("Reader").Users
            lstReaders.Items.Add(objUser.Name)
        Next

        'Add Contributors
        For Each objUser As SPUser In objWeb.Roles.Item("Contributor").Users
            lstContributors.Items.Add(objUser.Name)
        Next

        'Add Administrators
        For Each objUser As SPUser In objWeb.Roles.Item("Administrator").Users
            lstAdministrators.Items.Add(objUser.Name)
        Next

        'Draw controls
        objTabStrip.RenderControl(output)
        objMultiPage.RenderControl(output)

    End Sub

End Class
