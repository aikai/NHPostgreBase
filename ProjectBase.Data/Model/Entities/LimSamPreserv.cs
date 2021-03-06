using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class LimSamPreserv : ILimSamPreserv
	{
		public LimSamPreserv()
		{
			LimSamSubdetailWas = new Iesi.Collections.Generic.HashedSet<ILimSamSubdetailWa>();		
		}
		public virtual string SpsComment
		{
			get;
			set;
		}
		public virtual string SpsEname
		{
			get;
			set;
		}
		public virtual Guid Id
		{
			get;
			set;
		}
		public virtual string SpsTname
		{
			get;
			set;
		}
		public virtual Iesi.Collections.Generic.ISet<ILimSamSubdetailWa> LimSamSubdetailWas
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ILimSamPreserv);
		}
		
		public virtual bool Equals(ILimSamPreserv obj)
		{
			if (obj == null) return false;

			if (Equals(SpsComment, obj.SpsComment) == false) return false;
			if (Equals(SpsEname, obj.SpsEname) == false) return false;
			if (Equals(Id, obj.Id) == false) return false;
			if (Equals(SpsTname, obj.SpsTname) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (SpsComment != null ? SpsComment.GetHashCode() : 0);
			result = (result * 397) ^ (SpsEname != null ? SpsEname.GetHashCode() : 0);
			result = (result * 397) ^ Id.GetHashCode();
			result = (result * 397) ^ (SpsTname != null ? SpsTname.GetHashCode() : 0);
			return result;
		}
	}
}