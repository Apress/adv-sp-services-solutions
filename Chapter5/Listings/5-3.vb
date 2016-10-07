'IBF-Compliant VB.NET WebMethod
<WebMethod()> _
Public Function GetCompany( _
    <XmlElement(ElementName:="CompanyName", Namespace:="CustomerData")> _
    ByVal objReference As CompanyName) _
    As <XmlElement(ElementName:="Company", Namespace:="CustomerData")> Company
