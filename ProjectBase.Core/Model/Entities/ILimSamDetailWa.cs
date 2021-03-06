using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface ILimSamDetailWa
	{
        Guid Id { get; set; }

        //Guid? CauId { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        DateTime? SadAnalyseDate { get; set; }
        string SadAnaNum { get; set; }
        string SadAnaNumyear { get; set; }
        string SadComment { get; set; }
        bool? SadCon { get; set; }
        string SadFormat { get; set; }
        string SadName { get; set; }
        DateTime? SadSaveDate { get; set; }
        string SadSaveTime { get; set; }
        bool? SadStatus { get; set; }
        int? SamItem { get; set; }
        //Guid? SrcId { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        ILimGen LimGen { get; set; }
        ILimCaution LimCaution { get; set; }
        ILimSourceWa LimSourceWa { get; set; }
        ILimSamMasterWa LimSamMasterWa { get; set; }
        Iesi.Collections.Generic.ISet<ILimSamSubdetailWa> LimSamSubdetailWas { get; set; }

        bool Equals(object obj);
        bool Equals(ILimSamDetailWa obj);
        int GetHashCode();
	}
}