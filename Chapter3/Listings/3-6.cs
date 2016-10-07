using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;

public class Report : System.Web.UI.UserControl
{
    protected System.Web.UI.WebControls.DataGrid grid;
    protected System.Web.UI.WebControls.Label messages;
    string m_connection = null;

    public string ConnectionString 
    {
        get
        {
            return m_connection;
        }

        set
        {
            m_connection = value;
        }
    }

    public void runQuery()
    {
        try
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            string sqlString = "Select Top 5 * From authors";
            SqlCommand command = new SqlCommand(sqlString,con);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataset = new DataSet("root");
            adapter.Fill(dataset,"authors");

            grid.DataSource = dataset;
            grid.DataMember = "authors";
            grid.DataBind();
        }
        catch (Exception x)
        {
            messages.Text = x.Message;
        }

    }
}
