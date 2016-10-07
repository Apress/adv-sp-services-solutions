Imports System
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Xml.Serialization
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Utilities
Imports Microsoft.SharePoint.WebPartPages
Imports Microsoft.Web.UI.WebControls
Imports Microsoft.SharePoint.Portal
Imports Microsoft.SharePoint.Portal.Topology
Imports Microsoft.SharePoint.Portal.SiteData
Imports System.Web
Imports Microsoft.SharePoint.WebControls

<DefaultProperty("WSSMode"), ToolboxData("<{0}:Lister runat=server></{0}:Lister>"), XmlRoot(Namespace:="SPSTreeNav")> _
Public Class Lister
    Inherits Microsoft.SharePoint.WebPartPages.WebPart

    'Member Variables
    Private objTree As TreeView
    Private lblMessages As Label
    Private objCurrentWeb As SPWeb
    Private m_WSSMode As Boolean = False
    Private m_Red As Integer = 234
    Private m_Green As Integer = 234
    Private m_Blue As Integer = 234
    Private m_FontName As String = "arial"
    Private m_FontSize As String = "9pt"
    Private m_NewWindow As Boolean = False

    <Browsable(True), Category("Tree View"), DefaultValue(False), _
    WebPartStorage(Storage.Shared), FriendlyName("WSSMode"), Description( _
    "Sets the display mode of the tree.")> _
    Property WSSMode() As Boolean
        Get
            Return m_WSSMode
        End Get

        Set(ByVal Value As Boolean)
            m_WSSMode = Value
        End Set
    End Property

    <Browsable(True), Category("Tree View"), DefaultValue(234), _
    WebPartStorage(Storage.Shared), FriendlyName("Background Red"), Description( _
    "Red portion of RGB background color.")> _
    Property Red() As Integer
        Get
            Return m_Red
        End Get

        Set(ByVal Value As Integer)
            m_Red = Value
        End Set
    End Property

    <Browsable(True), Category("Tree View"), DefaultValue(234), _
    WebPartStorage(Storage.Shared), FriendlyName("Background Green"), _
    Description("Green portion of RGB background color.")> _
    Property Green() As Integer
        Get
            Return m_Green
        End Get

        Set(ByVal Value As Integer)
            m_Green = Value
        End Set
    End Property

    <Browsable(True), Category("Tree View"), DefaultValue(234), _
    WebPartStorage(Storage.Shared), FriendlyName("Background Blue"), _
    Description("Blue portion of RGB background color.")> _
    Property Blue() As Integer
        Get
            Return m_Blue
        End Get

        Set(ByVal Value As Integer)
            m_Blue = Value
        End Set
    End Property

    <Browsable(True), Category("Tree View"), DefaultValue("arial"), _
    WebPartStorage(Storage.Shared), FriendlyName("Font Name"), Description( _
    "Name of the display font.")> _
    Property FontName() As String
        Get
            Return m_FontName
        End Get

        Set(ByVal Value As String)
            m_FontName = Value
        End Set
    End Property

    <Browsable(True), Category("Tree View"), DefaultValue("9pt"), _
    WebPartStorage(Storage.Shared), FriendlyName("Font Size"), Description( _
    "Size of the display font.")> _
    Property FontSize() As String
        Get
            Return m_FontSize
        End Get

        Set(ByVal Value As String)
            m_FontSize = Value
        End Set
    End Property

    <Browsable(True), Category("Tree View"), DefaultValue(False), _
    WebPartStorage(Storage.Shared), FriendlyName("New Window"), _
    Description( _
    "Determines is a new window is opened when a listing link is clicked.")> _
    Property NewWindow() As Boolean
        Get
            Return m_NewWindow
        End Get

        Set(ByVal Value As Boolean)
            m_NewWindow = Value
        End Set
    End Property

    Protected Overrides Sub CreateChildControls()
        'Add Tree
        objTree = New TreeView
        objTree.BackColor = System.Drawing.Color.FromArgb(Red, Green, Blue)
        objTree.DefaultStyle.Add("font-family", FontName)
        objTree.DefaultStyle.Add("font-size", FontSize)
        Controls.Add(objTree)

        'Add message label
        lblMessages = New Label
        Controls.Add(lblMessages)
    End Sub

    Private Function AddSubAreasAndListings( _
ByVal objParentNode As Object, _
ByVal objParentArea As Area) As Boolean

        Try

            Dim blnReturn As Boolean = False

            'Add the sub areas under the parent area
            For Each objSubArea As Area In objParentArea.Areas
                If objSubArea.AreaTemplate = "SPSTOPIC" Then
                    Dim objAreaNode As New TreeNode
                    With objAreaNode
                        .Text = objSubArea.Title
                        .NavigateUrl = _
                        System.Web.HttpUtility.UrlPathEncode(objSubArea.WebUrl)
                        .ImageUrl = "/_layouts/images/cat.gif"
                        If WSSMode = False _
                        AndAlso Page.Request.Url.AbsolutePath.IndexOf( _
                        HttpUtility.UrlPathEncode(objSubArea.WebUrl)) = 0 Then
                            objAreaNode.Expanded = True
                            objAreaNode.DefaultStyle.Add("font-weight", "bold")
                            blnReturn = True
                        ElseIf WSSMode = True _
                        AndAlso Page.Request.UrlReferrer.AbsolutePath.IndexOf( _
                        HttpUtility.UrlPathEncode(objSubArea.WebUrl)) = 0 Then
                            objAreaNode.Expanded = True
                            objAreaNode.DefaultStyle.Add("font-weight", "bold")
                            blnReturn = True
                        End If

                    End With
                    objParentNode.Nodes.Add(objAreaNode)

                    'Recursively add additional sub areas and listings
                    If AddSubAreasAndListings(objAreaNode, objSubArea) = True Then
                        objAreaNode.Expanded = True
                        blnReturn = True
                    End If
                End If
            Next

            'Add the portal listings for this area
            For Each objListing As AreaListing In objParentArea.Listings
                If objListing.Type = ListingType.Site _
                Or objListing.Type = ListingType.TeamSite Then
                    Dim objListingNode As New TreeNode
                    With objListingNode
                        .Text = objListing.Title
                        .NavigateUrl = objListing.URL
                        .ImageUrl = "/_layouts/images/link.gif"
                        If NewWindow = True Then .Target = "_BLANK"
                    End With
                    objParentNode.Nodes.Add(objListingNode)
                End If
            Next

            Return blnReturn

        Catch x As Exception
            lblMessages.Text += x.Message
        End Try

    End Function

    Private Sub AddSubSites( _
ByVal objParentNode As TreeNode, ByVal objParentWeb As SPWeb)

        Try

            Dim objWebs As SPWebCollection = objParentWeb.GetSubwebsForCurrentUser()

            For Each objWeb As SPWeb In objWebs

                'Add Node
                Dim objNode As New TreeNode
                With objNode
                    .Text = objWeb.Title
                    .ImageUrl = "/_layouts/images/asp16.gif"
                    .NavigateUrl = objWeb.Url
                End With
                objParentNode.Nodes.Add(objNode)

                'Recurse sub nodes
                AddSubSites(objNode, objWeb)

            Next

        Catch x As Exception
            lblMessages.Text += x.Message
        End Try

    End Sub

    Protected Overrides Sub RenderWebPart( _
    ByVal output As System.Web.UI.HtmlTextWriter)
        Try

            'Get portal home Area
            Dim objPortalSite As New _
            SPSite(Page.Request.Url.GetLeftPart(UriPartial.Authority))
            Dim objContext As PortalContext = _
            PortalApplication.GetContext(objPortalSite.ID)
            Dim PortalGuid As Guid = _
            AreaManager.GetSystemAreaGuid(objContext, SystemArea.Home)
            Dim objPortalArea As Area = AreaManager.GetArea(objContext, PortalGuid)

            'Add the portal home Area to the tree
            Dim objPortalNode As New TreeNode
            With objPortalNode
                .Text = objPortalArea.Title
                .NavigateUrl = objPortalArea.WebUrl
                .ImageUrl = "/_layouts/images/sphomesm.gif"
                .Expanded = True
            End With
            objTree.Nodes.Add(objPortalNode)

            'Add sub areas and listings
            If AddSubAreasAndListings(objPortalNode, objPortalArea) = True Then
                objPortalNode.Expanded = True
            End If

            'Add the WSS Site Collection to the tree
            If WSSMode = True Then

                'Get this web
                Dim objSite As SPSite = SPControl.GetContextSite(Context)
                Dim objSiteWeb As SPWeb = objSite.OpenWeb()

                'Add it to tree
                Dim objSiteNode As New TreeNode
                With objSiteNode
                    .Text = objSiteWeb.Title
                    .NavigateUrl = objSiteWeb.Url
                    .ImageUrl = "/_layouts/images/globe.gif"
                    .DefaultStyle.Add("font-weight", "bold")
                    .Expanded = True
                End With
                objPortalNode.Nodes.Add(objSiteNode)

                'Add sub sites
                AddSubSites(objSiteNode, objSiteWeb)

            End If

        Catch x As Exception
            lblMessages.Text += x.Message
        End Try

        'Draw Controls
        objTree.RenderControl(output)
        lblMessages.RenderControl(output)

    End Sub

End Class
