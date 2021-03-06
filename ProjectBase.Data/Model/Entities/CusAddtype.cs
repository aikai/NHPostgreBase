using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class CusAddtype : ICusAddtype
	{
		public CusAddtype()
		{		
		}
        public virtual Guid Id
        {
            get;
            set;
        }
		public virtual string CadComment
		{
			get;
			set;
		}
		public virtual string CadName
		{
			get;
			set;
		}

        //public virtual ICusAdd CusAdd
        //{
        //    get;
        //    set;
        //}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ICusAddtype);
		}
		
		public virtual bool Equals(ICusAddtype obj)
		{
			if (obj == null) return false;

			if (Equals(CadComment, obj.CadComment) == false) return false;
			if (Equals(Id, obj.Id) == false) return false;
			if (Equals(CadName, obj.CadName) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (CadComment != null ? CadComment.GetHashCode() : 0);
			result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
			result = (result * 397) ^ (CadName != null ? CadName.GetHashCode() : 0);
			return result;
		}
	}
}