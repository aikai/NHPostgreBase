using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class CusCon : ICusCon
	{
		public CusCon()
		{		
		}
        public virtual Guid Id
        {
            get;
            set;
        }
		public virtual string ConComment
		{
			get;
			set;
		}
		public virtual string ConEmail
		{
			get;
			set;
		}
		public virtual string ConFax
		{
			get;
			set;
		}
		public virtual string ConMobile
		{
			get;
			set;
		}
		public virtual string ConName
		{
			get;
			set;
		}
		public virtual string ConNickname
		{
			get;
			set;
		}
		public virtual string ConPosition
		{
			get;
			set;
		}
		public virtual string ContDep
		{
			get;
			set;
		}
		public virtual string ConTel
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
		public virtual ICusMaster CusMaster
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ICusCon);
		}
		
		public virtual bool Equals(ICusCon obj)
		{
			if (obj == null) return false;

			if (Equals(ConComment, obj.ConComment) == false) return false;
			if (Equals(ConEmail, obj.ConEmail) == false) return false;
			if (Equals(ConFax, obj.ConFax) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
			if (Equals(ConMobile, obj.ConMobile) == false) return false;
			if (Equals(ConName, obj.ConName) == false) return false;
			if (Equals(ConNickname, obj.ConNickname) == false) return false;
			if (Equals(ConPosition, obj.ConPosition) == false) return false;
			if (Equals(ContDep, obj.ContDep) == false) return false;
			if (Equals(ConTel, obj.ConTel) == false) return false;
			if (Equals(CreateBy, obj.CreateBy) == false) return false;
			if (Equals(CreateDate, obj.CreateDate) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (ConComment != null ? ConComment.GetHashCode() : 0);
			result = (result * 397) ^ (ConEmail != null ? ConEmail.GetHashCode() : 0);
			result = (result * 397) ^ (ConFax != null ? ConFax.GetHashCode() : 0);
            result = (result * 397) ^ Id.GetHashCode();
			result = (result * 397) ^ (ConMobile != null ? ConMobile.GetHashCode() : 0);
			result = (result * 397) ^ (ConName != null ? ConName.GetHashCode() : 0);
			result = (result * 397) ^ (ConNickname != null ? ConNickname.GetHashCode() : 0);
			result = (result * 397) ^ (ConPosition != null ? ConPosition.GetHashCode() : 0);
			result = (result * 397) ^ (ContDep != null ? ContDep.GetHashCode() : 0);
			result = (result * 397) ^ (ConTel != null ? ConTel.GetHashCode() : 0);
			result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
			result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
			return result;
		}
	}
}