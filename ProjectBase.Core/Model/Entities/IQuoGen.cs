using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoGen
	{ 
        Guid Id { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        double? GenCode { get; set; }
        double? GenRevise { get; set; }
        DateTime? GenDate { get; set; }
        string GenDep { get; set; }
        double? GenYear { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string ProjName { get; set; }
        IQuoMaster QuoMaster { get; set; }
        double? EstCost { get; set; }
        string Status { get; set; }
        bool Equals(object obj);
        bool Equals(IQuoGen obj);
        int GetHashCode();
	}
}