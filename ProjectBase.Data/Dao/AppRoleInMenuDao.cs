using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class AppRoleInMenuDao : NHibernateDao<IAppRoleInMenu>, IAppRoleInMenuDao
    {
        protected override IQueryOver<IAppRoleInMenu, IAppRoleInMenu> BuildId(IQueryOver<IAppRoleInMenu, IAppRoleInMenu> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IAppRoleInMenu, IAppRoleInMenu> BuildInIds(IQueryOver<IAppRoleInMenu, IAppRoleInMenu> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IAppRoleInMenu, IAppRoleInMenu> BuildSort(IQueryOver<IAppRoleInMenu, IAppRoleInMenu> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IAppRoleInMenu entity)
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

        public override void Delete(IAppRoleInMenu entity)
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

        public IList<IAppRoleInMenu> Search(IAppRole appRole)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IAppRoleInMenu>);

                IAppRoleInMenu e = null;

                var query = s.QueryOver(() => e);

                if (appRole != null)
                {
                    IAppRole role = null;

                    query.Inner.JoinQueryOver(() => e.AppRole, () => role)
                         .Where(() => role.Id == appRole.Id);
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
