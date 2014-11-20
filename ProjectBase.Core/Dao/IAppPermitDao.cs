using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IAppPermitDao : IDao<IAppPermit>
    {
        IList<IAppPermit> Search(string action);
    }
}
