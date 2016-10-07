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

        //Property members
        protected string m_sqlServer;
        protected string m_database;
        protected string m_userName;
        protected string m_password;

         [Browsable(true), Category("Miscellaneous"), 
        DefaultValue(""),Description("The server where the database resides"),
        FriendlyName("SQL Server"),WebPartStorageAttribute(Storage.Shared)] 
        public string sqlServer 
        {
            get
            {
                return m_sqlServer;
            }

            set
            {
                m_sqlServer = value;
            }
        }

        [Browsable(true), Category("Miscellaneous"), 
        DefaultValue(""),Description("The name of the database"),
        FriendlyName("Database"),WebPartStorageAttribute(Storage.Shared)] 
        public string database 
        {
            get
            {
                return m_database;
            }

            set
            {
                m_database = value;
            }
        }

         [Browsable(true), Category("Miscellaneous"), 
        DefaultValue(""),Description("The account to access the database"),
        FriendlyName("Username"),WebPartStorageAttribute(Storage.Shared)] 
        public string userName 
        {
            get
            {
                return m_userName;
            }

            set
            {
                m_userName = value;
            }
        }

        [Browsable(true), Category("Miscellaneous"), 
        DefaultValue(""),Description("The password for the account"),
        FriendlyName("Password"),WebPartStorageAttribute(Storage.Shared)] 
        public string password 
        {
            get
            {
                return m_password;
            }

            set
            {
                m_password = value;
            }
        }

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
            //Run Query
            report.ConnectionString = "User ID=" + userName +
                ";Password=" + password +
                ";Data Source=" + sqlServer +
                ";Initial Catalog=" + database;

            report.runQuery();

            //Render the User Control
            report.RenderControl(output);
        }
    }
}
