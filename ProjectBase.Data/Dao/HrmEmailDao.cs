using NHibernate;
using ProjectBase.Core.Model;
using ProjectBase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Data
{
    public class HrmEmailDao : NHibernateDao<IHrmEmail>, IHrmEmailDao
    {
        protected override IQueryOver<IHrmEmail, IHrmEmail> BuildId(IQueryOver<IHrmEmail, IHrmEmail> query, object id)
        {
            var _id = Convert.ToString(id);

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IHrmEmail, IHrmEmail> BuildInIds(IQueryOver<IHrmEmail, IHrmEmail> query, object[] ids)
        {
            var _ids = new List<string>();

            ids.ToList().ForEach(x => _ids.Add(Convert.ToString(x)));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IHrmEmail, IHrmEmail> BuildSort(IQueryOver<IHrmEmail, IHrmEmail> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IHrmEmail entity)
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

        public override void Delete(IHrmEmail entity)
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
