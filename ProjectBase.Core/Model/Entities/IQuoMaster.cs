using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoMaster
    {
        Guid Id { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string QuoComment { get; set; }
        double? QuoCost { get; set; }
        DateTime? QuoDate { get; set; }
        string QuoDisconut { get; set; }
        double? QuoDisconutNum { get; set; }
        DateTime? QuoJobend { get; set; }
        DateTime? QuoJobstart { get; set; }
        string QuoPeriod { get; set; }
        string QuoPocode { get; set; }
        DateTime? QuoPodate { get; set; }
        string QuoScope { get; set; }
        string QuoTerm { get; set; }
        double? QuoTotal { get; set; }
        double? QuoVat { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        bool LangStatus { get; set; }
        bool QuoDiscountFlag { get; set; }
        double? QuoNetAmount { get; set; }
        bool QuoEmploy { get; set; }
        bool QuoTermFlag { get; set; }
        bool QuoCustomerMailFlag { get; set; }
        bool QuoCoworkerMailFlag { get; set; }
        bool? RequestFlag { get; set; }
        string MoneyFlag { get; set; }

        Iesi.Collections.Generic.ISet<IQuoDetail> QuoDetails { get; set; }
        Iesi.Collections.Generic.ISet<IQuoGen> QuoGens{ get; set; }
        Iesi.Collections.Generic.ISet<IQuoFile> QuoFiles { get; set; }
        Iesi.Collections.Generic.ISet<IQuoInCusCon> QuoInCusCons { get; set; }
        Iesi.Collections.Generic.ISet<IQuoTermdep> QuoTermdeps { get; set; }
        Iesi.Collections.Generic.ISet<IQuoTermpayment> QuoTermpayments { get; set; }
        Iesi.Collections.Generic.ISet<IQuoRemarkLog> QuoRemarkLogs { get; set; }
        Iesi.Collections.Generic.ISet<IQuoPoCode> QuoPoCodes { get; set; }
        Iesi.Collections.Generic.ISet<IQuoRequest> QuoRequests { get; set; }
        Iesi.Collections.Generic.ISet<IQuoRetention> QuoRetentions { get; set; }

        IQuoApprove QuoApprove { get; set; }
        ICusMaster CusMaster { get; set; }
        IQuoReceive QuoReceive { get; set; }

        IQuoGen GetQuoGenUsed();
        string GetQuoGenProject();
        string GetQuoGenCode();
        bool Equals(object obj);
        bool Equals(IQuoMaster obj);
        int GetHashCode();

        Iesi.Collections.Generic.ISet<IQuoCoWorker> QuoCoWorks { get; set; }
        IUaeProjectManage ProjManage { get; set; }
        bool ProjectFlag { get; set; }
        Iesi.Collections.Generic.ISet<IQuoWorker> QuoWorkers { get; set; }
    }
}