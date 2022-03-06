using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConserns.Validation
{
    //generally this type of tools are static
    ///1 instance 
    public static class ValidationTool
    {
        //for ex:IValidator:product validator,entity:product
       public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
