<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<HTML>
   <HEAD>
      <title>WebForm1</title>
   </HEAD>
   <body>
      <form method="post" action="http://spspdc/sites/test/_vti_bin/owssvr.dll">
      <SharePoint:FormDigest runat="server"></SharePoint:FormDigest>
      <input type="hidden" name="Cmd" value="Save">
      <input type="hidden" name="ID" value="New">
 <input type="hidden" name="List" value="2DBAFFF2-583D-49F4-9546-C80F4B57E58B">
      <input type="text" name="urn:schemas-microsoft-com:office:office#Title">
      <input type="submit" value="Submit">
      <input type="reset" value="Reset">
      </form>
   </body>
</HTML>
