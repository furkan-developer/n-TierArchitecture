using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Core.Interceptions.Castle
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        public override void Intercept(IInvocation invocation)
        {
            bool successflag = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                successflag = false;
                OnException(invocation,ex);
                throw;
            }
            finally
            {
                if (successflag)
                    OnSuccess(invocation);
            }
            OnAfter(invocation);
        }

        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception ex) { }
    }
}
