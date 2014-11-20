using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoWorkerDao : IDao<IQuoWorker>
    {
        bool CheckWorkerDuplicate(IHrmEmployee Employee, IQuoMaster quoMaster);
        IList<IQuoWorker> GetWorkerbyQuoMaster(string quoMasterId);
    }
}
