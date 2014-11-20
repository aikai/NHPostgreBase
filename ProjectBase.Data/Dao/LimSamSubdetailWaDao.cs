using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class LimSamSubdetailWaDao : NHibernateDao<ILimSamSubdetailWa>, ILimSamSubdetailWaDao
    {
        protected override IQueryOver<ILimSamSubdetailWa, ILimSamSubdetailWa> BuildId(IQueryOver<ILimSamSubdetailWa, ILimSamSubdetailWa> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<ILimSamSubdetailWa, ILimSamSubdetailWa> BuildInIds(IQueryOver<ILimSamSubdetailWa, ILimSamSubdetailWa> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<ILimSamSubdetailWa, ILimSamSubdetailWa> BuildSort(IQueryOver<ILimSamSubdetailWa, ILimSamSubdetailWa> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        //protected override IQueryOver<ILimSamSubdetailWa, ILimSamSubdetailWa> BuildParent(IQueryOver<ILimSamSubdetailWa, ILimSamSubdetailWa> query, object parentId)
        //{
        //    var _id = new Guid(Convert.ToString(parentId));

        //    ILimSamSubdetailWa e = null;

        //    return base.BuildParent(query, parentId).Where(() => e.CusMaster.Id == _id);
        //}

        public override void Update(ILimSamSubdetailWa entity)
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

        public override void Delete(ILimSamSubdetailWa entity)
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
