using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IProvince
    {
        string Id { get; set; }
        string ProvEname { get; set; }
        string ProvSign { get; set; }
        string ProvTname { get; set; }
        string RegId { get; set; }

        bool Equals(object obj);
        bool Equals(IProvince obj);
        int GetHashCode();
    }
}
