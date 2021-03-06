using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface ILimGen
	{
        Guid Id { get; set; }

        string GenNo { get; set; }
        string GenDep { get; set; }
        string Suffix { get; set; }
        string UniqueKey { get; set; }
        int GenCode { get; set; }
        int GenYear { get; set; }
        DateTime? GenDate { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        ILimSamDetailWa LimSamDetailWa { get; set; }

        bool Equals(object obj);
        bool Equals(ILimGen obj);
        int GetHashCode();
	}
}