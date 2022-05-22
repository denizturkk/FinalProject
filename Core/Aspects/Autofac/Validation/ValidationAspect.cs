using Castle.DynamicProxy;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //ASPECT
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //IValidator--fluent validation
            //BANK CORE DEVELOPPERS??  
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new @System.Exception("this is not a validation class ");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //reflection: creates instance of type(_validatorType) at
            //runtime then parse it to IValidator(lets sey this is productvalidator).
            //so this is product validator 
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            
            //get base type of productValidator(we assumed that is prod. valid.) then
            //get first generic parameters of that base type(product)
            //this is product
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            
            //EN
            //look at the parameters of method(invocation==method kinda &&==IResult Add(parameters))
            // then select the the parameter between parameters that matches the type of validation.
            //this can be more than 1 products
            //TR
            //add fonksiyonundaki dogrulama tipi product oldugu icin metodun icindeki parametrelerde
            //product u arıyor.birden fazla olabilir    
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
