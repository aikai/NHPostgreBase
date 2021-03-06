using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoTermpaymentDep
	{
        Guid Id { get; set; }

        string TpdDept { get; set; }
        double? TpdPersent { get; set; }
        double? TpdTotal { get; set; }
        string TpdComment { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        IQuoTermpayment QuoTermpayment { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoTermpaymentDep obj);
        int GetHashCode();
	}
}