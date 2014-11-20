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
    public class AppControlDao : NHibernateDao<IAppControl>, IAppControlDao
    {
        protected override IQueryOver<IAppControl, IAppControl> BuildId(IQueryOver<IAppControl, IAppControl> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IAppControl, IAppControl> BuildInIds(IQueryOver<IAppControl, IAppControl> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IAppControl, IAppControl> BuildSort(IQueryOver<IAppControl, IAppControl> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IAppControl entity)
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

        public override void Delete(IAppControl entity)
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

        public IList<IAppControl> Search(IAppRole Group)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IList<IAppControl>);

                IAppControl ac = null;
                IAppRole ar = null;
                //IAppControlDetail ad = null;

                var query = s.QueryOver(() => ac)
                             //.Left.JoinQueryOver(() => ac.apControlDetail, () => ad)
                             .Left.JoinQueryOver(() => ac.AppRole, () => ar);

                if (Group != null)
                {
                    query.Where(() => ac.AppRole == Group);
                }

                var result = query.List<IAppControl>();

                return result;
                //return query.OrderBy(() => ac.AppRole).Asc.List<IAppControl>();
                            //.ThenBy(() => ac.HrmEmployee.Id).Asc.List();
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        public object Save(IList<IAppControl> entitys)
        {
            try
            {
                if (VerifyAvailableIsNull(entitys)) return null;

                object id = null;
                Update(delegate(ISession s)
                {
                    foreach (var ent in entitys)
                    {
                        #region Update all record in childs
                        IAppControl ac = null;
                        IAppControlDetail o = null;

                        var _controlDetail = s.QueryOver<IAppControlDetail>(() => o)
                                        .Left.JoinQueryOver(() => o.AppControl, () => ac)
                                        .Where(() => ac.Id == ent.Id).List();

                        if (!VerifyAvailableIsNull(_controlDetail) && _controlDetail.Count > 0)
                        {
                            s.Clear();

                            foreach (var item in _controlDetail)
                            {
                                var found = ent.apControlDetail.Where(x => x.Id == item.Id)
                                                  .FirstOrDefault();

                                if (found == null)
                                {
                                    s.Delete(item);
                                }
                            }

                            s.Flush();
                        }
                        #endregion


                        s.Clear();
                        //id = s.Save(ent);
                        s.Update(s.Merge(ent));
                        s.Flush();
                    }                                        
                });
                return id;     
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }


        public IAppControl Search(IHrmEmployee entity)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return default(IAppControl);

                IAppControl ac = null;
                IAppControlDetail ad = null;
                
                var query = s.QueryOver(() => ac)
                             .Left.JoinQueryOver(() => ac.apControlDetail, () => ad);

                if (entity != null)
                {
                    query.Where(() => ac.HrmEmployee.Id == entity.Id);
                }


                return query.SingleOrDefault<IAppControl>();
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }


        public IList<IAppControl> SearchEmployeeEmail(IAppRole GroupId)
        {
            try
            {
                var s = Session;

                if (VerifyAvailableIsNull(s)) return default(IList<IAppControl>);


                IAppControl ac = null;
                IHrmEmployee emp = null;

                var query = s.QueryOver(() => ac)
                             .Left.JoinQueryOver(() => ac.HrmEmployee, () => emp);

                if (GroupId != null)
                {
                    query.Where(() => ac.AppRole == GroupId);
                }

                return query.List<IAppControl>();
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }
    }
}
