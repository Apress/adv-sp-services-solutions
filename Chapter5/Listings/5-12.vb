Public ReadOnly Property SmartTagName(ByVal SmartTagID As Integer) As String Implements Microsoft.Office.Interop.SmartTag.ISmartTagRecognizer.SmartTagName
    Get
        Return "http://schemas.microsoft.com/InformationBridge/2004#reference"
    End Get
End Property
