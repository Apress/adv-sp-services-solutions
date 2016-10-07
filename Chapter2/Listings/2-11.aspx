<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral,PublicKeyToken=71e9bce111e9429c" %>
<HTML>
   <HEAD>
      <title>POST Form</title>
   </HEAD>
   <body>
      <form
      method="post" action="http://[ServerName]/[SitePath]/_vti_bin/owssvr.dll">
         <SharePoint:FormDigest runat="server"></SharePoint:FormDigest>
      </form>
   </body>
</HTML>
