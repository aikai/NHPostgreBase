using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
	public interface IUaeProjectManage
	{
        string Id { get; set; }
        string ProjCode { get; set; }
        DateTime? ProjDateend { get; set; }
        DateTime? ProjDatestart { get; set; }
        string ProjDepartment { get; set; }
        string ProjEname { get; set; }
        DateTime? ProjExtent { get; set; }
        string ProjTname { get; set; }
        double? ProjValue { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        int? InctNum { get; set; }
        int? ProjYear { get; set; }

        bool Equals(object obj);
        bool Equals(IUaeProjectManage obj);
        int GetHashCode();
	}
}