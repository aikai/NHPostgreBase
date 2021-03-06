using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoTermInv
	{
        Guid Id { get; set; }

        string Prefix { get; set; }
        int Year { get; set; }
        int Month { get; set; }
        int InctNum { get; set; }
        string DocNo { get; set; }

        IQuoTermpayment QuoTermpayment { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoTermInv obj);
        int GetHashCode();
	}
}