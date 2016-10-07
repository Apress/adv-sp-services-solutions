<%@ Register TagPrefix="cms" Namespace="Microsoft.ContentManagement.WebControls" Assembly="Microsoft.ContentManagement.WebControls, Version=5.0.1200.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Page language="c#" Codebehind="EmployeeProfile.aspx.cs" AutoEventWireup="false" Inherits="CmsSharePointConnector.Templates.EmployeeProfile" %>
<%@ Register TagPrefix="uc1" TagName="CmsSpsConsole" Src="../Console/CmsSpsConsole.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.ContentManagement.SharePoint.WebControls" Assembly="Microsoft.ContentManagement.SharePoint.WebControls, Version=1.0.1000.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EmployeeProfile</title>
		<%

//=========================================================================
//	Microsoft Content Management Server Template File
//
//	 - Add placeholders within the form tag below.
//	 - The register directive above is necessary to tell ASP.NET where to 
//	   find the RobotMetaTag control.
//	 - The RobotMetaTag control renders META tags corresponding to the 
//	   IsRobotIndexable and IsRobotFollowable flags on a page, as well as 
//	   a BASE tag with href set to the URL of the template.
//=========================================================================

%>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<cms:RobotMetaTag runat="server" id="RobotMetaTag1"></cms:RobotMetaTag>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:CmsSpsConsole id="CmsSpsConsole1" runat="server"></uc1:CmsSpsConsole>
			<cc1:SharePointDocumentPlaceholderControl id="SharePointDocumentPlaceholderControl1" style="Z-INDEX: 101; LEFT: 184px; POSITION: absolute; TOP: 16px"
				runat="server" PlaceholderToBind="EmployeeProfile"></cc1:SharePointDocumentPlaceholderControl>
		</form>
	</body>
</HTML>
