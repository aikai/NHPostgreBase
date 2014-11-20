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
    public class HrmSignDao : NHibernateDao<IHrmSign>, IHrmSignDao
    {
        protected override IQueryOver<IHrmSign, IHrmSign> BuildId(IQueryOver<IHrmSign, IHrmSign> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IHrmSign, IHrmSign> BuildInIds(IQueryOver<IHrmSign, IHrmSign> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IHrmSign, IHrmSign> BuildSort(IQueryOver<IHrmSign, IHrmSign> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        public override void Update(IHrmSign entity)
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

        public override void Delete(IHrmSign entity)
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



        public IHrmSign GetImageByEmp(IHrmSign entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return null;

                IHrmSign hs = null;
                var s = Session;

                var result = s.QueryOver(() => hs)
                              .Where(() => hs.HrmEmployee.Id == entity.HrmEmployee.Id)
                              .SingleOrDefault<IHrmSign>();

                return result;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }


        public IHrmSign GetImageByEmp(string EmpId)
        {
            try
            {
                var s = Session;
                IHrmSign si = null;
                var query = s.QueryOver(() => si)
                             .Where(() => si.HrmEmployee.Id == EmpId)
                             .SingleOrDefault<IHrmSign>();

                return query;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
