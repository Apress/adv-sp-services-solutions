using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebControls;
using Microsoft.Web.UI.WebControls;

namespace SPSSubSiteTreeView
{

    [DefaultProperty(""),
        ToolboxData("<{0}:Builder runat=server></{0}:Builder>"),
        XmlRoot(Namespace="SPSSubSiteTreeView")]
    public class Builder : Microsoft.SharePoint.WebPartPages.WebPart
    {

        TreeView tree;

        protected override void CreateChildControls()
        {
            tree = new TreeView();
            Controls.Add(tree);
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            //get this web
            SPSite site = SPControl.GetContextSite(Context);
            SPWeb web = site.OpenWeb();

            //add tree root
            TreeNode root = new TreeNode();
            root.Text = web.Title;
            root.ImageUrl = "/_layouts/images/globe.gif";
            root.Expanded = true;
            tree.Nodes.Add(root);

            //add children
            addChildNodes(root,web);

            //display tree
            tree.RenderControl(output);
        }

        private void addChildNodes(TreeNode parentNode, SPWeb parentWeb)
        {
            //get child webs
            SPWebCollection webs = parentWeb.GetSubwebsForCurrentUser();

            foreach(SPWeb sub in webs)
            {
                //add to tree
                TreeNode node = new TreeNode();
                node.Text = sub.Title;
                node.ImageUrl = "/_layouts/images/asp16.gif";
                node.NavigateUrl = sub.Url;
                node.Target = "";
                parentNode.Nodes.Add(node);

                //recurse
                addChildNodes(node,sub);
            }
        }
    }
}
