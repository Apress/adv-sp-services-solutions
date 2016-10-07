namespace SiteLists
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Microsoft.SharePoint;
	using Microsoft.SharePoint.Utilities;
	using Microsoft.SharePoint.WebPartPages;
	using Microsoft.SharePoint.WebControls;
	using Microsoft.Web.UI.WebControls;

	public class WebUserControl1 : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected Microsoft.Web.UI.WebControls.TreeView TreeView1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{

				//get this web
				Label1.Text = "";
				SPSite site = SPControl.GetContextSite(Context);
				SPWeb web = site.OpenWeb();

				//add tree root
				TreeNode root = new TreeNode();
				root.Text = web.Title;
				root.ImageUrl = "/_layouts/images/globe.gif";
				root.Expanded = true;
				TreeView1.Nodes.Clear();
				TreeView1.Nodes.Add(root);

				//add documents node
				TreeNode docs = new TreeNode();
				docs.Text = "Libraries";
				docs.ImageUrl = "/_layouts/images/folder16.gif";
				root.Nodes.Add(docs);

				//add tasks node
				TreeNode tasks = new TreeNode();
				tasks.Text = "Task Lists";
				tasks.ImageUrl = "/_layouts/images/taskpane.gif";
				root.Nodes.Add(tasks);

				//add others node
				TreeNode others = new TreeNode();
				others.Text = "Other Lists";
				others.ImageUrl = "";
				root.Nodes.Add(others);

				//add lists to the tree
				SPListCollection lists = web.Lists;

				foreach (SPList list in lists)
				{
					TreeNode node = new TreeNode();

					switch(list.BaseTemplate)
					{
						case SPListTemplateType.DocumentLibrary:
							node.Text = list.Title;
							node.ImageUrl = "/_layouts/images/doc16.gif";
							node.NavigateUrl = list.DefaultViewUrl;
							docs.Nodes.Add(node);
							break;

						case SPListTemplateType.Tasks:
							node.Text = list.Title;
							node.ImageUrl = "/_layouts/images/check.gif";
							node.NavigateUrl = list.DefaultViewUrl;
							tasks.Nodes.Add(node);
							break;

						default:
							node.Text = list.Title;
							node.ImageUrl = "/_layouts/images/list.gif";
							node.NavigateUrl = list.DefaultViewUrl;
							others.Nodes.Add(node);
							break;

					}
				}
			}
			catch(Exception x)
			{
				Label1.Text = x.Message;
			}
		}
	}
}
