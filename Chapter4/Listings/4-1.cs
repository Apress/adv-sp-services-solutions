private string buildQuery(string keyword)
{
//Create query string from keywords
string queryText =	"SELECT" +
"\"DAV:href\"," +
"\"DAV:displayname\"," +
"\"DAV:contentclass\"," +
"\"DAV:getlastmodified\"," +
"\"DAV:getcontentlength\"," +
"\"DAV:iscollection\"," +
"\"urn:schemas-microsoft-com:sharepoint:portal:profile:WorkPhone\"," +
"\"urn:schemas-microsoft-com:sharepoint:portal:profile:WorkEmail\"," +
"\"urn:schemas-microsoft-com:sharepoint:portal:profile:Title\"," +
"\"urn:schemas-microsoft-com:sharepoint:portal:profile:Department\"," +
"\"urn:schemas.microsoft.com:fulltextqueryinfo:PictureURL\"," +
"\"urn:schemas-microsoft-com:office:office#Author\"," +
"\"urn:schemas.microsoft.com:fulltextqueryinfo:description\"," +
"\"urn:schemas.microsoft.com:fulltextqueryinfo:rank\"," +
"\"urn:schemas.microsoft.com:fulltextqueryinfo:sitename\"," +
"\"urn:schemas.microsoft.com:fulltextqueryinfo:displaytitle\"," +
"\"urn:schemas-microsoft-com:publishing:Category\"," +
"\"urn:schemas-microsoft-com:office:office#ows_CrawlType\"," +
"\"urn:schemas-microsoft-com:office:office#ows_ListTemplate\"," +
"\"urn:schemas-microsoft-com:office:office#ows_SiteName\"," +
"\"urn:schemas-microsoft-com:office:office#ows_ImageWidth\"," +
"\"urn:schemas-microsoft-com:office:office#ows_ImageHeight\"," +
"\"DAV:getcontenttype\"," +
"\"urn:schemas-microsoft-com:sharepoint:portal:area:Path\"," +
"\"urn:schemas-microsoft-com:sharepoint:portal:area:CategoryUrlNavigation\"," +
"\"urn:schemas-microsoft-com:publishing:CategoryTitle\"," +
"\"urn:schemas.microsoft.com:fulltextqueryinfo:sdid\"," +
"\"urn:schemas-microsoft-com:sharepoint:portal:objectid\"" +
" from " +
"( TABLE Portal_Content..Scope() " +
"UNION ALL TABLE Non_Portal_Content..Scope() ) " +
" where " +
"WITH " + 
"(\"DAV:contentclass\":0, " +
"\"urn:schemas.microsoft.com:fulltextqueryinfo:description\":0, " +
"\"urn:schemas.microsoft.com:fulltextqueryinfo:sourcegroup\":0, " +
"\"urn:schemas.microsoft.com:fulltextqueryinfo:cataloggroup\":0, " +
"\"urn:schemas-microsoft-com:office:office#Keywords\":1.0, " +
"\"urn:schemas-microsoft-com:office:office#Title\":0.9, " +
"\"DAV:displayname\":0.9, " +
"\"urn:schemas-microsoft-com:publishing:Category\":0.8, " +
"\"urn:schemas-microsoft-com:office:office#Subject\":0.8, " +
"\"urn:schemas-microsoft-com:office:office#Author\":0.7, " +
"\"urn:schemas-microsoft-com:office:office#Description\":0.5, " +
"\"urn:schemas-microsoft-com:sharepoint:portal:profile:PreferredName\":0.2, " +
"contents:0.1,*:0.05) AS #WeightedProps " + 
"((\"urn:schemas-microsoft-com:publishing:HomeBestBetKeywords\"" +
"= some array ['" + keyword + "'] " +
" RANK BY COERCION(absolute, 999)) " +
"OR (FREETEXT(" +
"\"urn:schemas-microsoft-com:sharepoint:portal:profile:PreferredName\", '" + 
keyword + "')  " +
"OR CONTAINS('\"" + keyword + "\"') " +
"RANK BY COERCION(multiply, 0.01)) " +
"OR FREETEXT(#WeightedProps, '" + keyword + "') ) " +
"ORDER BY \"urn:schemas.microsoft.com:fulltextqueryinfo:rank\" DESC";

return queryText;
}
