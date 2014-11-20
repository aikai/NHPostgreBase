using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IHrmSign 
    {
        Guid Id { get; set; }
        byte[] FileData { get; set; }
        double? FileSize { get; set; }
        string ContentType { get; set; }
        string FileName { get; set; }
        IHrmEmployee HrmEmployee { get; set; }
        

        bool Equals(object obj);
        bool Equals(IHrmSign obj);
        int GetHashCode();
    }
}
