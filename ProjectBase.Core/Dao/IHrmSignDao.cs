using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IHrmSignDao : IDao<IHrmSign>
    {
        IHrmSign GetImageByEmp(IHrmSign entity);
        IHrmSign GetImageByEmp(string EmpId);
    }
}
