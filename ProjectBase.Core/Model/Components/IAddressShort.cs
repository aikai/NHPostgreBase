using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IAddressShort
    {
        string ThaiAddress { get; set; }
        string EngAddress { get; set; }

        ITambol Tambol { get; set; }
        IAmphoe Amphoe { get; set; }
        IProvince Province { get; set; }

        IValueValidation PostCode { get; set; }

        string ToStringThai();
        string ToStringEng();

    }
}