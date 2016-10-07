public class AudienceTool : ToolPart
{
    //variables
    protected ListBox audienceList;
    protected TextBox audienceString;
    protected TextBox cancelString;

    protected override void OnLoad(EventArgs e)
    {
        //Get the portal context
        SPSite portal =
        new SPSite(Page.Request.Url.GetLeftPart(UriPartial.Authority));
        PortalContext context = PortalApplication.GetContext(portal.ID);

        //Get the list of audiences
        AudienceManager manager = new AudienceManager(context);

        EnsureChildControls();
        if (audienceList.Items.Count==0)
        {
            Container webpart = (Container)this.ParentToolPane.SelectedWebPart;
            audienceString.Text = webpart.Audiences;
            cancelString.Text = webpart.Audiences;

            //Fill the ListBox
            foreach(Audience audience in manager.Audiences)
            {
                audienceList.Items.Add(audience.AudienceName);
            }
        }
    }

    protected override void CreateChildControls()
    {
            audienceList = new ListBox();
            audienceList.SelectionMode = ListSelectionMode.Multiple;
            Controls.Add(audienceList);

            audienceString = new TextBox();
            Controls.Add(audienceString);

            cancelString = new TextBox();
            cancelString.Visible=false;
            Controls.Add(cancelString);

    }

    protected override void RenderToolPart(HtmlTextWriter output)
    {
            //Draw list
            audienceList.RenderControl(output);
            output.Write("<br>");
            audienceString.RenderControl(output);
            output.Write("<br>");
            cancelString.RenderControl(output);
    }
}
