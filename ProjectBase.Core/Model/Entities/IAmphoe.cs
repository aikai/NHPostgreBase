using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IAmphoe
    {
        string Id { get; set; }
        string AmpEname { get; set; }
        string AmpTname { get; set; }
        IProvince Province { get; set; }

        Iesi.Collections.Generic.ISet<ITambol> Tambols { get; set; }

        bool Equals(object obj);
        bool Equals(IAmphoe obj);
        int GetHashCode();
    }
}
