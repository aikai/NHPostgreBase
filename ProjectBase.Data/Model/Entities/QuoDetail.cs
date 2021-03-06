using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
    [Serializable]
    public partial class QuoDetail : IQuoDetail
    {
        public QuoDetail()
        {
            
        }

        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual int? QdeItem
        {
            get;
            set;
        }
        public virtual double? QdeCost
        {
            get;
            set;
        }
        public virtual string QdeDesc
        {
            get;
            set;
        }
        public virtual double? QdeQuantity
        {
            get;
            set;
        }
        public virtual double? QdeTotal
        {
            get;
            set;
        }
        public virtual int? Index
        {
            get;
            set;
        }

        public virtual IQuoMaster QuoMaster
        {
            get;
            set;
        }
        public virtual IUnit Unit
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return Equals(obj as IQuoDetail);
        }

        public virtual bool Equals(IQuoDetail obj)
        {
            if (obj == null) return false;

            if (Equals(Id, obj.Id) == false) return false;
            if (Equals(QdeCost, obj.QdeCost) == false) return false;
            if (Equals(QdeDesc, obj.QdeDesc) == false) return false;
            if (Equals(QdeQuantity, obj.QdeQuantity) == false) return false;
            if (Equals(QdeTotal, obj.QdeTotal) == false) return false;
            if (Equals(QuoMaster, obj.QuoMaster) == false) return false;
            if (Equals(Unit, obj.Unit) == false) return false;

            return true;
        }

        public override int GetHashCode()
        {
            int result = 1;

            result = (result * 397) ^ Id.GetHashCode();
            result = (result * 397) ^ (QdeCost != null ? QdeCost.GetHashCode() : 0);
            result = (result * 397) ^ (QdeDesc != null ? QdeDesc.GetHashCode() : 0);
            result = (result * 397) ^ (QdeQuantity != null ? QdeQuantity.GetHashCode() : 0);
            result = (result * 397) ^ (QdeTotal != null ? QdeTotal.GetHashCode() : 0);
            result = (result * 397) ^ (QuoMaster != null ? QuoMaster.GetHashCode() : 0);
            result = (result * 397) ^ (Unit != null ? Unit.GetHashCode() : 0);

            return result;
        }
    }
}