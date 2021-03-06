using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class Department : IDepartment
	{
		public Department()
		{		
		}
		public virtual string DeptEname
		{
			get;
			set;
		}
		public virtual string Id
		{
			get;
			set;
		}
		public virtual string DeptName
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IDepartment);
		}
		
		public virtual bool Equals(IDepartment obj)
		{
			if (obj == null) return false;

			if (Equals(DeptEname, obj.DeptEname) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
			if (Equals(DeptName, obj.DeptName) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (DeptEname != null ? DeptEname.GetHashCode() : 0);
            result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
			result = (result * 397) ^ (DeptName != null ? DeptName.GetHashCode() : 0);
			return result;
		}
	}
}