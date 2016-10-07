using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;

namespace SiteListsHost
{

	[DefaultProperty(""),
	ToolboxData("<{0}:Container runat=server></{0}:Container>"),
	XmlRoot(Namespace="SiteListsHost")]
	public class Container : Microsoft.SharePoint.WebPartPages.WebPart
	{

		//Holder for User Control
		protected SiteLists.WebUserControl1 tree;

		protected override void CreateChildControls()
		{
			//Load the User Control
			tree = (SiteLists.WebUserControl1)Page.LoadControl("/WebFormsUserControls/SiteLists/WebUserControl1.ascx");
			Controls.Add(tree);		  
		}

		protected override void RenderWebPart(HtmlTextWriter output)
		{
			//Render the User Control
			tree.RenderControl(output);
		}
	}
}
