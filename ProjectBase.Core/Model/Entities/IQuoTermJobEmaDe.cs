using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoTermJobEmaDe
	{
        Guid Id { get; set; }
        string TjdeAnalysis { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        Iesi.Collections.Generic.ISet<IQuoTermJobEmaFile> QuoTermJobEmaFiles { get; set; }

        IQuoTermJobEma QuoTermJobEma { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoTermJobEmaDe obj);
        int GetHashCode();
	}
}