using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trycodeHere.GenCode
{

    public class BasicSeed
    { 
        public string ReturnType;   //= "ContactEmail",
        public string FuncName;    //="Validate"
        public List<KeyValuePair<string,string>> Params; // int id , string uid
        //public List<string> ParaMembers;
    }

    public class seed
    {
        private string jsonclass;
        private IList<string[]> attibutes;

        public seed(string pseed)
        {
            this.jsonclass = pseed;
            attibutes = new List<string[]>();
        }

        public BasicSeed getBasicSeed()
        {
            var result = JsonConvert.DeserializeObject<BasicSeed>(jsonclass);
            return result;
        }

        public IList<string[]> getAttributes()
        { 
            dynamic dynObj = JsonConvert.DeserializeObject(jsonclass);
            //JContainer is the base class
            var jObj = (JObject)dynObj;
            foreach (JToken token in jObj.Children())
            {
                if (token is JProperty)
                {
                    var prop = token as JProperty;
                    var array = new string[2];
                    array[0] = prop.Name;
                    array[1] = prop.Value.ToString();
                    attibutes.Add(array);                   
                }
            }
            return attibutes;           
        }
    }
}
