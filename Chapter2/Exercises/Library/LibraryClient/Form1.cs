using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.IO;
using System.Xml;

namespace LibraryClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnUpload;
		private System.Windows.Forms.TextBox txtProperty;
		private System.Windows.Forms.OpenFileDialog openDialog;
		private System.Windows.Forms.Label lblProject;
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
			this.btnUpload = new System.Windows.Forms.Button();
			this.txtProperty = new System.Windows.Forms.TextBox();
			this.openDialog = new System.Windows.Forms.OpenFileDialog();
			this.lblProject = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnUpload
			// 
			this.btnUpload.Location = new System.Drawing.Point(24, 72);
			this.btnUpload.Name = "btnUpload";
			this.btnUpload.TabIndex = 0;
			this.btnUpload.Text = "Upload";
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			// 
			// txtProperty
			// 
			this.txtProperty.Location = new System.Drawing.Point(16, 32);
			this.txtProperty.Name = "txtProperty";
			this.txtProperty.Size = new System.Drawing.Size(304, 20);
			this.txtProperty.TabIndex = 1;
			this.txtProperty.Text = "";
			// 
			// lblProject
			// 
			this.lblProject.Location = new System.Drawing.Point(16, 16);
			this.lblProject.Name = "lblProject";
			this.lblProject.Size = new System.Drawing.Size(100, 16);
			this.lblProject.TabIndex = 2;
			this.lblProject.Text = "Project:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 273);
			this.Controls.Add(this.lblProject);
			this.Controls.Add(this.txtProperty);
			this.Controls.Add(this.btnUpload);
			this.Name = "Form1";
			this.Text = "Library Web Service Client";
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

		private void btnUpload_Click(object sender, System.EventArgs e)
		{

			//Get Document to upload
			if(openDialog.ShowDialog() != DialogResult.OK)return;

			//Load File into a byte array
			FileStream stream = new FileStream(openDialog.FileName, 
				FileMode.Open, FileAccess.Read);
			BinaryReader reader = new BinaryReader(stream);
			byte [] fileBuffer = reader.ReadBytes((int)stream.Length);
			reader.Close();
			stream.Close();

			//Build parameters
			string siteRef = "http://spsdevelopment/sites/DocumentWebService";
			string listName = "Shared Documents";
			string fileName = openDialog.FileName.Substring(
				openDialog.FileName.LastIndexOf("\\")+1);
			XmlDocument xmlDoc = new XmlDocument();
			XmlNode fields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
			fields.InnerXml = "<Field Name='Project'>" + txtProperty.Text + "</Field>";

			//Call web service
			LibraryService.DocService service = new LibraryService.DocService();
			string returnString = service.Upload(
				siteRef,listName,fileName,fileBuffer,fields);
			MessageBox.Show(returnString);

		}

	}
}
