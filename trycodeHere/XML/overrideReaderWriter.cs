using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace trycodeHere.XML
{   

    public class MySetting
    {
        public string Enabled;
        public string MakeItFast;
    }

    public class myAdaptor1 : System.Web.UI.Adapters.ControlAdapter
    {
        private string tagName;
        private System.Web.UI.HtmlTextWriterTag tagKey;
        private System.Web.UI.AttributeCollection attrColl;
        private System.Web.UI.StateBag attrState;
        private System.Web.UI.WebControls.Style controlStyle;
    }

    
    public class overrideReaderWriter
    {

        public static void test1()
        {
            Stream config = File.Open("config.xml", FileMode.Open, FileAccess.ReadWrite);
            //var btn = new System.Web.UI.WebControls.Button();
            var btn = new myAdaptor1();
            XmlSerializer ser = new XmlSerializer(btn.GetType());
            XmlFirstLowerWriter fw = new XmlFirstLowerWriter(config, Encoding.UTF8);
            ser.Serialize(fw, btn);
        }

        public static void test()
        {           
            Stream config = File.Open("config.xml",FileMode.Open,FileAccess.ReadWrite);
           
            XmlFirstUpperReader fr = new XmlFirstUpperReader(config);

            // You should always validate your config at least with XSD
            //XmlValidatingReader vr = new XmlValidatingReader(fr);
            //// Add the PascalCased XSD.
            //vr.Schemas.Add(theSchema);

            XmlSerializer ser = new XmlSerializer(typeof(MySetting));
            MySetting settings = (MySetting)ser.Deserialize(fr);
            //After modifying the settings class, you can save it back into the file with the proper camelCase by using the custom writer:

            //MySetting settings = (MySetting)ser.Deserialize(vr);
            // Modify the settings at will.

            XmlFirstLowerWriter fw = new XmlFirstLowerWriter(config,Encoding.UTF8);
            ser.Serialize(fw, settings);
        }
    }
    
}