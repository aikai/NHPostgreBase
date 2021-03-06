using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoRequest
	{
        Guid Id { get; set; }

        bool? ReqPerson { get; set; }
        string ReqPersonDe { get; set; }
        bool? ReqTool { get; set; }
        string ReqToolDe { get; set; }
        bool? ReqChemical { get; set; }
        string ReqChemicalDe { get; set; }
        bool? ReqGlass { get; set; }
        string ReqGlassDe { get; set; }
        bool? ReqJob { get; set; }
        string ReqComment { get; set; }
        string ReqBy { get; set; }
        DateTime? ReqDate { get; set; }
        bool? IsDelete { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        IQuoMaster QuoMaster { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoRequest obj);
        int GetHashCode();
	}
}