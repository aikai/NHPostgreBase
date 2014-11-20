using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class CusBustypeDao : NHibernateDao<ICusBustype>, ICusBustypeDao
    {
        protected override IQueryOver<ICusBustype, ICusBustype> BuildId(IQueryOver<ICusBustype, ICusBustype> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<ICusBustype, ICusBustype> BuildInIds(IQueryOver<ICusBustype, ICusBustype> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<ICusBustype, ICusBustype> BuildSort(IQueryOver<ICusBustype, ICusBustype> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<ICusBustype, ICusBustype> BuildParent(IQueryOver<ICusBustype, ICusBustype> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            ICusBustype e = null;

            return base.BuildParent(query, parentId).Where(() => e.CusBusgroup.Id == _id);
        }

        public override void Update(ICusBustype entity)
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

        public override void Delete(ICusBustype entity)
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
