using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IAppControlDao : IDao<IAppControl>
    {
        IList<IAppControl> Search(IAppRole GroupId);
        object Save(IList<IAppControl> entitys);
        IAppControl Search(IHrmEmployee entity);
        IList<IAppControl> SearchEmployeeEmail(IAppRole GroupId);
    }
}
