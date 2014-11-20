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
    public class AppPermitDao : NHibernateDao<IAppPermit>, IAppPermitDao
    {
        protected override IQueryOver<IAppPermit, IAppPermit> BuildId(IQueryOver<IAppPermit, IAppPermit> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IAppPermit, IAppPermit> BuildInIds(IQueryOver<IAppPermit, IAppPermit> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IAppPermit, IAppPermit> BuildSort(IQueryOver<IAppPermit, IAppPermit> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IAppPermit entity)
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

        public override void Delete(IAppPermit entity)
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

        public IList<IAppPermit> Search(string action)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IAppPermit>);

                IAppPermit e = null;

                var query = s.QueryOver(() => e);

                if (!string.IsNullOrEmpty(action))
                {
                    query.WhereRestrictionOn(() => e.Action).IsLike(action, MatchMode.Anywhere);
                }

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
