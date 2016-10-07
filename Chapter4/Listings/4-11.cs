[DefaultProperty("URL"),
ToolboxData("<{0}:Container runat=server></{0}:Container>"),
XmlRoot(Namespace="SPSPageView")]
public class Container : Microsoft.SharePoint.WebPartPages.WebPart
{
    //NOTE: URL and PageHeight property code not shown
    protected String m_audiences="All portal users;";

    [Browsable(false),Category("Miscellaneous"),
    DefaultValue("All portal users;"),
    WebPartStorage(Storage.Shared),
    FriendlyName("Audiences"),Description("The selected audiences.")]
    public string  Audiences
    {
        get
        {
            return m_audiences;
        }

        set
        {
            m_audiences = value;
        }
    }

    public override ToolPart[] GetToolParts()
    {
        WebPartToolPart webPartToolPart = new WebPartToolPart();
        CustomPropertyToolPart customToolPart = new CustomPropertyToolPart();
        AudienceTool audienceTool = new AudienceTool();

        ToolPart[] toolParts = new ToolPart[3]
        {webPartToolPart,customToolPart,audienceTool};
        return toolParts;
     }

    protected override void RenderWebPart(HtmlTextWriter output)
    {
        //Get the portal context
        SPSite portal =
        new SPSite(Page.Request.Url.GetLeftPart(UriPartial.Authority));
        PortalContext context = PortalApplication.GetContext(portal.ID);

        //Get the list of audiences for the user
        AudienceManager manager = new AudienceManager(context);
        ArrayList audienceIDList = manager.GetUserAudienceIDs();

        //Get the list of authorized audiences
        String [] audiences = Audiences.Split(";".ToCharArray());
        Boolean authorized = false;

        //Check the lists
        if(audienceIDList != null)
        {
            IEnumerator audienceNameIDs = audienceIDList.GetEnumerator();

            while(audienceNameIDs.MoveNext())
            {
                for(int i=audiences.GetLowerBound(0);
                i<=audiences.GetUpperBound(0);i++)
                {
                    if(audiences[i]==
                    ((AudienceNameID)audienceNameIDs.Current).AudienceName)
                    authorized=true;
                }
            }
        }

        //Draw web part
        if(authorized==true)
            output.Write("<div><iframe height='"
            + PageHeight + "' width='100%' src='" + URL + "'></iframe></div>");
    }
}
