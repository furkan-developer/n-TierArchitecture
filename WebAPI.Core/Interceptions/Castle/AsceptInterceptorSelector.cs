using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Core.Interceptions.Castle
{
    public class AsceptInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttribute = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

            var methodAttribute = type.GetMethod(method.Name)?.GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

            if (!methodAttribute.Equals(null))
                classAttribute.AddRange(methodAttribute);
            return classAttribute.OrderBy(a => a.Priority).ToArray();
        }
    }
}
