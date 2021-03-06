using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IAppRole
	{
        Guid Id { get; set; }

        string EnglishName { get; set; }
        string ThaiName { get; set; }

        Iesi.Collections.Generic.ISet<IAppControl> AppControls { get; set; }
        Iesi.Collections.Generic.ISet<IAppRoleInMenu> AppRoleInMenus { get; set; }

        IAppProject AppProject { get; set; }

        bool Equals(object obj);
        bool Equals(IAppRole obj);
        int GetHashCode();
	}
}