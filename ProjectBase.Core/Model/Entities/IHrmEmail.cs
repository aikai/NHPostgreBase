using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Core.Model
{
    public interface IHrmEmail
    {
        string Id { get; set; }
        string Email { get; set; }
        string EmailPass { get; set; }
        bool Active { get; set; }

        bool Equals(object obj);
        bool Equals(IHrmEmail obj);
        int GetHashCode();
    }
}
