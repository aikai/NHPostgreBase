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
    public class QuoInCusConDao : NHibernateDao<IQuoInCusCon>, IQuoInCusConDao
    {
        protected override IQueryOver<IQuoInCusCon, IQuoInCusCon> BuildId(IQueryOver<IQuoInCusCon, IQuoInCusCon> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoInCusCon, IQuoInCusCon> BuildInIds(IQueryOver<IQuoInCusCon, IQuoInCusCon> query, object[] ids)
        {
            var _ids = new List<string>();

            ids.ToList().ForEach(x => _ids.Add(Convert.ToString(x)));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoInCusCon, IQuoInCusCon> BuildSort(IQueryOver<IQuoInCusCon, IQuoInCusCon> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IQuoInCusCon, IQuoInCusCon> BuildParent(IQueryOver<IQuoInCusCon, IQuoInCusCon> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IQuoInCusCon e = null;

            return base.BuildParent(query, parentId).Where(() => e.QuoMaster.Id == _id);
        }

        public override void Update(IQuoInCusCon entity)
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

        public override void Delete(IQuoInCusCon entity)
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
