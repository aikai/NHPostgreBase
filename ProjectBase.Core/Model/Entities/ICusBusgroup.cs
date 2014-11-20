using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface ICusBusgroup
    {
        Guid Id { get; set; }
        string BgrRemark { get; set; }
        string BgrTname { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        bool Equals(object obj);
        bool Equals(ICusBusgroup obj);
        int GetHashCode();
    }
}
