using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IHrmEmployeeDao : IDao<IHrmEmployee>
    {
        IList<IHrmEmployee> Search(IHrmEmployee entity);
        IList<object> GetListDept();
        IHrmEmployee GetUserAndPosition(object id);
        string GetEmpThaiName(object id);
    }
}
