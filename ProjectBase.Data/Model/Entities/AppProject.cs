using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class AppProject : IAppProject
	{
		public AppProject()
		{
            AppControls = new Iesi.Collections.Generic.HashedSet<IAppControl>();
		}
        public virtual Guid Id
		{
			get;
			set;
		}
		public virtual string AppName
		{
			get;
			set;
		}

        public virtual Iesi.Collections.Generic.ISet<IAppControl> AppControls
        {
            get;
            set;
        }
        public virtual Iesi.Collections.Generic.ISet<IAppRole> AppRoles
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IAppProject);
		}
		
		public virtual bool Equals(IAppProject obj)
		{
			if (obj == null) return false;

			if (Equals(Id, obj.Id) == false) return false;
			if (Equals(AppName, obj.AppName) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
			result = (result * 397) ^ (AppName != null ? AppName.GetHashCode() : 0);
			return result;
		}
	}
}