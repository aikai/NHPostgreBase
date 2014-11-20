using ProjectBase.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Data.Model
{
    [Serializable]
    public partial class QuoWorker : IQuoWorker
    {
        public virtual Guid Id {get;set;}
        public virtual IQuoMaster QuoMaster { get; set; }
        public virtual IHrmEmployee Employee { get; set; }
        public virtual string Dept { get; set; }

        public virtual bool Equals(IQuoWorker obj)
        {
            if (obj == null) return false;
            if (Equals(Dept, obj.Dept) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(QuoMaster, obj.QuoMaster) == false) return false;
            if (Equals(Employee, obj.Employee) == false) return false;

            return true;
        }
    }
}
