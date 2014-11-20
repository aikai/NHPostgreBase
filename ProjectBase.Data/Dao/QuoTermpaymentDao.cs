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
    public class QuoTermpaymentDao : NHibernateDao<IQuoTermpayment>, IQuoTermpaymentDao
    {
        protected override IQueryOver<IQuoTermpayment, IQuoTermpayment> BuildId(IQueryOver<IQuoTermpayment, IQuoTermpayment> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoTermpayment, IQuoTermpayment> BuildInIds(IQueryOver<IQuoTermpayment, IQuoTermpayment> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoTermpayment, IQuoTermpayment> BuildSort(IQueryOver<IQuoTermpayment, IQuoTermpayment> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IQuoTermpayment, IQuoTermpayment> BuildParent(IQueryOver<IQuoTermpayment, IQuoTermpayment> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IQuoTermpayment e = null;

            return base.BuildParent(query, parentId).Where(() => e.QuoMaster.Id == _id);
        }

        public override void Update(IQuoTermpayment entity)
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

        public void Update(IList<IQuoTermpayment> entities, IQuoMaster entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entities) || 1 > entities.Count) return;

                Update(delegate(ISession s)
                {
                    #region Update all record in childs
                    IQuoMaster e = null;
                    IQuoTermpayment o = null;

                    var quoTermpayments = s.QueryOver<IQuoTermpayment>(() => o)
                                       .Inner.JoinQueryOver(() => o.QuoMaster, () => e)
                                       .Where(() => e.Id == entity.Id).List();

                    if (!VerifyAvailableIsNull(quoTermpayments) && quoTermpayments.Count > 0)
                    {
                        s.Clear();

                        foreach (var item in quoTermpayments)
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

                    s.Clear();

                    foreach (var item in entities)
                    {
                        IQuoTermpaymentDep p = null;

                        var quoTermpaymentDeps = s.QueryOver<IQuoTermpaymentDep>(() => p)
                                                  .Inner.JoinQueryOver(() => p.QuoTermpayment, () => o)
                                                  .Where(() => o.Id == item.Id).List();

                        if (!VerifyAvailableIsNull(quoTermpaymentDeps) && quoTermpaymentDeps.Count > 0)
                        {
                            foreach (var dep in quoTermpaymentDeps)
                            {
                                s.Delete(dep);
                            }

                            s.Flush();
                        }
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

        public override void Delete(IQuoTermpayment entity)
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

        public IList<IQuoTermpayment> SearchInvoice(DateTime? startDate, DateTime? endDate, string project, bool projectStatus, 
            string projectCode, IQuoTypeSta WorkStatus)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoTermpayment>);

                IQuoMaster e = null;
                IQuoGen g = null;
                IQuoTermpayment t = null;
                IQuoTermSta ts = null;
                IQuoTypeSta ty = null;

                //var query = s.QueryOver(() => e)
                //             .Left.JoinQueryOver(() => e.QuoGens, () => g)
                //             .Left.JoinQueryOver(() => e.QuoTermpayments, () => t)
                //             .Left.JoinQueryOver(() => t.QuoTermSta, () => ts)
                //             .Left.JoinQueryOver(() => ts.QuoTypeSta, () => ty)
                //             .Where(() => e.QuoEmploy == true)
                //             .And(() => e.QuoCoworkerMailFlag == true)
                //             .WhereRestrictionOn(() => e.QuoReceive).IsNotNull;

                var query = s.QueryOver(() => t)
                             .Left.JoinQueryOver(() => t.QuoMaster, () => e)
                             .Left.JoinQueryOver(() => e.QuoGens, () => g)
                             .Left.JoinQueryOver(() => t.QuoTermSta, () => ts)
                             .Left.JoinQueryOver(() => ts.QuoTypeSta, () => ty)
                             .Where(() => e.QuoEmploy == true)
                             //.And(() => e.QuoCoworkerMailFlag == true)
                             .WhereRestrictionOn(() => e.QuoReceive).IsNotNull;
                             //.And(() => t.CancelStatus == "0");

                if (startDate != null && startDate.HasValue)
                {
                    var date = startDate.Value.AddDays(-1);
                    query.Where(() => e.QuoDate > date);
                }

                if (endDate != null && endDate.HasValue)
                {
                    var date = endDate.Value.AddDays(1);
                    query.Where(() => e.QuoDate < date);
                }

                if (!string.IsNullOrEmpty(project))
                {
                    IQuoGen genProject = null;

                    query.Left.JoinQueryOver(() => e.QuoGens, () => genProject)
                         .WhereRestrictionOn(() => genProject.ProjName).IsLike(project, MatchMode.Anywhere);
                }

                //if (cusMaster != null)
                //{
                //    ICusMaster cus = null;

                //    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                //         .Where(() => cus.Id == cusMaster.Id);
                //}

                //if (Emp != null)
                //{
                //    IQuoCoWorker c = null;
                //    string strDept = Emp.DeptOrg;

                //    query.Left.JoinQueryOver(() => e.QuoCoWorks, () => c)
                //        //.Left.JoinQueryOver(() => c.Employee, () => hm)
                //        //.Where(() => hm.DeptOrg == strDept);
                //         .Where(() => c.Dept == strDept);
                //}

                // if Project == true mean serch by project
                // if Project == false mean serch by Subject
                #region CheckProject Status
                if (projectStatus)
                {
                    IUaeProjectManage pm = null;

                    query.Left.JoinQueryOver(() => e.ProjManage, () => pm);

                    if (!string.IsNullOrEmpty(project))
                    {
                        query.WhereRestrictionOn(() => pm.ProjEname).IsLike(project, MatchMode.Anywhere);
                    }

                    if (!string.IsNullOrEmpty(projectCode))
                    {
                        query.WhereRestrictionOn(() => pm.ProjCode).IsLike(projectCode, MatchMode.Anywhere);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(project))
                    {
                        IQuoGen genProject = null;

                        query.Left.JoinQueryOver(() => e.QuoGens, () => genProject)
                             .WhereRestrictionOn(() => genProject.ProjName).IsLike(project, MatchMode.Anywhere);
                    }
                } 
                #endregion


                if (WorkStatus != null && WorkStatus.Id != new Guid())
                {
                    query.WhereRestrictionOn(() => ty.Name == WorkStatus.Name);
                }

                return query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
                            .List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetMaxYearByDueDate()
        {
            try
            {
                int max = 0;
                var s = Session;

                if (!VerifyAvailableIsNull(s))
                {
                    IQuoTermpayment e = null;

                    var term = s.QueryOver(() => e)
                                .OrderBy(() => e.TerDueDate).Desc().Take(1)
                                .SingleOrDefault();

                    if (!VerifyAvailableIsNull(term))
                    {
                        var dueDate = term.TerDueDate;

                        if (!VerifyAvailableIsNull(dueDate) && dueDate.HasValue)
                        {
                            max = dueDate.Value.Year; 
                        }
                    }
                }

                return max;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoTermpayment> SearchInvoice(DateTime? startDate, DateTime? endDate, string project, bool projectStatus,
            string projectCode, string status)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoTermpayment>);

                IQuoMaster e = null;
                IQuoGen g = null;
                IQuoTermpayment t = null;
                IQuoTermSta ts = null;
                IQuoTypeSta ty = null;

                var query = s.QueryOver(() => t)
                             .Left.JoinQueryOver(() => t.QuoMaster, () => e)
                             .Left.JoinQueryOver(() => e.QuoGens, () => g)
                             .Left.JoinQueryOver(() => t.QuoTermSta, () => ts)
                             .Left.JoinQueryOver(() => ts.QuoTypeSta, () => ty)
                             .Where(() => e.QuoEmploy == true)
                             //.And(() => e.QuoCoworkerMailFlag == true)
                             .WhereRestrictionOn(() => e.QuoReceive).IsNotNull
                             .And(() => t.CancelStatus == "0");


                if (startDate != null && startDate.HasValue)
                {
                    var date = startDate.Value.AddDays(-1);
                    query.Where(() => e.QuoDate > date);
                }

                if (endDate != null && endDate.HasValue)
                {
                    var date = endDate.Value.AddDays(1);
                    query.Where(() => e.QuoDate < date);
                }

                if (!string.IsNullOrEmpty(project))
                {
                    IQuoGen genProject = null;

                    query.Left.JoinQueryOver(() => e.QuoGens, () => genProject)
                         .WhereRestrictionOn(() => genProject.ProjName).IsLike(project, MatchMode.Anywhere);
                }

                // if Project == true mean serch by project
                // if Project == false mean serch by Subject
                #region CheckProject Status
                if (projectStatus)
                {
                    IUaeProjectManage pm = null;

                    query.Left.JoinQueryOver(() => e.ProjManage, () => pm);

                    if (!string.IsNullOrEmpty(project))
                    {
                        query.WhereRestrictionOn(() => pm.ProjEname).IsLike(project, MatchMode.Anywhere);
                    }

                    if (!string.IsNullOrEmpty(projectCode))
                    {
                        query.WhereRestrictionOn(() => pm.ProjCode).IsLike(projectCode, MatchMode.Anywhere);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(project))
                    {
                        IQuoGen genProject = null;

                        query.Left.JoinQueryOver(() => e.QuoGens, () => genProject)
                             .WhereRestrictionOn(() => genProject.ProjName).IsLike(project, MatchMode.Anywhere);
                    }
                }
                #endregion

                if (!string.IsNullOrEmpty(status))
                {
                    query.WhereRestrictionOn(() => ty.Name).IsLike(status, MatchMode.Anywhere);
                }


                return query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
                            .List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int SummaryCloseJob()
        {
            try
            { 
                int count = 0;

                #region Use not OK
                //System.Text.StringBuilder sb = new StringBuilder();
                //sb.Append(@"select count(*) from ( ");
                //sb.Append("select b.quo_id, count(b.quo_id) from quo_termpayment b ");
                //sb.Append("left join quo_term_sta ts on ts.ter_id = b.ter_id ");
                //sb.Append("left join quo_type_sta ty on ty.tst_id = ts.tst_id ");
                //sb.Append("where ts.sta_id is not null and (ty.tst_description = 'UAF' and ty.tst_name  like '%รับเงิน%') ");
                //sb.Append("having count(b.quo_id) = (select count(a.quo_id) from quo_termpayment a where b.quo_id = a.quo_id group by a.quo_id) group by b.quo_id ");
                //sb.Append(") ");

                //var query = Session.CreateSQLQuery(sb.ToString());

                //var list = query.List();//<IQuoTermpayment>();

                //if (list.Count > 0)
                //{
                //    int.TryParse(list[0].ToString(), out count);
                //} 
                #endregion


                IQuoTermpayment t = null;
                IQuoTypeSta ty = null;
                IQuoTermSta ts = null;


                //var query = Session.QueryOver(() => t)
                //                   .Left.JoinQueryOver(() => t.QuoTermSta, () => ts)
                //                   .Left.JoinQueryOver(() => ts.QuoTypeSta, () => ty)
                //                   .Select(
                //                            Projections.Group(() => t.QuoMaster),
                //                            Projections.Count(() => t.QuoMaster)
                //                          )
                //                   .Where(() => ty.Description == "UAF")
                //                   .And(() => ty.Name.Contains("รับเงิน"));

                //ProjectionList proj = Projections.ProjectionList();
                //proj.Add(Projections.Property<IQuoMaster>(x => x.Id));
                //proj.Add(Projections.Group<IQuoMaster>(x => x.Id));
                //proj.Add(Projections.RowCount());

                //DetachedCriteria criteria = DetachedCriteria.For<IQuoMaster>();
                //criteria.SetProjection(proj);
                ////criteria.SetProjection(Projections.Property<IQuoMaster>(x => x.Id), Projections.Group<IQuoMaster>(x=>x.Id));


                var query = Session.QueryOver<IQuoTermpayment>(() => t)
                                   .Left.JoinQueryOver<IQuoTermSta>(() => t.QuoTermSta, () => ts)
                                   .Left.JoinQueryOver<IQuoTypeSta>(() => ts.QuoTypeSta, () => ty)
                                   .Where(() => ty.Description == "UAF")
                                   .WhereRestrictionOn(() => ty.Name).IsLike("รับเงิน", MatchMode.Anywhere)
                                   .Select(Projections.Property<IQuoTermpayment>(x => x.QuoMaster),
                                           Projections.Group<IQuoTermpayment>(x => x.QuoMaster));

                                   //         (Projections.Count
                                   //            (Projections.Property<IQuoTermpayment>(x => x.QuoMaster)), 5))

                count = query.RowCount();
                //var rs = query.List<object[]>();

                return count;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }


        public IList<IQuoTermpayment> GetCountTermReceiveMoney(IQuoMaster entity, string Dept, string Name, int Index)
        {
            try
            {
                int count = 0;

                IQuoTermpayment t = null;
                IQuoTermSta ts = null;
                IQuoTypeSta ty = null;
                IQuoMaster qm = null;


                var query = Session.QueryOver<IQuoTermpayment>(() => t)
                                   .Left.JoinQueryOver<IQuoTermSta>(() => t.QuoTermSta, () => ts)
                                   .Left.JoinQueryOver<IQuoTypeSta>(() => ts.QuoTypeSta, () => ty);

                if (string.IsNullOrEmpty(Dept))
                {
                    query.Where(() => ty.Group == Dept)
                         .And(() => ty.Index >= Index);
                }

                //if (string.IsNullOrEmpty(Name))
                //{
                //    query.WhereRestrictionOn(() => ty.Name).IsLike("รับเงิน", MatchMode.Anywhere)
                //         .AndRestrictionOn(()=>ty.Name.IsLike("ยกเลิก", MatchMode.Anywhere));
                //}

                if (entity != null)
                {
                    query.Left.JoinQueryOver(() => t.QuoMaster, () => qm)
                         .Where(() => qm.Id == entity.Id);
                }

                //return count;
                return query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
                            .List();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IList<IQuoTermpayment> GetTermpaymentByParent(IQuoMaster entity, string Dept)
        {
            try
            {
                IQuoTermpayment t = null;
                IQuoTermSta ts = null;
                IQuoTypeSta ty = null;
                IQuoMaster qm = null;

                IQuoTermJobLab l = null;
                IQuoTermJobLabDe ld = null;
                IQuoTermJobLabFile lf = null;

                IQuoTermJobEma ema = null;
                IQuoTermJobEmaDe emad = null;
                IQuoTermJobEmaFile emaf = null;

                IQuoTermJobEsmFile esm = null;
                

                var query = Session.QueryOver(() => t)
                                   .Left.JoinQueryOver(() => t.QuoMaster, () => qm);


                //if(Dept == "LAB")
                //{
                //    query.Left.JoinQueryOver(() => t, () => ts);     
                    
                //}
                //else if(Dept == "ESM")
                //{

                //}


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