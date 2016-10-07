function AddSharePointReferences(oProj)
{
    var refmanager = GetCSharpReferenceManager(oProj);
    var bExpanded = IsReferencesNodeExpanded(oProj);

    refmanager.Add("System.Xml");

    try
    {
        var ref = refmanager.Add("Microsoft.SharePoint.dll");
        ref.CopyLocal = false;
    }
    catch(e)
    {
        var sharePointRefMissingError =
        "The path to Microsoft.SharePoint.dll was not found.";
        wizard.ReportError(sharePointRefMissingError);
    }
    if(!bExpanded)
        CollapseReferencesNode(oProj);
}
