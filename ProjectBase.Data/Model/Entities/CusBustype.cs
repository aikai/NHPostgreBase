using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class CusBustype : ICusBustype
	{
		public CusBustype()
		{
			CusMasters = new Iesi.Collections.Generic.HashedSet<ICusMaster>();		
		}
        public virtual Guid Id
		{
			get;
			set;
		}
		public virtual string BtpRemark
		{
			get;
			set;
		}
		public virtual string BtpTname
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

		public virtual Iesi.Collections.Generic.ISet<ICusMaster> CusMasters
		{
			get;
			set;
		}
        public virtual ICusBusgroup CusBusgroup
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ICusBustype);
		}
		
		public virtual bool Equals(ICusBustype obj)
		{
			if (obj == null) return false;

            //if (Equals(CusBusgroup, obj.CusBusgroup) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
			if (Equals(BtpRemark, obj.BtpRemark) == false) return false;
			if (Equals(BtpTname, obj.BtpTname) == false) return false;
			if (Equals(CreateBy, obj.CreateBy) == false) return false;
			if (Equals(CreateDate, obj.CreateDate) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            //result = (result * 397) ^ (CusBusgroup != null ? CusBusgroup.GetHashCode() : 0);
            result = (result * 397) ^ Id.GetHashCode();
			result = (result * 397) ^ (BtpRemark != null ? BtpRemark.GetHashCode() : 0);
			result = (result * 397) ^ (BtpTname != null ? BtpTname.GetHashCode() : 0);
			result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
			result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
			return result;
		}
	}
}