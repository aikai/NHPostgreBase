using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoCoWorkerDao : IDao<IQuoCoWorker>
    {
        bool SaveCoWorker(IQuoMaster entity, IList<IQuoCoWorker> listEntity);
        IList<IQuoCoWorker> GetByQuoMaster(IQuoMaster entity);
    }
}
