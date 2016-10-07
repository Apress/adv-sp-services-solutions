Private intTerms As Integer
Private strTerms(30) As String 

Public Sub SmartTagInitialize(ByVal ApplicationName As String) Implements _
Microsoft.Office.Interop.SmartTag.ISmartTagRecognizer2.SmartTagInitialize
    strTerms(1) = "Vancouver Print & Copy"
    strTerms(2) = "Southwestern Publishing Company"
    strTerms(3) = "Kirkland Photocopier Sales"
    strTerms(4) = "LA Office Surplus"
    strTerms(5) = "Las Vegas Hotel & Casino"
    strTerms(6) = "Last Chance Printing"
    strTerms(7) = "Long Beach Copy Center"
    strTerms(8) = "Long Island Office Supplies"
    strTerms(9) = "MacDonald & Associates"
    strTerms(10) = "mComputer Plus"
    intTerms = 10
End Sub
