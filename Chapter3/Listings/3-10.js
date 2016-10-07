function GetCSharpTargetName(strName, strProjectName)
{
    var strTarget = strName;

    switch (strName)
    {
        case "webusercontrol.ascx":
            strTarget = "WebUserControl1.ascx";
            break;
        case "assemblyinfo.cs":
            strTarget = "AssemblyInfo.cs";
            break;
    }
    return strTarget; 
}

function DoOpenFile(strName)
{
    var bOpen = false;

    switch (strName)
    {
        case "WebUserControl1.ascx":
            bOpen = true;
            break;
    }
    return bOpen; 
}

function SetFileProperties(oFileItem, strFileName)
{
    if(strFileName == "WebUserControl1.ascx")
    {
        oFileItem.Properties("SubType").Value = "Form";
    }
}
