using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface ILimSamplingLocate
	{
        Guid Id { get; set; }

        string SapEname { get; set; }
        string SapTname { get; set; }

        bool Equals(object obj);
        bool Equals(ILimSamplingLocate obj);
        int GetHashCode();
	}
}