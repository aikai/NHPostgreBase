using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface ILimParamGroupWa
	{
        Guid Id { get; set; }

        string PrgEcomment { get; set; }
        string PrgEname { get; set; }
        string PrgTcomment { get; set; }
        string PrgTname { get; set; }

        bool Equals(object obj);
        bool Equals(ILimParamGroupWa obj);
        int GetHashCode();
	}
}