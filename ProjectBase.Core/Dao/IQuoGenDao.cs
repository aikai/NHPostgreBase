using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoGenDao : IDao<IQuoGen>
    {
        int GetMaxByGenCode();
        IList<IQuoGen> GetQuoGenByParent(IQuoMaster entity);
        IQuoGen GetQuoGenUsedByParent(IQuoMaster entity);
        IList<IQuoGen> SearchQuataionGenNo(IQuoGen entity, DateTime dStart, DateTime dEnd);
    }
}
