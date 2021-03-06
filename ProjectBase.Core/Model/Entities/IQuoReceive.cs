using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoReceive
	{
        Guid Id { get; set; }

        string Receive { get; set; }
        string ReceiveBy { get; set; }
        DateTime? ReceiveDate { get; set; }

        IQuoMaster QuoMaster { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoReceive obj);
        int GetHashCode();
	}
}