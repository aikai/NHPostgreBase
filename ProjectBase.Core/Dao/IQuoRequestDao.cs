using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoRequestDao : IDao<IQuoRequest>
    {
        IList<IQuoRequest> Search(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool isDelete);
    }
}
