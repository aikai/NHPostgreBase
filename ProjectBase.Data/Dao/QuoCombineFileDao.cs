using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using NHibernate;

namespace ProjectBase.Data
{
    public class QuoCombineFileDao : NHibernateDao<IQuoCombineFile>, IQuoCombineFileDao
    {
        protected override IQueryOver<IQuoCombineFile, IQuoCombineFile> BuildId(IQueryOver<IQuoCombineFile, IQuoCombineFile> query, object id)
        {
            var _id = new Guid(Convert.ToString(id));

            return base.BuildId(query, id).Where(x => x.Id == _id);
        }

        protected override IQueryOver<IQuoCombineFile, IQuoCombineFile> BuildInIds(IQueryOver<IQuoCombineFile, IQuoCombineFile> query, object[] ids)
        {
            var _ids = new List<Guid>();

            ids.ToList().ForEach(x => _ids.Add(new Guid(Convert.ToString(x))));

            return base.BuildInIds(query, ids).WhereRestrictionOn(x => x.Id).IsIn(_ids.ToArray());
        }

        protected override IQueryOver<IQuoCombineFile, IQuoCombineFile> BuildSort(IQueryOver<IQuoCombineFile, IQuoCombineFile> query)
        {
            return base.BuildSort(query).OrderBy(x => x.Id).Asc;
        }

        protected override IQueryOver<IQuoCombineFile, IQuoCombineFile> BuildParent(IQueryOver<IQuoCombineFile, IQuoCombineFile> query, object parentId)
        {
            var _id = new Guid(Convert.ToString(parentId));

            IQuoCombineFile e = null;

            return base.BuildParent(query, parentId).Where(() => e.QuoCombine.Id == _id);
        }

        public override void Update(IQuoCombineFile entity)
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

        public override void Delete(IQuoCombineFile entity)
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
