using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IAppProject
	{
        Guid Id { get; set; }
        string AppName { get; set; }

        Iesi.Collections.Generic.ISet<IAppControl> AppControls { get; set; }
        Iesi.Collections.Generic.ISet<IAppRole> AppRoles { get; set; }

        bool Equals(object obj);
        bool Equals(IAppProject obj);
        int GetHashCode();
	}
}