using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoRetention : IQuoRetention
	{
		public QuoRetention()
		{		
		}
        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual RetentionType Type
        {
            get;
            set;
        }
        public virtual string Description
        {
            get;
            set;
        }
        public virtual double? Money
        {
            get;
            set;
        }
        public virtual string Remark
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

        public virtual IQuoMaster QuoMaster
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IQuoRetention);
		}
		
		public virtual bool Equals(IQuoRetention obj)
		{
			if (obj == null) return false;

            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(Type, obj.Type) == false) return false;
            if (Equals(Description, obj.Description) == false) return false;
            if (Equals(Money, obj.Money) == false) return false;
            if (Equals(CreateBy, obj.CreateBy) == false) return false;
            if (Equals(CreateDate, obj.CreateDate) == false) return false;
            if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
            if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
            if (Equals(QuoMaster, obj.QuoMaster) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            result = (result * 397) ^ Id.GetHashCode();

            result = (result * 397) ^ (Type != null ? Type.GetHashCode() : 0);
            result = (result * 397) ^ (Description != null ? Description.GetHashCode() : 0);
            result = (result * 397) ^ (Money != null ? Money.GetHashCode() : 0);
            result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
            result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
            result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
            result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
            result = (result * 397) ^ (QuoMaster != null ? QuoMaster.GetHashCode() : 0);
			return result;
		}
	}
}