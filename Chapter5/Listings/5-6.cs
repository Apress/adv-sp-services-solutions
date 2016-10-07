[WebMethod][return:XmlArray]
public Customer [] TestGetCustomers(string reference)
{
    CompanyName companyName = new CompanyName();
    companyName.Name=reference;
    return GetCustomers(companyName);
}
