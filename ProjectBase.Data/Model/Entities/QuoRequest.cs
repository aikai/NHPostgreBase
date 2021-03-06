using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoRequest : IQuoRequest
	{
        public QuoRequest()
		{		
		}
        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual bool? ReqPerson
        {
            get;
            set;
        }
        public virtual string ReqPersonDe
        {
            get;
            set;
        }

        public virtual bool? ReqTool
        {
            get;
            set;
        }
        public virtual string ReqToolDe
        {
            get;
            set;
        }
        public virtual bool? ReqChemical
        {
            get;
            set;
        }
        public virtual string ReqChemicalDe
        {
            get;
            set;
        }
        public virtual bool? ReqGlass
        {
            get;
            set;
        }
        public virtual string ReqGlassDe
        {
            get;
            set;
        }
        public virtual bool? ReqJob
        {
            get;
            set;
        }
        public virtual string ReqComment
        {
            get;
            set;
        }
        public virtual string ReqBy
        {
            get;
            set;
        }
        public virtual DateTime? ReqDate
        {
            get;
            set;
        }
        public virtual bool? IsDelete
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

            return Equals(obj as IQuoRequest);
		}

        public virtual bool Equals(IQuoRequest obj)
		{
			if (obj == null) return false;

            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(ReqPerson, obj.ReqPerson) == false) return false;
            if (Equals(ReqPersonDe, obj.ReqPersonDe) == false) return false;
            if (Equals(ReqTool, obj.ReqTool) == false) return false;
            if (Equals(ReqToolDe, obj.ReqToolDe) == false) return false;
            if (Equals(ReqChemical, obj.ReqChemical) == false) return false;
            if (Equals(ReqChemicalDe, obj.ReqChemicalDe) == false) return false;
            if (Equals(ReqGlass, obj.ReqGlass) == false) return false;
            if (Equals(ReqGlassDe, obj.ReqGlassDe) == false) return false;
            if (Equals(ReqJob, obj.ReqJob) == false) return false;
            if (Equals(ReqComment, obj.ReqComment) == false) return false;
            if (Equals(ReqBy, obj.ReqBy) == false) return false;
            if (Equals(ReqDate, obj.ReqDate) == false) return false;
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

            result = (result * 397) ^ (ReqPerson != null ? ReqPerson.GetHashCode() : 0);
            result = (result * 397) ^ (ReqPersonDe != null ? ReqPersonDe.GetHashCode() : 0);
            result = (result * 397) ^ (ReqTool != null ? ReqTool.GetHashCode() : 0);
            result = (result * 397) ^ (ReqToolDe != null ? ReqToolDe.GetHashCode() : 0);
            result = (result * 397) ^ (ReqChemical != null ? ReqChemical.GetHashCode() : 0);
            result = (result * 397) ^ (ReqChemicalDe != null ? ReqChemicalDe.GetHashCode() : 0);
            result = (result * 397) ^ (ReqGlass != null ? ReqGlass.GetHashCode() : 0);
            result = (result * 397) ^ (ReqGlassDe != null ? ReqGlassDe.GetHashCode() : 0);
            result = (result * 397) ^ (ReqJob != null ? ReqJob.GetHashCode() : 0);
            result = (result * 397) ^ (ReqComment != null ? ReqComment.GetHashCode() : 0);
            result = (result * 397) ^ (ReqBy != null ? ReqBy.GetHashCode() : 0);
            result = (result * 397) ^ (ReqDate != null ? ReqDate.GetHashCode() : 0);
            result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
            result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
            result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
            result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);

            result = (result * 397) ^ (QuoMaster != null ? QuoMaster.GetHashCode() : 0);
			return result;
		}
	}
}