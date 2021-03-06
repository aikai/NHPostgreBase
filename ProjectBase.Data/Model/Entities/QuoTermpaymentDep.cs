using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoTermpaymentDep : IQuoTermpaymentDep
	{
        public QuoTermpaymentDep()
		{		
		}
        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual string TpdDept
        {
            get;
            set;
        }
        public virtual double? TpdPersent
        {
            get;
            set;
        }
        public virtual double? TpdTotal
        {
            get;
            set;
        }
        public virtual string TpdComment
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

        public virtual IQuoTermpayment QuoTermpayment
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IQuoTermpaymentDep);
		}
		
		public virtual bool Equals(IQuoTermpaymentDep obj)
		{
			if (obj == null) return false;

            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(TpdDept, obj.TpdDept) == false) return false;
            if (Equals(TpdPersent, obj.TpdPersent) == false) return false;
            if (Equals(TpdTotal, obj.TpdTotal) == false) return false;
            if (Equals(TpdComment, obj.TpdComment) == false) return false;
            if (Equals(CreateBy, obj.CreateBy) == false) return false;
            if (Equals(CreateDate, obj.CreateDate) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
            if (Equals(QuoTermpayment, obj.QuoTermpayment) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            result = (result * 397) ^ Id.GetHashCode();

            result = (result * 397) ^ (TpdDept != null ? TpdDept.GetHashCode() : 0);
            result = (result * 397) ^ (TpdPersent != null ? TpdPersent.GetHashCode() : 0);
            result = (result * 397) ^ (TpdTotal != null ? TpdTotal.GetHashCode() : 0);
            result = (result * 397) ^ (TpdComment != null ? TpdComment.GetHashCode() : 0);
            result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
            result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
            result = (result * 397) ^ (QuoTermpayment != null ? QuoTermpayment.GetHashCode() : 0);
			return result;
		}
	}
}