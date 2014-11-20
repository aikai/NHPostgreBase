using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoTermJobEsmFileDao : IDao<IQuoTermJobEsmFile>
    {
        void Update(IList<IQuoTermJobEsmFile> entities, IQuoTermpayment entity);
        IList<IQuoTermJobEsmFile> GetFileByParent(IQuoTermpayment TermpaymentEntity, IQuoMaster entity);
    }
}
