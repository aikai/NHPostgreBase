using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoRemarkLog : IQuoRemarkLog
	{
		public QuoRemarkLog()
		{		
		}
        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual string Remark
        {
            get;
            set;
        }
        public virtual DateTime? EditTime
        {
            get;
            set;
        }
        public virtual string CreateBy
        {
            get;
            set;
        }

        public virtual IQuoMaster QuoMaster
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IQuoRemarkLog);
		}
		
		public virtual bool Equals(IQuoRemarkLog obj)
		{
			if (obj == null) return false;

            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(Remark, obj.Remark) == false) return false;
            if (Equals(EditTime, obj.EditTime) == false) return false;
            if (Equals(CreateBy, obj.CreateBy) == false) return false;
            if (Equals(QuoMaster, obj.QuoMaster) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            result = (result * 397) ^ Id.GetHashCode();

            result = (result * 397) ^ (Remark != null ? Remark.GetHashCode() : 0);
            result = (result * 397) ^ (EditTime != null ? EditTime.GetHashCode() : 0);
            result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
            result = (result * 397) ^ (QuoMaster != null ? QuoMaster.GetHashCode() : 0);
			return result;
		}
	}
}