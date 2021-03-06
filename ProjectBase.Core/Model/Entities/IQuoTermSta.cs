using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoTermSta
	{
        Guid Id { get; set; }

        string Name { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        IQuoTermpayment QuoTermpayment { get; set; }
        IQuoTypeSta QuoTypeSta { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoTermSta obj);
        int GetHashCode();
	}
}