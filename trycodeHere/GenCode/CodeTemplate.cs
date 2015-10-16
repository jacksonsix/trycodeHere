using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trycodeHere.GenCode
{
    public class CodeTemplate
    {
        private seed _seed;
        private BasicSeed _basicseed;

        public string logicinterfacestring = @" {0} {1}({2});";
        public string logicbasestring = @"
        public virtual {0} {1}({2})
        [
            return CustomerDAL.{1}({3});
        ]
        ";                                          
                                            
        public string dalinterfacestring = "";
        public string dalbasestring = @"
        public  {0} {1}({2})
        [
            var db = DatabaseFactory.Create(ClientConfiguration.LegacyInstanceDbConnectionStringName);
                                               
            var cmd = db.GetStoredProcCommand(sql);                                              

            var dataSet = db.ExecuteDataSet(cmd);

            return (dataSet.Tables[0].Rows.Count <= 0) ? null : dataSet.Tables[0].Rows[0].CreateFromRow<{0}>();
        ]
        ";

        public CodeTemplate(seed seed)
        {
            this._seed = seed;
        }
        public CodeTemplate()
        { 
        }
        public CodeTemplate(BasicSeed bseed)
        {
            this._basicseed = bseed;
        }

        public void writeFile(IList<string> codes)
        {
            // NOTE: do not use FileStream for text files because it writes bytes, but StreamWriter
            // encodes the output as text.
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\jason.liang\Documents\genCode.txt"))
            {
                for(int i =0;i< codes.Count;i++) 
                {
                    string line = codes[i];                 
                    file.WriteLine(line);                  
                }
            }
        }

        public IList<string> gen()
        {
            List<string> codes = new List<string>();
            codes.Add(genLogicinterface());
            codes.Add(genLogicbase());
            codes.Add(genDALInterface());
            codes.Add(genDALbase());
            return codes;
        }

        private string genLogicinterface()
        {           
            string paras="";
            for (int i = 0; i < _basicseed.Params.Count;i++ )
            {
                paras = paras + _basicseed.Params[i].Value + " " + _basicseed.Params[i].Key + ",";
            }
            paras = paras.Remove(paras.Length-1);
            string logicinterface = String.Format(logicinterfacestring, _basicseed.ReturnType,_basicseed.FuncName, paras);
            return logicinterface;
        }

        private string genLogicbase()
        {
            string paras="";
            for (int i = 0; i < _basicseed.Params.Count;i++ )
            {
                paras = paras + _basicseed.Params[i].Value + " " + _basicseed.Params[i].Key + ",";
            }
            paras = paras.Remove(paras.Length-1);

            string cp = "";
            for (int i = 0; i < _basicseed.Params.Count; i++)
            {
                cp = cp + _basicseed.Params[i].Key  + ",";
            }
            cp = cp.Remove(cp.Length - 1);
           
           
            string logicinterface = String.Format(logicbasestring, _basicseed.ReturnType, _basicseed.FuncName, paras,cp);
            return logicinterface;
        }

        private string genDALInterface()
        {
            string paras = "";
            for (int i = 0; i < _basicseed.Params.Count; i++)
            {
                paras = paras + _basicseed.Params[i].Value + " " + _basicseed.Params[i].Key + ",";
            }
            paras = paras.Remove(paras.Length - 1);
            string logicinterface = String.Format(logicinterfacestring, _basicseed.ReturnType, _basicseed.FuncName, paras);
            return logicinterface;
        }

        private string genDALbase()
        {
            string paras = "";
            for (int i = 0; i < _basicseed.Params.Count; i++)
            {
                paras = paras + _basicseed.Params[i].Value + " " + _basicseed.Params[i].Key + ",";
            }
            paras = paras.Remove(paras.Length - 1);
            string logicinterface = String.Format(dalbasestring, _basicseed.ReturnType, _basicseed.FuncName, paras);
            return logicinterface;
        }


    }
}
