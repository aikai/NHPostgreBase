using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoTypeSta
	{
        Guid Id { get; set; }

        string Name { get; set; }
        string Description { get; set; }
        string Group { get; set; }
        int Index { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoTypeSta obj);
        int GetHashCode();
	}
}