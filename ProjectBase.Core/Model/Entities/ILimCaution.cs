using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface ILimCaution
	{
        Guid Id { get; set; }

        string CauComment { get; set; }
        string CauEname { get; set; }
        string CauTname { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        bool Equals(object obj);
        bool Equals(ILimCaution obj);
        int GetHashCode();
	}
}