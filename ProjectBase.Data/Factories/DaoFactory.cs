using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Data;
using ProjectBase.Core;

namespace ProjectBase.Data
{
    /// <summary>
    /// Exposes access to NHibernate DAO classes.  Motivation for this DAO
    /// framework can be found at http://www.hibernate.org/328.html.
    /// </summary>
    [Serializable]
    public class DaoFactory : IDaoFactory
    {
        public DaoFactory() { }

        #region This is a thread-safe, lazy singleton.
        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static DaoFactory Instance
        {
            get
            {
                try
                {
                    return Nested.DaoFactory;
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
            internal static readonly DaoFactory DaoFactory = new DaoFactory();
        }
        #endregion

        // Lim
        public ILimGenDao GetLimGenDao()
        {
            return new LimGenDao();
        }
        public ILimSamplingLocateDao GetLimSamplingLocateDao()
        {
            return new LimSamplingLocateDao();
        }
        public ILimSourceWaDao GetLimSourceWaDao()
        {
            return new LimSourceWaDao();
        }
        public ILimSamSubdetailWaDao GetLimSamSubdetailWaDao()
        {
            return new LimSamSubdetailWaDao();
        }
        public ILimSamPreservDao GetLimSamPreservDao()
        {
            return new LimSamPreservDao();
        }
        public ILimSamMasterWaDao GetLimSamMasterWaDao()
        {
            return new LimSamMasterWaDao();
        }
        public ILimSamDetailWaDao GetLimSamDetailWaDao()
        {
            return new LimSamDetailWaDao();
        }
        public ILimParamWaDao GetLimParamWaDao()
        {
            return new LimParamWaDao();
        }
        public ILimParamGroupWaDao GetLimParamGroupWaDao()
        {
            return new LimParamGroupWaDao();
        }
        public ILimCautionDao GetLimCautionDao()
        {
            return new LimCautionDao();
        }

        // Quatation
        public IQuoTermInvDao GetQuoTermInvDao()
        {
            return new QuoTermInvDao();
        }

        public IQuoTermRelateDao GetQuoTermRelateDao()
        {
            return new QuoTermRelateDao();
        }

        public IQuoCombineFileDao GetQuoCombineFileDao()
        {
            return new QuoCombineFileDao();
        }

        public IQuoCombineDeDao GetQuoCombineDeDao()
        {
            return new QuoCombineDeDao();
        }

        public IQuoCombineDao GetQuoCombineDao()
        {
            return new QuoCombineDao();
        }

        //public IGenDocNoDao GetGenDocNoDao()
        //{
        //    return new GenDocNoDao();
        //}

        public IQuoRetentionDao GetQuoRetentionDao()
        {
            return new QuoRetentionDao();
        }

        public IQuoTermJobEmaFilesDao GetQuoTermJobEmaFilesDao()
        {
            return new QuoTermJobEmaFilesDao();
        }

        public IQuoTermJobEsmFileDao GetQuoTermJobEsmFileDao()
        {
            return new QuoTermJobEsmFileDao();
        }

        public IQuoTermJobEmaFileDao GetQuoTermJobEmaFileDao()
        {
            return new QuoTermJobEmaFileDao();
        }

        public IQuoTermJobLabFileDao GetQuoTermJobLabFileDao()
        {
            return new QuoTermJobLabFileDao();
        }

        public IQuoTermStaDao GetQuoTermStaDao()
        {
            return new QuoTermStaDao();
        }

        public IQuoTypeStaDao GetQuoTypeStaDao()
        {
            return new QuoTypeStaDao();
        }

        public IQuoTermJobLabDeDao GetQuoTermJobLabDeDao()
        {
            return new QuoTermJobLabDeDao();
        }

        public IQuoTermJobLabDao GetQuoTermJobLabDao()
        {
            return new QuoTermJobLabDao();
        }

        public IQuoTermJobEmaDeDao GetQuoTermJobEmaDeDao()
        {
            return new QuoTermJobEmaDeDao();
        }

        public IQuoTermJobEmaDao GetQuoTermJobEmaDao()
        {
            return new QuoTermJobEmaDao();
        }

        public IQuoRequestDao GetQuoRequestDao()
        {
            return new QuoRequestDao();
        }

        public IQuoReceiveDao GetQuoReceiveDao()
        {
            return new QuoReceiveDao();
        }

        public IQuoPoCodeDao GetQuoPoCodeDao()
        {
            return new QuoPoCodeDao();
        }

        public IQuoRemarkLogDao GetQuoRemarkLogDao()
        {
            return new QuoRemarkLogDao();
        }

        public IQuoInCusConDao GetQuoInCusConDao()
        {
            return new QuoInCusConDao();
        }

        public IAppRoleInMenuDao GetAppRoleInMenuDao()
        {
            return new AppRoleInMenuDao();
        }
        
        public IUnitDao GetUnitDao()
        {
            return new UnitDao();
        }

        public IAppRoleDao GetAppRoleDao()
        {
            return new AppRoleDao();
        }

        public IAppProjectDao GetAppProjectDao()
        {
            return new AppProjectDao();
        }

        public IAppPermitDao GetAppPermitDao()
        {
            return new AppPermitDao();
        }

        public IAppMenuDao GetAppMenuDao()
        {
            return new AppMenuDao();
        }

        public IAppControlDao GetAppControlDao()
        {
            return new AppControlDao();
        }

        public ICusAddtypeDao GetCusAddtypeDao()
        {
            return new CusAddtypeDao();
        }

        public ICusDueTypeDao GetCusDueTypeDao()
        {
            return new CusDueTypeDao();
        }

        public IQuoTermdepDao GetQuoTermdepDao()
        {
            return new QuoTermdepDao();
        }

        public IQuoTermpaymentDao GetQuoTermpaymentDao()
        {
            return new QuoTermpaymentDao();
        }

        public IQuoTermpaymentDepDao GetQuoTermpaymentDepDao()
        {
            return new QuoTermpaymentDepDao();
        }

        public IQuoApproveDao GetQuoApproveDao()
        {
            return new QuoApproveDao();
        }

        public IQuoFileDao GetQuoFileDao()
        {
            return new QuoFileDao();
        }

        public ICusDueDao GetCusDueDao()
        {
            return new CusDueDao();
        }

        public IDepartmentDao GetDepartmentDao()
        {
            return new DepartmentDao();
        }

        public IQuoDetailDao GetQuoDetailDao()
        {
            return new QuoDetailDao();
        }

        public IQuoGenDao GetQuoGenDao()
        {
            return new QuoGenDao();
        }

        public IQuoMasterDao GetQuoMasterDao()
        {
            return new QuoMasterDao();
        }

        public IUaeProjectManageDao GetUaeProjectManageDao()
        {
            return new UaeProjectManageDao();
        }

        public IHrmEmployeeDao GetHrmEmployeeDao()
        {
            return new HrmEmployeeDao();
        }

        public ICusTypeDao GetCusTypeDao()
        {
            return new CusTypeDao();
        }

        public ICusMasterDao GetCusMasterDao()
        {
            return new CusMasterDao();
        }

        public ICusConDao GetCusConDao()
        {
            return new CusConDao();
        }

        public ICusBustypeDao GetCusBustypeDao()
        {
            return new CusBustypeDao();
        }

        public ICusBusgroupDao GetCusBusgroupDao()
        {
            return new CusBusgroupDao();
        }

        public ICusAddDao GetCusAddDao()
        {
            return new CusAddDao();
        }

        public IProvinceDao GetProvinceDao()
        {
            return new ProvinceDao();
        }

        public IAmphoeDao GetAmphoeDao()
        {
            return new AmphoeDao();
        }

        public ITambolDao GetTambolDao()
        {
            return new TambolDao();
        }

        public IHrmPositionDao GetHrmPosition()
        {
            return new HrmPositionDao();
        }

        public IHrmSignDao GetHrmSign()
        {
            return new HrmSignDao();
        }

        public IHrmEmailDao GetHrmEmail()
        {
            return new HrmEmailDao();
        }

        public IQuoCoWorkerDao GetQuoCoWorker()
        {
            return new QuoCoWorkerDao();
        }

        public IQuoWorkerDao GetQuoWorker()
        {
            return new QuoWorkerDao();
        }

        #region Inline DAO implementations
        /// <summary>
        /// Concrete DAO for accessing instances of <see cref="Customer" /> from DB.
        /// This should be extracted into its own class-file if it needs to extend the
        /// inherited DAO functionality.
        /// </summary>
        
        #endregion
    }
}
