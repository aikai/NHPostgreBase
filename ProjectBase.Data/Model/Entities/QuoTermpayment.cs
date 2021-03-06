using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoTermpayment : IQuoTermpayment
	{
        public QuoTermpayment()
		{
            QuoTermpaymentDeps = new Iesi.Collections.Generic.HashedSet<IQuoTermpaymentDep>();
            QuoTermRelates = new Iesi.Collections.Generic.HashedSet<IQuoTermRelate>();
		}
        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual string TerItem
        {
            get;
            set;
        }
        public virtual double? TerCost
        {
            get;
            set;
        }
        public virtual string TerRemark
		{
			get;
			set;
		}
        public virtual string TerSta
        {
            get;
            set;
        }
        public virtual string TerDescription
        {
            get;
            set;
        }
        public virtual DateTime? TerDueDate
        {
            get;
            set;
        }
        public virtual DateTime? FinalDate
        {
            get;
            set;
        }
        public virtual string FinalComment
        {
            get;
            set;
        }
        public virtual string CreateBy
        {
            get;
            set;
        }
        public virtual DateTime? CreateDate
        {
            get;
            set;
        }
		public virtual string UpdateBy
		{
			get;
			set;
		}
		public virtual DateTime? UpdateDate
		{
			get;
			set;
		}
        public virtual string InvoiceNo
        {
            get;
            set;
        }
        public virtual DateTime? InvoiceDate
        {
            get;
            set;
        }
        public virtual string CancelStatus
        {
            get;
            set;
        }
        public virtual DateTime? CancelAllDate
        {
            get;
            set;
        }

        public virtual Iesi.Collections.Generic.ISet<IQuoTermpaymentDep> QuoTermpaymentDeps
        {
            get;
            set;
        }

        public virtual Iesi.Collections.Generic.ISet<IQuoTermRelate> QuoTermRelates
        {
            get;
            set;
        }

        public virtual IQuoMaster QuoMaster
        {
            get;
            set;
        }

        public virtual IQuoTermSta QuoTermSta
        {
            get;
            set;
        }

        public virtual IQuoTermInv QuoTermInv
        {
            get;
            set;
        }

        //public virtual IGenDocNo GenDocNo
        //{
        //    get;
        //    set;
        //}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IQuoTermpayment);
		}
		
		public virtual bool Equals(IQuoTermpayment obj)
		{
			if (obj == null) return false;

            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(TerItem, obj.TerItem) == false) return false;
            if (Equals(TerCost, obj.TerCost) == false) return false;
            if (Equals(TerRemark, obj.TerRemark) == false) return false;
            if (Equals(TerSta, obj.TerSta) == false) return false;
            if (Equals(TerDescription, obj.TerDescription) == false) return false;
            if (Equals(TerDueDate, obj.TerDueDate) == false) return false;
            if (Equals(CreateBy, obj.CreateBy) == false) return false;
            if (Equals(CreateDate, obj.CreateDate) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
            if (Equals(QuoMaster, obj.QuoMaster) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            result = (result * 397) ^ Id.GetHashCode();

            result = (result * 397) ^ (TerItem != null ? TerItem.GetHashCode() : 0);
            result = (result * 397) ^ (TerCost != null ? TerCost.GetHashCode() : 0);
            result = (result * 397) ^ (TerRemark != null ? TerRemark.GetHashCode() : 0);
            result = (result * 397) ^ (TerSta != null ? TerSta.GetHashCode() : 0);
            result = (result * 397) ^ (TerDescription != null ? TerDescription.GetHashCode() : 0);
            result = (result * 397) ^ (TerDueDate != null ? TerDueDate.GetHashCode() : 0);
            result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
            result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
            result = (result * 397) ^ (QuoMaster != null ? QuoMaster.GetHashCode() : 0);
			return result;
		}
	}
}