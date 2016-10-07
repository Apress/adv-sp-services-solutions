'Returning an XmlArray in VB.NET
    <WebMethod()> _
    Public Function GetCompanies( _
    <XmlElement(ElementName:="CompanyName", Namespace:="CustomerData")> ByVal _
    objReference As CompanyName) As <XmlArray()> Company()
