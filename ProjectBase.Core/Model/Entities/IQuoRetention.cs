using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Core.Model
{
    public interface IQuoRetention
	{
        Guid Id { get; set; }

        RetentionType Type { get; set; }
        string Description { get; set; }
        double? Money { get; set; }
        string Remark { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        IQuoMaster QuoMaster { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoRetention obj);
        int GetHashCode();
	}
}