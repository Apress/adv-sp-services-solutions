using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

using System.Xml;
using System.Net;
using System.Security.Principal;


namespace Library
{

	public class DocService : System.Web.Services.WebService
	{
		public DocService()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		[WebMethod]
		public string Upload(string siteRef, string listName, string fileName,
			byte[] fileBuffer, XmlNode fields)
			/*
			 * siteRef is format "http://spspdc/sites/test"
			 * listName is in format "Shared Documents"
			 * fileName is format "Document1.doc"
			 * fileBuffer is the document in a byte array
			 * fields is in format 
			 <Fields><Field Name='Title'>My Document</Field>...</Fields>
					*/
		{
			try
			{

				//Log activity
				System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
				log.Source = "Library web service";
				log.WriteEntry("Service running under account "
					+ WindowsIdentity.GetCurrent().Name + ".",
					System.Diagnostics.EventLogEntryType.Information);

				//Build the destination file path
				string fileRef = siteRef + "/" + listName + "/" + fileName;

				//Upload file
				WebClient webClient = new WebClient();
				webClient.Credentials = CredentialCache.DefaultCredentials;
				webClient.UploadData(fileRef,"PUT",fileBuffer);
				log.WriteEntry(fileName + " uploaded to " + listName,
					System.Diagnostics.EventLogEntryType.Information);

				//Connect to the Lists web service for the target site
				SPSService.Lists listService = new SPSService.Lists();
				listService.Url = siteRef + "/_vti_bin/Lists.asmx";
				listService.Credentials = System.Net.CredentialCache.DefaultCredentials;

				//Create the Query for retrieving the recent document
				XmlDocument xmlDoc = new XmlDocument();
				XmlNode query = xmlDoc.CreateNode(XmlNodeType.Element, "Query", "");
				query.InnerXml = "<OrderBy><FieldRef Name='Modified' "
					+ "Ascending='FALSE'></FieldRef></OrderBy>";

				//Return information for the recent document
				XmlNode caml = listService.GetListItems(listName,null,query,null,"1",null);
				string id = caml.ChildNodes[1].ChildNodes[1].Attributes["ows_ID"].Value;

				//Create the Batch CAML element for updating
				XmlNode batch = xmlDoc.CreateNode(XmlNodeType.Element, "Batch", "");

				string temp = "<Method ID='DocService.Upload' Cmd='Update'>";
				temp += "<Field Name='FileRef'>" + fileRef + "</Field>";
				temp += "<Field Name='ID'>" + id + "</Field>";
				foreach(XmlNode field in fields.ChildNodes)
				{
					temp += field.OuterXml;
				}
				temp += "</Method>";
				batch.InnerXml =temp;

				XmlNode xmlReturn= listService.UpdateListItems(listName,batch);
				return xmlReturn.OuterXml;

			}
			catch (Exception x)
			{
				return x.Message;
			}
		}
	}
}
