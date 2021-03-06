using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoCombineDe
	{
        Guid Id { get; set; }

        string TjdAnalysis { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        IQuoCombine QuoCombine { get; set; }
        IQuoTermRelate QuoTermRelate { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoCombineDe obj);
        int GetHashCode();
	}
}