using System;

namespace MemberRegistry.model.validation
{
    interface IValidatable 
    {
        void Validate(model.validation.IValidator validator);
    }

}