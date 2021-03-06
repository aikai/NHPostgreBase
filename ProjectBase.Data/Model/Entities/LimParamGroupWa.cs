using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class LimParamGroupWa : ILimParamGroupWa
	{
		public LimParamGroupWa()
		{		
		}
		public virtual string PrgEcomment
		{
			get;
			set;
		}
		public virtual string PrgEname
		{
			get;
			set;
		}
		public virtual Guid Id
		{
			get;
			set;
		}
		public virtual string PrgTcomment
		{
			get;
			set;
		}
		public virtual string PrgTname
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ILimParamGroupWa);
		}
		
		public virtual bool Equals(ILimParamGroupWa obj)
		{
			if (obj == null) return false;

			if (Equals(PrgEcomment, obj.PrgEcomment) == false) return false;
			if (Equals(PrgEname, obj.PrgEname) == false) return false;
			if (Equals(Id, obj.Id) == false) return false;
			if (Equals(PrgTcomment, obj.PrgTcomment) == false) return false;
			if (Equals(PrgTname, obj.PrgTname) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (PrgEcomment != null ? PrgEcomment.GetHashCode() : 0);
			result = (result * 397) ^ (PrgEname != null ? PrgEname.GetHashCode() : 0);
			result = (result * 397) ^ Id.GetHashCode();
			result = (result * 397) ^ (PrgTcomment != null ? PrgTcomment.GetHashCode() : 0);
			result = (result * 397) ^ (PrgTname != null ? PrgTname.GetHashCode() : 0);
			return result;
		}
	}
}