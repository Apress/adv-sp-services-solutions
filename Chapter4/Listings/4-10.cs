public override void ApplyChanges()
{
    //Build audience list
    EnsureChildControls();
    cancelString.Text = audienceString.Text;
    audienceString.Text="";

    foreach(ListItem item in audienceList.Items)
    {
        if(item.Selected==true)
            audienceString.Text += item.Text + ";";
    }

    //Update web part property
    Container webpart = (Container)ParentToolPane.SelectedWebPart;
    webpart.Audiences = audienceString.Text;

}

public override void SyncChanges()
{
    //Update web part property
    EnsureChildControls();
    Container webpart = (Container)this.ParentToolPane.SelectedWebPart;
    audienceString.Text = webpart.Audiences;
    cancelString.Text = webpart.Audiences;
}

public override void CancelChanges()
{
    EnsureChildControls();
    audienceString.Text = cancelString.Text;
    Container webpart = (Container)ParentToolPane.SelectedWebPart;
    webpart.Audiences = cancelString.Text;
}
