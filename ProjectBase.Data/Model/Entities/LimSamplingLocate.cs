using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class LimSamplingLocate : ILimSamplingLocate
	{
		public LimSamplingLocate()
		{		
		}
		public virtual Guid Id
		{
			get;
			set;
		}
        public virtual string SapEname
		{
			get;
			set;
		}
        public virtual string SapTname
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ILimSamplingLocate);
		}
		
		public virtual bool Equals(ILimSamplingLocate obj)
		{
			if (obj == null) return false;

			if (Equals(Id, obj.Id) == false) return false;
            if (Equals(SapEname, obj.SapEname) == false) return false;
            if (Equals(SapTname, obj.SapTname) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ Id.GetHashCode();
            result = (result * 397) ^ (SapEname != null ? SapEname.GetHashCode() : 0);
            result = (result * 397) ^ (SapTname != null ? SapTname.GetHashCode() : 0);
			return result;
		}
	}
}