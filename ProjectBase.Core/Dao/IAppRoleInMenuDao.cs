using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IAppRoleInMenuDao : IDao<IAppRoleInMenu>
    {
        IList<IAppRoleInMenu> Search(IAppRole appRole);
    }
}
