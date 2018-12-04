using System;
using System.Collections.Generic;

namespace MemberRegistry.persistance
{
   interface IPersistance
    {
        List<model.Member> RetrieveMemberList();

        void SaveMemberList(List<model.Member> content);
    }
}