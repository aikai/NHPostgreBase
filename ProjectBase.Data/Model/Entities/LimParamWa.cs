using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class LimParamWa : ILimParamWa
	{
		public LimParamWa()
		{		
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
		public virtual string ParEname
		{
			get;
			set;
		}
		public virtual Guid Id
		{
			get;
			set;
		}
		public virtual int? ParOrder
		{
			get;
			set;
		}
		public virtual string ParSename
		{
			get;
			set;
		}
		public virtual string ParStname
		{
			get;
			set;
		}
		public virtual string ParTname
		{
			get;
			set;
		}
		public virtual Guid? PrgId
		{
			get;
			set;
		}
		public virtual Guid? PruId
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
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ILimParamWa);
		}
		
		public virtual bool Equals(ILimParamWa obj)
		{
			if (obj == null) return false;

			if (Equals(CreateBy, obj.CreateBy) == false) return false;
			if (Equals(CreateDate, obj.CreateDate) == false) return false;
			if (Equals(ParEname, obj.ParEname) == false) return false;
			if (Equals(Id, obj.Id) == false) return false;
			if (Equals(ParOrder, obj.ParOrder) == false) return false;
			if (Equals(ParSename, obj.ParSename) == false) return false;
			if (Equals(ParStname, obj.ParStname) == false) return false;
			if (Equals(ParTname, obj.ParTname) == false) return false;
			if (Equals(PrgId, obj.PrgId) == false) return false;
			if (Equals(PruId, obj.PruId) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
			result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (ParEname != null ? ParEname.GetHashCode() : 0);
			result = (result * 397) ^ Id.GetHashCode();
			result = (result * 397) ^ (ParOrder != null ? ParOrder.GetHashCode() : 0);
			result = (result * 397) ^ (ParSename != null ? ParSename.GetHashCode() : 0);
			result = (result * 397) ^ (ParStname != null ? ParStname.GetHashCode() : 0);
			result = (result * 397) ^ (ParTname != null ? ParTname.GetHashCode() : 0);
			result = (result * 397) ^ (PrgId != null ? PrgId.GetHashCode() : 0);
			result = (result * 397) ^ (PruId != null ? PruId.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
			return result;
		}
	}
}