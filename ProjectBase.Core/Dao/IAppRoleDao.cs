using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IAppRoleDao : IDao<IAppRole>
    {
        IList<IAppRole> Search(IAppProject appProject, string englishName, string thaiName);
        IList<IAppRole> GetByAppProject(IAppProject appProject);
        IAppRole GetByAppProject(IAppProject appProject, string EmpId);
    }
}
