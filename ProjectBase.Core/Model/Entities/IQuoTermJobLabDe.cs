using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoTermJobLabDe
	{
        Guid Id { get; set; }

        string TjdAnalysis { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        Iesi.Collections.Generic.ISet<IQuoTermJobLabFile> QuoTermJobLabFiles { get; set; }

        IQuoTermJobLab QuoTermJobLab { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoTermJobLabDe obj);
        int GetHashCode();
	}
}