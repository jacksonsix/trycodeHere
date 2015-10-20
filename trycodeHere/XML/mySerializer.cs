using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace trycodeHere.XML
{

    [XmlInclude(typeof(d1))]
    [XmlInclude(typeof(d2))]
    public abstract class basec
    {
        public string name="basec";
        
    }
    public class d1 : basec
    {
        public string dname = "d1";
    }

    public class d2 : basec
    {
        public string dname = "d2";
    }

    public class listx
    {
        public List<basec> baselist;
        public listx()
        {
            baselist = new List<basec>();
        }
    }

    public class mySerializer
    {      

        public static object LoadFromxml(System.Type t)
        {
            string sStartupPath = @"C:\F3MobileDev\Mobile\testwrite.xml";
            using (var stream = System.IO.File.OpenRead(sStartupPath))
            {
                var serilizer = new XmlSerializer(t);
                using (var xmlreader = new XmlTextReader(stream))
                {
                    var obj = serilizer.Deserialize(xmlreader);
                    return obj;
                }
            }
        }

        public static void SerialtoXml(object target, Type t)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlSerializer xsSubmit = new XmlSerializer(t);
            using (XmlWriter writer = XmlWriter.Create(@"C:\F3MobileDev\Mobile\testwrite.xml", settings))
            {
                xsSubmit.Serialize(writer, target);
                writer.Flush();
            }
        }

        public static void WriteHtml(string lines)
        {
            string tpath = @"C:\F3MobileDev\Mobile\new1.html";
            System.IO.StreamWriter file = new System.IO.StreamWriter(tpath);
            file.WriteLine("<html>");
            file.WriteLine("<head>");
            file.WriteLine(@"<style>
        .PropertyTopHeader
        {
            font-family: Arial, Verdana, Helvetica, sans-serif;
            font-size: 22px;
            font-weight: bold;
            color: #a60d00;
            text-decoration: none;
        }
        .maincontentsurvey2
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 10px;
            color: #000000;
            text-decoration: none;
        }
        .p9
        {
            padding: 9px;
        }
        .p5
        {
            padding: 5px;
        }
        .LoginTable
        {
            background-color: #F4F4F4;
        }
        .LoginBody
        {
            background-color: #333333;
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
        }
        .dealerTopHeader
        {
            font-family: Tahoma, Arial, Helvetica, sans-serif;
            font-size: 30px;
            font-weight: bold;
            color: #2D4082;
        }
        .dealerTopHeaderLogout
        {
            font-family: Arial, Helvetica, Sans-Serif;
            font-size: 11px;
            font-weight: bold;
            text-decoration: none;
            color: #2D4082;
        }
        .dealerTopHeaderNews
        {
            font-family: Arial, Helvetica, Sans-Serif;
            font-size: 11px;
            font-weight: bold;
            text-decoration: none;
            color: #FF3300;
        }
        .surveySideBanner
        {
            background-color: #F0F0F0;
        }
        .CustomerSatisfactionTitle
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
	        font-size: 12px;
	        color: #000000;
	        font-weight: bold;
        }
        .null
        {
        }
        .content
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #FF0000;
        }
        .smallscale
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 10px;
            font-weight: bold;
            color: #000000;
            padding: 5px 0;
        }
        .boldcontent
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: bold;
            color: #FF0000;
        }
        .contentbox
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            border: 1px #000000 solid;
        }
        a.mainlinks
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            color: #333300;
            text-decoration: none;
        }
        a.mainlinks:hover
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            color: #FF0000;
            text-decoration: none;
        }
        a.tab
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: bold;
            text-decoration: none;
        }
        a.tab:link
        {
            color: #FFFFFF;
        }
        a.tab:visited
        {
            color: #FFFFFF;
        }
        a.tab:hover
        {
            color: #FFFF00;
        }
        .legend
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 10px;
        }
        .imageborder
        {
            border-top: 1px groove #99CCCC;
            border-right: 1px groove #99CCCC;
            border-bottom: 1px groove #CCFFFF;
            border-left: 1px groove #CCFFFF;
        }
        .deletebutts
        {
            background-image: url(images/deletebutton.gif);
        }
        .butts
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            color: #FFFFFF;
            border: 1px solid #efefef;
            background-color: #ff0000;
        }
        .bleft
        {
            font-family: Times New Roman, Times, serif;
            font-size: 30px;
            text-align: Left;
            color: #FFFFFF;
        }
        .bright
        {
            padding-right: 5px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: italic;
            text-align: Right;
            color: #FFFFFF;
        }
        .copyright
        {
            font-family: Arial, Verdana, Helvetica, Sans-Serif;
            font-size: 9px;
            text-align: center;
            color: #999999;
        }
        .no-border
        {
            border-width: 0px;
        }
        textarea
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            text-align: left;
            color: black;
        }
        .tooltiptitle
        {
            color: #FFFFFF;
            text-decoration: none;
            cursor: Default;
            font-family: arial;
            font-weight: bold;
            font-size: 8pt;
        }
        .tooltipcontent
        {
            color: #000000;
            text-decoration: none;
            cursor: Default;
            font-family: arial;
            font-size: 8pt;
        }
        #ToolTip
        {
            position: absolute;
            width: 100px;
            top: 0px;
            left: 0px;
            z-index: 4;
            visibility: hidden;
        }
        .coupondealer
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 18px;
            font-weight: bold;
            text-align: left;
            color: black;
            padding-top: 10px;
            padding-left: 20px;
            padding-right: 15px;
        }
        .coupontext
        {
            font-family: Tahoma, Arial, Helvetica, sans-serif;
            font-size: 11px;
            text-align: left;
            padding-left: 20px;
            padding-right: 15px;
            color: black;
        }
        .couponptext
        {
            font-family: Tahoma, Arial, Helvetica, sans-serif;
            font-size: 11px;
            text-align: left;
            color: black;
        }
        .sortable
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            color: #003366;
            font-weight: bold;
            text-decoration: none;
            text-align: center;
        }
        table.sortable span.sortarrow
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #003366;
            text-decoration: none;
            text-align: center;
        }
        .sortbottom
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            color: #003366;
            text-decoration: none;
        }
        .userAdminRegion_mbgsap
        {
            overflow: auto;
            width: 425px;
            height: 250px;
            border-left-style: solid;
            border-left-width: 1px;
            border-left-color: #DEDEDE;
        }
        .legendHeader
        {
            /*background-color:#999999; 
	color: #000000; 
	font-size: 10px; 
	font-weight:bold; 
	font-family: Verdana, Arial, Helvetica, Sans-Serif;*/
            color: #003366;
            font-size: 12px;
            font-weight: bold;
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
        }
        .legendRow
        {
            /*background-color:#FFFFFF; 
	font-size: 10px; 
	font-family: Verdana, Arial, Helvetica, Sans-Serif;*/
            font-size: 10px;
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-weight: bold; /*text-decoration: underline;*/
        }
        .legendAlt
        {
            /*background-color:#FFFFCC; 
	font-size: 10px; 
	font-family: Verdana, Arial, Helvetica, Sans-Serif;*/
            font-size: 10px;
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
        }
        .maintitle
        {
            font-family: Arial, Helvetica, Sans-Serif;
            font-size: 11px;
            font-weight: bold;
            color: #FFFFFF;
            text-decoration: none;
            background-color: #0066FF;
        }
        .mainpager
        {
            font-family: Arial, Helvetica, Sans-Serif;
            font-size: 11px;
            font-weight: normal;
            color: #003366;
            text-align: right;
        }
        .mainheading
        {
            font-family: Arial, Helvetica, Sans-Serif;
            font-size: 11px;
            font-weight: bold;
            color: #003366;
            text-decoration: none;
            text-align: center;
            background-color: #E9E9E9;
        }
        .mainheading_left
        {
            font-family: Arial, Helvetica, Sans-Serif;
            font-size: 11px;
            font-weight: bold;
            color: #003366;
            text-decoration: none;
            text-align: left;
            background-color: #E9E9E9;
        }
        .maincontent
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            color: #003366;
            text-decoration: none;
        }
        .maincontent_alternatingrow
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            background-color: #DEDEDE;
            color: #003366;
            text-decoration: none;
        }
        .maincontent_bold
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: bold;
            color: #003366;
            text-decoration: none;
        }
        .maincontent_underline
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: bold;
            color: #003366;
            text-decoration: underline;
        }
        .mainfooter
        {
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-size: 11px;
            font-weight: normal;
            color: #003366;
            text-decoration: none;
            text-align: center;
            background-color: #FFFFCC;
        }
        label, input
        {
            font-family: Arial, Helvetica, Sans-Serif;
            font-size: 12px;
            font-weight: normal;
            color: #000000;
        }
        .redborder
        {
            border-color: red;
            border-width: 3px;
            border-style:solid;
        }
        .grayborder textarea
        {
            border-color: gray;
            border-width: 1px;
            border-style:solid;
        }
        .allinputs
        {
            font-family: Arial, Helvetica, Sans-Serif;
            font-size: 12px;
            font-weight: normal;
            color: #000000;
        }
        .allinputs1
        {
            font-family: Arial, Helvetica, Sans-Serif;
            font-size: 10px;
            font-weight: normal;
            color: #000000;
        }
       .allinputsaddcomment
        {
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-size: 9px;
            font-weight: normal;
            color: #5CB3FF;
            cursor:pointer;
        }
        .allinputsLabel
        {
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-size: 6.4pt;
            font-weight: bold;
            color: #000000;
        }
         .allinputsNRNO
        {
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-size: 6.4pt;
            font-weight: normal;
            color: #000000;
        }
        .allcontrols
        {
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-size: 10px;
            font-weight: normal;
            color: #000000;
            height: 22px;
        }
        .alltitle
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 15px;
            color: #0000FF;
        }
        .alllinks
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 15px;
            color: #0000FF;
            text-decoration: underline;
        }
        .smalllinks
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            color: #0000FF;
            text-decoration: underline;
        }
        .textlinks
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            color: #003366;
            text-decoration: underline;
        }
        table
        {
            border-collapse: collapse;
        }
        .style1
        {
            color: #FFFFFF;
            font-weight: bold;
        }
        a.style2
        {
            color: #FFFFFF;
            text-decoration: none;
        }
        .style2
        {
            color: #FFFFFF;
        }
        a.style3
        {
            color: #003366;
            text-decoration: none;
        }
        a.style3u
        {
            color: #003366;
            text-decoration: underline;
        }
        .style2
        {
            color: #FFFFFF;
        }
        .csichart
        {
            font-family: Tahoma, Arial, Helvetica, sans-serif;
            font-size: 10px;
            color: #FFFFFF;
        }
        .csilegend
        {
            font-family: Tahoma, Arial, Helvetica, sans-serif;
            font-size: 10px;
            color: #000000;
        }
        .box
        {
            padding-left: 5px;
            padding-right: 5px;
            padding-top: 2px;
            padding-bottom: 2px;
            border: 1px #000000 solid;
        }
        .barchart
        {
            padding-left: 0px;
            padding-right: 0px;
            padding-top: 2px;
            padding-bottom: 2px;
            border-left: 1px #000000 solid;
            border-bottom: 1px #000000 solid;
        }
        .linechart
        {
            font-family: Tahoma, Arial, Helvetica, sans-serif;
            font-size: 10px;
            color: #000000;
        }
        A:link
        {
            text-decoration: none;
            color: #999999;
        }
        A:visited
        {
            text-decoration: none;
            color: #999999;
        }
        A:active
        {
            text-decoration: none;
            color: #999999;
        }
        .label
        {
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-weight: bold;
            font-size: 10px;
        }
        .label_red
        {
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-size: 11px;
            font-weight: bold;
            color: #FF0000;
            height: 22px;
        }
        .label_blue
        {
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-size: 11px;
            font-weight: bold;
            color: #0000FF;
            height: 22px;
        }
        /*Modal Popup*/
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=70);
            opacity: 0.7;
            -moz-opacity: 0.7;
        }
        /*Modal Popup*/
        .modalPopup
        {
            /*background-color: #F0FFFF;*/
            background-image: url(../images/dealer-list-window.png);
            background-repeat: no-repeat; /*border-width: 3px;
	border-style: solid;
	border-color: Gray;*/
            padding: 3px;
            height: 300px;
            width: 450px;
        }
        .modalWindowContent td
        {
            color: black;
            font-family: Verdana;
            font-size: 12px;
            text-align: left;
        }
        /*CollapsiblePanel*/.collapsePanel
        {
            background-color: #DDDDDD;
            overflow: hidden;
        }
        /*CollapsiblePanel*/.collapsePanelHeader
        {
            width: 100%;
            height: 10px;
            background-color: Silver;
            background-repeat: repeat-x;
            color: #FFF;
            font-weight: bold;
        }
        /*Hover Menu*/.popupMenu
        {
            /*position:absolute;*/
            width: 250px;
            top: 0px;
            left: 0px;
            background-color: #FFFFFF;
            visibility: hidden;
            border: solid 1px #000000;
        }
        .userAdminButton
        {
            float: right;
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-size: 10px;
            font-weight: normal;
            padding: 2px 4px 6px 4px;
        }
        .userAdminButtonDisabled
        {
            /* firefox only */
            float: right;
            font-family: Verdana, Arial, Helvetica, Sans-Serif;
            font-size: 10px;
            font-weight: normal;
            color: Gray;
            padding: 2px 4px 6px 4px;
        }
        a.userAdminButton
        {
            text-decoration: underline;
        }
        .userAdminTitleBar
        {
            vertical-align: top;
            background-image: url(../images/section_title_bar.gif);
            background-repeat: repeat-x;
        }
        .userAdminSpacer
        {
            float: right;
            margin-right: 25px;
            padding: 1px;
            display: block;
        }
        .userAdminRegion
        {
            overflow: scroll;
            width: 375px;
            height: 250px;
            border-left-style: solid;
            border-left-width: 1px;
            border-left-color: #DEDEDE;
        }
        /* Content Page Layout             */.demoarea
        {
            padding: 20px;
            background-color: transparent;
        }
        .demoarea p
        {
            padding: 5px;
        }
        .demoheading
        {
            padding-bottom: 20px;
            color: #5377A9;
            font-family: Arial, Sans-Serif;
            font-weight: bold;
            font-size: 1.5em;
        }
        .demobottom
        {
            height: 8px;
            background: #FFF url(../images/demobottom.png) no-repeat left bottom;
        }
        .icon
        {
            vertical-align: middle;
        }
        .wizard
        {
            padding: 0 10px 10px 10px;
        }
        .wizardsidebar
        {
            padding: 2px 10px 2px 10px;
            background: url(../images/adduserbg.jpg) repeat-x;
        }
        .wizardsidebarimg
        {
            width: 16px;
            height: 16px;
            behavior: url(pngbehavior.htc);
        }
        .datagrids
        {
            border-width: 0px;
        }
        .radiobuttonlistheaderitem
        {
            white-space: nowrap;
        }
        .radiobuttoncolumn
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            color: #003366;
            text-align: left;
            text-decoration: none;
        }
        .hiddencolumn
        {
            display: none;
        }
        .customradiobuttontext
        {
            text-align: center;
            width: 80px;
        }
        .ultrasmall 
        {
            font-size:1px;
        }
       

    </style>");
            file.WriteLine("</head>");
            file.WriteLine("<body>");
            file.WriteLine(lines);
            file.WriteLine("</body>");
            file.Close();
        }
    }
}
