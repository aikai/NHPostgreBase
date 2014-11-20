using ProjectBase.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBase.Data.Model
{
    [Serializable]
    public partial class HrmEmail : IHrmEmail
    {
        public HrmEmail()
        {
        }

        public virtual string Id { get; set; }

        public virtual string Email { get; set; }

        public virtual string EmailPass { get; set; }

        public virtual bool Active { get; set; }

        public virtual bool Equals(IHrmEmail obj)
        {
            if (obj == null) return false;
            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(Email, obj.Email) == false) return false;
            if (Equals(EmailPass, obj.EmailPass) == false) return false;
            if (Equals(Active, obj.Active) == false) return false;
            return true;
        }
    }
}
