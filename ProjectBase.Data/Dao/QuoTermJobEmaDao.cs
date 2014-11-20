using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class QuoTermJobEmaDao : NHibernateDao<IQuoTermJobEma>, IQuoTermJobEmaDao
    {
        protected override NHibernate.IQueryOver<IQuoTermJobEma, IQuoTermJobEma> BuildId(NHibernate.IQueryOver<IQuoTermJobEma, IQuoTermJobEma> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override NHibernate.IQueryOver<IQuoTermJobEma, IQuoTermJobEma> BuildInIds(NHibernate.IQueryOver<IQuoTermJobEma, IQuoTermJobEma> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override NHibernate.IQueryOver<IQuoTermJobEma, IQuoTermJobEma> BuildSort(NHibernate.IQueryOver<IQuoTermJobEma, IQuoTermJobEma> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IQuoTermJobEma, IQuoTermJobEma> BuildParent(IQueryOver<IQuoTermJobEma, IQuoTermJobEma> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IQuoTermJobEma e = null;

            return base.BuildParent(query, parentId).Where(() => e.QuoTermpayment.Id == _id);
        }

        public override void Update(IQuoTermJobEma entity)
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

        public void Update(IList<IQuoTermJobEma> entities, IQuoTermpayment entity)
        {
            try
            {
                Update(delegate(ISession s)
                {
                    #region QuoTermJobLab
                    IQuoTermpayment e = null;
                    IQuoTermJobEma o = null;

                    var termJobLabs = s.QueryOver<IQuoTermJobEma>(() => o)
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
                            IQuoTermJobEmaDe de = null;

                            var termJobEmaDes = s.QueryOver<IQuoTermJobEmaDe>(() => de)
                                                    .Inner.JoinQueryOver(() => de.QuoTermJobEma, () => o)
                                                    .Where(() => o.Id == item.Id).List();

                            if (!VerifyAvailableIsNull(termJobEmaDes) && termJobEmaDes.Count > 0)
                            {
                                foreach (var dep in termJobEmaDes)
                                {
                                    var exist = item.QuoTermJobEmaDes.Where(x => x.Id == dep.Id)
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

                            foreach (var itm in item.QuoTermJobEmaDes)
                            {
                                IQuoTermJobEmaFile fi = null;

                                var termJobEmaFiles = s.QueryOver<IQuoTermJobEmaFile>(() => fi)
                                                       .Inner.JoinQueryOver(() => fi.QuoTermJobEmaDe, () => de)
                                                       .Where(() => de.Id == itm.Id).List();

                                if (!VerifyAvailableIsNull(termJobEmaFiles) && termJobEmaFiles.Count > 0)
                                {
                                    foreach (var file in termJobEmaFiles)
                                    {
                                        var exist = itm.QuoTermJobEmaFiles.Where(x => x.Id == file.Id)
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

        public override void Delete(IQuoTermJobEma entity)
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


        public IList<IQuoTermJobEma> GetFileByParentLabEma(IQuoTermpayment TermpaymentEntity, IQuoMaster entity)
        {
            try
            {
                IQuoTermJobEma l = null;
                IQuoTermJobEmaDe ld = null;
                IQuoTermJobEmaFile lf = null;

                IQuoTermpayment t = null;
                IQuoMaster m = null;


                var query = Session.QueryOver(() => l)
                                   .Left.JoinQueryOver(() => l.QuoTermJobEmaDes, () => ld)
                                   .Left.JoinQueryOver(() => ld.QuoTermJobEmaFiles, () => lf)
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
