using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class AppPermit : IAppPermit
	{
		public AppPermit()
		{
            //AppControls = new Iesi.Collections.Generic.HashedSet<IAppControl>();
		}
        public virtual Guid Id
        {
            get;
            set;
        }
		public virtual string Action
		{
			get;
			set;
		}



        //public virtual Iesi.Collections.Generic.ISet<IAppControl> AppControls
        //{
        //    get;
        //    set;
        //}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IAppPermit);
		}
		
		public virtual bool Equals(IAppPermit obj)
		{
			if (obj == null) return false;

			if (Equals(Action, obj.Action) == false) return false;
			if (Equals(Id, obj.Id) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Action != null ? Action.GetHashCode() : 0);
			result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
			return result;
		}
	}
}