using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface ICusDue
	{
        Guid Id { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        ICusDueType CusDueType { get; set; }
        string DueRemark { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        ICusMaster CusMaster { get; set; }

        bool Equals(object obj);
        bool Equals(ICusDue obj);
        int GetHashCode();
	}
}