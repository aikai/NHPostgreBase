using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class QuoTermJobEmaFilesDao : NHibernateDao<IQuoTermJobEmaFiles>, IQuoTermJobEmaFilesDao
    {
        protected override IQueryOver<IQuoTermJobEmaFiles, IQuoTermJobEmaFiles> BuildId(IQueryOver<IQuoTermJobEmaFiles, IQuoTermJobEmaFiles> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoTermJobEmaFiles, IQuoTermJobEmaFiles> BuildInIds(IQueryOver<IQuoTermJobEmaFiles, IQuoTermJobEmaFiles> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoTermJobEmaFiles, IQuoTermJobEmaFiles> BuildSort(IQueryOver<IQuoTermJobEmaFiles, IQuoTermJobEmaFiles> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IQuoTermJobEmaFiles, IQuoTermJobEmaFiles> BuildParent(IQueryOver<IQuoTermJobEmaFiles, IQuoTermJobEmaFiles> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IQuoTermJobEmaFiles e = null;

            return base.BuildParent(query, parentId).Where(() => e.QuoTermpayment.Id == _id);
        }

        public override void Update(IQuoTermJobEmaFiles entity)
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

        public override void Delete(IQuoTermJobEmaFiles entity)
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

        public void Update(IList<IQuoTermJobEmaFiles> entities, IQuoTermpayment entity)
        {
            try
            {
                Update(delegate(ISession s)
                {
                    #region QuoTermJob
                    IQuoTermpayment e = null;
                    IQuoTermJobEmaFiles o = null;

                    var termJobs = s.QueryOver<IQuoTermJobEmaFiles>(() => o)
                                       .Inner.JoinQueryOver(() => o.QuoTermpayment, () => e)
                                       .Where(() => e.Id == entity.Id).List();

                    if (!VerifyAvailableIsNull(termJobs) && termJobs.Count > 0)
                    {
                        s.Clear();

                        foreach (var item in termJobs)
                        {
                            var exist = entities.Where(x => x.Id == item.Id)
                                                .SingleOrDefault();

                            if (exist == null)
                            {
                                s.Delete(item);
                            }
                        }

                        s.Flush();
                    }
                    #endregion

                    s.Clear();

                    foreach (var item in entities)
                    {
                        s.Update(s.Merge(item));
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IList<IQuoTermJobEmaFiles> GetFileByParent(IQuoTermpayment TermpaymentEntity, IQuoMaster entity)
        {
            try
            {
                IQuoTermJobEmaFiles e = null;
                IQuoTermpayment t = null;

                var query = Session.QueryOver(() => e)
                                   .Left.JoinQueryOver(() => e.QuoTermpayment, () => t)
                                   .Where(() => t.Id == TermpaymentEntity.Id);

                return query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
                            .List();
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }
    }
}
