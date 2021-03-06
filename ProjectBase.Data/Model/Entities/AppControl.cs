using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class AppControl : IAppControl
	{
		public AppControl()
		{
            //AppPermit = new Iesi.Collections.Generic.HashedSet<IAppPermit>();
            apControlDetail = new Iesi.Collections.Generic.HashedSet<IAppControlDetail>();
		}

        public virtual Guid Id { get; set; }

        public virtual IHrmEmployee HrmEmployee { get; set; }
        //public virtual IAppPermit AppPermit { get; set; }
        //public virtual Iesi.Collections.Generic.ISet<IAppPermit> AppPermit { get; set; }
        public virtual Iesi.Collections.Generic.ISet<IAppControlDetail> apControlDetail { get; set; }
        public virtual IAppRole AppRole { get; set; }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IAppControl);
		}
		
		public virtual bool Equals(IAppControl obj)
		{
			if (obj == null) return false;

            //if (Equals(AppId, obj.AppId) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
            //if (Equals(EmpId, obj.EmpId) == false) return false;
            //if (Equals(Permission, obj.Permission) == false) return false;
            //if (Equals(RoleId, obj.RoleId) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            //result = (result * 397) ^ (AppId != null ? AppId.GetHashCode() : 0);
            result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
            //result = (result * 397) ^ (EmpId != null ? EmpId.GetHashCode() : 0);
            //result = (result * 397) ^ (Permission != null ? Permission.GetHashCode() : 0);
            //result = (result * 397) ^ (RoleId != null ? RoleId.GetHashCode() : 0);
			return result;
		}

    }
}