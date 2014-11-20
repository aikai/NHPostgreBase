using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface ICusDueType
    {
        Guid Id { get; set; }
        string DtyDescrip { get; set; }
        string DtyRemark { get; set; }

        //ICusDue CusDue { get; set; }

        bool Equals(object obj);
        bool Equals(ICusDueType obj);
        int GetHashCode();
    }
}
