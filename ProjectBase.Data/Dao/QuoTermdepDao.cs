using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class QuoTermdepDao : NHibernateDao<IQuoTermdep>, IQuoTermdepDao
    {
        protected override IQueryOver<IQuoTermdep, IQuoTermdep> BuildId(IQueryOver<IQuoTermdep, IQuoTermdep> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoTermdep, IQuoTermdep> BuildInIds(IQueryOver<IQuoTermdep, IQuoTermdep> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoTermdep, IQuoTermdep> BuildSort(IQueryOver<IQuoTermdep, IQuoTermdep> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IQuoTermdep entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return;

                Update(delegate(ISession s)
                {
                    s.Clear();
                    s.Update(s.Merge(entity));
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(IList<IQuoTermdep> entities, IQuoMaster entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entities) || 1 > entities.Count) return;

                Update(delegate(ISession s)
                {
                    #region Update all record in childs
                    IQuoMaster e = null;
                    IQuoTermdep o = null;

                    var quoTermdeps = s.QueryOver<IQuoTermdep>(() => o)
                                       .Inner.JoinQueryOver(() => o.QuoMaster, () => e)
                                       .Where(() => e.Id == entity.Id).List();

                    if (!VerifyAvailableIsNull(quoTermdeps) && quoTermdeps.Count > 0)
                    {
                        s.Clear();

                        foreach (var item in quoTermdeps)
                        {
                            var exist = entities.Where(x => x.Id == item.Id)
                                                .SingleOrDefault();

                            if (exist == null)
                            {
                                s.Delete(item);
                            }
                        }

                        s.Flush();
                    }
                    #endregion

                    s.Clear();

                    foreach (var item in entities)
                    {
                        s.Update(s.Merge(item));
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete(IQuoTermdep entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return;

                Update(delegate(ISession s) { s.Delete(s.Merge(entity)); });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
