using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface ILimSamPreserv
	{
        Guid Id { get; set; }

        string SpsComment { get; set; }
        string SpsEname { get; set; }
        string SpsTname { get; set; }
        Iesi.Collections.Generic.ISet<ILimSamSubdetailWa> LimSamSubdetailWas { get; set; }

        bool Equals(object obj);
        bool Equals(ILimSamPreserv obj);
        int GetHashCode();
	}
}