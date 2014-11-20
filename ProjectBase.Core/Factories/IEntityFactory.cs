using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    /// <summary>
    /// Provides an interface for retrieving entity objects
    /// </summary>
    public interface IEntityFactory
    {
        // Lim
        ILimGen CreateLimGen();
        ILimSamplingLocate CreateLimSamplingLocate();
        ILimSourceWa CreateLimSourceWa();
        ILimSamSubdetailWa CreateLimSamSubdetailWa();
        ILimSamPreserv CreateLimSamPreserv();
        ILimSamMasterWa CreateLimSamMasterWa();
        ILimSamDetailWa CreateLimSamDetailWa();
        ILimParamWa CreateLimParamWa();
        ILimParamGroupWa CreateLimParamGroupWa();
        ILimCaution CreateLimCaution();

        // Quatation
        IQuoTermInv CreateQuoTermInv();
        IQuoTermRelate CreateQuoTermRelate();
        IQuoCombineFile CreateQuoCombineFile();
        IQuoCombineDe CreateQuoCombineDe();
        IQuoCombine CreateQuoCombine();
        //IGenDocNo CreateGenDocNo();
        IQuoRetention CreateQuoRetention();
        IQuoTermJobEsmFile CreateQuoTermJobEsmFile();
        IQuoTermJobEmaFiles CreateQuoTermJobEmaFiles();
        IQuoTermJobEmaFile CreateQuoTermJobEmaFile();
        IQuoTermJobEma CreateQuoTermJobEma();
        IQuoTermJobLabFile CreateQuoTermJobLabFile();
        IQuoTermSta CreateQuoTermSta();
        IQuoTypeSta CreateQuoTypeSta();
        IQuoTermJobLabDe CreateQuoTermJobLabDe();
        IQuoTermJobLab CreateQuoTermJobLab();
        IQuoTermJobEmaDe CreateQuoTermJobEmaDe();
        IQuoRequest CreateQuoRequest();
        IQuoReceive CreateQuoReceive();
        IQuoPoCode CreateQuoPoCode();
        IQuoRemarkLog CreateQuoRemarkLog();
        IQuoInCusCon CreateQuoInCusCon();
        IAppRoleInMenu CreateAppRoleInMenu();
        IUnit CreateUnit();
        IAppRole CreateAppRole();
        IAppProject CreateAppProject();
        IAppPermit CreateAppPermit();
        IAppMenu CreateAppMenu();
        IAppControl CreateAppControl();
        IAppControlDetail CreateAppControlDetail();
        ICusAddtype CreateCusAddtype();
        ICusDueType CreateCusDueType();
        IQuoTermdep CreateQuoTermdep();
        IQuoTermpayment CreateQuoTermpayment();
        IQuoTermpaymentDep CreateQuoTermpaymentDep();
        IQuoApprove CreateQuoApprove();
        IQuoFile CreateQuoFile();
        ICusDue CreateCusDue();
        IDepartment CreateDepartment();
        IQuoDetail CreateQuoDetail();
        IQuoGen CreateQuoGen();
        IQuoMaster CreateQuoMaster();
        IUaeProjectManage CreateUaeProjectManage();
        IHrmEmployee CreateHrmEmployee();
        ICusType CreateCusType();
        ICusMaster CreateCusMaster();
        ICusCon CreateCusCon();
        ICusBustype CreateCusBustype();
        ICusBusgroup CreateCusBusgroup();
        ICusAdd CreateCusAdd();
        IProvince CreateProvince();
        IAmphoe CreateAmphoe();
        ITambol CreateTambol();
        IAddress CreateAddress();
        IAddressShort CreateAddressShort();
        IHrmPosition CreateHrmPosition();
        IHrmSign CreateHrmSign();
        IHrmEmail CreateHrmEmail();
        IQuoCoWorker CreateQuoCoWorker();
        IQuoWorker CreateQuoWorker();
    }

    // There's no need to declare each of the entity interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations
    
    #endregion
}
