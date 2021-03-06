using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class CusMaster : ICusMaster
	{
		public CusMaster()
		{
			CusAdds = new Iesi.Collections.Generic.HashedSet<ICusAdd>();
			CusCons = new Iesi.Collections.Generic.HashedSet<ICusCon>();
            CusDues = new Iesi.Collections.Generic.HashedSet<ICusDue>();
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
		public virtual string CusCode
		{
			get;
			set;
		}
		public virtual string CusComment
		{
			get;
			set;
		}
		public virtual double? CusCredit
		{
			get;
			set;
		}
		public virtual string CusCreditDetail
		{
			get;
			set;
		}
        //public virtual string CusEaddress
        //{
        //    get;
        //    set;
        //}
		public virtual string CusEmail
		{
			get;
			set;
		}
		public virtual string CusEname
		{
			get;
			set;
		}
		public virtual string CusEroad
		{
			get;
			set;
		}
		public virtual string CusEtel
		{
			get;
			set;
		}
		public virtual string CusFax
		{
			get;
			set;
		}
        //public virtual string CusTaddress
        //{
        //    get;
        //    set;
        //}
		public virtual string CusTel
		{
			get;
			set;
		}
		public virtual string CusTname
		{
			get;
			set;
		}
		public virtual string CusTroad
		{
			get;
			set;
		}
		public virtual string CusTtel
		{
			get;
			set;
		}
		public virtual string CusWww
		{
			get;
			set;
		}
        //public virtual string CusZipcode
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

        public virtual Iesi.Collections.Generic.ISet<ICusAdd> CusAdds
        {
            get;
            set;
        }
		public virtual Iesi.Collections.Generic.ISet<ICusCon> CusCons
		{
			get;
			set;
		}
        public virtual Iesi.Collections.Generic.ISet<ICusDue> CusDues
        {
            get;
            set;
        }
		public virtual ICusType CusType
		{
			get;
			set;
		}
        public virtual ICusBustype CusBustype
        {
            get;
            set;
        }
        public virtual ICusBusgroup CusBusgroup
        {
            get;
            set;
        }
        //public virtual ITambol Tambol
        //{
        //    get;
        //    set;
        //}
        //public virtual IAmphoe Amphoe
        //{
        //    get;
        //    set;
        //}
        //public virtual IProvince Province
        //{
        //    get;
        //    set;
        //}

        public virtual IAddressShort AddressShort
        {
            get;
            set;
        }

        public virtual int CusIndex
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ICusMaster);
		}
		
		public virtual bool Equals(ICusMaster obj)
		{
			if (obj == null) return false;

            //if (Equals(Amphoe, obj.Amphoe) == false) return false;
            //if (Equals(CusBusgroup, obj.CusBusgroup) == false) return false;
			if (Equals(CreateBy, obj.CreateBy) == false) return false;
			if (Equals(CreateDate, obj.CreateDate) == false) return false;
			if (Equals(CusCode, obj.CusCode) == false) return false;
			if (Equals(CusComment, obj.CusComment) == false) return false;
			if (Equals(CusCredit, obj.CusCredit) == false) return false;
			if (Equals(CusCreditDetail, obj.CusCreditDetail) == false) return false;
			//if (Equals(CusEaddress, obj.CusEaddress) == false) return false;
			if (Equals(CusEmail, obj.CusEmail) == false) return false;
			if (Equals(CusEname, obj.CusEname) == false) return false;
			if (Equals(CusEroad, obj.CusEroad) == false) return false;
			if (Equals(CusEtel, obj.CusEtel) == false) return false;
			if (Equals(CusFax, obj.CusFax) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
			//if (Equals(CusTaddress, obj.CusTaddress) == false) return false;
			if (Equals(CusTel, obj.CusTel) == false) return false;
			if (Equals(CusTname, obj.CusTname) == false) return false;
			if (Equals(CusTroad, obj.CusTroad) == false) return false;
			if (Equals(CusTtel, obj.CusTtel) == false) return false;
			if (Equals(CusWww, obj.CusWww) == false) return false;
			//if (Equals(CusZipcode, obj.CusZipcode) == false) return false;
            //if (Equals(Province, obj.Province) == false) return false;
            //if (Equals(Tambol, obj.Tambol) == false) return false;
			if (Equals(UpdateBy, obj.UpdateBy) == false) return false;
			if (Equals(UpdateDate, obj.UpdateDate) == false) return false;
            if (Equals(AddressShort, obj.AddressShort) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

            //result = (result * 397) ^ (Amphoe != null ? Amphoe.GetHashCode() : 0);
            //result = (result * 397) ^ (CusBusgroup != null ? CusBusgroup.GetHashCode() : 0);
			result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
			result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
			result = (result * 397) ^ (CusCode != null ? CusCode.GetHashCode() : 0);
			result = (result * 397) ^ (CusComment != null ? CusComment.GetHashCode() : 0);
			result = (result * 397) ^ (CusCredit != null ? CusCredit.GetHashCode() : 0);
			result = (result * 397) ^ (CusCreditDetail != null ? CusCreditDetail.GetHashCode() : 0);
            //result = (result * 397) ^ (CusEaddress != null ? CusEaddress.GetHashCode() : 0);
			result = (result * 397) ^ (CusEmail != null ? CusEmail.GetHashCode() : 0);
			result = (result * 397) ^ (CusEname != null ? CusEname.GetHashCode() : 0);
			result = (result * 397) ^ (CusEroad != null ? CusEroad.GetHashCode() : 0);
			result = (result * 397) ^ (CusEtel != null ? CusEtel.GetHashCode() : 0);
			result = (result * 397) ^ (CusFax != null ? CusFax.GetHashCode() : 0);
            result = (result * 397) ^ Id.GetHashCode();
            //result = (result * 397) ^ (CusTaddress != null ? CusTaddress.GetHashCode() : 0);
			result = (result * 397) ^ (CusTel != null ? CusTel.GetHashCode() : 0);
			result = (result * 397) ^ (CusTname != null ? CusTname.GetHashCode() : 0);
			result = (result * 397) ^ (CusTroad != null ? CusTroad.GetHashCode() : 0);
			result = (result * 397) ^ (CusTtel != null ? CusTtel.GetHashCode() : 0);
			result = (result * 397) ^ (CusWww != null ? CusWww.GetHashCode() : 0);
            //result = (result * 397) ^ (CusZipcode != null ? CusZipcode.GetHashCode() : 0);
            //result = (result * 397) ^ (Province != null ? Province.GetHashCode() : 0);
            //result = (result * 397) ^ (Tambol != null ? Tambol.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
			result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
            result = (result * 397) ^ (AddressShort != null ? AddressShort.GetHashCode() : 0);
			return result;
		}
    }
}