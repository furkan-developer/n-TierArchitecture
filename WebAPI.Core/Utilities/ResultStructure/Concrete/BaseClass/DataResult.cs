using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.Utilities.ResultStructure.Abstact;

namespace WebAPI.Core.Utilities.ResultStructure
{
    public class DataResult<T> : Result,IDataResult<T>
    {
        public DataResult(T data,bool process) : base(process)
        {
            Data = data;
        }

        public DataResult(T data,bool process, string message) : base(process, message)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
