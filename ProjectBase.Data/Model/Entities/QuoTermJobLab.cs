using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoTermJobLab : IQuoTermJobLab
	{
        public QuoTermJobLab()
		{
            QuoTermJobLabDes = new Iesi.Collections.Generic.HashedSet<IQuoTermJobLabDe>();
		}
        public virtual Guid Id
		{
			get;
			set;
		}
        public virtual string TjlRepnum
		{
			get;
			set;
		}
        public virtual string TjlDescription
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

        public virtual Iesi.Collections.Generic.ISet<IQuoTermJobLabDe> QuoTermJobLabDes
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

            return Equals(obj as IQuoTermJobLab);
		}

        public virtual bool Equals(IQuoTermJobLab obj)
		{
			if (obj == null) return false;

            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(TjlRepnum, obj.TjlRepnum) == false) return false;
            if (Equals(TjlDescription, obj.TjlDescription) == false) return false;
			if (Equals(CreateBy, obj.CreateBy) == false) return false;
			if (Equals(CreateDate, obj.CreateDate) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            result = (result * 397) ^ Id.GetHashCode();
            result = (result * 397) ^ (TjlRepnum != null ? TjlRepnum.GetHashCode() : 0);
            result = (result * 397) ^ (TjlDescription != null ? TjlDescription.GetHashCode() : 0);
			result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
			result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
			return result;
		}
	}
}