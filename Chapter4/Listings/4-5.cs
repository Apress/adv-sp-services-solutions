DataSet results;

protected override object IssueQuery(string strQuery, int startRowIndex, int endRowIndex)
{
    results =(System.Data.DataSet)
        base.IssueQuery (strQuery, startRowIndex, endRowIndex);
    return results;
}
