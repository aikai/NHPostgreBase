using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface ILimSamSubdetailWa
	{
        Guid Id { get; set; }

        string SasAsetic1 { get; set; }
        string SasAsetic250 { get; set; }
        string SasAsetic500 { get; set; }
        string SasContainer { get; set; }
        string SasFosface { get; set; }
        string SasGlass1 { get; set; }
        string SasGlass250 { get; set; }
        string SasGlass425 { get; set; }
        int? SasItem { get; set; }
        string SasSterite { get; set; }
        ILimSamDetailWa LimSamDetailWa { get; set; }
        ILimSamPreserv LimSamPreserv { get; set; }

        bool Equals(object obj);
        bool Equals(ILimSamSubdetailWa obj);
        int GetHashCode();
	}
}