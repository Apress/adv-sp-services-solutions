if(diaOpen.ShowDialog() == DialogResult.OK)
{
    try
    {

        //Load File into a byte array
        FileStream objStream = new FileStream(
        diaOpen.FileName, FileMode.Open, FileAccess.Read);
        BinaryReader objReader = new BinaryReader(objStream);
        byte [] arrFileBytes = objReader.ReadBytes((int)objStream.Length);
        objReader.Close();
        objStream.Close();

        //Upload file
        string strTarget = "http://spspdc/sites/Test/Shared%20Documents/";
        string strDestination = strTarget 
        + diaOpen.FileName.Substring(diaOpen.FileName.LastIndexOf("\\")+1);
        WebClient objWebClient = new WebClient();
        objWebClient.Credentials = CredentialCache.DefaultCredentials;
        objWebClient.UploadData(strDestination,"PUT",arrFileBytes);

        MessageBox.Show("Document uploaded.");
    }
    catch (Exception x)
    {
        MessageBox.Show(x.Message);
    }
}
