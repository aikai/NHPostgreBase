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
    public class QuoCoWorkerDao : NHibernateDao<IQuoCoWorker>, IQuoCoWorkerDao
    {
        protected override IQueryOver<IQuoCoWorker, IQuoCoWorker> BuildId(IQueryOver<IQuoCoWorker, IQuoCoWorker> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoCoWorker, IQuoCoWorker> BuildInIds(IQueryOver<IQuoCoWorker, IQuoCoWorker> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoCoWorker, IQuoCoWorker> BuildSort(IQueryOver<IQuoCoWorker, IQuoCoWorker> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public bool SaveCoWorker(IQuoMaster entity, IList<IQuoCoWorker> listEntity)
        {
            try
            {
                bool bResult = false;

                Update(delegate(ISession s)
                {
                    s.Clear();
                    IQuoCoWorker c= null;
                    IQuoMaster m = null;

                    var oldCoWorks = s.QueryOver<IQuoCoWorker>(() => c)
                                      .Left.JoinQueryOver(() => c.QuoMaster, () => m)
                                      .Where(() => m.Id == entity.Id)
                                      .List();

                    if (oldCoWorks.Count() > 0)
                    {   
                        foreach (var exist in oldCoWorks)
                        {
                            s.Delete(exist);
                        }

                        s.Flush();
                    }
                    

                    foreach (var item in listEntity)
                    {
                        s.Save(item);
                    }

                    bResult = true;
                });

                return bResult;
            }
            catch (Exception ex)
            {   
                throw ex;
            }   
        }

        public IList<IQuoCoWorker> GetByQuoMaster(IQuoMaster entity)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoCoWorker>);

                IList<IQuoCoWorker> entities = null;
                IQuoCoWorker e = null;

                var query = s.QueryOver(() => e);

                if (entity != null)
                {
                    IQuoMaster quo = null;

                    query.Inner.JoinQueryOver(() => e.QuoMaster, () => quo)
                         .Where(() => quo.Id == entity.Id);

                    entities = query.List();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
