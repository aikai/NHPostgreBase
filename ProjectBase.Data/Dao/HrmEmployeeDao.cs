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
    public class HrmEmployeeDao : NHibernateDao<IHrmEmployee>, IHrmEmployeeDao
    {
        protected override IQueryOver<IHrmEmployee, IHrmEmployee> BuildId(IQueryOver<IHrmEmployee, IHrmEmployee> query, object id)
        {
            var _id = Convert.ToString(id);

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IHrmEmployee, IHrmEmployee> BuildInIds(IQueryOver<IHrmEmployee, IHrmEmployee> query, object[] ids)
        {
            var _ids = new List<string>();

            ids.ToList().ForEach(x => _ids.Add(Convert.ToString(x)));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IHrmEmployee, IHrmEmployee> BuildSort(IQueryOver<IHrmEmployee, IHrmEmployee> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IHrmEmployee entity)
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

        public override void Delete(IHrmEmployee entity)
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

        //public IList<IHrmEmployee> Search(string id, string name, IAppPermit appPermit, int i)
        //{
        //    try
        //    {
        //        var s = Session;
        //        if (VerifyAvailableIsNull(s)) return default(IList<IHrmEmployee>);

        //        IHrmEmployee e = null;

        //        var query = s.QueryOver(() => e);

        //        if (!string.IsNullOrEmpty(id))
        //        {
        //            query.WhereRestrictionOn(() => e.Id).IsLike(id, MatchMode.Anywhere);
        //        }

        //        if (!string.IsNullOrEmpty(name))
        //        {
        //            query.WhereRestrictionOn(() => e.EmpEngname).IsLike(name, MatchMode.Anywhere);
        //        }

        //        if (appPermit != null)
        //        {
        //            IAppPermit permit = null;
        //            IAppControl control = null;

        //            query.Left.JoinQueryOver(() => e.AppControls, () => control)
        //                 //.Left.JoinQueryOver(() => control.AppPermit, () => permit)
        //                 .Where(() => permit.Id == appPermit.Id);
        //        }

        //        return query.List();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public IList<object> GetListDept()
        {
            try
            {
                var s = Session;
                var criteria = s.CreateCriteria<IHrmEmployee>();
                criteria.SetProjection(Projections.Distinct(Projections.Property<IHrmEmployee>(a => a.DeptOrg)));

                return criteria.List<object>();
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        public IList<IHrmEmployee> Search(IHrmEmployee entity)
        {
            try
            {
                var s = Session;
                if (VerifyAvailableIsNull(s)) return null;

                IHrmEmployee e = null;

                var query = s.QueryOver(() => e);

                if (!string.IsNullOrEmpty(entity.EmpThainame))
                {
                    query.WhereRestrictionOn(() => e.EmpThainame).IsLike(entity.EmpThainame, MatchMode.Anywhere);
                }

                if (!string.IsNullOrEmpty(entity.DeptOrg))
                {
                    query.WhereRestrictionOn(() => e.DeptOrg).IsLike(entity.DeptOrg, MatchMode.Anywhere);
                }

                
                //query.SelectList(list => list
                //            .Select(() => e.Id).WithAlias(() => e.Id)
                //            .Select(() => e.EmpThainame).WithAlias(() => e.EmpThainame)
                //            .Select(() => e.DeptOrg).WithAlias(() => e.DeptId));

                return query.OrderBy(() =>e.Id).Asc.List();
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        public string GetEmpThaiName(object id)
        {
            try
            {
                var thaiName = string.Empty;
                var emp = this.GetById(id);

                if (!VerifyAvailableIsNull(emp))
                {
                    thaiName = emp.EmpThainame;
                }

                return thaiName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IHrmEmployee GetUserAndPosition(object id)
        {
            try
            {
                //var s = Session;
                //if (VerifyAvailableIsNull(s)) return null;

                //IHrmEmployee e = null;
                //IHrmSign s = null;
                //IHrmPosition p = null;

                //var rs = s.QueryOver(() => e)
                //          .Left.JoinQueryOver(() => e.PsId, () => p.Id);

                return null;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }
    }
}
