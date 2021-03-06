using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class Tambol : ITambol
	{
		public Tambol()
		{		
		}
		public virtual string TamEname
		{
			get;
			set;
		}
		public virtual string Id
		{
			get;
			set;
		}
		public virtual string TamTname
		{
			get;
			set;
		}
		public virtual string TamZip
		{
			get;
			set;
		}
		public virtual IAmphoe Amphoe
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ITambol);
		}
		
		public virtual bool Equals(ITambol obj)
		{
			if (obj == null) return false;

			if (Equals(TamEname, obj.TamEname) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
			if (Equals(TamTname, obj.TamTname) == false) return false;
			if (Equals(TamZip, obj.TamZip) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (TamEname != null ? TamEname.GetHashCode() : 0);
            result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
			result = (result * 397) ^ (TamTname != null ? TamTname.GetHashCode() : 0);
			result = (result * 397) ^ (TamZip != null ? TamZip.GetHashCode() : 0);
			return result;
		}
	}
}