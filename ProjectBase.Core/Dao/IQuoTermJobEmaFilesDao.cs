using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoTermJobEmaFilesDao : IDao<IQuoTermJobEmaFiles>
    {
        void Update(IList<IQuoTermJobEmaFiles> entities, IQuoTermpayment entity);
        IList<IQuoTermJobEmaFiles> GetFileByParent(IQuoTermpayment TermpaymentEntity, IQuoMaster entity);
    }
}
