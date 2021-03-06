using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoTermpayment
	{
        Guid Id { get; set; }

        string TerItem { get; set; }
        double? TerCost { get; set; }
        string TerRemark { get; set; }
        string TerSta { get; set; }
        string TerDescription { get; set; }
        DateTime? TerDueDate { get; set; }
        DateTime? FinalDate { get; set; }
        string FinalComment { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string InvoiceNo { get; set; }
        DateTime? InvoiceDate { get; set; }
        string CancelStatus { get; set; }
        DateTime? CancelAllDate { get; set; }

        Iesi.Collections.Generic.ISet<IQuoTermpaymentDep> QuoTermpaymentDeps { get; set; }
        Iesi.Collections.Generic.ISet<IQuoTermRelate> QuoTermRelates { get; set; }

        IQuoMaster QuoMaster { get; set; }
        IQuoTermSta QuoTermSta { get; set; }
        //IGenDocNo GenDocNo { get; set; }
        IQuoTermInv QuoTermInv { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoTermpayment obj);
        int GetHashCode();
	}
}