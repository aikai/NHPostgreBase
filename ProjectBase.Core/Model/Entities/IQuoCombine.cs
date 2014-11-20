using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IQuoCombine
    {
        Guid Id { get; set; }

        string TjlRepnum { get; set; }
        string TjlDescription { get; set; }
        int Year { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        Iesi.Collections.Generic.ISet<IQuoCombineDe> QuoCombineDes { get; set; }
        Iesi.Collections.Generic.ISet<IQuoCombineFile> QuoCombineFiles { get; set; }

        IQuoMaster QuoMaster { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoCombine obj);
        int GetHashCode();
    }
}
