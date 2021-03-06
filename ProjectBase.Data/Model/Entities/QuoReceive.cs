using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoReceive : IQuoReceive
	{
        public QuoReceive()
		{		
		}
        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual string Receive
        {
            get;
            set;
        }
        public virtual string ReceiveBy
        {
            get;
            set;
        }
        public virtual DateTime? ReceiveDate
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

            return Equals(obj as IQuoReceive);
		}

        public virtual bool Equals(IQuoReceive obj)
		{
			if (obj == null) return false;

            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(Receive, obj.Receive) == false) return false;
            if (Equals(ReceiveBy, obj.ReceiveBy) == false) return false;
            if (Equals(ReceiveDate, obj.ReceiveDate) == false) return false;
            if (Equals(QuoMaster, obj.QuoMaster) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            result = (result * 397) ^ Id.GetHashCode();

            result = (result * 397) ^ (Receive != null ? Receive.GetHashCode() : 0);
            result = (result * 397) ^ (ReceiveBy != null ? ReceiveBy.GetHashCode() : 0);
            result = (result * 397) ^ (ReceiveDate != null ? ReceiveDate.GetHashCode() : 0);
            result = (result * 397) ^ (QuoMaster != null ? QuoMaster.GetHashCode() : 0);
			return result;
		}
	}
}