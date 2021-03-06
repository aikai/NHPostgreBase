using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IAppControlDetail
	{
        Guid Id { get; set; }

        IAppControl AppControl { get; set; }
        //Iesi.Collections.Generic.ISet<IAppPermit> AppPermit { get; set; }
        IAppPermit AppPermit { get; set; }

        bool Equals(object obj);
        bool Equals(IAppControl obj);
        int GetHashCode();
	}
}