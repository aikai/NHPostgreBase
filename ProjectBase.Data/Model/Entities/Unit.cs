using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class Unit : IUnit
	{
		public Unit()
		{		
		}
		public virtual Guid Id
		{
			get;
			set;
		}
		public virtual string UnitName
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IUnit);
		}
		
		public virtual bool Equals(IUnit obj)
		{
			if (obj == null) return false;

			if (Equals(Id, obj.Id) == false) return false;
			if (Equals(UnitName, obj.UnitName) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
			result = (result * 397) ^ (UnitName != null ? UnitName.GetHashCode() : 0);
			return result;
		}
	}
}