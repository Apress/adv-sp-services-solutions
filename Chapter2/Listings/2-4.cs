private void Download_Click(string strSourceFileURL)
{
    try
    {

        //Build the destination path
        string strDesktop  =
        System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string strDestinationFilePath  = strDesktop + "\\"
        + strSourceFileURL.Substring(strSourceFileURL.LastIndexOf("/")+1);

        //Download file
        WebClient objWebClient = new WebClient();
        objWebClient.Credentials = CredentialCache.DefaultCredentials;
        objWebClient.DownloadFile(strSourceFileURL, strDestinationFilePath);

        MessageBox.Show("File downloaded to your desktop.");
}
    catch (Exception x)
    {
        MessageBox.Show(x.Message);
    }

}
