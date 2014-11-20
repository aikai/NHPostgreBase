using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class QuoCombineDao : NHibernateDao<IQuoCombine>, IQuoCombineDao
    {
        protected override NHibernate.IQueryOver<IQuoCombine, IQuoCombine> BuildId(NHibernate.IQueryOver<IQuoCombine, IQuoCombine> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override NHibernate.IQueryOver<IQuoCombine, IQuoCombine> BuildInIds(NHibernate.IQueryOver<IQuoCombine, IQuoCombine> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override NHibernate.IQueryOver<IQuoCombine, IQuoCombine> BuildSort(NHibernate.IQueryOver<IQuoCombine, IQuoCombine> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IQuoCombine, IQuoCombine> BuildParent(IQueryOver<IQuoCombine, IQuoCombine> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IQuoCombine e = null;

            return base.BuildParent(query, parentId).Where(() => e.QuoMaster.Id == _id);
        }

        public override void Update(IQuoCombine entity)
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

        public override void Delete(IQuoCombine entity)
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

        public void Update(IList<IQuoCombine> entities, IQuoMaster entity)
        {
            try
            {
                Update(delegate(ISession s)
                {
                    #region QuoCombine
                    IQuoMaster e = null;
                    IQuoCombine o = null;

                    var quoCombines = s.QueryOver<IQuoCombine>(() => o)
                                       .Inner.JoinQueryOver(() => o.QuoMaster, () => e)
                                       .Where(() => e.Id == entity.Id).List();

                    if (!VerifyAvailableIsNull(quoCombines) && quoCombines.Count > 0)
                    {
                        s.Clear();

                        foreach (var item in quoCombines)
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
                        #region QuoCombineDe
                        s.Clear();

                        foreach (var item in entities)
                        {
                            IQuoCombineDe de = null;

                            var quoCombineDes = s.QueryOver<IQuoCombineDe>(() => de)
                                                 .Inner.JoinQueryOver(() => de.QuoCombine, () => o)
                                                 .Where(() => o.Id == item.Id).List();

                            if (!VerifyAvailableIsNull(quoCombineDes) && quoCombineDes.Count > 0)
                            {
                                foreach (var dep in quoCombineDes)
                                {
                                    var exist = item.QuoCombineDes.Where(x => x.Id == dep.Id)
                                                    .SingleOrDefault();

                                    if (exist == null)
                                    {
                                        s.Delete(dep);
                                    }
                                }

                                s.Flush();
                            }
                        }
                        #endregion

                        #region QuoCombineFile
                        s.Clear();

                        foreach (var item in entities)
                        {
                            IQuoCombineFile fi = null;

                            var quoCombineFiles = s.QueryOver<IQuoCombineFile>(() => fi)
                                                   .Inner.JoinQueryOver(() => fi.QuoCombine, () => o)
                                                   .Where(() => o.Id == item.Id).List();

                            if (!VerifyAvailableIsNull(quoCombineFiles) && quoCombineFiles.Count > 0)
                            {
                                foreach (var file in quoCombineFiles)
                                {
                                    var exist = item.QuoCombineFiles.Where(x => x.Id == file.Id)
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

        //public IList<IQuoCombine> GetFileByParent(IQuoTermpayment TermpaymentEntity, IQuoMaster entity)
        //{
        //    try
        //    {
        //        IQuoCombine l = null;
        //        IQuoCombineDe ld = null;
        //        IQuoCombineFile lf = null;

        //        IQuoTermpayment t = null;
        //        IQuoMaster m = null;

        //        var query = Session.QueryOver(() => l)
        //                           .Left.JoinQueryOver(() => l.QuoCombineDes, () => ld)
        //                           .Left.JoinQueryOver(() => ld.QuoCombineFiles, () => lf)
        //                           .Left.JoinQueryOver(() => l.QuoTermpayment, () => t)
        //                           .Where(() => t.Id == TermpaymentEntity.Id)
        //                           .WhereRestrictionOn(() => t.Id).IsNotNull;


        //        if (entity != null)
        //        {
        //            //query.Left
        //        }


        //        return query.TransformUsing(NHibernate.Transform.Transformers.DistinctRootEntity)
        //                    .List();
        //    }
        //    catch (Exception ex)
        //    {   
        //        throw ex;
        //    }
        //}
    }
}
