using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IQuoTermJobEma
    {
        Guid Id { get; set; }

        string TjeRepnum { get; set; }
        string TjeDescription { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        Iesi.Collections.Generic.ISet<IQuoTermJobEmaDe> QuoTermJobEmaDes { get; set; }

        IQuoTermpayment QuoTermpayment { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoTermJobEma obj);
        int GetHashCode();
    }
}
