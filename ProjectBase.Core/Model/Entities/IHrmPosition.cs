using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IHrmPosition
    {
        string Id { get; set; }
        string PsTname { get; set; }
        string PsEname { get; set; }
        string PsComment { get; set; }
        string PsMn { get; set; }
        string PsIden { get; set; }
        

        bool Equals(object obj);
        bool Equals(IHrmPosition obj);
        int GetHashCode();
    }
}
