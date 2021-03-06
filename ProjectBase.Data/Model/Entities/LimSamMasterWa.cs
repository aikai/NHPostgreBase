using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class LimSamMasterWa : ILimSamMasterWa
	{
		public LimSamMasterWa()
		{
			LimSamDetailWas = new Iesi.Collections.Generic.HashedSet<ILimSamDetailWa>();		
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
		public virtual string SamComment
		{
			get;
			set;
		}
		public virtual string SamEmp
		{
			get;
			set;
		}
		public virtual Guid Id
		{
			get;
			set;
		}
		public virtual string SamLocation
		{
			get;
			set;
		}
		public virtual string SamNumber
		{
			get;
			set;
		}
		public virtual string SamPo
		{
			get;
			set;
		}
		public virtual string SamQuo
		{
			get;
			set;
		}
		public virtual DateTime? SamRecDate
		{
			get;
			set;
		}
		public virtual string SamRecTime
		{
			get;
			set;
		}
		public virtual string SamSampling
		{
			get;
			set;
		}
		public virtual string SamWitness
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
		public virtual Iesi.Collections.Generic.ISet<ILimSamDetailWa> LimSamDetailWas
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ILimSamMasterWa);
		}
		
		public virtual bool Equals(ILimSamMasterWa obj)
		{
			if (obj == null) return false;

			if (Equals(CreateBy, obj.CreateBy) == false) return false;
			if (Equals(CreateDate, obj.CreateDate) == false) return false;
            if (Equals(QuoMaster, obj.QuoMaster) == false) return false;
			if (Equals(SamComment, obj.SamComment) == false) return false;
			if (Equals(SamEmp, obj.SamEmp) == false) return false;
			if (Equals(Id, obj.Id) == false) return false;
			if (Equals(SamLocation, obj.SamLocation) == false) return false;
			if (Equals(SamNumber, obj.SamNumber) == false) return false;
			if (Equals(SamPo, obj.SamPo) == false) return false;
			if (Equals(SamQuo, obj.SamQuo) == false) return false;
			if (Equals(SamRecDate, obj.SamRecDate) == false) return false;
			if (Equals(SamRecTime, obj.SamRecTime) == false) return false;
			if (Equals(SamSampling, obj.SamSampling) == false) return false;
			if (Equals(SamWitness, obj.SamWitness) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
			result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
            result = (result * 397) ^ (QuoMaster != null ? QuoMaster.GetHashCode() : 0);
			result = (result * 397) ^ (SamComment != null ? SamComment.GetHashCode() : 0);
			result = (result * 397) ^ (SamEmp != null ? SamEmp.GetHashCode() : 0);
			result = (result * 397) ^ Id.GetHashCode();
			result = (result * 397) ^ (SamLocation != null ? SamLocation.GetHashCode() : 0);
			result = (result * 397) ^ (SamNumber != null ? SamNumber.GetHashCode() : 0);
			result = (result * 397) ^ (SamPo != null ? SamPo.GetHashCode() : 0);
			result = (result * 397) ^ (SamQuo != null ? SamQuo.GetHashCode() : 0);
			result = (result * 397) ^ (SamRecDate != null ? SamRecDate.GetHashCode() : 0);
			result = (result * 397) ^ (SamRecTime != null ? SamRecTime.GetHashCode() : 0);
			result = (result * 397) ^ (SamSampling != null ? SamSampling.GetHashCode() : 0);
			result = (result * 397) ^ (SamWitness != null ? SamWitness.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
			return result;
		}
	}
}