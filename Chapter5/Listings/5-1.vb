'Name Reference
<XmlRoot(Namespace:="CustomerData", IsNullable:=False)> _
Public Class CompanyName

    Dim m_Name As String

    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal Value As String)
            m_Name = Value
        End Set
    End Property

End Class
