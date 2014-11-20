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
    public class AppRoleDao : NHibernateDao<IAppRole>, IAppRoleDao
    {
        protected override IQueryOver<IAppRole, IAppRole> BuildId(IQueryOver<IAppRole, IAppRole> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IAppRole, IAppRole> BuildInIds(IQueryOver<IAppRole, IAppRole> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IAppRole, IAppRole> BuildSort(IQueryOver<IAppRole, IAppRole> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IAppRole entity)
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

        public override void Delete(IAppRole entity)
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

        public IList<IAppRole> GetByAppProject(IAppProject appProject)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IAppRole>);

                IList<IAppRole> entities = null;
                IAppRole e = null;

                var query = s.QueryOver(() => e);

                if (appProject != null)
                {
                    IAppProject proj = null;

                    query.Inner.JoinQueryOver(() => e.AppProject, () => proj)
                         .Where(() => proj.Id == appProject.Id);

                    entities = query.List();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IAppRole GetByAppProject(IAppProject appProject, string EmpId)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IAppRole);

                AppProjectDao dao = new AppProjectDao();
                var proj = dao.GetById(appProject.Id.ToString());

                IAppRole r = null;
                IAppControl c = null;

                var q = s.QueryOver(() => r)
                         .Left.JoinQueryOver(() => r.AppControls, () => c);

                if (appProject != null)
                {
                    q.Where(() => r.AppProject.Id == appProject.Id);
                }

                if (!string.IsNullOrEmpty(EmpId))
                {
                    q.Where(() => c.HrmEmployee.Id == EmpId);
                }

                var rs = q.SingleOrDefault<IAppRole>();

                return rs;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        public IList<IAppRole> Search(IAppProject appProject, string englishName, string thaiName)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IAppRole>);

                IAppRole e = null;

                var query = s.QueryOver(() => e);

                if (appProject != null)
                {
                    IAppProject proj = null;

                    query.Inner.JoinQueryOver(() => e.AppProject, () => proj)
                         .Where(() => proj.Id == appProject.Id);
                }

                if (!string.IsNullOrEmpty(englishName))
                {
                    query.WhereRestrictionOn(() => e.EnglishName).IsLike(englishName, MatchMode.Anywhere);
                }

                if (!string.IsNullOrEmpty(thaiName))
                {
                    query.WhereRestrictionOn(() => e.ThaiName).IsLike(thaiName, MatchMode.Anywhere);
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
