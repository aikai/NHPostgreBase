using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IQuoTermJobLab
    {
        Guid Id { get; set; }

        string TjlRepnum { get; set; }
        string TjlDescription { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        Iesi.Collections.Generic.ISet<IQuoTermJobLabDe> QuoTermJobLabDes { get; set; }

        IQuoTermpayment QuoTermpayment { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoTermJobLab obj);
        int GetHashCode();
    }
}
