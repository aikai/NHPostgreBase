using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoTermdep : IQuoTermdep
	{
		public QuoTermdep()
		{		
		}
        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual string TdeDept
        {
            get;
            set;
        }
        public virtual double? TdePersent
        {
            get;
            set;
        }
        public virtual double? TdeTotal
		{
			get;
			set;
		}
		public virtual string TdeComment
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

        public virtual IQuoMaster QuoMaster
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IQuoTermdep);
		}
		
		public virtual bool Equals(IQuoTermdep obj)
		{
			if (obj == null) return false;

            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(TdeDept, obj.TdeDept) == false) return false;
            if (Equals(TdePersent, obj.TdePersent) == false) return false;
            if (Equals(TdeTotal, obj.TdeTotal) == false) return false;
            if (Equals(TdeComment, obj.TdeComment) == false) return false;
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

            result = (result * 397) ^ (TdeDept != null ? TdeDept.GetHashCode() : 0);
            result = (result * 397) ^ (TdePersent != null ? TdePersent.GetHashCode() : 0);
            result = (result * 397) ^ (TdeTotal != null ? TdeTotal.GetHashCode() : 0);
			result = (result * 397) ^ (TdeComment != null ? TdeComment.GetHashCode() : 0);
            result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
            result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
            result = (result * 397) ^ (QuoMaster != null ? QuoMaster.GetHashCode() : 0);
			return result;
		}
	}
}