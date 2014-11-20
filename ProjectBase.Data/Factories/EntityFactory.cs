using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using ProjectBase.Data.Model;

namespace ProjectBase.Data
{
    /// <summary>
    /// Exposes access to entity classes.  Motivation for this entity
    /// </summary>
    [Serializable]
    public class EntityFactory : IEntityFactory
    {
        public EntityFactory() { }

        #region This is a thread-safe, lazy singleton.
        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static EntityFactory Instance
        {
            get
            {
                try
                {
                    return Nested.EntityFactory;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        protected class Nested
        {
            static Nested() { }
            internal static readonly EntityFactory EntityFactory = new EntityFactory();
        }
        #endregion

        // Lim
        public ILimGen CreateLimGen()
        {
            return new LimGen();
        }
        public ILimSamplingLocate CreateLimSamplingLocate()
        {
            return new LimSamplingLocate();
        }
        public ILimSourceWa CreateLimSourceWa()
        {
            return new LimSourceWa();
        }
        public ILimSamSubdetailWa CreateLimSamSubdetailWa()
        {
            return new LimSamSubdetailWa();
        }
        public ILimSamPreserv CreateLimSamPreserv()
        {
            return new LimSamPreserv();
        }
        public ILimSamMasterWa CreateLimSamMasterWa()
        {
            return new LimSamMasterWa();
        }
        public ILimSamDetailWa CreateLimSamDetailWa()
        {
            return new LimSamDetailWa();
        }
        public ILimParamWa CreateLimParamWa()
        {
            return new LimParamWa();
        }
        public ILimParamGroupWa CreateLimParamGroupWa()
        {
            return new LimParamGroupWa();
        }
        public ILimCaution CreateLimCaution()
        {
            return new LimCaution();
        }

        // Quatation
        public IQuoTermInv CreateQuoTermInv()
        {
            return new QuoTermInv();
        }

        public IQuoTermRelate CreateQuoTermRelate()
        {
            return new QuoTermRelate();
        }

        public IQuoCombineFile CreateQuoCombineFile()
        {
            return new QuoCombineFile();
        }

        public IQuoCombineDe CreateQuoCombineDe()
        {
            return new QuoCombineDe();
        }

        public IQuoCombine CreateQuoCombine()
        {
            return new QuoCombine();
        }

        //public IGenDocNo CreateGenDocNo()
        //{
        //    return new GenDocNo();
        //}

        public IQuoRetention CreateQuoRetention()
        {
            return new QuoRetention();
        }

        public IQuoTermJobEmaFiles CreateQuoTermJobEmaFiles()
        {
            return new QuoTermJobEmaFiles();
        }

        public IQuoTermJobEsmFile CreateQuoTermJobEsmFile()
        {
            return new QuoTermJobEsmFile();
        }

        public IQuoTermJobEmaFile CreateQuoTermJobEmaFile()
        {
            return new QuoTermJobEmaFile();
        }

        public IQuoTermJobLabFile CreateQuoTermJobLabFile()
        {
            return new QuoTermJobLabFile();
        }

        public IQuoTermSta CreateQuoTermSta()
        {
            return new QuoTermSta();
        }

        public IQuoTypeSta CreateQuoTypeSta()
        {
            return new QuoTypeSta();
        }

        public IQuoTermJobLabDe CreateQuoTermJobLabDe()
        {
            return new QuoTermJobLabDe();
        }

        public IQuoTermJobLab CreateQuoTermJobLab()
        {
            return new QuoTermJobLab();
        }

        public IQuoTermJobEmaDe CreateQuoTermJobEmaDe()
        {
            return new QuoTermJobEmaDe();
        }

        public IQuoTermJobEma CreateQuoTermJobEma()
        {
            return new QuoTermJobEma();
        }

        public IQuoRequest CreateQuoRequest()
        {
            return new QuoRequest();
        }

        public IQuoReceive CreateQuoReceive()
        {
            return new QuoReceive();
        }

        public IQuoPoCode CreateQuoPoCode()
        {
            return new QuoPoCode();
        }

        public IQuoRemarkLog CreateQuoRemarkLog()
        {
            return new QuoRemarkLog();
        }

        public IQuoInCusCon CreateQuoInCusCon()
        {
            return new QuoInCusCon();
        }

        public IAppRoleInMenu CreateAppRoleInMenu()
        {
            return new AppRoleInMenu();
        }

        public IUnit CreateUnit()
        {
            return new Unit();
        }

        public IAppRole CreateAppRole()
        {
            return new AppRole();
        }

        public IAppProject CreateAppProject()
        {
            return new AppProject();
        }

        public IAppPermit CreateAppPermit()
        {
            return new AppPermit();
        }

        public IAppMenu CreateAppMenu()
        {
            return new AppMenu();
        }

        public IAppControl CreateAppControl()
        {
            return new AppControl();
        }

        public ICusAddtype CreateCusAddtype()
        {
            return new CusAddtype();
        }

        public ICusDueType CreateCusDueType()
        {
            return new CusDueType();
        }

        public IQuoTermdep CreateQuoTermdep()
        {
            return new QuoTermdep();
        }

        public IQuoTermpayment CreateQuoTermpayment()
        {
            return new QuoTermpayment();
        }

        public IQuoTermpaymentDep CreateQuoTermpaymentDep()
        {
            return new QuoTermpaymentDep();
        }

        public IQuoApprove CreateQuoApprove()
        {
            return new QuoApprove();
        }

        public IQuoFile CreateQuoFile()
        {
            return new QuoFile();
        }

        public ICusDue CreateCusDue()
        {
            return new CusDue();
        }

        public IDepartment CreateDepartment()
        {
            return new Department();
        }

        public IQuoDetail CreateQuoDetail()
        {
            return new QuoDetail();
        }

        public IQuoGen CreateQuoGen()
        {
            return new QuoGen();
        }

        public IQuoMaster CreateQuoMaster()
        {
            return new QuoMaster();
        }

        public IUaeProjectManage CreateUaeProjectManage()
        {
            return new UaeProjectManage();
        }

        public IHrmEmployee CreateHrmEmployee()
        {
            return new HrmEmployee();
        }

        public ICusType CreateCusType()
        {
            return new CusType();
        }

        public ICusMaster CreateCusMaster()
        {
            return new CusMaster();
        }

        public ICusCon CreateCusCon()
        {
            return new CusCon();
        }

        public ICusBustype CreateCusBustype()
        {
            return new CusBustype();
        }

        public ICusBusgroup CreateCusBusgroup()
        {
            return new CusBusgroup();
        }

        public ICusAdd CreateCusAdd()
        {
            return new CusAdd();
        }

        public IProvince CreateProvince()
        {
            return new Province();
        }

        public IAmphoe CreateAmphoe()
        {
            return new Amphoe();
        }

        public ITambol CreateTambol()
        {
            return new Tambol();
        }

        public IAddress CreateAddress()
        {
            return new Address();
        }

        public IAddressShort CreateAddressShort()
        {
            return new AddressShort();
        }

        public IAppControlDetail CreateAppControlDetail()
        {
            return new AppControlDetail();
        }

        public IHrmPosition CreateHrmPosition()
        {
            return new HrmPosition();
        }

        public IHrmSign CreateHrmSign()
        {
            return new HrmSign();
        }

        public IHrmEmail CreateHrmEmail()
        {
            return new HrmEmail();
        }

        public IQuoCoWorker CreateQuoCoWorker()
        {
            return new QuoCoWorker();
        }

        public IQuoWorker CreateQuoWorker()
        {
            return new QuoWorker();
        }

        #region Inline Entity implementations
        /// <summary>
        /// Concrete entity for accessing instances of <see cref="Customs" /> from DB.
        /// This should be extracted into its own class-file if it needs to extend the
        /// inherited Entity functionality.
        /// </summary>
        
        #endregion
    }
}