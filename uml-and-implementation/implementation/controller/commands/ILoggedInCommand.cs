using System;
using System.Collections.Generic;

namespace MemberRegistry.controller.commands 
{
    interface ILoggedInCommand 
    {
        void EnsureUserIsLoggedIn(model.Member user);
    }
}