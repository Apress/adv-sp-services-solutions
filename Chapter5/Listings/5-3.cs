//IBF-Compliant C# WebMethod
[WebMethod]
[return:XmlElement(ElementName="Company",Namespace="CustomerData")]
public Company GetCompany(
    [XmlElement(ElementName="CompanyName",Namespace="CustomerData")]
    CompanyName reference)
