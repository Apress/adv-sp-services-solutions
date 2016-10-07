using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;

namespace MySearchResults
{

    [DefaultProperty(""),
    ToolboxData("<{0}:ResultSet runat=server></{0}:ResultSet>"),
    XmlRoot(Namespace="MySearchResults")]
    public class ResultSet :
    Microsoft.SharePoint.Portal.WebControls.SearchResults
    {

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            base.RenderWebPart(output);
        }
    }
}
