using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoTermInvDao : IDao<IQuoTermInv>
    {
        IQuoTermInv GetByDocNo(string docNo);
    }
}
