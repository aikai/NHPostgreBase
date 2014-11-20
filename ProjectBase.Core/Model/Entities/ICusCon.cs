using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface ICusCon
    {
        Guid Id { get; set; }
        string ConComment { get; set; }
        string ConEmail { get; set; }
        string ConFax { get; set; }
        string ConMobile { get; set; }
        string ConName { get; set; }
        string ConNickname { get; set; }
        string ConPosition { get; set; }
        string ContDep { get; set; }
        string ConTel { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        ICusMaster CusMaster { get; set; }

        bool Equals(object obj);
        bool Equals(ICusCon obj);
        int GetHashCode();
    }
}
