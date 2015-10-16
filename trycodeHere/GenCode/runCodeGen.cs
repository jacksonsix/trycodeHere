using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trycodeHere.GenCode
{
    public class runCodeGen
    {
        public  static void run()
        {
            var para = new List<KeyValuePair<string,string>>();
            KeyValuePair<string, string> p1 = new KeyValuePair<string, string>("id","int");
            KeyValuePair<string, string> p2 = new KeyValuePair<string, string>("uid", "string");   
            para.Add(p1);
            para.Add(p2);

            var product = new BasicSeed {
                ReturnType= "ContactEmail",
                FuncName="Validate",
                Params = para
            };

            string cls = JsonConvert.SerializeObject(product);
            seed test = new seed(cls);
            var basic = test.getBasicSeed();
            CodeTemplate codet = new CodeTemplate(basic);
            var v1 = codet.gen();
            codet.writeFile(v1);
        }
    }
}
