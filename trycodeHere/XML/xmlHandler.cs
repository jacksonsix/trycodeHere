using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

//Or alternatively if you have the XML in a string use the LoadXml method.
//Once you have it loaded, you can use SelectNodes and SelectSingleNode to query specific values, for example:
//XmlNode node = doc.SelectSingleNode("//Company/Email/text()");

namespace trycodeHere
{
    class xmlHandler
    {

        private XmlDocument doc = new XmlDocument();
        public xmlHandler(string file)
        {
            doc.Load(file);
        }

        public void selectSinglenode()
        {
            XmlNode node = doc.SelectSingleNode("//Header/TraceProvider/text()");
        }

        public void selectNodes()
        { 
            
        }
       
    }
}
