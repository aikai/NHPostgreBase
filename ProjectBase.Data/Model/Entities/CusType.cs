using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class CusType : ICusType
	{
		public CusType()
		{
			CusMasters = new Iesi.Collections.Generic.HashedSet<ICusMaster>();		
		}
        public virtual Guid Id
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
		public virtual string CtpComment
		{
			get;
			set;
		}
		public virtual string CtpEname
		{
			get;
			set;
		}
		public virtual string CtpTname
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
		public virtual Iesi.Collections.Generic.ISet<ICusMaster> CusMasters
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ICusType);
		}
		
		public virtual bool Equals(ICusType obj)
		{
			if (obj == null) return false;

			if (Equals(CreateBy, obj.CreateBy) == false) return false;
			if (Equals(CreateDate, obj.CreateDate) == false) return false;
			if (Equals(CtpComment, obj.CtpComment) == false) return false;
			if (Equals(CtpEname, obj.CtpEname) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
			if (Equals(CtpTname, obj.CtpTname) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
			result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (CtpComment != null ? CtpComment.GetHashCode() : 0);
			result = (result * 397) ^ (CtpEname != null ? CtpEname.GetHashCode() : 0);
            result = (result * 397) ^ Id.GetHashCode();
			result = (result * 397) ^ (CtpTname != null ? CtpTname.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
			return result;
		}
	}
}