using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class Province : IProvince
	{
		public Province()
		{		
		}
		public virtual string ProvEname
		{
			get;
			set;
		}
		public virtual string Id
		{
			get;
			set;
		}
		public virtual string ProvSign
		{
			get;
			set;
		}
		public virtual string ProvTname
		{
			get;
			set;
		}
		public virtual string RegId
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IProvince);
		}
		
		public virtual bool Equals(IProvince obj)
		{
			if (obj == null) return false;

			if (Equals(ProvEname, obj.ProvEname) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
			if (Equals(ProvSign, obj.ProvSign) == false) return false;
			if (Equals(ProvTname, obj.ProvTname) == false) return false;
			if (Equals(RegId, obj.RegId) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (ProvEname != null ? ProvEname.GetHashCode() : 0);
            result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
			result = (result * 397) ^ (ProvSign != null ? ProvSign.GetHashCode() : 0);
			result = (result * 397) ^ (ProvTname != null ? ProvTname.GetHashCode() : 0);
			result = (result * 397) ^ (RegId != null ? RegId.GetHashCode() : 0);
			return result;
		}
	}
}