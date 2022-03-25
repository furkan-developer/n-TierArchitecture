using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.Utilities.ResultStructure;

namespace WebAPI.Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var item in logics)
            {
                if (!item.Process)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
