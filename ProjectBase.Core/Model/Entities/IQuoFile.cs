using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Core.Model
{
    public interface IQuoFile
	{
        Guid Id { get; set; }
        DateTime? AttachDatetime { get; set; }
        string ContentType { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        byte[] FileData { get; set; }
        string FileDescription { get; set; }
        string FileName { get; set; }
        double? FileSize { get; set; }
        QuoFileType FileType { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        int? Index { get; set; }

        IQuoMaster QuoMaster { get; set; }

        bool Equals(object obj);
        bool Equals(IQuoFile obj);
        int GetHashCode();
	}
}