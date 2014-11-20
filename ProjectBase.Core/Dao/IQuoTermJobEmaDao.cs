using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoTermJobEmaDao : IDao<IQuoTermJobEma>
    {
        void Update(IList<IQuoTermJobEma> entities, IQuoTermpayment entity);
        IList<IQuoTermJobEma> GetFileByParentLabEma(IQuoTermpayment TermpaymentEntity, IQuoMaster entity);
    }
}
