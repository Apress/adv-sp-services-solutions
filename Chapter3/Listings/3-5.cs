using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;

using System.Collections;

//Key Points
// 1. Reference System.Collections
// 2. Must have an excluded path for the ASCX files
// 3. Deploy the assembly in the \bin directory

namespace WebFormsUserControlHost
{

    [DefaultProperty("ControlPath"),
    ToolboxData("<{0}:Host runat=server></{0}:Host>"),
    XmlRoot(Namespace="WebFormsUserControlHost")]
    public class Host : Microsoft.SharePoint.WebPartPages.WebPart
    {

        private string path = "";

        [Browsable(true),
            Category("Miscellaneous"),
            DefaultValue(""),
            WebPartStorage(Storage.Shared),
            FriendlyName("Web Forms User Control Path"),
            Description("The URL of the User Control to display.")]
        public string ControlPath
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }


        Label messages = new Label();

        protected override void CreateChildControls()
        {
            try
            {
                Controls.Add(messages);
                Controls.Add(Page.LoadControl(ControlPath));
            }
            catch (Exception x)
            {
                messages.Text = x.Message;
            }
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {

            IEnumerator controls = Controls.GetEnumerator();
            controls.Reset();
            while (controls.MoveNext())
            {
                try
                {
                    if (!controls.Current.Equals(messages))
                     ((UserControl)controls.Current).RenderControl(output);
                }
                catch (Exception x)
                {
                    messages.Text += x.Message;
                }
            }
            output.Write("<br>");
            messages.RenderControl(output);
        }
    }
}
