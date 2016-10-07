using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Data.SqlClient;
using System.Net;
using System.Xml;

namespace Site_Explorer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView treeView1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(8, 8);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(272, 256);
			this.treeView1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.treeView1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			string conn = 
				"Integrated Security=SSPI;" +
				"Initial Catalog=DataLanC1_Site" +
				";Data Source=spspdc";

			string sql = "SELECT Title, FullUrl " + 
				"FROM dbo.Webs " + 
				"WHERE (ParentWebId IS NULL) AND (FullUrl <> '') " + 
				"AND (FullUrl IS NOT NULL) " + 
				"ORDER BY Title";

			try
			{
				//Return the sites
				SqlDataAdapter adapter = new SqlDataAdapter();
				SqlConnection connection = new SqlConnection(conn);
				DataSet dataSet = new DataSet("root");
				adapter.SelectCommand = new SqlCommand(sql,connection);
				adapter.Fill(dataSet,"Sites");

				//Put top-level sites in tree
				DataRowCollection siteRows = dataSet.Tables["Sites"].Rows;

				foreach(DataRow siteRow in siteRows)
				{
					TreeNode treeNode = new TreeNode();
					treeNode.Text = siteRow["Title"].ToString();
					treeNode.Tag = "http://[ServerName]/" +
						siteRow["FullUrl"].ToString();
					treeView1.Nodes.Add(treeNode);
					fillTree(treeNode);
				}
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}

		}

		private void fillTree(TreeNode parent)
		{
			//Redirect web service
			SPSService.Webs service = new SPSService.Webs();
			service.Url = parent.Tag.ToString() + "/_vti_bin/Webs.asmx";
			service.Credentials = CredentialCache.DefaultCredentials;

			//Get child webs
			XmlNode nodes = service.GetWebCollection();

			//Add child webs to tree
			foreach(XmlNode node in nodes)
			{
				TreeNode child = new TreeNode();
				child.Text = node.Attributes["Title"].Value;
				child.Tag = node.Attributes["Url"].Value;
				parent.Nodes.Add(child);
				fillTree(child);

			}
		}
	}
}
