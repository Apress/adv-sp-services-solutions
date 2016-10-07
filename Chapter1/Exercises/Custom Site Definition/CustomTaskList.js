function AddListMenuItems(m, ctx)
{
    if (typeof(Custom_AddListMenuItems) != "undefined") 
    {
        if (Custom_AddListMenuItems(m, ctx))           
            return;
    }
    if (ctx.listBaseType == BASETYPE_DISCUSSION)
    {
        strDisplayText = L_Reply_Text;
        if(itemTable.Ordering.length>=504) 
        {
            var L_ReplyLimitMsg_Text="Cannot reply to this thread. The reply limit has been reached.";
            strAction="alert('" + L_ReplyLimitMsg_Text + "')";
        }
        else
        {
            strAction = "STSNavigate('" + ctx.newFormUrl 
            + "?Threading=" + escapeProperly(itemTable.Ordering)
            + "&Guid=" + escapeProperly(itemTable.ThreadID)
            + "&Subject=" + escapeProperly(itemTable.Subject)
            + "&Source=" + GetSource() + "')";
        }
        strImagePath = ctx.imagesPath + "reply.gif";
        CAMOpt(m, strDisplayText, strAction, strImagePath);
    }
    strDisplayText = L_ViewItem_Text;
    strAction = "STSNavigate('" + ctx.displayFormUrl+"?ID="+ currentItemID + "&Source=" +
                GetSource() + "')";
    strImagePath = "";
    CAMOpt(m, strDisplayText, strAction, strImagePath);
    strDisplayText = L_EditItem_Text;
    strAction = "STSNavigate('" + ctx.editFormUrl+"?ID="+ currentItemID + "&Source=" +
                GetSource() + "')";
    strImagePath = ctx.imagesPath + "edititem.gif";
    CAMOpt(m, strDisplayText, strAction, strImagePath);
    if (ctx.listTemplate == LISTTEMPLATE_EVENTS &&
        currentItemID.indexOf(".0.") > 0)
    {
        var SeriesIdEnd = currentItemID.indexOf(".0.");
        var itemSeriesID = currentItemID.substr(0, SeriesIdEnd);
        strDisplayText = L_EditSeriesItem_Text;
        strAction = "STSNavigate('" + ctx.editFormUrl+"?ID="+ itemSeriesID + "&Source=" +
                    GetSource() + "')";
        strImagePath = ctx.imagesPath + "recur.gif";
        CAMOpt(m, strDisplayText, strAction, strImagePath);
    }
    if (currentItemID.indexOf(".0.") < 0)
    {
		strDisplayText = L_DeleteItem_Text;
		strAction = "DeleteListItem()";
		strImagePath = ctx.imagesPath + "delitem.gif";
		CAMOpt(m, strDisplayText, strAction, strImagePath);
    }
    if (ctx.listTemplate == LISTTEMPLATE_CONTACTS)
    {
        strDisplayText = L_ExportContact_Text;
        strAction = "STSNavigate('" + ctx.HttpPath + "&Cmd=Display&CacheControl=1&List=" + ctx.listName + "&ID=" +  currentItemID + "&Using=" + escapeProperly(ctx.listUrlDir) + "/vcard.vcf" + "')";
        strImagePath = ctx.imagesPath + "exptitem.gif";
        CAMOpt(m, strDisplayText, strAction, strImagePath);
    }
	if (ctx.listTemplate == LISTTEMPLATE_TASKS)
	{
		strDisplayText = "Export Task";
		strAction = "exportTask('" + ctx.HttpRoot + "','" + ctx.listName + "','" +
								currentItemID + "')";
		strImagePath = ctx.imagesPath + "exptitem.gif";
		CAMOpt(m, strDisplayText, strAction, strImagePath);
	}
    if (currentItemID.indexOf(".0.") < 0)
    {
        strDisplayText = L_Subscribe_Text;
        strAction = "NavigateToSubNewAspx('" + ctx.HttpRoot + "', 'List=" + ctx.listName + "&ID=" + currentItemID +"')";
        strImagePath = "";
        CAMOpt(m, strDisplayText, strAction, strImagePath);
    }
    if (ctx.isModerated == true &&
        ctx.listBaseType != BASETYPE_SURVEY)
    {
        strDisplayText = L_ModerateItem_Text;
        strAction = "STSNavigate('" + ctx.editFormUrl+"?ID="+ currentItemID + "&ChangeApproval=TRUE&Source=" +
                    GetSource() + "')";
        strImagePath = "";
        CAMOpt(m, strDisplayText, strAction, strImagePath);
    }
}
var objHttp;
function exportTask(SitePath,listName,currentItemID)
{
	try
	{

	//Use MSXML to make web service call
	objHttp = new ActiveXObject("MSXML2.XMLHTTP");
		
	//Create the SOAP envelope
	strEnvelope =  
	"<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
	" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"" +
	" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
	"  <soap:Body>" +
	"    <GetListItems xmlns=\"http://schemas.microsoft.com/sharepoint/soap/\">" +
	"      <listName>" + listName + "</listName>" +
	"      <query>" +
	"         <Query><Where>" +
	"           <Eq><FieldRef Name=\"ID\" />" +
	"           <Value Type=\"Counter\">" + currentItemID + "</Value></Eq>" +
	"         </Where></Query>" + 
	"      </query>" +
	"      <viewFields><ViewFields>" +
	"         <FieldRef Name=\"ID\"/><FieldRef Name=\"Title\"/>" + 
	"         <FieldRef Name=\"Status\"/><FieldRef Name=\"Priority\"/>" + 
	"         <FieldRef Name=\"StartDate\"/><FieldRef Name=\"DueDate\"/>" + 
	"         <FieldRef Name=\"Body\"/><FieldRef Name=\"PercentComplete\"/>" + 
	"      </ViewFields></viewFields>" + 
	"    </GetListItems>" +
	"  </soap:Body>" +
	"</soap:Envelope>";  

		//Make the call
		objHttp.open("post", SitePath + "/_vti_bin/Lists.asmx");
		objHttp.setRequestHeader("Content-Type", "text/xml; charset=utf-8");
		objHttp.setRequestHeader("SOAPAction", "http://schemas.microsoft.com/sharepoint/soap/GetListItems");
		objHttp.send(strEnvelope);

		//Wait for return XML
		window.setTimeout(showResults, 1);

	}

	catch(e)
	{
	alert(e.message);
	}
}
function showResults(){
	try
	{

	if(objHttp.readyState==4)
	{
	  
		//Parse XML
		var responseXML = objHttp.responseText;
		objHttp = null;

		var title = nodeValue("Title",responseXML);
		var status = nodeValue("Status",responseXML);
		var priority = nodeValue("Priority",responseXML);
		var startdate = nodeValue("StartDate",responseXML);
		var duedate = nodeValue("DueDate",responseXML);
		var body = nodeValue("Body",responseXML);
		var percent = nodeValue("PercentComplete",responseXML);

		//Create a new task in Outlook 2003
		var ol = new ActiveXObject("Outlook.Application.11");
		var olTask = ol.CreateItem(3);

		//Subject
		try{olTask.Subject = title; }catch(e){}

		//Start Date
		try{olTask.StartDate = startdate;}catch(e){}

		//Due Date
		try{olTask.DueDate = duedate;}catch(e){}

		//Body
		try{olTask.Body = body; }catch(e){}

		//Status
		switch(status)
		{
		case 'Not Started':
			try{olTask.Status = 0; }catch(e){}
			break;
		case 'In Progress':
			try{olTask.Status = 1; }catch(e){}
			break;
		case 'Completed':
			try{olTask.Status = 2; }catch(e){}
			break;
		case 'Deferred':
			try{olTask.Status = 4; }catch(e){}
			break;
		case 'Waiting on some else':
			try{olTask.Status = 3; }catch(e){}
			break;
		}

		//Priority
		switch(priority)
		{
		case '(1) High':
			try{olTask.Importance = 2; }catch(e){}
			break;
		case '(2) Normal':
			try{olTask.Importance = 1; }catch(e){}
			break;
		case '(3) Low':
			try{olTask.Importance = 0; }catch(e){}
			break;
		}

		//Percent Complete
		try{olTask.PercentComplete = percent * 100; }catch(e){}

		//Show the new task
		olTask.Display();
		olTask = null;
		ol = null;

	}

	else
		window.setTimeout(showResults, 1);

	}

	catch(e){
	alert(e.message);
	}

	finally
	{
	CollectGarbage();
	}
}
function nodeValue(nodeName,xmlString){

  try
  {
      //Parses return XML
      var singleQuote="'";
      var searchString = "ows_" + nodeName + "=" + singleQuote;
      if (xmlString.indexOf(searchString,0) == -1)
      {
		return '';      
      }
      else
      {
		var searchBegin = xmlString.indexOf(searchString,0) + searchString.length;
		var searchEnd = xmlString.indexOf(singleQuote,searchBegin);
		return xmlString.substring(searchBegin,searchEnd);
      }
  }

  catch(e)
  {
    alert(e);
  }

}
