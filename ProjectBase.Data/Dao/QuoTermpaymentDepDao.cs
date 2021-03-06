﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class QuoTermpaymentDepDao : NHibernateDao<IQuoTermpaymentDep>, IQuoTermpaymentDepDao
    {
        protected override IQueryOver<IQuoTermpaymentDep, IQuoTermpaymentDep> BuildId(IQueryOver<IQuoTermpaymentDep, IQuoTermpaymentDep> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoTermpaymentDep, IQuoTermpaymentDep> BuildInIds(IQueryOver<IQuoTermpaymentDep, IQuoTermpaymentDep> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoTermpaymentDep, IQuoTermpaymentDep> BuildSort(IQueryOver<IQuoTermpaymentDep, IQuoTermpaymentDep> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IQuoTermpaymentDep entity)
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

        public override void Delete(IQuoTermpaymentDep entity)
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
