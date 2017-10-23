using System;

namespace MemberRegistry.model.validation
{
    interface IValidator
    {
	    void Validate(model.Member member);
	    void Validate(model.Boat boat);
    }
}