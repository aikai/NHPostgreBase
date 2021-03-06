using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;
using System.Linq;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoMaster : IQuoMaster
	{
		public QuoMaster()
		{
            QuoDetails = new Iesi.Collections.Generic.HashedSet<IQuoDetail>();
            QuoGens = new Iesi.Collections.Generic.HashedSet<IQuoGen>();
            QuoFiles = new Iesi.Collections.Generic.HashedSet<IQuoFile>();
            QuoInCusCons = new Iesi.Collections.Generic.HashedSet<IQuoInCusCon>();
            QuoTermdeps = new Iesi.Collections.Generic.HashedSet<IQuoTermdep>();
            QuoTermpayments = new Iesi.Collections.Generic.HashedSet<IQuoTermpayment>();
            QuoRemarkLogs = new Iesi.Collections.Generic.HashedSet<IQuoRemarkLog>();
            QuoPoCodes = new Iesi.Collections.Generic.HashedSet<IQuoPoCode>();
            QuoRequests = new Iesi.Collections.Generic.HashedSet<IQuoRequest>();
            QuoCoWorks = new Iesi.Collections.Generic.HashedSet<IQuoCoWorker>();
            QuoRetentions = new Iesi.Collections.Generic.HashedSet<IQuoRetention>();
		}

        #region My properties
        public virtual Guid Id { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual string QuoComment { get; set; }
        public virtual double? QuoCost { get; set; }
        public virtual DateTime? QuoDate { get; set; }
        public virtual string QuoDisconut { get; set; }
        public virtual double? QuoDisconutNum { get; set; }
        public virtual DateTime? QuoJobend { get; set; }
        public virtual DateTime? QuoJobstart { get; set; }
        public virtual string QuoPeriod { get; set; }
        public virtual string QuoPocode { get; set; }
        public virtual DateTime? QuoPodate { get; set; }
        public virtual string QuoScope { get; set; }
        public virtual string QuoTerm { get; set; }
        public virtual double? QuoTotal { get; set; }
        public virtual double? QuoVat { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual bool LangStatus { get; set; }
        public virtual bool QuoDiscountFlag { get; set; }
        public virtual double? QuoNetAmount { get; set; }
        public virtual bool QuoEmploy { get; set; }
        public virtual bool QuoTermFlag { get; set; }
        public virtual bool QuoCustomerMailFlag { get; set; }
        public virtual bool QuoCoworkerMailFlag { get; set; }
        public virtual bool? RequestFlag { get; set; }
        public virtual bool ProjectFlag { get; set; }
        public virtual string MoneyFlag { get; set; }        

        public virtual Iesi.Collections.Generic.ISet<IQuoDetail> QuoDetails { get; set; }
        public virtual Iesi.Collections.Generic.ISet<IQuoGen> QuoGens { get; set; }
        public virtual Iesi.Collections.Generic.ISet<IQuoFile> QuoFiles { get; set; }
        public virtual Iesi.Collections.Generic.ISet<IQuoInCusCon> QuoInCusCons { get; set; }
        public virtual Iesi.Collections.Generic.ISet<IQuoTermdep> QuoTermdeps { get; set; }
        public virtual Iesi.Collections.Generic.ISet<IQuoTermpayment> QuoTermpayments { get; set; }
        public virtual Iesi.Collections.Generic.ISet<IQuoRemarkLog> QuoRemarkLogs { get; set; }
        public virtual Iesi.Collections.Generic.ISet<IQuoPoCode> QuoPoCodes { get; set; }
        public virtual Iesi.Collections.Generic.ISet<IQuoRequest> QuoRequests { get; set; }
        public virtual Iesi.Collections.Generic.ISet<IQuoCoWorker> QuoCoWorks { get; set; }
        public virtual Iesi.Collections.Generic.ISet<IQuoRetention> QuoRetentions { get; set; }
        public virtual Iesi.Collections.Generic.ISet<IQuoWorker> QuoWorkers { get; set; }

        public virtual IQuoApprove QuoApprove { get; set; }
        public virtual ICusMaster CusMaster { get; set; }
        public virtual IQuoReceive QuoReceive { get; set; }
        public virtual IUaeProjectManage ProjManage { get; set; }
        #endregion

        #region My methods
        public virtual IQuoGen GetQuoGenUsed()
        {
            IQuoGen quoGen = null;

            try
            {
                if (QuoGens != null && QuoGens.Count > 0)
                {
                    IEnumerable<IQuoGen> quoGens = null;
                    var maxYear = QuoGens.Select(x => x.GenYear).Max();

                    if (maxYear != null && maxYear.HasValue)
                    {
                        quoGens = QuoGens.Where(x => x.GenYear >= maxYear);
                    }

                    var maxCode = QuoGens.Select(x => x.GenCode).Max();

                    if (maxCode != null && maxCode.HasValue)
                    {
                        if (quoGens != null)
                        {
                            quoGens = quoGens.Where(x => x.GenCode >= maxCode);
                        }
                    }

                    var maxRevise = QuoGens.Select(x => x.GenRevise).Max();

                    if (maxRevise != null && maxRevise.HasValue)
                    {
                        if (quoGens != null)
                        {
                            quoGens = quoGens.Where(x => x.GenRevise >= maxRevise);
                        }
                    }

                    if (quoGens != null && quoGens.Count() > 0)
                    {
                        quoGen = quoGens.First();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return quoGen;
        }

        public virtual string GetQuoGenProject()
        {
            var projName = string.Empty;

            try
            {
                var quoGen = GetQuoGenUsed();

                if (quoGen != null)
                {
                    projName = quoGen.ProjName;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return projName;
        }

        public virtual string GetQuoGenCode()
        {
            var sb = new System.Text.StringBuilder();

            try
            {
                var quoGen = GetQuoGenUsed();

                if (quoGen != null)
                {
                    sb.Append(quoGen.GenDep);
                    sb.AppendFormat("{0:0000}", quoGen.GenCode);

                    if (quoGen.GenRevise != null && quoGen.GenRevise.HasValue)
                    {
                        if (quoGen.GenRevise > 0)
                        {
                            sb.AppendFormat("-{0:00}", quoGen.GenRevise); 
                        }
                    }

                    sb.AppendFormat("/{0}", quoGen.GenYear);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return Equals(obj as IQuoMaster);
        }

        public virtual bool Equals(IQuoMaster obj)
        {
            if (obj == null) return false;

            //if (Equals(QuoApprove, obj.QuoApprove) == false) return false;
            if (Equals(CreateBy, obj.CreateBy) == false) return false;
            if (Equals(CreateDate, obj.CreateDate) == false) return false;
            //if (Equals(CusMaster, obj.CusMaster) == false) return false;
            //if (Equals(QuoGen, obj.QuoGen) == false) return false;
            //if (Equals(UaeProjectManage, obj.UaeProjectManage) == false) return false;
            //if (Equals(QuoAmount, obj.QuoAmount) == false) return false;
            if (Equals(QuoComment, obj.QuoComment) == false) return false;
            if (Equals(QuoCost, obj.QuoCost) == false) return false;
            if (Equals(QuoDate, obj.QuoDate) == false) return false;
            if (Equals(QuoDisconut, obj.QuoDisconut) == false) return false;
            if (Equals(QuoDisconutNum, obj.QuoDisconutNum) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(QuoJobend, obj.QuoJobend) == false) return false;
            if (Equals(QuoJobstart, obj.QuoJobstart) == false) return false;
            if (Equals(QuoPeriod, obj.QuoPeriod) == false) return false;
            if (Equals(QuoPocode, obj.QuoPocode) == false) return false;
            if (Equals(QuoPodate, obj.QuoPodate) == false) return false;
            if (Equals(QuoScope, obj.QuoScope) == false) return false;
            if (Equals(QuoTerm, obj.QuoTerm) == false) return false;
            if (Equals(QuoTotal, obj.QuoTotal) == false) return false;
            if (Equals(QuoVat, obj.QuoVat) == false) return false;
            if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
            if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int result = 1;

            //result = (result * 397) ^ (QuoApprove != null ? QuoApprove.GetHashCode() : 0);
            result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
            result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
            //result = (result * 397) ^ (CusMaster != null ? CusMaster.GetHashCode() : 0);
            //result = (result * 397) ^ (QuoGen != null ? QuoGen.GetHashCode() : 0);
            //result = (result * 397) ^ (UaeProjectManage != null ? UaeProjectManage.GetHashCode() : 0);
            //result = (result * 397) ^ (QuoAmount != null ? QuoAmount.GetHashCode() : 0);
            result = (result * 397) ^ (QuoComment != null ? QuoComment.GetHashCode() : 0);
            result = (result * 397) ^ (QuoCost != null ? QuoCost.GetHashCode() : 0);
            result = (result * 397) ^ (QuoDate != null ? QuoDate.GetHashCode() : 0);
            result = (result * 397) ^ (QuoDisconut != null ? QuoDisconut.GetHashCode() : 0);
            result = (result * 397) ^ (QuoDisconutNum != null ? QuoDisconutNum.GetHashCode() : 0);
            result = (result * 397) ^ Id.GetHashCode();
            result = (result * 397) ^ (QuoJobend != null ? QuoJobend.GetHashCode() : 0);
            result = (result * 397) ^ (QuoJobstart != null ? QuoJobstart.GetHashCode() : 0);
            result = (result * 397) ^ (QuoPeriod != null ? QuoPeriod.GetHashCode() : 0);
            result = (result * 397) ^ (QuoPocode != null ? QuoPocode.GetHashCode() : 0);
            result = (result * 397) ^ (QuoPodate != null ? QuoPodate.GetHashCode() : 0);
            result = (result * 397) ^ (QuoScope != null ? QuoScope.GetHashCode() : 0);
            result = (result * 397) ^ (QuoTerm != null ? QuoTerm.GetHashCode() : 0);
            result = (result * 397) ^ (QuoTotal != null ? QuoTotal.GetHashCode() : 0);
            result = (result * 397) ^ (QuoVat != null ? QuoVat.GetHashCode() : 0);
            result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
            result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
            return result;
        }         
        #endregion 
        
    }
}