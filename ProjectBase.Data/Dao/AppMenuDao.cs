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
    public class AppMenuDao : NHibernateDao<IAppMenu>, IAppMenuDao
    {
        protected override IQueryOver<IAppMenu, IAppMenu> BuildId(IQueryOver<IAppMenu, IAppMenu> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IAppMenu, IAppMenu> BuildInIds(IQueryOver<IAppMenu, IAppMenu> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IAppMenu, IAppMenu> BuildSort(IQueryOver<IAppMenu, IAppMenu> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IAppMenu, IAppMenu> BuildParent(IQueryOver<IAppMenu, IAppMenu> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IAppMenu e = null;

            return base.BuildParent(query, parentId).Where(() => e.Parent.Id == _id);
        }

        public override void Update(IAppMenu entity)
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

        public override void Delete(IAppMenu entity)
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

        public IList<IAppMenu> GetRootMenu()
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IAppMenu>);

                IAppMenu e = null;

                var query = s.QueryOver(() => e)
                             .WhereRestrictionOn(() => e.Parent).IsNull;

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IAppMenu> GetByParentMenu(IAppMenu parent)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IAppMenu>);

                IList<IAppMenu> entities = null;

                if (!VerifyAvailableIsNull(parent))
                {
                    IAppMenu e = null;
                    IAppMenu o = null;

                    var query = s.QueryOver(() => e)
                                 .Inner.JoinQueryOver(() => e.Parent, () => o)
                                 .Where(() => o.Id == parent.Id);

                    entities = query.List(); 
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IAppMenu> Search(IAppMenu parent, string englishName, string thaiName)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IAppMenu>);

                IAppMenu e = null;

                var query = s.QueryOver(() => e);

                if (parent != null)
                {
                    IAppMenu o = null;

                    query.Inner.JoinQueryOver(() => e.Parent, () => o)
                         .Where(() => o.Id == parent.Id);
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
