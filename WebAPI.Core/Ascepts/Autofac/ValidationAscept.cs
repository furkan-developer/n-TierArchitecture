using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.CrossCuttingConcerns.Validation.FluentValidation;
using WebAPI.Core.Interceptions.Castle;

namespace WebAPI.Core.Ascepts
{
    public class ValidationAscept : MethodInterception
    {
        private readonly Type _validatorType;

        public ValidationAscept(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new ValidationException("Doğrulama yapılacak referans yanlış");

            _validatorType = validatorType;
        }

        public override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
