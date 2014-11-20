using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;
using NHibernate.Criterion;
using System.Configuration;
using System.Globalization;

namespace ProjectBase.Data
{
    public class QuoTermInvDao : NHibernateDao<IQuoTermInv>, IQuoTermInvDao
    {
        protected override IQueryOver<IQuoTermInv, IQuoTermInv> BuildId(IQueryOver<IQuoTermInv, IQuoTermInv> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoTermInv, IQuoTermInv> BuildInIds(IQueryOver<IQuoTermInv, IQuoTermInv> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoTermInv, IQuoTermInv> BuildSort(IQueryOver<IQuoTermInv, IQuoTermInv> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IQuoTermInv, IQuoTermInv> BuildParent(IQueryOver<IQuoTermInv, IQuoTermInv> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IQuoTermInv e = null;

            return base.BuildParent(query, parentId).Where(() => e.QuoTermpayment.Id == _id);
        }

        protected override IQueryOver<IQuoTermInv, IQuoTermInv> BuildExistence(IQueryOver<IQuoTermInv, IQuoTermInv> query, IQuoTermInv entity)
        {
            return base.BuildExistence(query, entity).WhereRestrictionOn(x => x.DocNo).IsLike(entity.DocNo, MatchMode.Exact);
        }

        protected int GetMaxIncNum(int year, int month)
        {
            var max = 0;

            try
            {
                if (1 > year)
                {
                    throw new Exception("Year is less than zero.");
                }

                if (1 > month)
                {
                    throw new Exception("Month is less than zero.");
                }

                var s = Session;

                if (!VerifyAvailableIsNull(s))
                {
                    IQuoTermInv e = null;

                    var query = s.QueryOver(() => e)
                                 .Where(() => e.Year == year)
                                 .And(() => e.Month == month)
                                 .Select(Projections.ProjectionList()
                                    .Add(Projections.Max(() => e.InctNum)))
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

        protected string GetNewDocNo(string prefix, int year, int month, int max)
        {
            var sb = new StringBuilder();

            try
            {
                DateTime date;

                if (DateTime.TryParseExact(string.Format("1/{0}/{1}", month, year),
                        ProjectBase.Utils.Components.Format.Instance.DateShort,
                        ProjectBase.Utils.Commons.Utility.Instance.EngCulture, DateTimeStyles.None, out date))
                {
                    sb.Append(prefix);
                    sb.Append(date.ToString("yy", ProjectBase.Utils.Commons.Utility.Instance.ThaCulture));
                    sb.Append("-");
                    sb.AppendFormat("{0:00}", month);
                    sb.AppendFormat("{0:00000}", max);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sb.ToString();
        }

        public override object Save(IQuoTermInv entity)
        {
            try
            {
                if (VerifyAvailableIsNull(entity)) return null;

                if (string.IsNullOrEmpty(entity.Prefix))
                {
                    throw new Exception("Prefix is null or empty.");
                }

                object id = null;
                Update(delegate(ISession s)
                {
                    var toDay = DateTime.Now;
                    var max = this.GetMaxIncNum(toDay.Year, toDay.Month);// Maximum value: 99999.

                    entity.Year = toDay.Year;
                    entity.Month = toDay.Month;

                    do
                    {
                        max++;// Increment maximum value.
                        var docNo = this.GetNewDocNo(entity.Prefix, entity.Year, entity.Month, max);

                        if (string.IsNullOrEmpty(docNo))
                        {
                            throw new Exception("DocNo is null or empty.");
                        }

                        entity.InctNum = max;
                        entity.DocNo = docNo;

                    } while (max <= 99999 && this.IsExist(entity));

                    if (max <= 99999)
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

        public override void Update(IQuoTermInv entity)
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

        public override void Delete(IQuoTermInv entity)
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

        public IQuoTermInv GetByDocNo(string docNo)
        {
            IQuoTermInv entity = null;

            try
            {
                if (!string.IsNullOrEmpty(docNo))
                {
                    var s = Session;

                    if (!VerifyAvailableIsNull(s))
                    {
                        // ERROR:  duplicate key value violates unique constraint "DOC_NO_key"
                        // DETAIL:  Key ("DOC_NO")=(ESM57-1100001) already exists.

                        IQuoTermInv e = null;

                        entity = s.QueryOver(() => e)
                                  .WhereRestrictionOn(() => e.DocNo).IsLike(docNo, MatchMode.Exact)
                                  .SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }
    }
}