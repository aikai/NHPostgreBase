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
    public class QuoGenDao : NHibernateDao<IQuoGen>, IQuoGenDao
    {
        protected override IQueryOver<IQuoGen, IQuoGen> BuildId(IQueryOver<IQuoGen, IQuoGen> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoGen, IQuoGen> BuildInIds(IQueryOver<IQuoGen, IQuoGen> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoGen, IQuoGen> BuildSort(IQueryOver<IQuoGen, IQuoGen> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IQuoGen, IQuoGen> BuildParent(IQueryOver<IQuoGen, IQuoGen> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IQuoGen e = null;

            return base.BuildParent(query, parentId).Where(() => e.QuoMaster.Id == _id);
        }

        public override void Update(IQuoGen entity)
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

        public override void Delete(IQuoGen entity)
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

        public int GetMaxByGenCode()
        {
            try
            {
                int maximun = 0;
                var s = Session;

                if (!VerifyAvailableIsNull(s))
                {
                    var result = s.CreateCriteria(typeof(IQuoGen))
                                  .SetProjection(Projections.Max<IQuoGen>(x => x.GenCode))
                                  .UniqueResult();

                    if (!VerifyAvailableIsNull(result))
                    {
                        maximun = Convert.ToInt32(result); 
                    }

                    //IQuoGen e = null;

                    //var result = s.QueryOver(() => e)
                    //              .Select(Projections.ProjectionList()
                    //                   .Add(Projections.Max(() => e.GenCode)))
                    //              .List<int?>().First();

                    //var maximun = VerifyAvailableIsNull(result) || !result.HasValue ? 0 : result.Value;
                }

                return maximun;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoGen> GetQuoGenByParent(IQuoMaster entity)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoGen>);

                IList<IQuoGen> results = null;
                IQuoGen e = null;

                var query = s.QueryOver(() => e);

                if (entity != null)
                {
                    IQuoMaster parent = null;

                    query.Inner.JoinQueryOver(() => e.QuoMaster, () => parent)
                         .Where(() => parent.Id == entity.Id);

                    results = query.List();
                }

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQuoGen GetQuoGenUsedByParent(IQuoMaster entity)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IQuoGen);

                IList<IQuoGen> results = null;
                IQuoGen e = null;

                var query = s.QueryOver(() => e);

                if (entity != null)
                {
                    IQuoMaster parent = null;

                    query.Inner.JoinQueryOver(() => e.QuoMaster, () => parent)
                         .Where(() => parent.Id == entity.Id)
                         .Select(Projections.ProjectionList()
                            .Add(Projections.Max(() => e.GenYear))
                            .Add(Projections.Max(() => e.GenCode))
                            .Add(Projections.Max(() => e.GenRevise)));

                    results = query.List();
                }

                return results == null || 1 > results.Count ? null : results.First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoGen> SearchQuataionGenNo(IQuoGen entity, DateTime dStart, DateTime dEnd)
        {
            try
            {
                IList<IQuoGen> IL_rs = new List<IQuoGen>();
                var s = Session;

                if (!VerifyAvailableIsNull(s))
                {
                    #region Wait For Re Implement
                    //DetachedCriteria dcMaxYear = DetachedCriteria.For<ProjectBase.Data.Model.Entities.QuoGen>();
                    //ProjectionList projYear = Projections.ProjectionList();
                    //projYear.Add(Projections.Max<IQuoGen>(x => x.GenYear));
                    //projYear.Add(Projections.GroupProperty("GenYear"));
                    //dcMaxYear.SetProjection(projYear);


                    //DetachedCriteria dcMaxCode = DetachedCriteria.For<ProjectBase.Data.Model.Entities.QuoGen>();
                    //ProjectionList projCode = Projections.ProjectionList();
                    //projCode.Add(Projections.Max<IQuoGen>(x => x.GenCode));
                    //projCode.Add(Projections.GroupProperty("GenCode"));
                    //dcMaxCode.SetProjection(projCode);


                    //DetachedCriteria dcMaxRevise = DetachedCriteria.For<ProjectBase.Data.Model.Entities.QuoGen>();
                    //ProjectionList projRevise = Projections.ProjectionList();
                    //projRevise.Add(Projections.Max<IQuoGen>(x => x.GenRevise));
                    //projRevise.Add(Projections.GroupProperty("GenRevise"));
                    //dcMaxRevise.SetProjection(projRevise);


                    //IL_rs = s.CreateCriteria(typeof(ProjectBase.Data.Model.Entities.QuoGen))
                    //                .Add(Subqueries.PropertyEq("GenYear", dcMaxYear))
                    //                .Add(Subqueries.PropertyEq("GenCode", dcMaxCode))
                    //                .Add(Subqueries.PropertyEq("GenRevise", dcMaxRevise))
                    //                .List<IQuoGen>();


                    //string sql = "select a.gen_dep, a.gen_code, a.gen_revise, a.gen_year, a.proj_name, a.est_cost, a.gen_date, a.rowid from ";
                    //sql = sql + "quo_gen a;";
                    //ISQLQuery query = s.CreateSQLQuery(sql);
                    //IL_rs = query.List();

                    //var query = s.CreateSQLQuery(@"select {prov.*} from Province prov");
                    //query.AddEntity("prov", typeof(IProvince));
                    //var rs = query.List();
                    #endregion


                    System.Text.StringBuilder sb = new StringBuilder();
                    sb.Append(@"select {q.*} from quo_gen q ");
                    sb.Append("where (q.gen_code, q.gen_revise, q.gen_year) IN ");
                    sb.Append("( ");
                    sb.Append("select  max(a.gen_code) as genCode, max(a.gen_revise) as genRevise,max(a.gen_year) as genYear ");
                    sb.Append("from quo_gen a ");
                    sb.Append("group by a.gen_dep, a.gen_code, a.gen_year ) ");

                    #region Add Parameter
                    if (entity != null)
                    {
                        if (!string.IsNullOrEmpty(entity.GenDep))
                        {
                            sb.Append("AND (q.GEN_DEP = :GenDep ) ");
                        }


                        if (entity.GenCode > 0)
                        {
                            sb.Append("AND (q.GEN_CODE = :GenCode )");
                        }


                        if (entity.GenYear > 0)
                        {
                            sb.Append("AND (q.Gen = :GenYear ) ");
                        }


                        if (!string.IsNullOrEmpty(entity.ProjName))
                        {
                            sb.Append("AND (q.PROJ_NAME = :ProjName ) ");
                        }
                    } 
                    #endregion

                    sb.Append(" order by q.GEN_YEAR DESC, q.GEN_CODE DESC, q.GEN_REVISE DESC ");

                    var query = s.CreateSQLQuery(sb.ToString());
                    query.AddEntity("q", typeof(ProjectBase.Data.Model.QuoGen));


                    #region Set Parameter
                    if (entity != null)
                    {
                        if (!string.IsNullOrEmpty(entity.GenDep))
                        {
                            query.SetParameter("GenDep", entity.GenDep);
                        }

                        if (entity.GenCode > 0)
                        {
                            query.SetParameter("GenCode", entity.GenCode);
                        }


                        if (entity.GenYear > 0)
                        {
                            query.SetParameter("GenYear", entity.GenYear);
                        }


                        if (!string.IsNullOrEmpty(entity.ProjName))
                        {
                            query.SetParameter("PROJ_NAME", entity.ProjName);
                        }
                    } 
                    #endregion

                    IL_rs = query.List<IQuoGen>();
                }

                return IL_rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
