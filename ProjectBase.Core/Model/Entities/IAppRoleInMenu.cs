using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IAppRoleInMenu
	{
        Guid Id { get; set; }

        IAppRole AppRole { get; set; }
        IAppMenu AppMenu { get; set; }

        bool Equals(object obj);
        bool Equals(IAppRoleInMenu obj);
        int GetHashCode();
	}
}