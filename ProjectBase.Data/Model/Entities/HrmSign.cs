using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class HrmSign : IHrmSign
	{
        public HrmSign()
		{
		}

        public virtual Guid Id
        {
            get;
            set;
        }

        public virtual byte[] FileData
        {
            get;
            set;
        }

        public virtual double? FileSize
        {
            get;
            set;
        }

        public virtual string ContentType
        {
            get;
            set;
        }

        public virtual string FileName { get; set; }

        public virtual IHrmEmployee HrmEmployee
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;

            return Equals(obj as IHrmSign);
		}
		
		public virtual bool Equals(IHrmSign obj)
		{
			if (obj == null) return false;

			if (Equals(Id, obj.Id) == false) return false;
            if (Equals(FileData, obj.FileData) == false) return false;
            if (Equals(ContentType, obj.ContentType) == false) return false;
            if (Equals(FileSize, obj.FileSize) == false) return false;


			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;
			
            result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
            result = (result * 397) ^ (FileData != null ? FileData.GetHashCode() : 0);
            result = (result * 397) ^ (FileSize != null ? FileSize.GetHashCode() : 0);
            result = (result * 397) ^ (ContentType != null ? ContentType.GetHashCode() : 0);

            return result;
		}
    }
}