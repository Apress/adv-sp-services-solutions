For Each objMatch As Match In objMatches

    Dim strMatchedTerm As String = objMatch.Groups("term").Value
    Dim intTagLength As Integer = strTerms(i).Length
    Dim intIndexOfMatch As Integer = _
      Text.ToUpper(CultureInfo.CurrentCulture).IndexOf( _
      strTerms(i).ToUpper(CultureInfo.CurrentCulture), _
      objMatch.Index, objMatch.Length)

    'Context string to invoke IBF
    Dim strContextString As String = _
      String.Format(COMPANY_CONTEXT_XML, strTerms(i))

    'Format the strings
    Dim strTermFormatted As String = _
      HttpUtility.HtmlEncode(strTerms(i))
    Dim strContext As String = _
      String.Format(CultureInfo.CurrentCulture, _
      strContextString, strTermFormatted)

    'Write the tag
    Dim objPropertyBag As ISmartTagProperties = _
      RecognizerSite2.GetNewPropertyBag()
    objPropertyBag.Write("data", strContext)
    RecognizerSite2.CommitSmartTag( _
      "http://schemas.microsoft.com/InformationBridge/2004#reference", _
      intIndexOfMatch + 1, intTagLength, objPropertyBag)

Next
