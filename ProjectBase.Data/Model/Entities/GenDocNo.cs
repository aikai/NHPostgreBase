using System;
using System.Collections.Generic;
using ProjectBase.Core.Domain.Entities;

namespace ProjectBase.Data.Model.Entities
{
	[Serializable]
    public partial class GenDocNo : IGenDocNo
	{
        public GenDocNo()
		{		
		}
        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual string Prefix
        {
            get;
            set;
        }
        public virtual int Year
        {
            get;
            set;
        }
        public virtual int Month
        {
            get;
            set;
        }
        public virtual int InctNum
        {
            get;
            set;
        }
        public virtual string DocNo
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

            return Equals(obj as IGenDocNo);
		}

        public virtual bool Equals(IGenDocNo obj)
		{
			if (obj == null) return false;

            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(Prefix, obj.Prefix) == false) return false;
            if (Equals(Year, obj.Year) == false) return false;
            if (Equals(Month, obj.Month) == false) return false;
            if (Equals(InctNum, obj.InctNum) == false) return false;
            if (Equals(DocNo, obj.DocNo) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            result = (result * 397) ^ Id.GetHashCode();

            result = (result * 397) ^ (Prefix != null ? Prefix.GetHashCode() : 0);
            result = (result * 397) ^ Year.GetHashCode();
            result = (result * 397) ^ Month.GetHashCode();
            result = (result * 397) ^ InctNum.GetHashCode();
            result = (result * 397) ^ (DocNo != null ? DocNo.GetHashCode() : 0);
			return result;
		}
	}
}