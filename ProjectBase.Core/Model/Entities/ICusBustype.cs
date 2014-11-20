using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface ICusBustype
    {
        Guid Id { get; set; }
        string BtpRemark { get; set; }
        string BtpTname { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        Iesi.Collections.Generic.ISet<ICusMaster> CusMasters { get; set; }
        ICusBusgroup CusBusgroup { get; set; }

        bool Equals(object obj);
        bool Equals(ICusBustype obj);
        int GetHashCode();
    }
}
