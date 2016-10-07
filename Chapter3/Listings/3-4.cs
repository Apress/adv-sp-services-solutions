using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;

namespace SimpleReportHost
{

    [DefaultProperty(""),
    ToolboxData("<{0}:Container runat=server></{0}:Container>"),
    XmlRoot(Namespace="SimpleReportHost")]
    public class Container : Microsoft.SharePoint.WebPartPages.WebPart
    {

        //Holder for User Control
        protected SimpleReport.Report report;

        protected override void CreateChildControls()
        {
            //Load the User Control
            report = (SimpleReport.Report)Page.LoadControl
            ("/WebFormsUserControls/SimpleReport/report.ascx");
            Controls.Add(report);
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            //Render the User Control
            report.RenderControl(output);
        }
    }
}
