using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trycodeHere.GenCode
{
    public class CodeGen
    {
        private string _codeString;
        private seed _seed;
        private CodeTemplate _template;
        private InsertWorker _worker;

        public CodeGen()
        {
            _codeString = "";
            _seed = new seed("");
            _template = new CodeTemplate();
            _worker = new InsertWorker();
        }
        public CodeGen(seed pseed, CodeTemplate pcodetemplate, InsertWorker pworker)
        {
            this._seed = pseed;
            this._template = pcodetemplate;
            this._worker = pworker;
        }
        public void Generate()
        { 
            
        }

        public void InsertCode()
        { 
            
        }

    }
}
