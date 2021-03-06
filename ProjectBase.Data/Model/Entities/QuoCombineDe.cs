using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class QuoCombineDe : IQuoCombineDe
	{
        public QuoCombineDe() { }

        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual string TjdAnalysis
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

        public virtual IQuoCombine QuoCombine
        {
            get;
            set;
        }
        public virtual IQuoTermRelate QuoTermRelate
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;

            return Equals(obj as IQuoCombineDe);
		}

        public virtual bool Equals(IQuoCombineDe obj)
		{
			if (obj == null) return false;

            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(TjdAnalysis, obj.TjdAnalysis) == false) return false;

            if (Equals(CreateBy, obj.CreateBy) == false) return false;
            if (Equals(CreateDate, obj.CreateDate) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;

            if (Equals(QuoCombine, obj.QuoCombine) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            result = (result * 397) ^ Id.GetHashCode();
            result = (result * 397) ^ (TjdAnalysis != null ? TjdAnalysis.GetHashCode() : 0);

            result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
            result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);

            result = (result * 397) ^ (QuoCombine != null ? QuoCombine.GetHashCode() : 0);
			return result;
		}
	}
}