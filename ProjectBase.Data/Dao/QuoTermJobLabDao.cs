using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class QuoTermJobLabDao : NHibernateDao<IQuoTermJobLab>, IQuoTermJobLabDao
    {
        protected override NHibernate.IQueryOver<IQuoTermJobLab, IQuoTermJobLab> BuildId(NHibernate.IQueryOver<IQuoTermJobLab, IQuoTermJobLab> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override NHibernate.IQueryOver<IQuoTermJobLab, IQuoTermJobLab> BuildInIds(NHibernate.IQueryOver<IQuoTermJobLab, IQuoTermJobLab> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override NHibernate.IQueryOver<IQuoTermJobLab, IQuoTermJobLab> BuildSort(NHibernate.IQueryOver<IQuoTermJobLab, IQuoTermJobLab> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IQuoTermJobLab, IQuoTermJobLab> BuildParent(IQueryOver<IQuoTermJobLab, IQuoTermJobLab> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IQuoTermJobLab e = null;

            return base.BuildParent(query, parentId).Where(() => e.QuoTermpayment.Id == _id);
        }

        public override void Update(IQuoTermJobLab entity)
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

        public void Update(IList<IQuoTermJobLab> entities, IQuoTermpayment entity)
        {
            try
            {
                Update(delegate(ISession s)
                {
                    #region QuoTermJobLab
                    IQuoTermpayment e = null;
                    IQuoTermJobLab o = null;

                    var termJobLabs = s.QueryOver<IQuoTermJobLab>(() => o)
                                          .Inner.JoinQueryOver(() => o.QuoTermpayment, () => e)
                                          .Where(() => e.Id == entity.Id).List();

                    if (!VerifyAvailableIsNull(termJobLabs) && termJobLabs.Count > 0)
                    {
                        s.Clear();

                        foreach (var item in termJobLabs)
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

                    if (!VerifyAvailableIsNull(entities) && entities.Count > 0)
                    {
                        #region QuoTermJobLabDe
                        s.Clear();

                        foreach (var item in entities)
                        {
                            IQuoTermJobLabDe de = null;

                            var termJobLabDes = s.QueryOver<IQuoTermJobLabDe>(() => de)
                                                    .Inner.JoinQueryOver(() => de.QuoTermJobLab, () => o)
                                                    .Where(() => o.Id == item.Id).List();

                            if (!VerifyAvailableIsNull(termJobLabDes) && termJobLabDes.Count > 0)
                            {
                                foreach (var dep in termJobLabDes)
                                {
                                    var exist = item.QuoTermJobLabDes.Where(x => x.Id == dep.Id)
                                                    .SingleOrDefault();

                                    if (exist == null)
                                    {
                                        s.Delete(dep);
                                    }
                                }

                                s.Flush();
                            }

                            #region QuoTermJobLabDe
                            s.Clear();

                            foreach (var itm in item.QuoTermJobLabDes)
                            {
                                IQuoTermJobLabFile fi = null;

                                var termJobLabFiles = s.QueryOver<IQuoTermJobLabFile>(() => fi)
                                                       .Inner.JoinQueryOver(() => fi.QuoTermJobLabDe, () => de)
                                                       .Where(() => de.Id == itm.Id).List();

                                if (!VerifyAvailableIsNull(termJobLabFiles) && termJobLabFiles.Count > 0)
                                {
                                    foreach (var file in termJobLabFiles)
                                    {
                                        var exist = itm.QuoTermJobLabFiles.Where(x => x.Id == file.Id)
                                                       .SingleOrDefault();

                                        if (exist == null)
                                        {
                                            s.Delete(file);
                                        }
                                    }

                                    s.Flush();
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }

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

        public override void Delete(IQuoTermJobLab entity)
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


        public IList<IQuoTermJobLab> GetFileByParent(IQuoTermpayment TermpaymentEntity, IQuoMaster entity)
        {
            try
            {
                IQuoTermJobLab l = null;
                IQuoTermJobLabDe ld = null;
                IQuoTermJobLabFile lf = null;

                IQuoTermpayment t = null;
                IQuoMaster m = null;

                var query = Session.QueryOver(() => l)
                                   .Left.JoinQueryOver(() => l.QuoTermJobLabDes, () => ld)
                                   .Left.JoinQueryOver(() => ld.QuoTermJobLabFiles, () => lf)
                                   .Left.JoinQueryOver(() => l.QuoTermpayment, () => t)
                                   .Where(() => t.Id == TermpaymentEntity.Id)
                                   .WhereRestrictionOn(() => t.Id).IsNotNull;


                if (entity != null)
                {
                    //query.Left
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
