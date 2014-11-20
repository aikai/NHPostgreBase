using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoTermdepDao : IDao<IQuoTermdep>
    {
        void Update(IList<IQuoTermdep> entities, IQuoMaster entity);
    }
}
