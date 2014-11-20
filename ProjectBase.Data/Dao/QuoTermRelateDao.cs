using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class QuoTermRelateDao : NHibernateDao<IQuoTermRelate>, IQuoTermRelateDao
    {
        protected override NHibernate.IQueryOver<IQuoTermRelate, IQuoTermRelate> BuildId(NHibernate.IQueryOver<IQuoTermRelate, IQuoTermRelate> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override NHibernate.IQueryOver<IQuoTermRelate, IQuoTermRelate> BuildInIds(NHibernate.IQueryOver<IQuoTermRelate, IQuoTermRelate> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override NHibernate.IQueryOver<IQuoTermRelate, IQuoTermRelate> BuildSort(NHibernate.IQueryOver<IQuoTermRelate, IQuoTermRelate> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IQuoTermRelate, IQuoTermRelate> BuildParent(IQueryOver<IQuoTermRelate, IQuoTermRelate> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IQuoTermRelate e = null;

            return base.BuildParent(query, parentId).Where(() => e.QuoTermpayment.Id == _id);
        }

        public override void Update(IQuoTermRelate entity)
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

        public override void Delete(IQuoTermRelate entity)
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

        public IList<IQuoTermRelate> GetByQuoTermpayment(IQuoTermpayment entity)
        {
            try
            {
                IList<IQuoTermRelate> entities = null;

                if (!VerifyAvailableIsNull(entity))
                {
                    var s = Session;

                    if (!VerifyAvailableIsNull(s))
                    {
                        IQuoTermRelate e = null;
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

        public IList<IQuoTermRelate> GetByQuoCombineDe(IQuoCombineDe entity)
        {
            try
            {
                IList<IQuoTermRelate> entities = null;

                if (!VerifyAvailableIsNull(entity))
                {
                    var s = Session;

                    if (!VerifyAvailableIsNull(s))
                    {
                        IQuoTermRelate e = null;
                        IQuoCombineDe o = null;

                        entities = s.QueryOver(() => e)
                                    .Inner.JoinQueryOver(() => e.QuoCombineDe, () => o)
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
    }
}
