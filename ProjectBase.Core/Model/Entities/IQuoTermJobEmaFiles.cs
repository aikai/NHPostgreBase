using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IQuoTermJobEmaFiles
	{
        Guid Id { get; set; }

        DateTime? AttachDatetime { get; set; }
        string ContentType { get; set; }
        byte[] FileData { get; set; }
        string FileName { get; set; }
        string FileDescription { get; set; }
        double? FileSize { get; set; }
        int? Index { get; set; }

        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        IQuoTermpayment QuoTermpayment { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoTermJobEmaFiles obj);
        int GetHashCode();
	}
}