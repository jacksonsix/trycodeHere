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

        public static void test()
        {
            basec x = new d1();
            basec x1 = new d2();
            listx ll = new listx();
            ll.baselist.Add(x);
            ll.baselist.Add(x1);

            SerialtoXml(ll, ll.GetType());

        }

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
    }
}
