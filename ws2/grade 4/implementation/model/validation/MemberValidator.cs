using System;

namespace MemberRegistry.model.validation
{
    class MemberValidator : IValidator
    {
	    public void Validate(model.Member member)
        {
            Console.WriteLine("Validating Member.");
        }

	    public void Validate(model.Boat boat)
        {
            Console.WriteLine("Validating Boat.");
        }
    }
}