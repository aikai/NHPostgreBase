using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoTermpaymentDao : IDao<IQuoTermpayment>
    {
        void Update(IList<IQuoTermpayment> entities, IQuoMaster entity);
        IList<IQuoTermpayment> SearchInvoice(DateTime? startDate, DateTime? endDate, string project,
            bool projectStatus, string projectCode, IQuoTypeSta WorkStatus);
        IList<IQuoTermpayment> SearchInvoice(DateTime? startDate, DateTime? endDate, string project, bool projectStatus,
            string projectCode, string status);
        int GetMaxYearByDueDate();
        int SummaryCloseJob();
        IList<IQuoTermpayment> GetCountTermReceiveMoney(IQuoMaster entity, string Dept, string Name, int Index);
        IList<IQuoTermpayment> GetTermpaymentByParent(IQuoMaster entity, string Dept);
    }
}
