using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.Data.SqlClient;

namespace IBFPubsService
{
	[WebService(Namespace="PubsService")]
	public class Service1 : System.Web.Services.WebService
	{
		public Service1()
		{
			InitializeComponent();
		}

		#region Component Designer generated code

		private IContainer components = null;

		private void InitializeComponent()
		{
		}

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
		[return:XmlArray]
		public Book [] GetBooks(
			[XmlElement(ElementName="Author",Namespace="PubsData")]
			Author author)
		{
			try
			{
				//Build query
				string sql =
					"SELECT dbo.titles.title, dbo.publishers.pub_name AS Publisher "
					+ "FROM dbo.publishers INNER JOIN "
					+ "dbo.titles ON dbo.publishers.pub_id = dbo.titles.pub_id "
					+ "INNER JOIN "
					+ "dbo.titleauthor ON dbo.titles.title_id = dbo.titleauthor.title_id "
					+ "INNER JOIN "
					+ "dbo.authors ON dbo.titleauthor.au_id = dbo.authors.au_id "
					+ "WHERE (dbo.authors.au_lname = '" + author.LastName + "')";

				string conn =
					"Password=;User ID=sa;Initial Catalog=pubs;Data Source=(local);";

				//Execute query
				SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);
				DataSet root = new DataSet("root");
				adapter.Fill(root,"details");
				DataTable details = root.Tables["details"];

				//Build array for results
				Book [] books = new Book[details.Rows.Count];
				int i=0;

				//Populate array
				foreach(DataRow row in details.Rows)
				{
					books[i] = new Book();
					books[i].Title = row.ItemArray[0].ToString();
					books[i].Publisher = row.ItemArray[1].ToString();
					i++;
				}

				//Return results
				return books;
			}

			catch(Exception x)
			{
				Book [] errorsBook = new Book[1];
				errorsBook[0] = new Book();
				errorsBook[0].Title = "Error";
				errorsBook[0].Publisher = x.Message;
				return errorsBook;
			}
		}
	}

	//Author element
	[XmlRoot(Namespace="PubsData",IsNullable=false)]
	public class Author
	{
		string lastName;

		public string LastName
		{
			get{return lastName;}
			set{lastName = value;}
		}
	}

	//Book element
	[XmlRoot(Namespace="PubsData",IsNullable=false)]
	public class Book
	{
		string title;
		string publisher;

		public string Title
		{
			get{return title;}
			set{title = value;}
		}

		public string Publisher
		{
			get{return publisher;}
			set{publisher = value;}
		}
	}

}
