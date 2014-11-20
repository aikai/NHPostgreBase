using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Core.Model
{
    public interface IQuoWorker
    {
        Guid Id { get; set; }
        IQuoMaster QuoMaster { get; set; }
        IHrmEmployee Employee { get; set; }
        string Dept { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoWorker obj);
        int GetHashCode();
    }
}
