using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoTermStaDao : IDao<IQuoTermSta>
    {
        IList<IQuoTermSta> GetByQuoTermpayment(IQuoTermpayment entity);
        IList<IQuoTermSta> ExportToExcel(string typeName);
        IList<IQuoTermSta> ExportToExcel(DateTime? startDate, DateTime? endDate, string typeName);
    }
}
