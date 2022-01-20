using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Core.Utilities.ResultStructure
{
    public interface IResult
    {
        bool Process { get; }
        string Message { get; }
    }
}
