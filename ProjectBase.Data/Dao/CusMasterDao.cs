using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;
using NHibernate.Criterion;
using ProjectBase.Data.Model;


namespace ProjectBase.Data
{
    public class CusMasterDao : NHibernateDao<ICusMaster>, ICusMasterDao
    {
        protected override IQueryOver<ICusMaster, ICusMaster> BuildId(IQueryOver<ICusMaster, ICusMaster> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<ICusMaster, ICusMaster> BuildInIds(IQueryOver<ICusMaster, ICusMaster> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<ICusMaster, ICusMaster> BuildSort(IQueryOver<ICusMaster, ICusMaster> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public IList<ICusMaster> Search(string cusTname, string cusEname, ICusBusgroup cusBusgroup)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<ICusMaster>);

                ICusMaster e = null;

                var query = s.QueryOver(() => e);

                if (!string.IsNullOrEmpty(cusTname))
                {
                    query.WhereRestrictionOn(() => e.CusTname).IsLike(cusTname, MatchMode.Anywhere);
                }

                if (!string.IsNullOrEmpty(cusEname))
                {
                    query.WhereRestrictionOn(() => e.CusEname).IsLike(cusEname, MatchMode.Anywhere);
                }

                if (cusBusgroup != null)
                {
                    ICusBusgroup grp = null;

                    query.Left.JoinQueryOver(() => e.CusBusgroup, () => grp)
                         .Where(() => grp.Id == cusBusgroup.Id);
                }

                return query.Take(50)
                            .List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<ICusMaster> Search(string cusCode, string cusThaiName, string cusEngName, string cusContact)
        {
            try
            {
                 var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<ICusMaster>);
                ICusMaster e = null;
                ICusCon c = null;

                var query = s.QueryOver(() => e);

                if (!string.IsNullOrEmpty(cusCode))
                {
                    query.WhereRestrictionOn(() => e.CusCode).IsLike(cusCode, MatchMode.Anywhere);
                }

                if (!string.IsNullOrEmpty(cusThaiName))
                {
                    query.WhereRestrictionOn(() => e.CusTname).IsLike(cusThaiName, MatchMode.Anywhere);
                }

                if (!string.IsNullOrEmpty(cusEngName))
                {
                    query.WhereRestrictionOn(() => e.CusEname).IsLike(cusEngName, MatchMode.Anywhere);
                }

                if (!string.IsNullOrEmpty(cusContact))
                {
                    query.Left.JoinQueryOver(() => e.CusCons, () => c)
                         .WhereRestrictionOn(() => c.ConName).IsLike(cusContact, MatchMode.Anywhere);
                }

                
                 
                return query.List();
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        public override void Update(ICusMaster entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return;

                Update(delegate(ISession s)
                {
                    ICusMaster cm = null;
                    ICusCon cc = null;
                    ICusAdd ca = null;
                    ICusDue cd = null;


                    #region Comment
                    //var dues = s.QueryOver<ICusDue>(() => cd)
                    //               .Left.JoinQueryOver(() => cd.CusMaster, () => cm)
                    //               .Where(() => cm.Id == entity.Id).List();

                    //if (!VerifyAvailableIsNull(dues) && dues.Count > 0)
                    //{
                    //    s.Clear();

                    //    foreach (var item in dues)
                    //    {
                    //        var found = entity.CusDues.Where(x => x.Id == item.Id)
                    //                          .FirstOrDefault();

                    //        if (found == null)
                    //        {
                    //            s.Delete(item);
                    //        }
                    //    }

                    //    s.Flush();
                    //}

                    //var address = s.QueryOver<ICusAdd>(() => ca)
                    //                .Left.JoinQueryOver(() => ca.CusMaster, () => cm)
                    //                .Where(() => cm.Id == entity.Id).List();

                    //if (!VerifyAvailableIsNull(address) && address.Count > 0)
                    //{
                    //    s.Clear();

                    //    foreach (var item in address)
                    //    {
                    //        var found = entity.CusAdds.Where(x => x.Id == item.Id)
                    //                          .FirstOrDefault();

                    //        if (found == null)
                    //        {
                    //            s.Delete(item);
                    //        }
                    //    }

                    //    s.Flush();
                    //}


                    //var cons = s.QueryOver<ICusCon>(() => cc)
                    //                .Left.JoinQueryOver(() => cc.CusMaster, () => cm)
                    //                .Where(() => cm.Id == entity.Id).List();

                    //if (!VerifyAvailableIsNull(cons) && cons.Count > 0)
                    //{
                    //    s.Clear();

                    //    foreach (var item in cons)
                    //    {
                    //        var found = entity.CusCons.Where(x => x.Id == item.Id)
                    //                          .FirstOrDefault();

                    //        if (found == null)
                    //        {
                    //            s.Delete(item);
                    //        }
                    //    }

                    //    s.Flush();
                    //} 
                    #endregion


                    
                    var dues = s.QueryOver<ICusDue>(() => cd)
                                   .Left.JoinQueryOver(() => cd.CusMaster, () => cm)
                                   .Where(() => cm.Id == entity.Id).List();

                    if (!VerifyAvailableIsNull(dues) && dues.Count > 0)
                    {
                        s.Clear();

                        foreach (var item in dues)
                        {
                            s.Delete(item);
                        }

                        s.Flush();
                    }


                    var address = s.QueryOver<ICusAdd>(() => ca)
                                    .Left.JoinQueryOver(() => ca.CusMaster, () => cm)
                                    .Where(() => cm.Id == entity.Id).List();

                    if (!VerifyAvailableIsNull(address) && address.Count > 0)
                    {
                        s.Clear();

                        foreach (var item in address)
                        {
                            s.Delete(item);
                        }

                        s.Flush();
                    }


                    var cons = s.QueryOver<ICusCon>(() => cc)
                                    .Left.JoinQueryOver(() => cc.CusMaster, () => cm)
                                    .Where(() => cm.Id == entity.Id).List();

                    if (!VerifyAvailableIsNull(cons) && cons.Count > 0)
                    {
                        s.Clear();

                        foreach (var item in cons)
                        {
                            s.Delete(item);
                        }

                        s.Flush();
                    } 
                    


                    s.Clear();
                    s.Update(s.Merge(entity));
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete(ICusMaster entity)
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

        public override object Save(ICusMaster entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return null;
                
                object id = null;
                Update(delegate(ISession s)
                {
                    #region Generate CustomerCode
                    int CustomerCount = 0;
                    string strName = entity.CusEname.Trim().Substring(0, 1);

                    var maxRow = s.CreateCriteria<ICusMaster>()
                                                        .SetProjection(Projections.Max<ICusMaster>(x => x.CusIndex))
                                                        .UniqueResult();

                    if (maxRow != null)
                    {
                        int.TryParse(maxRow.ToString(), out CustomerCount);
                    }

                    if (CustomerCount > 0)
                    {
                        CustomerCount += 1;
                        //entity.CusCode = strName.ToUpper() + CustomerCount.ToString().PadLeft(4, '0');
                        entity.CusIndex = CustomerCount;
                    }
                    else
                    {
                        //entity.CusCode = strName.ToUpper() + "0001";
                        entity.CusIndex = 1;
                    } 
                    #endregion

                    s.Clear();
                    id = s.Save(entity);
                    s.Flush();
                });
                return id;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateCustomerCode(ICusMaster entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return null;

                var s = Session;
                string CustomerCode = string.Empty;

                if (entity != null)
                {
                    if (string.IsNullOrEmpty(entity.CusCode))
                    {
                        #region Generate CustomerCode
                        int CustomerCount = 0;
                        string strName = entity.CusEname.Trim().Substring(0, 1);

                        var maxRow = s.CreateCriteria<ICusMaster>()
                                                            .SetProjection(Projections.Max<ICusMaster>(x => x.CusIndex))
                                                            .UniqueResult();

                        if (maxRow != null)
                        {
                            int.TryParse(maxRow.ToString(), out CustomerCount);
                        }

                        if (CustomerCount > 0)
                        {
                            CustomerCount += 1;
                            entity.CusCode = strName.ToUpper() + CustomerCount.ToString().PadLeft(4, '0');
                            entity.CusIndex = CustomerCount;
                        }
                        else
                        {
                            entity.CusCode = strName.ToUpper() + "0001";
                            entity.CusIndex = 1;
                        }
                        #endregion

                        s.Clear();
                        s.Update(s.Merge(entity));
                        s.Flush();

                        CustomerCode = entity.CusCode;
                    }
                    else
                    {
                        CustomerCode = entity.CusCode;
                    }
                }

                return CustomerCode;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

    }
}
