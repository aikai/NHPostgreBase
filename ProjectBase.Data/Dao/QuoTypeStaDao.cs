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
    public class QuoTypeStaDao : NHibernateDao<IQuoTypeSta>, IQuoTypeStaDao
    {
        protected override IQueryOver<IQuoTypeSta, IQuoTypeSta> BuildId(IQueryOver<IQuoTypeSta, IQuoTypeSta> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoTypeSta, IQuoTypeSta> BuildInIds(IQueryOver<IQuoTypeSta, IQuoTypeSta> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoTypeSta, IQuoTypeSta> BuildSort(IQueryOver<IQuoTypeSta, IQuoTypeSta> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IQuoTypeSta entity)
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

        public override void Delete(IQuoTypeSta entity)
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

        public IList<IQuoTypeSta> GetByGroup(string group)
        {
            try
            {
                IList<IQuoTypeSta> entities = null;

                if (!string.IsNullOrEmpty(group))
                {
                    var s = Session;

                    if (!VerifyAvailableIsNull(s))
                    {
                        IQuoTypeSta e = null;

                        entities = s.QueryOver(() => e)
                                    .WhereRestrictionOn(() => e.Group).IsLike(group, MatchMode.Exact)
                                    .List();
                    }
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
