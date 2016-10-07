using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Portal;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Portal.Search;
using System.Data;
using System.Data.SqlClient;

namespace SPSQueryProvider
{
    [DefaultProperty(""),
    ToolboxData("<{0}:Search runat=server></{0}:Search>"),
    XmlRoot(Namespace="SPSQueryProvider")]
    public class Search : Microsoft.SharePoint.WebPartPages.WebPart
    {

        //GUI elements
        TextBox keywords;
        Button search;
        DataGrid grid;
        Label messages;

        //Search objects
        PortalContext context;
        QueryProvider query;
        DataSet results;

        protected override void OnLoad(System.EventArgs e)
        {
            try
            {
                //Retrieve context for search
                context = PortalApplication.GetContext();
                query = new QueryProvider(context.SearchApplicationName);
            }
            catch
            {
                context=null;
                query=null;
            }
        }

        protected override void CreateChildControls()
        {
            //Build GUI
            keywords = new TextBox();
            Controls.Add(keywords);

            search = new Button();
            search.Text = "Search";
            search.Click += new EventHandler(search_Click);
            Controls.Add(search);

            grid = new DataGrid();
            grid.AutoGenerateColumns = false;
            grid.GridLines = GridLines.None;
            Controls.Add(grid);

            BoundColumn boundColumn = new BoundColumn();
            boundColumn.DataField =
            "urn:schemas-microsoft-com:publishing:CategoryTitle";
            boundColumn.HeaderText = "Category";
            grid.Columns.Add(boundColumn);

            HyperLinkColumn linkColumn = new HyperLinkColumn();
            linkColumn.DataNavigateUrlField = "DAV:href";
            linkColumn.DataTextField =
            "urn:schemas.microsoft.com:fulltextqueryinfo:displaytitle";
            linkColumn.HeaderText = "Title";
            grid.Columns.Add(linkColumn);

            boundColumn = new BoundColumn();
            boundColumn.DataField =
            "urn:schemas.microsoft.com:fulltextqueryinfo:description";
            boundColumn.HeaderText = "Description";
            grid.Columns.Add(boundColumn);

            messages = new Label();
            Controls.Add(messages);

        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            try
            {
                //Bind results
                grid.DataSource = results;
                grid.DataBind();
            }
            catch(Exception x)
            {
                messages.Text += x.Message;
            }

            //Display GUI
            output.Write("<TABLE BORDER=0>");
            output.Write("<TR>");
            output.Write("<TD>");
            keywords.RenderControl(output);
            output.Write("</TD>");
            output.Write("</TR>");
            output.Write("<TR>");
            output.Write("<TD>");
            search.RenderControl(output);
            output.Write("</TD>");
            output.Write("</TR>");
            output.Write("<TR>");
            output.Write("<TD>");
            grid.RenderControl(output);
            output.Write("</TD>");
            output.Write("</TR>");
            output.Write("<TR>");
            output.Write("<TD>");
            messages.RenderControl(output);
            output.Write("</TD>");
            output.Write("</TR>");
            output.Write("</TABLE>");
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                //Execute Query
                results = query.Execute(buildQuery());
            }
            catch(Exception x)
            {
                messages.Text += x.Message;
            }
        }

    }
}
