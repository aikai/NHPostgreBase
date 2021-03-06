using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoApprove
	{
        Guid Id { get; set; }
        string ApvComment { get; set; }
        byte[] ApvSig { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        double? EmpId { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoApprove obj);
        int GetHashCode();
	}
}