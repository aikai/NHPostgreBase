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
    public class LimGenDao : NHibernateDao<ILimGen>, ILimGenDao
    {
        protected override IQueryOver<ILimGen, ILimGen> BuildId(IQueryOver<ILimGen, ILimGen> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<ILimGen, ILimGen> BuildInIds(IQueryOver<ILimGen, ILimGen> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<ILimGen, ILimGen> BuildSort(IQueryOver<ILimGen, ILimGen> query)
        {
            return base.BuildSort(query).OrderBy(x => x.GenYear).Desc
                       .ThenBy(x => x.GenDep).Asc
                       .ThenBy(x => x.GenCode).Asc
                       .ThenBy(x => x.Suffix).Asc;
        }

        protected override IQueryOver<ILimGen, ILimGen> BuildParent(IQueryOver<ILimGen, ILimGen> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            ILimGen e = null;

            return base.BuildParent(query, parentId).Where(() => e.LimSamDetailWa.Id == _id);
        }

        protected override IQueryOver<ILimGen, ILimGen> BuildExistence(IQueryOver<ILimGen, ILimGen> query, ILimGen entity)
        {
            return base.BuildExistence(query, entity).WhereRestrictionOn(x => x.UniqueKey).IsLike(entity.UniqueKey, MatchMode.Exact);
        }

        protected int GetMaxGenCode(int genYear, string genDep)
        {
            var max = 0;

            try
            {
                if (1 > genYear)
                {
                    throw new Exception("GenYear is less than zero.");
                }

                if (string.IsNullOrEmpty(genDep))
                {
                    throw new Exception("GenDep is null or empty.");
                }

                var s = Session;

                if (!VerifyAvailableIsNull(s))
                {
                    ILimGen e = null;

                    var query = s.QueryOver(() => e)
                                 .Where(() => e.GenYear == genYear)
                                 .AndRestrictionOn(() => e.GenDep).IsLike(genDep, MatchMode.Exact)
                                 .Select(Projections.ProjectionList()
                                    .Add(Projections.Max(() => e.GenCode)))
                                 .List<int?>().First();

                    if (!VerifyAvailableIsNull(query))
                    {
                        max = query.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return max;
        }

        //protected string GetNewDocNo(string prefix, int year, int month, int max)
        //{
        //    var sb = new StringBuilder();

        //    try
        //    {
        //        DateTime date;

        //        if (DateTime.TryParseExact(string.Format("1/{0}/{1}", month, year),
        //                ProjectBase.Utils.Components.Format.Instance.DateShort,
        //                ProjectBase.Utils.Commons.Utility.Instance.EngCulture, DateTimeStyles.None, out date))
        //        {
        //            sb.Append(prefix);
        //            sb.Append(date.ToString("yy", ProjectBase.Utils.Commons.Utility.Instance.ThaCulture));
        //            sb.Append("-");
        //            sb.AppendFormat("{0:00}", month);
        //            sb.AppendFormat("{0:00000}", max);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return sb.ToString();
        //}

        public override object Save(ILimGen entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return null;

                object id = null;
                Update(delegate(ISession s)
                {
                    var toDay = DateTime.Now;
                    entity.GenYear = toDay.Year;

                    var max = this.GetMaxGenCode(entity.GenYear, entity.GenDep);// Maximum value: 999.

                    do
                    {
                        max++;// Increment maximum value.

                        var gocNo = string.Format("{0:000}", max);;

                        //if (string.IsNullOrEmpty(docNo))
                        //{
                        //    throw new Exception("DocNo is null or empty.");
                        //}

                        //entity.InctNum = max;
                        //entity.DocNo = docNo;

                    } while (max <= 999 && this.IsExist(entity));

                    if (max <= 999)
                    {
                        s.Clear();
                        id = s.Save(entity);
                    }
                });
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(ILimGen entity)
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

        public override void Delete(ILimGen entity)
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
    }
}
