using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IAppPermit
	{
        Guid Id { get; set; }
        string Action { get; set; }

        //Iesi.Collections.Generic.ISet<IAppControl> AppControls { get; set; }

        bool Equals(object obj);
        bool Equals(IAppPermit obj);
		int GetHashCode();
	}
}