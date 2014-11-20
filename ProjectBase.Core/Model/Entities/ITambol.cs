using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface ITambol
    {
        string Id { get; set; }
        string TamEname { get; set; }
        string TamTname { get; set; }
        string TamZip { get; set; }
        IAmphoe Amphoe { get; set; }

        bool Equals(object obj);
        bool Equals(ITambol obj);
        int GetHashCode();
    }
}
