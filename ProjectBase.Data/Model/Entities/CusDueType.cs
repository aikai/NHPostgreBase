using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class CusDueType : ICusDueType
	{
		public CusDueType()
		{		
		}
        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual string DtyDescrip
		{
			get;
			set;
		}
		public virtual string DtyRemark
		{
			get;
			set;
		}

        //public virtual ICusDue CusDue
        //{
        //    get;
        //    set;
        //}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ICusDueType);
		}
		
		public virtual bool Equals(ICusDueType obj)
		{
			if (obj == null) return false;

            if (Equals(DtyDescrip, obj.DtyDescrip) == false) return false;
			if (Equals(Id, obj.Id) == false) return false;
			if (Equals(DtyRemark, obj.DtyRemark) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (DtyDescrip != null ? DtyDescrip.GetHashCode() : 0);
			result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
			result = (result * 397) ^ (DtyRemark != null ? DtyRemark.GetHashCode() : 0);
			return result;
		}
	}
}