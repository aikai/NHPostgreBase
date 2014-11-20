using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface ICusType
    {
        Guid Id { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string CtpComment { get; set; }
        string CtpEname { get; set; }
        string CtpTname { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        Iesi.Collections.Generic.ISet<ICusMaster> CusMasters { get; set; }

        bool Equals(object obj);
        bool Equals(ICusType obj);
        int GetHashCode();
    }
}
