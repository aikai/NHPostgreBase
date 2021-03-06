using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class HrmPosition : IHrmPosition
	{
        public HrmPosition()
		{
		}

        public virtual string Id
        {
            get;
            set;
        }
        
        public virtual string PsTname
        {
            get;
            set;
        }

        public virtual string PsEname
        {
            get;
            set;
        }

        public virtual string PsComment
        {
            get;
            set;
        }

        public virtual string PsMn
        {
            get;
            set;
        }

        public virtual string PsIden
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;

            return Equals(obj as IHrmPosition);
		}

        public virtual bool Equals(IHrmPosition obj)
		{
			if (obj == null) return false;

			if (Equals(Id, obj.Id) == false) return false;
            if (Equals(PsTname, obj.PsTname) == false) return false;
            if (Equals(PsEname, obj.PsEname) == false) return false;
            if (Equals(PsComment, obj.PsComment) == false) return false;
            if (Equals(PsMn, obj.PsMn) == false) return false;
            if (Equals(PsIden, obj.PsIden) == false) return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;
			
            result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
            result = (result * 397) ^ (PsTname != null ? PsTname.GetHashCode() : 0);
            result = (result * 397) ^ (PsEname != null ? PsEname.GetHashCode() : 0);
            result = (result * 397) ^ (PsComment != null ? PsComment.GetHashCode() : 0);
            result = (result * 397) ^ (PsMn != null ? PsMn.GetHashCode() : 0);
            result = (result * 397) ^ (PsIden != null ? PsIden.GetHashCode() : 0);

            return result;
		}
    }
}