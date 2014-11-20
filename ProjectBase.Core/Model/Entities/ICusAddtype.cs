using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface ICusAddtype
    {
        Guid Id { get; set; }
        string CadComment { get; set; }
        string CadName { get; set; }

        //ICusAdd CusAdd { get; set; }

        bool Equals(object obj);
        bool Equals(ICusAddtype obj);
        int GetHashCode();
    }
}
