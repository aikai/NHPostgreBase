using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface ILimSourceWa
	{
        Guid Id { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string SrcComment { get; set; }
        string SrcEname { get; set; }
        string SrcTname { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        bool Equals(object obj);
        bool Equals(ILimSourceWa obj);
        int GetHashCode();
	}
}