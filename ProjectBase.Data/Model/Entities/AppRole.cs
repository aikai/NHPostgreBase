using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class AppRole : IAppRole
	{
		public AppRole()
		{
            AppControls = new Iesi.Collections.Generic.HashedSet<IAppControl>();
            AppRoleInMenus = new Iesi.Collections.Generic.HashedSet<IAppRoleInMenu>();
		}

        public virtual Guid Id
		{
			get;
			set;
		}
        public virtual string EnglishName
		{
			get;
			set;
		}
        public virtual string ThaiName
        {
            get;
            set;
        }

        public virtual Iesi.Collections.Generic.ISet<IAppControl> AppControls
        {
            get;
            set;
        }
        public virtual Iesi.Collections.Generic.ISet<IAppRoleInMenu> AppRoleInMenus
        {
            get;
            set;
        }

        public virtual IAppProject AppProject
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IAppRole);
		}
		
		public virtual bool Equals(IAppRole obj)
		{
			if (obj == null) return false;

			if (Equals(Id, obj.Id) == false) return false;
            if (Equals(EnglishName, obj.EnglishName) == false) return false;
            if (Equals(ThaiName, obj.ThaiName) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
            result = (result * 397) ^ (EnglishName != null ? EnglishName.GetHashCode() : 0);
            result = (result * 397) ^ (ThaiName != null ? ThaiName.GetHashCode() : 0);
			return result;
		}
	}
}