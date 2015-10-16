using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace trycodeHere.html
{

    public class KeyValue
    {
        public string key;
        public string value;
    }

    [XmlInclude(typeof(iTable))]
    [XmlInclude(typeof(iRow))]
    [XmlInclude(typeof(iCell))]
    public class iNode 
    {     
        public string ControlType;
        public List<KeyValue> attrs;      
        public List<iNode> children;

        public iNode()
        {
            attrs = new List<KeyValue>();
            children = new List<iNode>();
        }

       public void importfromControl(WebControl control)
        {
            string[] AttributeName = new string[control.Attributes.Count];
            control.Attributes.Keys.CopyTo(AttributeName, 0);

            for (int i = 0; i < AttributeName.Length; i++)
            {
                var d = new KeyValue();
                d.key = AttributeName[i];
                d.value = control.Attributes[AttributeName[i]];
                attrs.Add(d);
            }
           if (control.CssClass != null && control.CssClass.Length > 0) attrs.Add(new KeyValue { key = "Class", value = control.CssClass } );
           if (control.Style != null ) attrs.Add(new KeyValue { key = "Style", value = control.Style.ToString() });
           
        }

       public void importFromHtmlNode(ref HtmlNode node)
       {
           _import(this, ref node);
       }

       private void _import(iNode n, ref HtmlNode htmln)
       {
           htmln.Id = "red";
           n.ControlType = htmln.Name;
           string[] AttributeName = new string[htmln.Attributes.Count];        

           for (int i = 0; i < AttributeName.Length; i++)
           {
               HtmlAttribute at = htmln.Attributes[i];
               var d = new KeyValue();
               d.key = at.Name;
               d.value = at.Value;
               n.attrs.Add(d);
           }

           if (htmln.Descendants().Count() > 0)
           {
               var list = htmln.Descendants().ToList();

               for (int i = 0; i < list.Count;i++ )
               {
                   var v =list[i];
                   var name = v.Name;
                   if (name.Contains("text") || name.Contains("td") || name.Contains("tr")) continue;
                   iNode nc = new iNode();
                   n.children.Add(nc);
                   _import(nc, ref v);
               }
           }

            
       }


       public virtual string renderHtml()
       {
           return _render(this);          
       }

       private string _render(iNode adpt)
       { 
            var tags = new System.Web.Mvc.TagBuilder(adpt.ControlType);
            StringBuilder sb = new StringBuilder();
            for (int i=0;i< adpt.children.Count ;i++)
            {
                string sss=_render(adpt.children[i]);
                sb.Append(sss);
            }
            tags.InnerHtml = sb.ToString();

            foreach (var a in adpt.attrs)
            {
                tags.Attributes.Add(a.key,a.value);
            }
            string html = tags.ToString();
            return html;
       }

    }

    public class iCell : iNode    // td
    {
        public override string renderHtml()
        {
           return _render(this);
        }
        private string _render(iNode adpt)
        {           
            var tags = new System.Web.Mvc.TagBuilder("td");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < adpt.children.Count; i++)
            {
                string sss = adpt.children[i].renderHtml();
                sb.Append(sss);
            }
            tags.InnerHtml = sb.ToString();

            foreach (var a in adpt.attrs)
            {
                tags.Attributes.Add(a.key, a.value);
            }
            return tags.ToString();            
        }
    }
    public class iRow :iNode                 // tr
    {
        public iCell[] cells;
        public iRow()
        {
            cells = new iCell[0];
        }

        public void addCell(int i,iNode element)
        {
            iCell c = new iCell();
            c.children.Add(element);
            if (i < 0) return;
            else if (i >= cells.Length)
            {
                var copy = new iCell[i + 1];
                Array.Copy(cells, copy, cells.Length);
                for (int j = cells.Length; j < copy.Length; j++)
                {
                    iCell cel = new iCell();
                    copy[j] = cel;
                }
                copy[i] = c;
                cells = copy;
            }
            else
            {
                cells[i] = c;
            }
        }

        public override string renderHtml()
        {          
            var tags = new System.Web.Mvc.TagBuilder("tr");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cells.Length; i++)
            {
                string sss =cells[i].renderHtml();
                sb.Append(sss);
            }
            tags.InnerHtml = sb.ToString();

            foreach (var a in attrs)
            {
                tags.Attributes.Add(a.key, a.value);
            }   
            return tags.ToString();
        }
    }


    public class iTable : iNode
    {
        public iRow[] rows;
        public iTable()
        {
             rows = new iRow[0];
        }

        public override string renderHtml()
        {                  
            var tags = new System.Web.Mvc.TagBuilder("table");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows.Length; i++)
            {
                string sss = rows[i].renderHtml();
                sb.Append(sss);
            }
            tags.InnerHtml = sb.ToString();

            foreach (var a in attrs)
            {
                tags.Attributes.Add(a.key, a.value);
            }              

            return  tags.ToString();   
        }

        public void addAt(int i, int j, iNode element)
        {
            if (i < 0) return;
            else if (i >= rows.Length)
            {
                var copy = new iRow[i + 1];
                Array.Copy(rows, copy, rows.Length);
                for (int k = rows.Length; k < copy.Length; k++)
                {
                    iRow m = new iRow();
                    copy[k] = m;
                }
                copy[i].addCell(j, element);
                rows = copy;
            }
            else
            { 
                var tr = rows[i];
                tr.addCell(j, element);
            }

        }      
    }



    [Serializable]
    public class ListLayout
    {
        public string name { get; set; }
        public string id;
        private string createdby { get; set; }
        // [XmlArray(ElementName = "Controls")]
        //[XmlArrayItem(ElementName = "control")]
        public List<iNode> controls { get; set; }
        public ListLayout()
        {
            name = "linearLayout";
            createdby = "BY me";
            controls = new List<iNode>();
        }
        public void addView(iNode v)
        {
            controls.Add(v);
        }

        public string RenderHtml()
        {
            //var tags = new System.Web.Mvc.TagBuilder(t);

            StringBuilder ssb = new StringBuilder();
            for (int i = 0; i < controls.Count; i++)
            {
                ssb.Append(controls[i].renderHtml());
            }

            string final = ssb.ToString();
            return final;
        }

        //public void setAdapter(Adaptor apt) { }
        //public void setOnItemclickListner() { }
    }


    public class webControls
    {

        private static void Import()
        {
            string sStartupPath = @"C:\F3MobileDev\Mobile\test.xml";          
           
            string fileText = System.IO.File.ReadAllText(sStartupPath);
          
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(fileText);

           // HtmlNode specificNode = 
            HtmlNodeCollection nodesMatchingXPath = doc.DocumentNode.SelectNodes("x/path/nodes");

            var clo = doc.DocumentNode.Descendants().ToList();
            iNode root = new iNode();
            root.ControlType = "label";
            for (int i = 0; i < clo.Count;i++ )
            {
                var v = clo[i];
                string name = v.Name;
                if (name.Contains("text") || name.Contains("td") || name.Contains("tr")) continue;
                if (v.Id.Equals("red")) continue;
                iNode n = new iNode();
                n.ControlType = name;
                n.importFromHtmlNode(ref v);
                root.children.Add(n);
            }

            string s = root.renderHtml();
           

        }

        public static void test()
        {
            Import();

            var btn = new System.Web.UI.WebControls.Button();
            btn.Text = "click om me";
            btn.OnClientClick = "here";
            btn.CssClass = "w3-input";
            btn.Attributes["acw"] = "acw";
            btn.Attributes["acwss"] = "acwss";

            if(btn.CssClass != null && btn.CssClass.Length>0) btn.Attributes["CssClass"] = btn.CssClass;
            if (btn.OnClientClick != null && btn.OnClientClick.Length > 0) btn.Attributes["OnClientClick"] = btn.OnClientClick;

            var adp = new iNode();
            adp.importfromControl(btn);
            adp.ControlType = btn.GetType().Name;


            var tab = new System.Web.UI.WebControls.Table();            
            tab.Attributes.Add("keya","valuea");
            var adp2 = new iTable();
            adp2.ControlType = tab.GetType().Name;
            adp2.importfromControl(tab);

            adp2.addAt(0, 0, adp);
            
            
            //adp.children.Add(adp2);

            var layout = new ListLayout();
            layout.addView(adp2);
            //layout.addView(adp2);

            //adp.exporttoControl(btn);

            trycodeHere.XML.mySerializer.SerialtoXml(layout, layout.GetType());

            var x = (ListLayout)trycodeHere.XML.mySerializer.LoadFromxml(typeof(ListLayout));

            string ssx = x.RenderHtml();
        }
      
    }
}
