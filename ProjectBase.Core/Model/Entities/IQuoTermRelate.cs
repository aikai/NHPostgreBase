using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IQuoTermRelate
    {
        Guid Id { get; set; }

        string RetDescrip { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        IQuoTermpayment QuoTermpayment { get; set; }
        IQuoCombineDe QuoCombineDe { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoTermRelate obj);
        int GetHashCode();
    }
}
