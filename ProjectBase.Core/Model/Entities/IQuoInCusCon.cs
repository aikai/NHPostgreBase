using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoInCusCon
	{
        Guid Id { get; set; }

        IQuoMaster QuoMaster { get; set; }
        ICusCon CusCon { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoInCusCon obj);
        int GetHashCode();
	}
}