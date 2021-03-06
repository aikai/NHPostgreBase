using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class Amphoe : IAmphoe
	{
		public Amphoe()
		{
			Tambols = new Iesi.Collections.Generic.HashedSet<ITambol>();
		}
		public virtual string AmpEname
		{
			get;
			set;
		}
		public virtual string Id
		{
			get;
			set;
		}
		public virtual string AmpTname
		{
			get;
			set;
		}
        public virtual IProvince Province
		{
			get;
			set;
		}
		public virtual Iesi.Collections.Generic.ISet<ITambol> Tambols
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IAmphoe);
		}
		
		public virtual bool Equals(IAmphoe obj)
		{
			if (obj == null) return false;

			if (Equals(AmpEname, obj.AmpEname) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
			if (Equals(AmpTname, obj.AmpTname) == false) return false;
            //if (Equals(Province, obj.Province) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (AmpEname != null ? AmpEname.GetHashCode() : 0);
            result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
			result = (result * 397) ^ (AmpTname != null ? AmpTname.GetHashCode() : 0);
            //result = (result * 397) ^ (Province != null ? Province.GetHashCode() : 0);
			return result;
		}
	}
}