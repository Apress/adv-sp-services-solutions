//Returning an XmlArray in C#
[WebMethod]
[return:XmlArray]
public Company [] GetCompanies(
    [XmlElement(ElementName="CompanyName",Namespace="CustomerData")]
    CompanyName reference)
