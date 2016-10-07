using Microsoft.SharePoint.Portal;
using Microsoft.SharePoint.Portal.Audience;
using Microsoft.SharePoint.WebPartPages.Communication;
using System.Security;
using System.Data;
using System.Collections;
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;

namespace SPSListByAudience
{

	[DefaultProperty(""),
	ToolboxData("<{0}:Grouper runat=server></{0}:Grouper>"),
	XmlRoot(Namespace="SPSListByAudience")]
	public class Grouper : 
		Microsoft.SharePoint.WebPartPages.WebPart,
		Microsoft.SharePoint.WebPartPages.Communication.IListConsumer
	{
		//member variables
		protected DataTable list;
		protected String [] displayNames;
		protected Label messages;
		protected Boolean isConnected;
		protected int colSpan;

		protected override void CreateChildControls()
		{
			messages = new Label();
			Controls.Add(messages);
		}

		public override void EnsureInterfaces()
		{
			try
			{
				RegisterInterface("AudienceGrouper",
					"IListConsumer",
					WebPart.LimitOneConnection,
					ConnectionRunAt.Server,
					this,"","Get a list from...",
					"Receives a list for grouping.");
			}

			catch(SecurityException e)
			{
				messages.Text += "<p>" + e.Message + "</p>";
			}
		}

		public override ConnectionRunAt CanRunAt()
		{
			return ConnectionRunAt.Server;
		}

		public override void PartCommunicationConnect(string interfaceName,
			WebPart connectedPart, string connectedInterfaceName, ConnectionRunAt runAt)
		{
			if(runAt==ConnectionRunAt.Server)
			{
				EnsureChildControls();
				if(interfaceName=="AudienceGrouper")isConnected=true;
			}
		}

		public void ListProviderInit(object sender,
			ListProviderInitEventArgs listProviderInitEventArgs)
		{
			//Get the display names of the fields
			displayNames = listProviderInitEventArgs.FieldDisplayList;
			colSpan = displayNames.GetLength(0);
		}

		public void PartialListReady(object sender,
			PartialListReadyEventArgs partialListReadyEventArgs)
		{
			// Nothing to do
		}

		public void ListReady(object sender, ListReadyEventArgs listReadyEventArgs)
		{
			list = listReadyEventArgs.List;
		}

		protected override void RenderWebPart(HtmlTextWriter output)
		{
			try
			{
				if(isConnected==true)
				{

					//Write out the column display names
					output.Write("<table border=0 width=\"100%\">");
					output.Write("  <tr>");
					for(int i=displayNames.GetLowerBound(0);
						i<=displayNames.GetUpperBound(0);i++)
					{
						if(displayNames[i]!="Audience")
							output.Write("      <th>" + displayNames[i] + "</th>");
					}

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

						while(audienceNameIDs.MoveNext())
						{

							//Get the set of items for this audience
							String audienceName =
								((AudienceNameID)audienceNameIDs.Current).AudienceName;
							DataView dataView = new DataView(list,
								"Audience='" + audienceName + "'",
								"",DataViewRowState.CurrentRows);

							if (dataView.Count!=0)
							{
								//Write out the audience name
								output.Write(
									"   <tr><td class=\"ms-sectionheader\" colspan=\""
									+ colSpan.ToString() + "\">" + audienceName
									+ "</td></tr>");

								//Write out the rows
								foreach (DataRowView rowView in dataView)
								{
									output.Write("   <tr>");

									//Write out columns
									IEnumerator columns
										= rowView.Row.ItemArray.GetEnumerator();
									while(columns.MoveNext())
									{
										if(columns.Current.ToString()!=audienceName)
											output.Write("      <td>"
												+ columns.Current.ToString() + "</td>");
									}

									output.Write("   </tr>");
								}

							}
						}
					}

					//close the table
					output.Write("</table>");
				}
				else
				{
					messages.Text += "<p>Connect this web part to a list.</p>";
				}

				//Show messages
				messages.RenderControl(output);

			}
			catch(Exception x)
			{
				output.Write("<p>" + x.Message + "</p>");
			}
		}
	}
}
