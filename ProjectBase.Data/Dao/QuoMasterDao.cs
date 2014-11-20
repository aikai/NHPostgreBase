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
    public class QuoMasterDao : NHibernateDao<IQuoMaster>, IQuoMasterDao
    {
        protected override IQueryOver<IQuoMaster, IQuoMaster> BuildId(IQueryOver<IQuoMaster, IQuoMaster> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoMaster, IQuoMaster> BuildInIds(IQueryOver<IQuoMaster, IQuoMaster> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoMaster, IQuoMaster> BuildSort(IQueryOver<IQuoMaster, IQuoMaster> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override object Save(IQuoMaster entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return null;

                object id = null;
                Update(delegate(ISession s)
                {
                    s.Clear();
                    id = s.Save(entity);
                    s.Flush();

                    #region Update all record in childs
                    s.Clear();

                    foreach (var item in entity.QuoGens)
                    {
                        var quoMaster = item.QuoMaster;
                        quoMaster.Id = new Guid(id.ToString());

                        s.Save(item);
                    }
                    #endregion
                });
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(IQuoMaster entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return;

                Update(delegate(ISession s)
                {
                    #region Update all record in childs
                    IQuoMaster e = null;
                    IQuoDetail o = null;

                    var quoDetails = s.QueryOver<IQuoDetail>(() => o)
                                      .Left.JoinQueryOver(() => o.QuoMaster, () => e)
                                      .Where(() => e.Id == entity.Id).List();

                    if (!VerifyAvailableIsNull(quoDetails) && quoDetails.Count > 0)
                    {
                        s.Clear();

                        foreach (var item in quoDetails)
                        {
                            var exist = entity.QuoDetails.Where(x => x.Id == item.Id)
                                              .SingleOrDefault();

                            if (exist == null)
                            {
                                s.Delete(item);
                            }
                        }

                        s.Flush();
                    }

                    IQuoInCusCon c = null;

                    var quoInCusCons = s.QueryOver<IQuoInCusCon>(() => c)
                                        .Left.JoinQueryOver(() => c.QuoMaster, () => e)
                                        .Where(() => e.Id == entity.Id).List();

                    if (!VerifyAvailableIsNull(quoInCusCons) && quoInCusCons.Count > 0)
                    {
                        s.Clear();

                        foreach (var item in quoInCusCons)
                        {
                            var exist = entity.QuoInCusCons.Where(x => x.Id == item.Id)
                                              .SingleOrDefault();

                            if (exist == null)
                            {
                                s.Delete(item);
                            }
                        }

                        s.Flush();
                    }

                    IQuoRemarkLog r = null;

                    var quoRemarkLogs = s.QueryOver<IQuoRemarkLog>(() => r)
                                        .Left.JoinQueryOver(() => r.QuoMaster, () => e)
                                        .Where(() => e.Id == entity.Id).List();

                    if (!VerifyAvailableIsNull(quoRemarkLogs) && quoRemarkLogs.Count > 0)
                    {
                        s.Clear();

                        foreach (var item in quoRemarkLogs)
                        {
                            var exist = entity.QuoRemarkLogs.Where(x => x.Id == item.Id)
                                              .SingleOrDefault();

                            if (exist == null)
                            {
                                s.Delete(item);
                            }
                        }

                        s.Flush();
                    }

                    IQuoPoCode po = null;

                    var quoPoCodes = s.QueryOver<IQuoPoCode>(() => po)
                                      .Left.JoinQueryOver(() => po.QuoMaster, () => e)
                                      .Where(() => e.Id == entity.Id).List();

                    if (!VerifyAvailableIsNull(quoPoCodes) && quoPoCodes.Count > 0)
                    {
                        s.Clear();

                        foreach (var item in quoPoCodes)
                        {
                            var exist = entity.QuoPoCodes.Where(x => x.Id == item.Id)
                                              .SingleOrDefault();

                            if (exist == null)
                            {
                                s.Delete(item);
                            }
                        }

                        s.Flush();
                    }

                    var quoGens = entity.QuoGens;

                    if (!VerifyAvailableIsNull(quoGens) && quoGens.Count > 0)
                    {
                        s.Clear();

                        var quoGen = quoGens.First();
                        IQuoGen g = null;

                        var exist = s.QueryOver<IQuoGen>(() => g)
                                     .Where(() => g.Id == quoGen.Id)
                                     .SingleOrDefault();

                        if (exist != null)
                        {
                            exist.ProjName = quoGen.ProjName;
                            exist.GenDep = quoGen.GenDep;

                            s.Update(exist);
                        }

                        s.Flush();
                    }
                    #endregion

                    s.Clear();
                    s.Update(s.Merge(entity));
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateMasterOnly(IQuoMaster entity)
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

        public override void Delete(IQuoMaster entity)
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

        public IList<IQuoMaster> GetByUaeProjectManage(IUaeProjectManage projManage)
        {
            try
            {
                IList<IQuoMaster> quoMasters = null;

                var s = Session;

                if (!VerifyAvailableIsNull(s))
                {
                    IQuoMaster e = null;

                    var query = s.QueryOver(() => e);

                    if (projManage != null)
                    {
                        IUaeProjectManage proj = null;

                        query.Inner.JoinQueryOver(() => e.ProjManage, () => proj)
                             .Where(() => proj.Id == projManage.Id);

                        quoMasters = query.List();
                    }
                }

                return quoMasters;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> GetByCusMaster(ICusMaster cusMaster)
        {
            try
            {
                IList<IQuoMaster> quoMasters = null;

                var s = Session;

                if (!VerifyAvailableIsNull(s))
                {
                    IQuoMaster e = null;

                    var query = s.QueryOver(() => e);

                    if (cusMaster != null)
                    {
                        ICusMaster cus = null;

                        query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                             .Where(() => cus.Id == cusMaster.Id);

                        quoMasters = query.List();
                    }
                }

                return quoMasters;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> GetOnlyHaveTerm(DateTime? startDate, DateTime? endDate)
        {
            IList<IQuoMaster> entities = null;

            try
            {
                var s = Session;

                if (!VerifyAvailableIsNull(s))
                {
                    IQuoMaster e = null;
                    IQuoTermpayment term = null;

                    var query = s.QueryOver(() => e)
                                 .Inner.JoinQueryOver(() => e.QuoTermpayments, () => term)
                                 .Where(() => e.QuoEmploy == true);

                    if (startDate != null && startDate.HasValue)
                    {
                        var start = startDate.Value.AddDays(-1);
                        query.Where(() => e.QuoDate > start);

                        if (endDate != null && endDate.HasValue)
                        {
                            var end = endDate.Value.AddDays(1);
                            query.Where(() => e.QuoDate < end);

                            entities = query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
                                            .List();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entities;
        }

        public IList<IQuoMaster> Search(DateTime? startDate, DateTime? endDate, bool employ)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e)
                             .Where(() => e.QuoEmploy == employ);

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

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> Search(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e);

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

                if (cusMaster != null)
                {
                    ICusMaster cus = null;

                    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                         .Where(() => cus.Id == cusMaster.Id);
                }

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> Search(DateTime? startDate, DateTime? endDate, string project, 
            ICusMaster cusMaster, bool employ, bool term)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e)
                             .Where(() => e.QuoEmploy == employ)
                             .And(() => e.QuoTermFlag == term);

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

                if (cusMaster != null)
                {
                    ICusMaster cus = null;

                    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                         .Where(() => cus.Id == cusMaster.Id);
                }

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> Search(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, bool term, bool mail)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e)
                             .Where(() => e.QuoEmploy == employ)
                             .And(() => e.QuoTermFlag == term);
                             //.And(() => e.QuoCoworkerMailFlag == mail);

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

                if (cusMaster != null)
                {
                    ICusMaster cus = null;

                    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                         .Where(() => cus.Id == cusMaster.Id);
                }

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> SearchByWorkerMail(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, bool mail, IHrmEmployee Emp)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e)
                             .Where(() => e.QuoEmploy == employ);
                             //.And(() => e.QuoCoworkerMailFlag == mail);

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

                if (cusMaster != null)
                {
                    ICusMaster cus = null;

                    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                         .Where(() => cus.Id == cusMaster.Id);
                }

                if (Emp != null)
                {
                    IQuoCoWorker c = null;
                    //string strDept = Emp.DeptOrg.Substr(0, 3);
                    string strDept = string.Empty;
                    
                    char[] arr = Emp.DeptOrg.ToCharArray();
                    if (arr.Length > 0)
                    {
                        if (arr.Length == 3 || Emp.Id.Equals("0087"))
                        {
                            strDept = string.Format("{0}{1}{2}", arr[0], arr[1], arr[2]);
                        }
                        else
                        {
                            strDept = string.Format("{0}{1}{2}{3}", arr[0], arr[1], arr[2], arr[3]);
                        }
                    }

                    query.Left.JoinQueryOver(() => e.QuoCoWorks, () => c)
                        .WhereRestrictionOn(() => c.Dept).IsLike(strDept, MatchMode.Anywhere);
                }

                return query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
                            .List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> SearchByPoCode(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, string poCode)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e)
                             .Where(() => e.QuoEmploy == employ);

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

                if (cusMaster != null)
                {
                    ICusMaster cus = null;

                    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                         .Where(() => cus.Id == cusMaster.Id);
                }

                if (!string.IsNullOrEmpty(poCode))
                {
                    IQuoPoCode po = null;

                    query.Left.JoinQueryOver(() => e.QuoPoCodes, () => po)
                         .WhereRestrictionOn(() => po.PoCode).IsLike(poCode, MatchMode.Anywhere);
                }

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> SearchByPoCode(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, bool term, string poCode)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e)
                             .Where(() => e.QuoEmploy == employ)
                             .And(() => e.QuoTermFlag == term);

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

                if (cusMaster != null)
                {
                    ICusMaster cus = null;

                    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                         .Where(() => cus.Id == cusMaster.Id);
                }

                if (!string.IsNullOrEmpty(poCode))
                {
                    IQuoPoCode po = null;

                    query.Left.JoinQueryOver(() => e.QuoPoCodes, () => po)
                         .WhereRestrictionOn(() => po.PoCode).IsLike(poCode, MatchMode.Anywhere);
                }

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> SearchByProposed(DateTime? startDate, DateTime? endDate, bool? employ)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e);

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

                if (employ != null && employ.HasValue)
                {
                    query.Where(() => e.QuoEmploy == employ);
                }

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> SearchByProposed(DateTime? startDate, DateTime? endDate, bool? employ, string vat)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e);

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

                if (employ != null && employ.HasValue)
                {
                    query.Where(() => e.QuoEmploy == employ);
                }

                if (!string.IsNullOrEmpty(vat))
                {
                    if (vat.Equals("0"))
                    {
                        query.Where(() => 1 > e.QuoVat);
                    }
                    else
                    {
                        query.Where(() => e.QuoVat > 0);
                    }
                }

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> SearchByTerm(DateTime? startDate, DateTime? endDate, bool employ)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;
                IQuoTermpayment term = null;

                var query = s.QueryOver(() => e)
                             .Inner.JoinQueryOver(() => e.QuoTermpayments, () => term)
                             .Where(() => e.QuoEmploy == employ);

                if (startDate != null && startDate.HasValue)
                {
                    var date = startDate.Value.AddDays(-1);
                    query.Where(() => term.TerDueDate > date);
                }

                if (endDate != null && endDate.HasValue)
                {
                    var date = endDate.Value.AddDays(1);
                    query.Where(() => term.TerDueDate < date);
                }

                return query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
                            .List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SummaryStatusQuotation(string EmpId)
        {
            try
            {
                string summaryResult = string.Empty;
                int rsWaitReceiveAll = 0;
                int rsWaitReceiveLab = 0;
                int rsWaitReceiveEma = 0;
                int rsWaitReceiveEsm = 0;
                int rsInProcess = 0;
                int rsCloseJob = 0;
                var rsSumAll = SummaryCountQuatation(null);
                var rsWaitSend = SummaryQuoWaitSend(null);

                rsWaitReceiveLab = SummaryQuoWaitReceive("LAB");
                rsWaitReceiveEma = SummaryQuoWaitReceive("EMA");
                rsWaitReceiveEsm = SummaryQuoWaitReceive("ESM");
                rsWaitReceiveAll = SummaryQuoWaitReceive(null);
                rsCloseJob = SummaryQuoCloseJob(null);


                HrmEmployeeDao hrm = new HrmEmployeeDao();
                var Emp = hrm.GetById(EmpId);
                string strDept = string.Empty;

                if (Emp.DeptOrg.ToString().Length > 3)
                {
                    strDept = Emp.DeptOrg.ToString().Substring(0, 3);
                }
                else
                {
                    strDept = Emp.DeptOrg;
                }

                var appDao = ProjectBase.Data.DaoFactory.Instance.GetAppControlDao();
                var result = appDao.Search(Emp);

                if (result.AppRole != null && !string.IsNullOrEmpty(result.AppRole.EnglishName))
                {
                    if (result.AppRole.EnglishName == "Administrator")
                    {
                        rsInProcess = SummaryQuoInProcess(null);
                    }
                    else
                    {
                        //if (strDept == "LAB" || strDept == "EMA" || strDept == "ESM")
                        {
                            rsInProcess = SummaryQuoInProcess(strDept);
                        }
                    }
                }
                summaryResult = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", rsSumAll, rsWaitSend, rsWaitReceiveAll,
                rsWaitReceiveLab, rsWaitReceiveEma, rsWaitReceiveEsm, rsInProcess, rsCloseJob);
                

                return summaryResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SummaryQuoWaitSend(string EmpId)
        {
            try
            {
                int resultCount = 0;

                var s = Session;
                IQuoMaster q = null;
                bool bEmploy = true;
                bool bSendCoWorkMail = false;
                IQuoCoWorker c = null;
                IQuoReceive r = null;


                var Query = s.QueryOver(() => q)
                             .Left.JoinQueryOver(() => q.QuoReceive, () => r)
                             .Left.JoinQueryOver(() => q.QuoCoWorks, () => c)
                             .WhereRestrictionOn(() => r.Id).IsNull
                             .AndRestrictionOn(() => c.Id).IsNull
                             .And(() => q.QuoEmploy == bEmploy);


                if (!string.IsNullOrEmpty(EmpId))
                {
                    Query.Where(() => q.CreateBy == EmpId);
                }

                var rsQuery = Query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
                                   .List<IQuoMaster>();

                if (rsQuery.Count() > 0)
                {
                    resultCount = rsQuery.Count();
                }

                return resultCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SummaryQuoWaitReceive(string Dept)
        {
            try
            {
                int resultCount = 0;

                var s = Session;
                IQuoMaster q = null;
                bool bEmploy = true;
                bool bSendCoWorkMail = true;
                IQuoCoWorker c = null;
                IQuoReceive r = null;

                var Query = s.QueryOver(() => q)
                             .Left.JoinQueryOver(() => q.QuoReceive, () => r)
                             .Left.JoinQueryOver(() => q.QuoCoWorks, () => c)
                             .WhereRestrictionOn(() => r.Id).IsNull
                             .AndRestrictionOn(() => c.Id).IsNotNull
                             .And(() => q.QuoEmploy == bEmploy);


                if (!string.IsNullOrEmpty(Dept))
                {
                    //Query.Left.JoinQueryOver(() => q.QuoCoWorks, () => c)
                         Query.WhereRestrictionOn(() => c.Dept).IsLike(Dept, MatchMode.Anywhere);
                }

                var rsQuery = Query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
                                   .List<IQuoMaster>();

                if (rsQuery.Count() > 0)
                {
                    resultCount = rsQuery.Count();//.Where(x => x.QuoReceive == null &&
                                                     //x.QuoCoWorks != null).Count();
                }

                return resultCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SummaryQuoInProcess(string Dept)
        {
            try
            {
                int resultCount = 0;

                var s = Session;
                IQuoMaster q = null;
                bool bEmploy = true;
                //bool bSendCoWorkMail = true;
                IQuoCoWorker c = null;
                IQuoTermpayment tm = null;
                IQuoTermSta ts = null;
                IQuoTypeSta ty = null;

                var Query = s.QueryOver(() => q)
                              .Where(() => q.QuoEmploy == bEmploy)
                              //.And(() => q.QuoCoworkerMailFlag == bSendCoWorkMail)
                              .And(() => q.QuoReceive != null);

                if (!string.IsNullOrEmpty(Dept))
                {
                    //Query.Where(() => q.CreateBy == EmpId);
                    Query.Left.JoinQueryOver(() => q.QuoCoWorks, () => c)
                        .WhereRestrictionOn(() => c.Dept).IsLike(Dept);
                }


                var rsQuery = Query.Where(() => q.MoneyFlag == "0").List<IQuoMaster>();

                if (rsQuery.Count() > 0)
                {
                    resultCount = rsQuery.Where(x => x.QuoReceive != null).Count();
                }

                return resultCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SummaryStatusQuotation()
        {
            try
            {
                string summaryResult = string.Empty;
                var rsSumAll = SummaryCountQuatation(null);
                var rsWaitSend = SummaryQuoWaitSend(null);

                var rsWaitReceive = SummaryQuoWaitReceive(null);
                var rsInProcess = SummaryQuoInProcess(null);
                //var rsCloseJob = null;

                summaryResult = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", rsSumAll, rsWaitSend, rsWaitReceive, rsInProcess, 0 , 0, 0);

                return summaryResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> Search(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool isDelete, IHrmEmployee Emp)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster masterGen = null;
                IQuoRequest e = null;

                var query = s.QueryOver(() => masterGen)
                             .Left.JoinQueryOver(() => masterGen.QuoRequests, () => e)
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
                    IQuoGen genProject = null;

                    //query.Left.JoinQueryOver(() => e.QuoMaster, () => masterGen)
                    query.Left.JoinQueryOver(() => masterGen.QuoGens, () => genProject)
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

                if (Emp != null)
                {
                    IQuoCoWorker c = null;
                    //IHrmEmployee hm = null;
                    string strDept = Emp.DeptOrg;

                    query.Left.JoinQueryOver(() => masterGen.QuoCoWorks, () => c)
                        //.Left.JoinQueryOver(() => c.Employee, () => hm)
                        //.Where(() => hm.DeptOrg == strDept);
                         .Where(() => c.Dept == strDept);
                }


                return query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
                            .List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> Search(DateTime? startDate, DateTime? endDate, string project, 
            ICusMaster cusMaster, bool Project, string ProjectCode)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e);

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
                

                // if Project == true mean serch by project
                // if Project == false mean serch by Subject
                if (Project)
                {
                    IUaeProjectManage pm = null;

                    query.Left.JoinQueryOver(() => e.ProjManage, () => pm);

                    if (!string.IsNullOrEmpty(project))
                    {
                        query.WhereRestrictionOn(() => pm.ProjEname).IsLike(project, MatchMode.Anywhere);
                    }

                    if (!string.IsNullOrEmpty(ProjectCode))
                    {
                        query.WhereRestrictionOn(() => pm.ProjCode).IsLike(ProjectCode, MatchMode.Anywhere);
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


                if (cusMaster != null)
                {
                    ICusMaster cus = null;

                    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                         .Where(() => cus.Id == cusMaster.Id);
                }

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public IList<IQuoMaster> SearchByWorkerMail(DateTime? startDate, DateTime? endDate, string project, 
            ICusMaster cusMaster, bool employ, IHrmEmployee Emp, 
            bool projectStatus, string projectCode, IQuoTypeSta WorkStatus)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e)
                             .Where(() => e.QuoEmploy == employ);
                             //.And(() => e.QuoCoworkerMailFlag == mail);

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

                // if Project == true mean serch by project
                // if Project == false mean serch by Subject
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

                if (cusMaster != null)
                {
                    ICusMaster cus = null;

                    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                         .Where(() => cus.Id == cusMaster.Id);
                }

                if (Emp != null)
                {
                    IQuoCoWorker c = null;
                    string strDept = string.Empty;//= Emp.DeptOrg.Substr(0,3);
                    char[] arr = Emp.DeptOrg.ToCharArray();
                    strDept = string.Format("{0}{1}{2}", arr[0], arr[1], arr[2]);

                    query.Left.JoinQueryOver(() => e.QuoCoWorks, () => c)
                        //.Where(() => c.Dept == strDept);
                         .WhereRestrictionOn(() => c.Dept).IsLike(strDept, MatchMode.Anywhere);
                }

                if (WorkStatus!=null && WorkStatus.Index > 0)
                {
                    if (WorkStatus.Index == 1)
                    {
                        //IQuoReceive r = null;
                        //query//.Left.JoinQueryOver(() => e.QuoReceive, () => r)
                        //     .WhereRestrictionOn(() => e.QuoReceive).IsNotNull;
                        query.Where(() => e.QuoReceive == null);
                    }
                    else if (WorkStatus.Index == 2)
                    {
                    }
                    else if (WorkStatus.Index == 5)
                    {
                        IQuoReceive r = null;
                        IQuoTermSta ts = null;
                        IQuoTermpayment tm = null;
                        IQuoTypeSta ty = null;

                        query.WhereRestrictionOn(() => e.QuoReceive).IsNotNull
                             .Left.JoinQueryOver(() => e.QuoTermpayments, () => tm)
                             .Left.JoinQueryOver(() => tm.QuoTermSta, () => ts)
                             .Left.JoinQueryOver(() => ts.QuoTypeSta, () => ty)
                             .Where(() => ty.Id == WorkStatus.Id);
                    }
                        // Wait UAF Close Invoice
                    else if (WorkStatus.Index == 7)
                    {
                        //IQuoReceive r = null;
                        //IQuoTermSta ts = null;
                        //IQuoTermpayment tm = null;
                        //IQuoTypeSta ty = null;

                        //query.WhereRestrictionOn(() => e.QuoReceive).IsNotNull
                        //     .Left.JoinQueryOver(() => e.QuoTermpayments, () => tm)
                        //     .Left.JoinQueryOver(() => tm.QuoTermSta, () => ts)
                        //     .Left.JoinQueryOver(() => ts.QuoTypeSta, () => ty)
                        //     .Where(() => ty.Description.IsLike("UAF"));
                    }
                    else if (WorkStatus.Index == 8)
                    {
                        IQuoTermSta ts = null;
                        IQuoTermpayment tm = null;
                        IQuoTypeSta ty = null;

                        query.WhereRestrictionOn(() => e.QuoReceive).IsNotNull
                             .Left.JoinQueryOver(() => e.QuoTermpayments, () => tm)
                             .Left.JoinQueryOver(() => tm.QuoTermSta, () => ts)
                             .Left.JoinQueryOver(() => ts.QuoTypeSta, () => ty)
                             .Where(() => ty.Id == WorkStatus.Id);
                    }
                }

                return query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
                            .List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> SearchByPoCode(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, string poCode, bool projectStatus, string projectCode)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e)
                             .Where(() => e.QuoEmploy == employ);

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

                // if Project == true mean serch by project
                // if Project == false mean serch by Subject
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


                if (cusMaster != null)
                {
                    ICusMaster cus = null;

                    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                         .Where(() => cus.Id == cusMaster.Id);
                }

                if (!string.IsNullOrEmpty(poCode))
                {
                    IQuoPoCode po = null;

                    query.Left.JoinQueryOver(() => e.QuoPoCodes, () => po)
                         .WhereRestrictionOn(() => po.PoCode).IsLike(poCode, MatchMode.Anywhere);
                }

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> SearchByPoCode(DateTime? startDate, DateTime? endDate, string project,
            ICusMaster cusMaster, bool employ, bool term, string poCode, bool projectStatus, string projectCode)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e)
                             .Where(() => e.QuoEmploy == employ)
                             .And(() => e.QuoTermFlag == term);

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

                // if Project == true mean serch by project
                // if Project == false mean serch by Subject
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

                if (cusMaster != null)
                {
                    ICusMaster cus = null;

                    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                         .Where(() => cus.Id == cusMaster.Id);
                }

                if (!string.IsNullOrEmpty(poCode))
                {
                    IQuoPoCode po = null;

                    query.Left.JoinQueryOver(() => e.QuoPoCodes, () => po)
                         .WhereRestrictionOn(() => po.PoCode).IsLike(poCode, MatchMode.Anywhere);
                }

                return query.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> SearchByInvoiceStatusUAF(DateTime? startDate, DateTime? endDate, string project, 
            ICusMaster cusMaster, bool projectStatus, string projectCode)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;
                IQuoCoWorker c = null;

                var query = s.QueryOver(() => e)
                             .Left.JoinQueryOver(() => e.QuoCoWorks, () =>c)
                             .Where(() => e.QuoEmploy == true)
                             .And(() => e.MoneyFlag != "-1" && e.MoneyFlag != "-2" && e.MoneyFlag != "-9");

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

                // if Project == true mean serch by project
                // if Project == false mean serch by Subject
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

                if (cusMaster != null)
                {
                    ICusMaster cus = null;

                    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                         .Where(() => cus.Id == cusMaster.Id);
                }

                IQuoTermSta ts = null;
                IQuoTermpayment tm = null;
                IQuoTypeSta ty = null;

                //var conjunc = new Conjunction();
                //conjunc.Add(Restrictions.And(Restrictions.Not(Restrictions.On(() => ty.Group).IsLike("Group ESM", MatchMode.Anywhere)), Restrictions.Eq("Description", "UAF")));
                //conjunc.Add(Restrictions.And(Restrictions.Eq("Group", "Group ESM"), Restrictions.On<IQuoTypeSta>(xx => xx.Index).IsIn(new string[] { "3", "4", "5", "6" })));


                var disjunct = new Disjunction();
                disjunct.Add(Restrictions.And(Restrictions.Not(Restrictions.On(() => ty.Group).IsLike("Group ESM", MatchMode.Anywhere)), Restrictions.Eq("Description", "UAF")));
                disjunct.Add(Restrictions.And(Restrictions.Eq("Group", "Group ESM"), Restrictions.On<IQuoTypeSta>(xx => xx.Index).IsIn(new string[] {"2", "3", "4", "5"})));


                query.WhereRestrictionOn(() => e.QuoReceive).IsNotNull
                     .Left.JoinQueryOver(() => e.QuoTermpayments, () => tm)
                     .Left.JoinQueryOver(() => tm.QuoTermSta, () => ts)
                     .Left.JoinQueryOver(() => ts.QuoTypeSta, () => ty)
                     .Where(disjunct);
                    //.Where(() => ty.Description.IsLike("UAF"));
                     //.Where(conjunc);


                return query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
                           .List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SummaryCountQuatation(string EmpId)
        {
            try
            {
                int resultCount = 0;
                var s = Session;
                IQuoMaster q = null;

                var Query = s.QueryOver(() => q);
                               
                if (!string.IsNullOrEmpty(EmpId))
                {
                    Query.Where(() => q.CreateBy == EmpId);
                }

                resultCount = Query.RowCount();
                
                return resultCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SummaryQuoCloseJob(string Dept)
        {
            try
            {
                int resultCount = 0;

                var s = Session;
                IQuoMaster q = null;
                bool bEmploy = true;

                var Query = s.QueryOver(() => q)
                              .Where(() => q.QuoEmploy == bEmploy)
                              .And(() => q.MoneyFlag == "1");


                if (!string.IsNullOrEmpty(Dept))
                {
                }

                resultCount = Query.RowCount();

                return resultCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<IQuoMaster> SearchQuotationByWorker(DateTime? startDate, DateTime? endDate, string project, ICusMaster cusMaster, bool employ, bool mail, IHrmEmployee Emp)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IQuoMaster>);

                IQuoMaster e = null;

                var query = s.QueryOver(() => e)
                             .Where(() => e.QuoEmploy == employ);

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

                if (cusMaster != null)
                {
                    ICusMaster cus = null;

                    query.Inner.JoinQueryOver(() => e.CusMaster, () => cus)
                         .Where(() => cus.Id == cusMaster.Id);
                }

                if (Emp != null)
                {
                    //IQuoCoWorker c = null;
                    //string strDept = string.Empty;
                    //char[] arr = Emp.DeptOrg.ToCharArray();
                    //strDept = string.Format("{0}{1}{2}", arr[0], arr[1], arr[2]);

                    //query.Left.JoinQueryOver(() => e.QuoCoWorks, () => c)
                    //    .WhereRestrictionOn(() => c.Dept).IsLike(strDept, MatchMode.Anywhere);

                    IQuoWorker w = null;
                    IHrmEmployee emp = null;
                    var empId= Emp.Id;

                    query.Left.JoinQueryOver(() => e.QuoWorkers, () => w)
                         .Where(() => w.Employee == Emp);
                        //.Left.JoinQueryOver(() => w.Employee, () => emp)
                             //.WhereRestrictionOn(() => emp.Id).Equals(empId.ToString());
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
