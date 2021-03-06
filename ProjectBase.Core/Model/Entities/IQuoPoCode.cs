using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoPoCode
	{
        Guid Id { get; set; }

        string PoCode { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        int? Index { get; set; }

        IQuoMaster QuoMaster { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoPoCode obj);
        int GetHashCode();
	}
}