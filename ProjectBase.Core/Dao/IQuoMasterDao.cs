using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoMasterDao : IDao<IQuoMaster>
    {
        void UpdateMasterOnly(IQuoMaster entity);

        IList<IQuoMaster> Search(DateTime? startDate, DateTime? endDate, bool employ);
        IList<IQuoMaster> Search(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster);
        IList<IQuoMaster> Search(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, bool term);
        IList<IQuoMaster> Search(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, bool term, bool mail);

        IList<IQuoMaster> SearchByWorkerMail(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, bool mail, IHrmEmployee Emp);

        IList<IQuoMaster> SearchByPoCode(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, string poCode);
        IList<IQuoMaster> SearchByPoCode(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, bool term, string poCode);

        IList<IQuoMaster> SearchByProposed(DateTime? startDate, DateTime? endDate, bool? employ);
        IList<IQuoMaster> SearchByProposed(DateTime? startDate, DateTime? endDate, bool? employ, string vat);
        IList<IQuoMaster> SearchByTerm(DateTime? startDate, DateTime? endDate, bool employ);

        IList<IQuoMaster> GetByUaeProjectManage(IUaeProjectManage projManage);
        IList<IQuoMaster> GetByCusMaster(ICusMaster cusMaster);
        IList<IQuoMaster> GetOnlyHaveTerm(DateTime? startDate, DateTime? endDate);

        string SummaryStatusQuotation(string EmpId);
        int SummaryQuoWaitSend(string EmpId);
        int SummaryQuoWaitReceive(string Dept);
        int SummaryQuoInProcess(string EmpId);
        int SummaryQuoCloseJob(string Dept);
        string SummaryStatusQuotation();

        IList<IQuoMaster> Search(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool isDelete, IHrmEmployee Emp);

        IList<IQuoMaster> Search(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool Project, string ProjectCode);

        IList<IQuoMaster> SearchByWorkerMail(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, IHrmEmployee Emp, bool projectStatus,
            string projectCode, IQuoTypeSta WorkStatus);

        IList<IQuoMaster> SearchByPoCode(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, string poCode, bool projectStatus, string projectCode);
        IList<IQuoMaster> SearchByPoCode(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, bool term, string poCode, bool projectStatus, string projectCode);

        IList<IQuoMaster> SearchByInvoiceStatusUAF(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool projectStatus, string projectCode);

        int SummaryCountQuatation(string EmpId);

        IList<IQuoMaster> SearchQuotationByWorker(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, bool mail, IHrmEmployee Emp);
    }
}
