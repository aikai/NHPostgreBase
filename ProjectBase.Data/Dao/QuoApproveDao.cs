using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class QuoApproveDao : NHibernateDao<IQuoApprove>, IQuoApproveDao
    {
        protected override IQueryOver<IQuoApprove, IQuoApprove> BuildId(IQueryOver<IQuoApprove, IQuoApprove> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoApprove, IQuoApprove> BuildInIds(IQueryOver<IQuoApprove, IQuoApprove> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoApprove, IQuoApprove> BuildSort(IQueryOver<IQuoApprove, IQuoApprove> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IQuoApprove entity)
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

        public override void Delete(IQuoApprove entity)
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
