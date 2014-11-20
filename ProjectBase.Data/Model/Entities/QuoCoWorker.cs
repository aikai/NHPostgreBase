using ProjectBase.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Data.Model
{
    [Serializable]
    public partial class QuoCoWorker : IQuoCoWorker
    {
        public virtual Guid Id { get; set; }

        public virtual IQuoMaster QuoMaster { get; set; }

        public virtual IHrmEmployee Employee { get; set; }

        public virtual string Dept { get; set; }

        public virtual string CreateBy { get; set; }

        public virtual DateTime? CreateDate { get; set; }

        public virtual bool Equals(IQuoCoWorker obj)
        {
            if (obj == null) return false;

            if (Equals(CreateBy, obj.CreateBy) == false) return false;
            if (Equals(CreateDate, obj.CreateDate) == false) return false;
            if (Equals(Dept, obj.Dept) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(QuoMaster, obj.QuoMaster) == false) return false;
            if (Equals(Employee, obj.Employee) == false) return false;

            return true;
        }
    }
}
