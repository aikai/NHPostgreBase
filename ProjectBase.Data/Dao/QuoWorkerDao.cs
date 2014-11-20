using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;
using NHibernate.Criterion;

namespace ProjectBase.Data
{
    public class QuoWorkerDao : NHibernateDao<IQuoWorker>, IQuoWorkerDao
    {
        protected override IQueryOver<IQuoWorker, IQuoWorker> BuildId(IQueryOver<IQuoWorker, IQuoWorker> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoWorker, IQuoWorker> BuildInIds(IQueryOver<IQuoWorker, IQuoWorker> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoWorker, IQuoWorker> BuildSort(IQueryOver<IQuoWorker, IQuoWorker> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public bool CheckWorkerDuplicate(IHrmEmployee Employee, IQuoMaster quoMaster)
        {
            try
            {
                bool result = false;
                if (VerifyAvailableIsNull(quoMaster)) return false;

                var s = Session;

                if (!VerifyAvailableIsNull(s))
                {
                    IQuoWorker e = null;

                    var entities = s.QueryOver(() => e)
                                    .Where(() => e.QuoMaster == quoMaster)
                                    .And(() => e.Employee == Employee)
                                    .List();

                    if (entities.Count() > 0)
                    {
                        result = true;
                    }
                }


                return result;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }


        public IList<IQuoWorker> GetWorkerbyQuoMaster(string quoMasterId)
        {
            try
            {
                var s = Session;    
                IList<IQuoWorker> listWorker = new List<IQuoWorker>();


                if (!VerifyAvailableIsNull(s))
                {
                    IQuoWorker e = null;
                    IQuoMaster m = null;


                    listWorker = s.QueryOver(() => e)
                                  .Left.JoinQueryOver(() => e.QuoMaster, () =>m)
                                  .Where(() => m.Id == new Guid(quoMasterId))
                                  .List();
                }

                return listWorker;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
