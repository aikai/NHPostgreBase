using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoGen : IQuoGen
	{
		public QuoGen()
		{		
		}
        public virtual Guid Id
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
		public virtual double? GenCode
		{
			get;
			set;
		}
        public virtual double? GenRevise
        {
            get;
            set;
        }
		public virtual DateTime? GenDate
		{
			get;
			set;
		}
		public virtual string GenDep
		{
			get;
			set;
		}
		public virtual double? GenYear
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
        public virtual string ProjName
        {
            get;
            set;
        }
        public virtual IQuoMaster QuoMaster
        {
            get;
            set;
        }
        public virtual double? EstCost
        {
            get;
            set;
        }
        public virtual string Status
        {
            get;
            set;
        }
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IQuoGen);
		}
		
		public virtual bool Equals(IQuoGen obj)
		{
			if (obj == null) return false;

			if (Equals(CreateBy, obj.CreateBy) == false) return false;
			if (Equals(CreateDate, obj.CreateDate) == false) return false;
			if (Equals(GenCode, obj.GenCode) == false) return false;
			if (Equals(GenDate, obj.GenDate) == false) return false;
			if (Equals(GenDep, obj.GenDep) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
			if (Equals(GenYear, obj.GenYear) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
            if (Equals(ProjName, obj.ProjName) == false) return false;
            if (Equals(EstCost, obj.EstCost) == false) return false;
            if (Equals(Status, obj.Status) == false) return false;

            return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
			result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (GenCode != null ? GenCode.GetHashCode() : 0);
			result = (result * 397) ^ (GenDate != null ? GenDate.GetHashCode() : 0);
			result = (result * 397) ^ (GenDep != null ? GenDep.GetHashCode() : 0);
            result = (result * 397) ^ Id.GetHashCode();
			result = (result * 397) ^ (GenYear != null ? GenYear.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
            result = (result * 397) ^ (ProjName != null ? ProjName.GetHashCode() : 0);
            result = (result * 397) ^ (EstCost != null ? EstCost.GetHashCode() : 0);
            result = (result * 397) ^ (Status != null ? Status.GetHashCode() : 0);
            
			return result;
		}

        
    }
}