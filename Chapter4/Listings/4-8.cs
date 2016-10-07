using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.Portal;
using Microsoft.SharePoint.Portal.Audience;
using System.Collections;

namespace SPSMyAudiences
{

    [DefaultProperty(""),
        ToolboxData("<{0}:Membership runat=server></{0}:Membership>"),
        XmlRoot(Namespace="SPSMyAudiences")]
    public class Membership : Microsoft.SharePoint.WebPartPages.WebPart
    {

        protected override void RenderWebPart(HtmlTextWriter output)
        {

            try
            {
                //Get the portal context
                SPSite portal =
                new SPSite(Page.Request.Url.GetLeftPart(UriPartial.Authority));
                PortalContext context = PortalApplication.GetContext(portal.ID);

                //Get the list of audiences for the user
                AudienceManager manager = new AudienceManager(context);
                ArrayList audienceIDList = manager.GetUserAudienceIDs();

                if(audienceIDList != null)
                {
                   IEnumerator audienceNameIDs = audienceIDList.GetEnumerator();

                    output.Write("<div class=\"ms-sectionheader\">");
                    while(audienceNameIDs.MoveNext())
                    {
                        output.Write(
                          ((AudienceNameID)audienceNameIDs.Current).AudienceName
                          + "<br>");
                    }
                    output.Write("</div>");
                }
            }

            catch (Exception x)
            {
                output.Write("<p>" + x.Message + "</p>");
            }
        }
    }
}
