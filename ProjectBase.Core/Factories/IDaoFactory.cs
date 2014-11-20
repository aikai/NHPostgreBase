using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    /// <summary>
    /// Provides an interface for retrieving DAO objects
    /// </summary>
    public interface IDaoFactory
    {
        // Lim
        ILimGenDao GetLimGenDao();
        ILimSamplingLocateDao GetLimSamplingLocateDao();
        ILimSourceWaDao GetLimSourceWaDao();
        ILimSamSubdetailWaDao GetLimSamSubdetailWaDao();
        ILimSamPreservDao GetLimSamPreservDao();
        ILimSamMasterWaDao GetLimSamMasterWaDao();
        ILimSamDetailWaDao GetLimSamDetailWaDao();
        ILimParamWaDao GetLimParamWaDao();
        ILimParamGroupWaDao GetLimParamGroupWaDao();
        ILimCautionDao GetLimCautionDao();

        // Quatation
        IQuoTermInvDao GetQuoTermInvDao();
        IQuoTermRelateDao GetQuoTermRelateDao();
        IQuoCombineFileDao GetQuoCombineFileDao();
        IQuoCombineDeDao GetQuoCombineDeDao();
        IQuoCombineDao GetQuoCombineDao();
        IQuoRetentionDao GetQuoRetentionDao();
        IQuoTermJobEsmFileDao GetQuoTermJobEsmFileDao();
        IQuoTermJobEmaFilesDao GetQuoTermJobEmaFilesDao();
        IQuoTermJobEmaFileDao GetQuoTermJobEmaFileDao();
        IQuoTermJobEmaDao GetQuoTermJobEmaDao();
        IQuoTermJobLabFileDao GetQuoTermJobLabFileDao();
        IQuoTermStaDao GetQuoTermStaDao();
        IQuoTypeStaDao GetQuoTypeStaDao();
        IQuoTermJobLabDeDao GetQuoTermJobLabDeDao();
        IQuoTermJobLabDao GetQuoTermJobLabDao();
        IQuoTermJobEmaDeDao GetQuoTermJobEmaDeDao();
        IQuoRequestDao GetQuoRequestDao();
        IQuoReceiveDao GetQuoReceiveDao();
        IQuoPoCodeDao GetQuoPoCodeDao();
        IQuoRemarkLogDao GetQuoRemarkLogDao();
        IQuoInCusConDao GetQuoInCusConDao();
        IAppRoleInMenuDao GetAppRoleInMenuDao();
        IUnitDao GetUnitDao();
        IAppRoleDao GetAppRoleDao();
        IAppProjectDao GetAppProjectDao();
        IAppPermitDao GetAppPermitDao();
        IAppMenuDao GetAppMenuDao();
        IAppControlDao GetAppControlDao();
        ICusAddtypeDao GetCusAddtypeDao();
        ICusDueTypeDao GetCusDueTypeDao();
        IQuoTermdepDao GetQuoTermdepDao();
        IQuoTermpaymentDao GetQuoTermpaymentDao();
        IQuoTermpaymentDepDao GetQuoTermpaymentDepDao();
        IQuoApproveDao GetQuoApproveDao();
        IQuoFileDao GetQuoFileDao();
        ICusDueDao GetCusDueDao();
        IDepartmentDao GetDepartmentDao();
        IQuoDetailDao GetQuoDetailDao();
        IQuoGenDao GetQuoGenDao();
        IQuoMasterDao GetQuoMasterDao();
        IUaeProjectManageDao GetUaeProjectManageDao();
        IHrmEmployeeDao GetHrmEmployeeDao();
        ICusTypeDao GetCusTypeDao();
        ICusMasterDao GetCusMasterDao();
        ICusConDao GetCusConDao();
        ICusBustypeDao GetCusBustypeDao();
        ICusBusgroupDao GetCusBusgroupDao();
        ICusAddDao GetCusAddDao();
        IProvinceDao GetProvinceDao();
        IAmphoeDao GetAmphoeDao();
        ITambolDao GetTambolDao();
        IHrmPositionDao GetHrmPosition();
        IHrmSignDao GetHrmSign();
        IHrmEmailDao GetHrmEmail();
        IQuoCoWorkerDao GetQuoCoWorker();
        IQuoWorkerDao GetQuoWorker();
    }

    // There's no need to declare each of the DAO interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations
    // Lim
    public interface ILimGenDao : IDao<ILimGen> { }
    public interface ILimSamplingLocateDao : IDao<ILimSamplingLocate> { }
    public interface ILimSourceWaDao : IDao<ILimSourceWa> { }
    public interface ILimSamSubdetailWaDao : IDao<ILimSamSubdetailWa> { }
    public interface ILimSamPreservDao : IDao<ILimSamPreserv> { }
    public interface ILimSamMasterWaDao : IDao<ILimSamMasterWa> { }
    public interface ILimSamDetailWaDao : IDao<ILimSamDetailWa> { }
    public interface ILimParamWaDao : IDao<ILimParamWa> { }
    public interface ILimParamGroupWaDao : IDao<ILimParamGroupWa> { }
    public interface ILimCautionDao : IDao<ILimCaution> { }

    // Quatation
    public interface IQuoCombineFileDao : IDao<IQuoCombineFile> { }
    public interface IQuoCombineDeDao : IDao<IQuoCombineDe> { }
    public interface IQuoRetentionDao : IDao<IQuoRetention> { }
    public interface IQuoTermJobEmaFileDao : IDao<IQuoTermJobEmaFile> { }
    public interface IQuoTermJobLabFileDao : IDao<IQuoTermJobLabFile> { }
    public interface IQuoTermJobLabDeDao : IDao<IQuoTermJobLabDe> { }
    public interface IQuoTermJobEmaDeDao : IDao<IQuoTermJobEmaDe> { }
    public interface IQuoReceiveDao : IDao<IQuoReceive> { }
    public interface IQuoPoCodeDao : IDao<IQuoPoCode> { }
    public interface IQuoRemarkLogDao : IDao<IQuoRemarkLog> { }
    public interface IQuoInCusConDao : IDao<IQuoInCusCon> { }
    public interface IUnitDao : IDao<IUnit> { }
    public interface ICusAddtypeDao : IDao<ICusAddtype> { }
    public interface ICusDueTypeDao : IDao<ICusDueType> { }
    public interface IQuoTermpaymentDepDao : IDao<IQuoTermpaymentDep> { }
    public interface IQuoApproveDao : IDao<IQuoApprove> { }
    public interface IQuoFileDao : IDao<IQuoFile> { }
    public interface ICusDueDao : IDao<ICusDue> { }
    public interface IDepartmentDao : IDao<IDepartment> { }
    public interface IQuoDetailDao : IDao<IQuoDetail> { }
    public interface ICusTypeDao : IDao<ICusType> { }
    public interface ICusConDao : IDao<ICusCon> { }
    public interface ICusBustypeDao : IDao<ICusBustype> { }
    public interface ICusBusgroupDao : IDao<ICusBusgroup> { }
    public interface ICusAddDao : IDao<ICusAdd> { }
    public interface IProvinceDao : IDao<IProvince> { }
    public interface IAmphoeDao : IDao<IAmphoe> { }
    public interface ITambolDao : IDao<ITambol> { }
    public interface IHrmPositionDao : IDao<IHrmPosition> { }
    public interface IHrmEmailDao : IDao<IHrmEmail> { }  
#endregion
}
