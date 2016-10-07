[WebMethod]
[return:XmlArray]
public Customer [] GetCustomers(
    [XmlElement(ElementName="CompanyName",Namespace="CustomerData")]
    CompanyName reference)
    {
    try
    {
      //Build query
      string sql = 
      "SELECT dbo.Contact.Last_Name + ', ' + dbo.Contact.First_Name AS Name, " +
      "dbo.Contact.Job_Title AS Title, dbo.Contact.Phone, dbo.Contact.Email " +
      "FROM dbo.Contact INNER JOIN dbo.Company " +
      "ON dbo.Contact.Company_Id = dbo.Company.Company_Id " +
      "WHERE (dbo.Company.Company_Name = '" + reference.Name + "')";

      string conn =
      "Password=;User ID=sa;Initial Catalog=MyDatabase;Data Source=(local);";

        //Execute query
        SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);
        DataSet root = new DataSet("root");
        adapter.Fill(root,"results");
        DataTable results = root.Tables["results"];

        //Build array for results
        Customer [] customers = new Customer[results.Rows.Count];
        int i=0;

        //Populate array
        foreach(DataRow row in results.Rows)
        {
            customers[i] = new Customer();
            customers[i].Name = row.ItemArray[0].ToString();
            customers[i].Title = row.ItemArray[1].ToString();
            customers[i].Phone = row.ItemArray[2].ToString();
            customers[i].Email = row.ItemArray[3].ToString();
            i++;
        }

        //Return results
        return customers;
    }

    catch(Exception x)
    {
        Customer [] error = new Customer[1];
        error[0] = new Customer();
        error[0].Name = "Error";
        error[0].Title = x.Message;
        return error;
    }
}
