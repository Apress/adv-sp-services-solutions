using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace IBFPubsUI
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class UserControl1 : System.Windows.Forms.UserControl, Microsoft.InformationBridge.Framework.Interfaces.IRegion
	{
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserControl1()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// UserControl1
			// 
			this.Controls.Add(this.label1);
			this.Name = "UserControl1";
			this.ResumeLayout(false);

		}
		#endregion

		//Implement this interface
		public Microsoft.InformationBridge.Framework.Interfaces.IRegionFrameProxy
			HostProxy
		{
			set
			{
			}
		}

		public System.Xml.XmlNode Data
		{
			set
			{
				try
				{
					label1.Text="";

					XmlNode books = (XmlNode)value;
					foreach (XmlNode book in books.ChildNodes)
					{
						foreach(XmlNode info in book.ChildNodes)
						{
							label1.Text += info.InnerText + "\n";
						}
					}
				}
				catch(Exception x)
				{
					label1.Text = x.Message;
				}
			}
		}

		public Microsoft.InformationBridge.Framework.Interfaces.FrameType
			HostType
		{
			set
			{
			}
		}

		public Microsoft.InformationBridge.Framework.Interfaces.IVisualStyles
			VisualStyle
		{
			set
			{
			}
		}

	}
}
