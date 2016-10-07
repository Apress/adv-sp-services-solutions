protected override string GenerateQueryString(string strKeyword,System.Collections.ArrayList rgScopeList,string strWhereAndPart,out string strSavedQuery)
{
    //Add wildcard functionality to the query
    string wherePart = base.QueryTemplateWherePart;
    string firstPart =
        wherePart.Substring(0,wherePart.LastIndexOf("RANK BY COERCION"));
    string lastPart =
        wherePart.Substring(wherePart.LastIndexOf("RANK BY COERCION"));
    wherePart =
         firstPart + " OR CONTAINS('\"%__keywordinput__%\"') " + lastPart;
    base.QueryTemplateWherePart = wherePart;

    //Run query
    string query =
        base.GenerateQueryString(strKeyword,rgScopeList,
                                 strWhereAndPart,out strSavedQuery);
    strSavedQuery = query;
    return query;
}
