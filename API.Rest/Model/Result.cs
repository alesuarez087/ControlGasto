using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Rest.Model
{
    public class Result
    {        
        public Object Data
        {
            get;set;
        }

        public string Search
        {
            get;set;
        }

        public string Success
        {
            get;set;
        }

        public string Error
        {
            get;set;
        }
    }
}
