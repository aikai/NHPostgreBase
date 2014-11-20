using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IAppMenuDao : IDao<IAppMenu>
    {
        IList<IAppMenu> GetRootMenu();
        IList<IAppMenu> GetByParentMenu(IAppMenu parent);
        IList<IAppMenu> Search(IAppMenu parent, string englishName, string thaiName);
    }
}
