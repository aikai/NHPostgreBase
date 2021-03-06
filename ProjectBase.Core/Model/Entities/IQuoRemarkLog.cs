using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoRemarkLog
	{
        Guid Id { get; set; }

        string Remark { get; set; }
        DateTime? EditTime { get; set; }
        string CreateBy { get; set; }

        IQuoMaster QuoMaster { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoRemarkLog obj);
        int GetHashCode();
	}
}