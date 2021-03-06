function OnFinish(selProj, selObj)
{
    var oldSuppressUIValue = true;
    try
    {
        oldSuppressUIValue = dte.SuppressUI;

        var strProjectPath = wizard.FindSymbol("PROJECT_PATH");
        var strProjectName = wizard.FindSymbol("PROJECT_NAME");

        var bEmptyProject = 0; //wizard.FindSymbol("EMPTY_PROJECT");

        var proj = CreateCSharpProject(strProjectName, strProjectPath,
        "defaultwebproject.csproj");

        if( !ProjectIsARootWeb( strProjectPath ) )
        {
            wizard.AddSymbol("NOT_ROOT_WEB_APP", true);
        }

        var InfFile = CreateInfFile();
        if (!bEmptyProject && proj)
        {
            AddReferencesForWebForm(proj);

            // add the project properties
            wizard.AddSymbol("DEFAULT_SERVER_SCRIPT", "JavaScript");
            wizard.AddSymbol("DEFAULT_CLIENT_SCRIPT", "JavaScript");

            // add project files
            AddFilesToCSharpProject(proj, strProjectName, strProjectPath,
            InfFile, false);
            SetStartupPage(proj, "WebUserControl1.ascx");
                        CollapseReferencesNode(proj);
                        AddSharePointReferences(proj)

        }
        proj.Save();
    }
    catch(e)
    {
        if( e.description.length > 0 )
            SetErrorInfo(e);
        return e.number;
    }
    finally
    {
            dte.SuppressUI = oldSuppressUIValue;
            if( InfFile )
            InfFile.Delete();
    }
}
