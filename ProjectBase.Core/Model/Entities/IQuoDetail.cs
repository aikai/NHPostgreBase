using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoDetail
	{
        Guid Id { get; set; }
        int? QdeItem { get; set; }
        double? QdeCost { get; set; }
        string QdeDesc { get; set; }
        double? QdeQuantity { get; set; }
        double? QdeTotal { get; set; }
        int? Index { get; set; }

        IQuoMaster QuoMaster { get; set; }
        IUnit Unit { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoDetail obj);
        int GetHashCode();
	}
}