using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoTermRelateDao : IDao<IQuoTermRelate>
    {
        IList<IQuoTermRelate> GetByQuoTermpayment(IQuoTermpayment entity);
        IList<IQuoTermRelate> GetByQuoCombineDe(IQuoCombineDe entity);
    }
}
