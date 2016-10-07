<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:my="http://schemas.microsoft.com/office/infopath/2003/myXSD/2004-10-21T23:56:40" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:xd="http://schemas.microsoft.com/office/infopath/2003" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns:xdExtension="http://schemas.microsoft.com/office/infopath/2003/xslt/extension" xmlns:xdXDocument="http://schemas.microsoft.com/office/infopath/2003/xslt/xDocument" xmlns:xdSolution="http://schemas.microsoft.com/office/infopath/2003/xslt/solution" xmlns:xdFormatting="http://schemas.microsoft.com/office/infopath/2003/xslt/formatting" xmlns:xdImage="http://schemas.microsoft.com/office/infopath/2003/xslt/xImage" xmlns:xdUtil="http://schemas.microsoft.com/office/infopath/2003/xslt/Util" xmlns:xdMath="http://schemas.microsoft.com/office/infopath/2003/xslt/Math" xmlns:xdDate="http://schemas.microsoft.com/office/infopath/2003/xslt/Date" xmlns:sig="http://www.w3.org/2000/09/xmldsig#" xmlns:xdSignatureProperties="http://schemas.microsoft.com/office/infopath/2003/SignatureProperties">
	<xsl:output method="html" indent="no"/>
	<xsl:template match="my:myFields">
		<html>
			<head>
				<meta http-equiv="Content-Type" content="text/html"></meta>
				<style controlStyle="controlStyle">@media screen 			{ 			BODY{margin-left:21px;background-position:21px 0px;} 			} 		BODY{color:windowtext;background-color:window;layout-grid:none;} 		.xdListItem {display:inline-block;width:100%;vertical-align:text-top;} 		.xdListBox,.xdComboBox{margin:1px;} 		.xdInlinePicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) } 		.xdLinkedPicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) url(#default#urn::controls/Binder) } 		.xdSection{border:1pt solid #FFFFFF;margin:6px 0px 6px 0px;padding:1px 1px 1px 5px;} 		.xdRepeatingSection{border:1pt solid #FFFFFF;margin:6px 0px 6px 0px;padding:1px 1px 1px 5px;} 		.xdBehavior_Formatting {BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting);} 	 .xdBehavior_FormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting);} 	.xdExpressionBox{margin: 1px;padding:1px;word-wrap: break-word;text-overflow: ellipsis;overflow-x:hidden;}.xdBehavior_GhostedText,.xdBehavior_GhostedTextNoBUI{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#TextField) url(#default#GhostedText);}	.xdBehavior_GTFormatting{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_GTFormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_Boolean{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#BooleanHelper);}	.xdBehavior_Select{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#SelectHelper);}	.xdRepeatingTable{BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word;}.xdScrollableRegion{BEHAVIOR: url(#default#ScrollableRegion);} 		.xdMaster{BEHAVIOR: url(#default#MasterHelper);} 		.xdActiveX{margin:1px; BEHAVIOR: url(#default#ActiveX);} 		.xdFileAttachment{display:inline-block;margin:1px;BEHAVIOR:url(#default#urn::xdFileAttachment);} 		.xdPageBreak{display: none;}BODY{margin-right:21px;} 		.xdTextBoxRTL{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:right;} 		.xdRichTextBoxRTL{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-overflow:ellipsis;text-align:right;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTTextRTL{height:100%;width:100%;margin-left:22px;overflow:hidden;padding:0px;white-space:nowrap;} 		.xdDTButtonRTL{margin-right:-21px;height:18px;width:20px;behavior: url(#default#DTPicker);}.xdTextBox{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:left;} 		.xdRichTextBox{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-overflow:ellipsis;text-align:left;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTPicker{;display:inline;margin:1px;margin-bottom: 2px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;} 		.xdDTText{height:100%;width:100%;margin-right:22px;overflow:hidden;padding:0px;white-space:nowrap;} 		.xdDTButton{margin-left:-21px;height:18px;width:20px;behavior: url(#default#DTPicker);} 		.xdRepeatingTable TD {VERTICAL-ALIGN: top;}</style>
				<style tableEditor="TableStyleRulesID">TABLE.xdLayout TD {
	BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none
}
TABLE.msoUcTable TD {
	BORDER-RIGHT: 1pt solid; BORDER-TOP: 1pt solid; BORDER-LEFT: 1pt solid; BORDER-BOTTOM: 1pt solid
}
TABLE {
	BEHAVIOR: url (#default#urn::tables/NDTable)
}
</style>
				<style languageStyle="languageStyle">BODY {
	FONT-SIZE: 10pt; FONT-FAMILY: Verdana
}
TABLE {
	FONT-SIZE: 10pt; FONT-FAMILY: Verdana
}
SELECT {
	FONT-SIZE: 10pt; FONT-FAMILY: Verdana
}
.optionalPlaceholder {
	PADDING-LEFT: 20px; FONT-WEIGHT: normal; FONT-SIZE: xx-small; BEHAVIOR: url(#default#xOptional); COLOR: #333333; FONT-STYLE: normal; FONT-FAMILY: Verdana; TEXT-DECORATION: none
}
.langFont {
	FONT-FAMILY: Verdana
}
.defaultInDocUI {
	FONT-SIZE: xx-small; FONT-FAMILY: Verdana
}
.optionalPlaceholder {
	PADDING-RIGHT: 20px
}
</style>
				<style themeStyle="urn:office.microsoft.com:themeBlue">BODY {
	COLOR: black; BACKGROUND-COLOR: white
}
TABLE {
	BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse
}
TD {
	BORDER-LEFT-COLOR: #517dbf; BORDER-BOTTOM-COLOR: #517dbf; BORDER-TOP-COLOR: #517dbf; BORDER-RIGHT-COLOR: #517dbf
}
TH {
	BORDER-LEFT-COLOR: #517dbf; BORDER-BOTTOM-COLOR: #517dbf; COLOR: black; BORDER-TOP-COLOR: #517dbf; BACKGROUND-COLOR: #cbd8eb; BORDER-RIGHT-COLOR: #517dbf
}
.xdTableHeader {
	COLOR: black; BACKGROUND-COLOR: #ebf0f9
}
P {
	MARGIN-TOP: 0px
}
H1 {
	MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #1e3c7b
}
H2 {
	MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #1e3c7b
}
H3 {
	MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #1e3c7b
}
H4 {
	MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #1e3c7b
}
H5 {
	MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #517dbf
}
H6 {
	MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #ebf0f9
}
.primaryVeryDark {
	COLOR: #ebf0f9; BACKGROUND-COLOR: #1e3c7b
}
.primaryDark {
	COLOR: white; BACKGROUND-COLOR: #517dbf
}
.primaryMedium {
	COLOR: black; BACKGROUND-COLOR: #cbd8eb
}
.primaryLight {
	COLOR: black; BACKGROUND-COLOR: #ebf0f9
}
.accentDark {
	COLOR: white; BACKGROUND-COLOR: #517dbf
}
.accentLight {
	COLOR: black; BACKGROUND-COLOR: #ebf0f9
}
</style>
			</head>
			<body>
				<div> </div>
				<div>
					<table class="xdFormLayout xdLayout" style="TABLE-LAYOUT: fixed; WIDTH: 651px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1">
						<colgroup>
							<col style="WIDTH: 651px"></col>
						</colgroup>
						<tbody vAlign="top">
							<tr class="primaryVeryDark">
								<td style="BORDER-TOP-STYLE: none; BORDER-BOTTOM: 5pt solid; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none">
									<div>
										<font size="4">
											<span style="FONT-SIZE: 12pt">
												<strong>
													<font face="Times New Roman">Employee Profile</font>
												</strong>
											</span>
										</font>
									</div>
								</td>
							</tr>
							<tr class="primarylight" style="MIN-HEIGHT: 0.313in">
								<td vAlign="top" style="BORDER-TOP: 5pt solid; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; TEXT-ALIGN: left; BORDER-BOTTOM-STYLE: none">
									<div>
										<table class="xdFormLayout xdLayout" style="TABLE-LAYOUT: fixed; WIDTH: 647px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1">
											<colgroup>
												<col style="WIDTH: 323px"></col>
												<col style="WIDTH: 324px"></col>
											</colgroup>
											<tbody vAlign="top">
												<tr style="MIN-HEIGHT: 1in">
													<td style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
														<div>
															<span style="FONT-SIZE: 12pt">
																<strong>
																	<font face="Times New Roman">Name</font>
																</strong>
															</span>
														</div>
													</td>
													<td style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
														<div><span class="xdTextBox" hideFocus="1" title="" xd:xctname="PlainText" xd:CtrlId="CTRL1" xd:binding="my:field1" tabIndex="-1" xd:disableEditing="yes" style="WIDTH: 100%; WHITE-SPACE: nowrap; WORD-WRAP: normal">
																<xsl:value-of select="my:field1"/>
															</span>
														</div>
													</td>
												</tr>
											</tbody>
										</table>
									</div>
									<div>
										<table class="xdFormLayout xdLayout" style="TABLE-LAYOUT: fixed; WIDTH: 647px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1">
											<colgroup>
												<col style="WIDTH: 323px"></col>
												<col style="WIDTH: 324px"></col>
											</colgroup>
											<tbody vAlign="top">
												<tr style="MIN-HEIGHT: 1in">
													<td style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
														<div>
															<span style="FONT-SIZE: 12pt">
																<strong>
																	<font face="Times New Roman">Title</font>
																</strong>
															</span>
														</div>
													</td>
													<td style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
														<div><span class="xdTextBox" hideFocus="1" title="" xd:xctname="PlainText" xd:CtrlId="CTRL2" xd:binding="my:field2" tabIndex="-1" xd:disableEditing="yes" style="WIDTH: 100%; WHITE-SPACE: nowrap; WORD-WRAP: normal">
																<xsl:value-of select="my:field2"/>
															</span>
														</div>
													</td>
												</tr>
											</tbody>
										</table>
									</div>
									<div>
										<table class="xdFormLayout xdLayout" style="TABLE-LAYOUT: fixed; WIDTH: 647px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1">
											<colgroup>
												<col style="WIDTH: 323px"></col>
												<col style="WIDTH: 324px"></col>
											</colgroup>
											<tbody vAlign="top">
												<tr style="MIN-HEIGHT: 1in">
													<td style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
														<div>
															<span style="FONT-SIZE: 12pt">
																<strong>
																	<font face="Times New Roman">Phone</font>
																</strong>
															</span>
														</div>
													</td>
													<td style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
														<div><span class="xdTextBox" hideFocus="1" title="" xd:xctname="PlainText" xd:CtrlId="CTRL3" xd:binding="my:field3" tabIndex="-1" xd:disableEditing="yes" style="WIDTH: 100%; WHITE-SPACE: nowrap; WORD-WRAP: normal">
																<xsl:value-of select="my:field3"/>
															</span>
														</div>
													</td>
												</tr>
											</tbody>
										</table>
									</div>
									<div>
										<table class="xdFormLayout xdLayout" style="TABLE-LAYOUT: fixed; WIDTH: 647px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1">
											<colgroup>
												<col style="WIDTH: 323px"></col>
												<col style="WIDTH: 324px"></col>
											</colgroup>
											<tbody vAlign="top">
												<tr style="MIN-HEIGHT: 1in">
													<td style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
														<div>
															<span style="FONT-SIZE: 12pt">
																<strong>
																	<font face="Times New Roman">E-Mail</font>
																</strong>
															</span>
														</div>
													</td>
													<td style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
														<div><span class="xdTextBox" hideFocus="1" title="" xd:xctname="PlainText" xd:CtrlId="CTRL4" xd:binding="my:field4" tabIndex="-1" xd:disableEditing="yes" style="WIDTH: 100%; WHITE-SPACE: nowrap; WORD-WRAP: normal">
																<xsl:value-of select="my:field4"/>
															</span>
														</div>
													</td>
												</tr>
											</tbody>
										</table>
									</div>
									<div>
										<table class="xdFormLayout xdLayout" style="TABLE-LAYOUT: fixed; WIDTH: 647px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1">
											<colgroup>
												<col style="WIDTH: 323px"></col>
												<col style="WIDTH: 324px"></col>
											</colgroup>
											<tbody vAlign="top">
												<tr style="MIN-HEIGHT: 1in">
													<td style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
														<div>
															<span style="FONT-SIZE: 12pt">
																<strong>
																	<font face="Times New Roman">Skills</font>
																</strong>
															</span>
														</div>
													</td>
													<td style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
														<div><span class="xdTextBox" hideFocus="1" title="" xd:xctname="PlainText" xd:CtrlId="CTRL5" xd:binding="my:field5" tabIndex="-1" xd:disableEditing="yes" style="WIDTH: 100%; WHITE-SPACE: nowrap; WORD-WRAP: normal">
																<xsl:value-of select="my:field5"/>
															</span>
														</div>
													</td>
												</tr>
											</tbody>
										</table>
									</div>
									<div>
										<table class="xdFormLayout xdLayout" style="TABLE-LAYOUT: fixed; WIDTH: 647px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1">
											<colgroup>
												<col style="WIDTH: 323px"></col>
												<col style="WIDTH: 324px"></col>
											</colgroup>
											<tbody vAlign="top">
												<tr style="MIN-HEIGHT: 1in">
													<td style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
														<div>
															<span style="FONT-SIZE: 12pt">
																<strong>
																	<font face="Times New Roman">Other</font>
																</strong>
															</span>
														</div>
													</td>
													<td style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
														<div><span class="xdTextBox" hideFocus="1" title="" xd:xctname="PlainText" xd:CtrlId="CTRL6" xd:binding="my:field6" tabIndex="-1" xd:disableEditing="yes" style="WIDTH: 100%; WHITE-SPACE: nowrap; WORD-WRAP: normal">
																<xsl:value-of select="my:field6"/>
															</span>
														</div>
													</td>
												</tr>
											</tbody>
										</table>
									</div>
									<div>
										<font size="2"></font> </div>
								</td>
							</tr>
						</tbody>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
