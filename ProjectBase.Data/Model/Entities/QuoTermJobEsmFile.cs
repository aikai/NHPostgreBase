using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoTermJobEsmFile : IQuoTermJobEsmFile
	{
        public QuoTermJobEsmFile()
		{		
		}
        public virtual Guid Id
        {
            get;
            set;
        }
		public virtual DateTime? AttachDatetime
		{
			get;
			set;
		}
		public virtual string ContentType
		{
			get;
			set;
		}
		public virtual byte[] FileData
		{
			get;
			set;
		}
		public virtual string FileName
		{
			get;
			set;
		}
        public virtual string FileDescription
        {
            get;
            set;
        }
		public virtual double? FileSize
		{
			get;
			set;
		}
        public virtual int? Index
        {
            get;
            set;
        }
        public virtual string CreateBy
        {
            get;
            set;
        }
        public virtual DateTime? CreateDate
        {
            get;
            set;
        }
		public virtual string UpdateBy
		{
			get;
			set;
		}
		public virtual DateTime? UpdateDate
		{
			get;
			set;
		}

        public virtual IQuoTermpayment QuoTermpayment
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;

            return Equals(obj as IQuoTermJobEsmFile);
		}

        public virtual bool Equals(IQuoTermJobEsmFile obj)
		{
			if (obj == null) return false;

            if (Equals(Id, obj.Id) == false) return false;

			if (Equals(AttachDatetime, obj.AttachDatetime) == false) return false;
			if (Equals(ContentType, obj.ContentType) == false) return false;
			if (Equals(FileData, obj.FileData) == false) return false;
			if (Equals(FileName, obj.FileName) == false) return false;
			if (Equals(FileSize, obj.FileSize) == false) return false;

            if (Equals(CreateBy, obj.CreateBy) == false) return false;
            if (Equals(CreateDate, obj.CreateDate) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;

            if (Equals(QuoTermpayment, obj.QuoTermpayment) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            result = (result * 397) ^ Id.GetHashCode();

			result = (result * 397) ^ (AttachDatetime != null ? AttachDatetime.GetHashCode() : 0);
			result = (result * 397) ^ (ContentType != null ? ContentType.GetHashCode() : 0);
			result = (result * 397) ^ (FileData != null ? FileData.GetHashCode() : 0);
			result = (result * 397) ^ (FileName != null ? FileName.GetHashCode() : 0);
			result = (result * 397) ^ (FileSize != null ? FileSize.GetHashCode() : 0);

            result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
            result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);

            result = (result * 397) ^ (QuoTermpayment != null ? QuoTermpayment.GetHashCode() : 0);
			return result;
		}
	}
}