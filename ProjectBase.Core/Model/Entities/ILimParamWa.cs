using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface ILimParamWa
	{
        Guid Id { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string ParEname { get; set; }
        int? ParOrder { get; set; }
        string ParSename { get; set; }
        string ParStname { get; set; }
        string ParTname { get; set; }
        Guid? PrgId { get; set; }
        Guid? PruId { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        bool Equals(object obj);
        bool Equals(ILimParamWa obj);
        int GetHashCode();
	}
}