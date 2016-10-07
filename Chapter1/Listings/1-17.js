function CreateMenu()
{
    if (! IsContextSet()) 
        return;
    var ctx = currentCtx;
    if (itemTable == null || imageCell == null ||
        (onKeyPress == false &&
         (event.srcElement.tagName=="A" ||
          event.srcElement.parentNode.tagName == "A")))
        return;
    IsMenuShown = true;
    window.document.body.onclick="";
    m = CMenu(currentItemID + "_menu");
    currenMenu = m;
        if (ctx.isVersions)
            AddVersionMenuItems(m, ctx);
    else if (ctx.listBaseType == BASETYPE_DOCUMENT_LIBRARY)
        AddDocLibMenuItems(m, ctx);
    else if (ctx.listTemplate == LISTTEMPLATE_MEETINGS)
         AddMeetingMenuItems(m, ctx);
    else   
         AddListMenuItems(m, ctx);
    OMenu(m, itemTable, null, null, -1);
    document.body.onclick=HideSelectedRow;
    return false;
}
