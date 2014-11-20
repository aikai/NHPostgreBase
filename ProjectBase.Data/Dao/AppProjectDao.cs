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
    public class AppProjectDao : NHibernateDao<IAppProject>, IAppProjectDao
    {
        protected override IQueryOver<IAppProject, IAppProject> BuildId(IQueryOver<IAppProject, IAppProject> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IAppProject, IAppProject> BuildInIds(IQueryOver<IAppProject, IAppProject> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IAppProject, IAppProject> BuildSort(IQueryOver<IAppProject, IAppProject> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IAppProject entity)
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

        public override void Delete(IAppProject entity)
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

        public IList<IAppProject> Search(string appName)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IAppProject>);

                IAppProject e = null;

                var query = s.QueryOver(() => e);

                if (!string.IsNullOrEmpty(appName))
                {
                    query.WhereRestrictionOn(() => e.AppName).IsLike(appName, MatchMode.Anywhere);
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
