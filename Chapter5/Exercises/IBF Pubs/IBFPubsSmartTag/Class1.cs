using System;
using System.Web;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.SmartTag;

namespace IBFPubsSmartTag
{

	public class AuthorRecognizer: ISmartTagRecognizer, ISmartTagRecognizer2
	{
		int numTerms;
		string[] terms = new string[30];

		private const string AUTHOR_CONTEXT_XML = 
			"<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
			"<ContextInformation xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" " +
			"xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
			"MetadataScopeName=\"Pubs\" EntityName=\"Library\" ViewName=\"BasicView\" " +
			"ReferenceSchemaName=\"Author (PubsData)\" " +
			"xmlns=" +
			"\"http://schemas.microsoft.com/InformationBridge/2004/ContextInformation\">" +
			"<Reference>" +
			"<Author xmlns=\"PubsData\" d2p1:MetadataScopeName=\"Pubs\" " +
			"d2p1:EntityName=\"Library\" d2p1:ViewName=\"BasicView\" " +
			"d2p1:ReferenceSchemaName=\"Author (PubsData)\" " +
			"xmlns:d2p1=\"http://schemas.microsoft.com/InformationBridge/2004\">" +
			"<LastName>{0}</LastName></Author></Reference></ContextInformation>";

		public void SmartTagInitialize(string ApplicationName)
		{
			try
			{
				terms[1] = "White";
				terms[2] = "Green";
				terms[3] = "Carson";
				terms[4] = "O'Leary";
				terms[5] = "Straight";
				terms[6] = "Smith";
				terms[7] = "Bennet";
				terms[8] = "Dull";
				terms[9] = "Gringlesby";
				terms[10] = "Locksley";
				terms[11] = "Blotchet-Halls";
				terms[12] = "Yokomoto";
				terms[13] = "del Castillo";
				terms[14] = "DeFrance";
				terms[15] = "Stringer";
				terms[16] = "MacFeather";
				terms[17] = "Karsen";
				terms[18] = "Panteley";
				terms[19] = "Hunter";
				terms[20] = "McBadden";
				terms[21] = "Ringer";
				numTerms = 21;
			}
			catch (System.Exception x)
			{
				MessageBox.Show (x.ToString());
			}
		}

		public void Recognize2(string Text, IF_TYPE DataType, int LocaleID,
			ISmartTagRecognizerSite2 RecognizerSite2, string ApplicationName,
			ISmartTagTokenList TokenList)
		{
			try
			{
				// Set the culture info for string comparisions
				Thread.CurrentThread.CurrentCulture = new CultureInfo(LocaleID);

				for(int i=1; i<=numTerms; i++)
				{
					//Look for the term in the Text
					string expression = @"(\W|^)*(?<term>" + terms[i] + @")(\W|$)";
					Regex regex = new Regex(expression, RegexOptions.IgnoreCase);
					MatchCollection matches = regex.Matches(Text);

					//Process each match in the Text
					foreach (Match match in matches)
					{
						string matchedTerm = match.Groups["term"].Value;
						int indexOfMatch =
							Text.ToUpper(CultureInfo.CurrentCulture).IndexOf(
							terms[i].ToUpper(CultureInfo.CurrentCulture),
							match.Index, match.Length);

						//Length will always be the length of the term.
						int tagLength = terms[i].Length;

						//Context string to invoke IBF
						string contextString =
							string.Format(AUTHOR_CONTEXT_XML,terms[i]);

						//Format the strings
						string termFormatted = HttpUtility.HtmlEncode(terms[i]);
						string context = string.Format(
							CultureInfo.CurrentCulture, contextString, termFormatted);

						//Write the tag
						ISmartTagProperties propertyBag =
							RecognizerSite2.GetNewPropertyBag();
						propertyBag.Write("data", context);
						RecognizerSite2.CommitSmartTag(
							"http://schemas.microsoft.com/InformationBridge/2004#reference",
							indexOfMatch+1, tagLength, propertyBag);
					}
				}
			}
			catch(Exception x)
			{
				MessageBox.Show(x.Message);
			}
		}

		public string ProgId
		{
			get{return "IBFPubsSmartTag.AuthorRecognizer";}
		}

		public string get_Name(int LocaleID)
		{
			return "Author Recognizer";
		}

		public string get_Desc(int LocaleID)
		{
			return "Author Recognizer recognizes last names in documents";
		}

		public string get_SmartTagName(int SmartTagID)
		{
			if (SmartTagID==1)
			{
				return "http://schemas.microsoft.com/InformationBridge/2004#reference";
			}
			return "";
		}

		public int SmartTagCount
		{
			get
			{
				return 1;
			}
		}

		public string get_SmartTagDownloadURL(int SmartTagID)
		{
			return "";
		}

		public void Recognize(string Text, IF_TYPE DataType, int LocaleID,
			ISmartTagRecognizerSite RecognizerSite)
		{
			// Not using this because using Recognize2 method instead.
		}

		public void DisplayPropertyPage(int SmartTagID, int LocaleID)
		{
			// Not implemented
		}

		public bool get_PropertyPage(int SmartTagID, int LocaleID)
		{
			return false;
		}
	}
}

