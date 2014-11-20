using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoCombineDao : IDao<IQuoCombine>
    {
        void Update(IList<IQuoCombine> items, IQuoMaster entity);
    }
}
