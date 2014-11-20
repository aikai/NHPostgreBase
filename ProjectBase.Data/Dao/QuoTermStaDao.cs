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
    public class QuoTermStaDao : NHibernateDao<IQuoTermSta>, IQuoTermStaDao
    {
        protected override IQueryOver<IQuoTermSta, IQuoTermSta> BuildId(IQueryOver<IQuoTermSta, IQuoTermSta> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoTermSta, IQuoTermSta> BuildInIds(IQueryOver<IQuoTermSta, IQuoTermSta> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoTermSta, IQuoTermSta> BuildSort(IQueryOver<IQuoTermSta, IQuoTermSta> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IQuoTermSta, IQuoTermSta> BuildParent(IQueryOver<IQuoTermSta, IQuoTermSta> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IQuoTermSta e = null;

            return base.BuildParent(query, parentId).Where(() => e.QuoTermpayment.Id == _id);
        }

        public override void Update(IQuoTermSta entity)
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

        public override void Delete(IQuoTermSta entity)
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

        public IList<IQuoTermSta> GetByQuoTermpayment(IQuoTermpayment entity)
        {
            try
            {
                IList<IQuoTermSta> entities = null;

                if (!VerifyAvailableIsNull(entity))
                {
                    var s = Session;

                    if (!VerifyAvailableIsNull(s))
                    {
                        IQuoTermSta e = null;
                        IQuoTermpayment o = null;

                        entities = s.QueryOver(() => e)
                                    .Inner.JoinQueryOver(() => e.QuoTermpayment, () => o)
                                    .Where(() => o.Id == entity.Id)
                                    .List();
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoTermSta> ExportToExcel(string typeName)
        {
            try
            {
                IList<IQuoTermSta> entities = null;

                if (!string.IsNullOrEmpty(typeName))
                {
                    var s = Session;

                    if (!VerifyAvailableIsNull(s))
                    {
                        IQuoTermSta e = null;
                        IQuoTypeSta type = null;

                        entities = s.QueryOver(() => e)
                                    .Inner.JoinQueryOver(() => e.QuoTypeSta, () => type)
                                    .WhereRestrictionOn(() => type.Name).IsLike(typeName, MatchMode.Exact)
                                    .List();
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoTermSta> ExportToExcel(DateTime? startDate, DateTime? endDate, string typeName)
        {
            try
            {
                IList<IQuoTermSta> entities = null;

                if ((startDate != null && startDate.HasValue)
                        && (endDate != null && endDate.HasValue) && !string.IsNullOrEmpty(typeName))
                {
                    var s = Session;

                    if (!VerifyAvailableIsNull(s))
                    {
                        IQuoTermSta e = null;
                        IQuoTypeSta type = null;

                        var query = s.QueryOver(() => e)
                                     .Inner.JoinQueryOver(() => e.QuoTypeSta, () => type);

                        var first = startDate.Value.AddDays(-1);
                        var end = endDate.Value.AddDays(1);

                        entities = query.Where(() => e.UpdateDate > first)
                                        .And(() => e.UpdateDate < end)
                                        .AndRestrictionOn(() => type.Name).IsLike(typeName, MatchMode.Exact)
                                        .List();
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
