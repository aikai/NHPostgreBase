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
    public class QuoRequestDao : NHibernateDao<IQuoRequest>, IQuoRequestDao
    {
        protected override IQueryOver<IQuoRequest, IQuoRequest> BuildId(IQueryOver<IQuoRequest, IQuoRequest> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoRequest, IQuoRequest> BuildInIds(IQueryOver<IQuoRequest, IQuoRequest> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoRequest, IQuoRequest> BuildSort(IQueryOver<IQuoRequest, IQuoRequest> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IQuoRequest, IQuoRequest> BuildParent(IQueryOver<IQuoRequest, IQuoRequest> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IQuoRequest e = null;

            return base.BuildParent(query, parentId).Where(() => e.QuoMaster.Id == _id);
        }

        public override void Update(IQuoRequest entity)
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

        public override void Delete(IQuoRequest entity)
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

        public IList<IQuoRequest> Search(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool isDelete)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoRequest>);

                IQuoRequest e = null;

                var query = s.QueryOver(() => e)
                             .Where(() => e.IsDelete == isDelete)
                             .AndRestrictionOn(() => e.QuoMaster).IsNotNull;

                if (startDate != null && startDate.HasValue)
                {
                    var date = startDate.Value.AddDays(-1);
                    query.And(() => e.ReqDate > date);
                }

                if (endDate != null && endDate.HasValue)
                {
                    var date = endDate.Value.AddDays(1);
                    query.And(() => e.ReqDate < date);
                }

                if (!string.IsNullOrEmpty(project))
                {
                    IQuoMaster masterGen = null;
                    IQuoGen genProject = null;

                    query.Left.JoinQueryOver(() => e.QuoMaster, () => masterGen)
                         .Left.JoinQueryOver(() => masterGen.QuoGens, () => genProject)
                         .AndRestrictionOn(() => genProject.ProjName).IsLike(project, MatchMode.Anywhere);
                }

                if (cusMaster != null)
                {
                    IQuoMaster masterCus = null;
                    ICusMaster cus = null;

                    query.Left.JoinQueryOver(() => e.QuoMaster, () => masterCus)
                         .Left.JoinQueryOver(() => masterCus.CusMaster, () => cus)
                         .And(() => cus.Id == cusMaster.Id);
                }


                

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
