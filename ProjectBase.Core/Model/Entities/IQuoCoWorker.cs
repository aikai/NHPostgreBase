using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Core.Model
{
    public interface IQuoCoWorker
    {
        Guid Id { get; set; }
        IQuoMaster QuoMaster { get; set; }
        IHrmEmployee Employee { get; set; }
        string Dept { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoCoWorker obj);
        int GetHashCode();
    }
}
