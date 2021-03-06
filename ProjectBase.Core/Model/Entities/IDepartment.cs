using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IDepartment
	{
        string Id { get; set; }
        string DeptEname { get; set; }
        string DeptName { get; set; }

        bool Equals(object obj);
        bool Equals(IDepartment obj);
        int GetHashCode();
	}
}