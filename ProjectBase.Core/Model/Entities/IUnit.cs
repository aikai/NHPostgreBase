using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IUnit
	{
        Guid Id { get; set; }
        string UnitName { get; set; }

        bool Equals(object obj);
        bool Equals(IUnit obj);
        int GetHashCode();
	}
}