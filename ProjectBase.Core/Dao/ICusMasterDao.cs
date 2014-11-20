using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface ICusMasterDao : IDao<ICusMaster>
    {
        IList<ICusMaster> Search(string cusTname, string cusEname, ICusBusgroup cusBusgroup);
        IList<ICusMaster> Search(string cusCode, string cusThaiName, string cusEngName, string cusContact);
        string UpdateCustomerCode(ICusMaster customer);
    }
}
