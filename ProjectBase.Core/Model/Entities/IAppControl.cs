using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IAppControl
	{
        Guid Id { get; set; }

        IHrmEmployee HrmEmployee { get; set; }
        //IAppPermit AppPermit { get; set; }
        IAppRole AppRole { get; set; }

        //Iesi.Collections.Generic.ISet<IAppPermit> AppPermit { get; set; }
        Iesi.Collections.Generic.ISet<IAppControlDetail> apControlDetail { get; set; }

        bool Equals(object obj);
        bool Equals(IAppControl obj);
        int GetHashCode();
	}
}