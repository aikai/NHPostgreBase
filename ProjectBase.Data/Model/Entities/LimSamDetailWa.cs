using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class LimSamDetailWa : ILimSamDetailWa
	{
		public LimSamDetailWa()
		{
			LimSamSubdetailWas = new Iesi.Collections.Generic.HashedSet<ILimSamSubdetailWa>();		
		}
        //public virtual Guid? CauId
        //{
        //    get;
        //    set;
        //}
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
		public virtual DateTime? SadAnalyseDate
		{
			get;
			set;
		}
		public virtual string SadAnaNum
		{
			get;
			set;
		}
		public virtual string SadAnaNumyear
		{
			get;
			set;
		}
		public virtual string SadComment
		{
			get;
			set;
		}
		public virtual bool? SadCon
		{
			get;
			set;
		}
		public virtual string SadFormat
		{
			get;
			set;
		}
		public virtual Guid Id
		{
			get;
			set;
		}
		public virtual string SadName
		{
			get;
			set;
		}
		public virtual DateTime? SadSaveDate
		{
			get;
			set;
		}
		public virtual string SadSaveTime
		{
			get;
			set;
		}
		public virtual bool? SadStatus
		{
			get;
			set;
		}
		public virtual int? SamItem
		{
			get;
			set;
		}
        //public virtual Guid? SrcId
        //{
        //    get;
        //    set;
        //}
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

        public virtual ILimGen LimGen
        {
            get;
            set;
        }
        public virtual ILimCaution LimCaution
        {
            get;
            set;
        }
        public virtual ILimSourceWa LimSourceWa
        {
            get;
            set;
        }
        public virtual ILimSamMasterWa LimSamMasterWa
        {
            get;
            set;
        }
		public virtual Iesi.Collections.Generic.ISet<ILimSamSubdetailWa> LimSamSubdetailWas
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ILimSamDetailWa);
		}
		
		public virtual bool Equals(ILimSamDetailWa obj)
		{
			if (obj == null) return false;

            //if (Equals(CauId, obj.CauId) == false) return false;
            if (Equals(LimCaution, obj.LimCaution) == false) return false;
			if (Equals(CreateBy, obj.CreateBy) == false) return false;
			if (Equals(CreateDate, obj.CreateDate) == false) return false;
			if (Equals(SadAnalyseDate, obj.SadAnalyseDate) == false) return false;
			if (Equals(SadAnaNum, obj.SadAnaNum) == false) return false;
			if (Equals(SadAnaNumyear, obj.SadAnaNumyear) == false) return false;
			if (Equals(SadComment, obj.SadComment) == false) return false;
			if (Equals(SadCon, obj.SadCon) == false) return false;
			if (Equals(SadFormat, obj.SadFormat) == false) return false;
			if (Equals(Id, obj.Id) == false) return false;
			if (Equals(SadName, obj.SadName) == false) return false;
			if (Equals(SadSaveDate, obj.SadSaveDate) == false) return false;
			if (Equals(SadSaveTime, obj.SadSaveTime) == false) return false;
			if (Equals(SadStatus, obj.SadStatus) == false) return false;
			if (Equals(SamItem, obj.SamItem) == false) return false;
            //if (Equals(SrcId, obj.SrcId) == false) return false;
            if (Equals(LimSourceWa, obj.LimSourceWa) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            //result = (result * 397) ^ (CauId != null ? CauId.GetHashCode() : 0);
            result = (result * 397) ^ (LimCaution != null ? LimCaution.GetHashCode() : 0);
			result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
			result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (SadAnalyseDate != null ? SadAnalyseDate.GetHashCode() : 0);
			result = (result * 397) ^ (SadAnaNum != null ? SadAnaNum.GetHashCode() : 0);
			result = (result * 397) ^ (SadAnaNumyear != null ? SadAnaNumyear.GetHashCode() : 0);
			result = (result * 397) ^ (SadComment != null ? SadComment.GetHashCode() : 0);
			result = (result * 397) ^ (SadCon != null ? SadCon.GetHashCode() : 0);
			result = (result * 397) ^ (SadFormat != null ? SadFormat.GetHashCode() : 0);
			result = (result * 397) ^ Id.GetHashCode();
			result = (result * 397) ^ (SadName != null ? SadName.GetHashCode() : 0);
			result = (result * 397) ^ (SadSaveDate != null ? SadSaveDate.GetHashCode() : 0);
			result = (result * 397) ^ (SadSaveTime != null ? SadSaveTime.GetHashCode() : 0);
			result = (result * 397) ^ (SadStatus != null ? SadStatus.GetHashCode() : 0);
			result = (result * 397) ^ (SamItem != null ? SamItem.GetHashCode() : 0);
            //result = (result * 397) ^ (SrcId != null ? SrcId.GetHashCode() : 0);
            result = (result * 397) ^ (LimSourceWa != null ? LimSourceWa.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
			return result;
		}
	}
}