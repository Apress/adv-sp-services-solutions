public IVisualStyles VisualStyle
{
    get{return visualStyles;}
    set
    {
        //Save the styles
        visualStyles = value;

        //Set the styles
        if(visualStyles!=null)
        {
            visualStyles_UserPreferencesChanged(null,null);
            visualStyles.UserPreferencesChanged += new
                Microsoft.Win32.UserPreferenceChangedEventHandler
                (visualStyles_UserPreferencesChanged);
        }
    }
}

private void visualStyles_UserPreferencesChanged(object sender,
    Microsoft.Win32.UserPreferenceChangedEventArgs e)
{
    if(visualStyles!=null)
    {
        //Get styles
        Color backColor = visualStyles.GetColor(Colors.RegionBackColor);
        Color foreColor = visualStyles.GetColor(Colors.RegionHeaderText);
        Font boldFont = visualStyles.GetFont(Fonts.DefaultFontBold);
        Font defaultFont = visualStyles.GetFont(Fonts.DefaultFont);

        //Set styles
        BackColor = backColor;

        foreach(Control control in Controls)
        {
            control.BackColor = backColor;
            control.ForeColor = foreColor;

            if(control.Name=="lblName")
                control.Font = boldFont;
            else
                control.Font = defaultFont;
        }
    }
}
