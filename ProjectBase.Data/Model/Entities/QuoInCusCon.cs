using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoInCusCon : IQuoInCusCon
	{
        public QuoInCusCon()
		{		
		}
        public virtual Guid Id
		{
			get;
			set;
		}
        public virtual IQuoMaster QuoMaster
		{
			get;
			set;
		}
        public virtual ICusCon CusCon
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IQuoInCusCon);
		}
		
		public virtual bool Equals(IQuoInCusCon obj)
		{
			if (obj == null) return false;

			if (Equals(Id, obj.Id) == false) return false;
            //if (Equals(MenuId, obj.MenuId) == false) return false;
            //if (Equals(RoleId, obj.RoleId) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
            //result = (result * 397) ^ (MenuId != null ? MenuId.GetHashCode() : 0);
            //result = (result * 397) ^ (RoleId != null ? RoleId.GetHashCode() : 0);
			return result;
		}
	}
}