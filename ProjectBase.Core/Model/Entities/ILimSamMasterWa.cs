using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface ILimSamMasterWa
	{
        Guid Id { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string SamComment { get; set; }
        string SamEmp { get; set; }
        string SamLocation { get; set; }
        string SamNumber { get; set; }
        string SamPo { get; set; }
        string SamQuo { get; set; }
        DateTime? SamRecDate { get; set; }
        string SamRecTime { get; set; }
        string SamSampling { get; set; }
        string SamWitness { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        IQuoMaster QuoMaster { get; set; }
        Iesi.Collections.Generic.ISet<ILimSamDetailWa> LimSamDetailWas { get; set; }

        bool Equals(object obj);
        bool Equals(ILimSamMasterWa obj);
        int GetHashCode();
	}
}