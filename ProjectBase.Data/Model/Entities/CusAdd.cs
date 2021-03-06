using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class CusAdd : ICusAdd
	{
		public CusAdd()
		{		
		}
        public virtual Guid Id
        {
            get;
            set;
        }
        //public virtual string AddrEaddress
        //{
        //    get;
        //    set;
        //}
        public virtual string AddrEmail
        {
            get;
            set;
        }
        public virtual string AddrEname
        {
            get;
            set;
        }
        public virtual string AddrEroad
        {
            get;
            set;
        }
        public virtual string AddrFax
        {
            get;
            set;
        }
        //public virtual string AddrTaddress
        //{
        //    get;
        //    set;
        //}
        public virtual string AddrTel
        {
            get;
            set;
        }
        public virtual string AddrTname
        {
            get;
            set;
        }
        public virtual string AddrTroad
        {
            get;
            set;
        }
        public virtual string AddrWww
        {
            get;
            set;
        }
        //public virtual string AddrZipcode
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

        public virtual ICusMaster CusMaster
        {
            get;
            set;
        }
        public virtual ICusAddtype CusAddtype
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
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return Equals(obj as ICusAdd);
        }

        public virtual bool Equals(ICusAdd obj)
        {
            if (obj == null) return false;

            //if (Equals(AddrEaddress, obj.AddrEaddress) == false) return false;
            if (Equals(AddrEmail, obj.AddrEmail) == false) return false;
            if (Equals(AddrEname, obj.AddrEname) == false) return false;
            if (Equals(AddrEroad, obj.AddrEroad) == false) return false;
            if (Equals(AddrFax, obj.AddrFax) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
            //if (Equals(AddrTaddress, obj.AddrTaddress) == false) return false;
            if (Equals(AddrTel, obj.AddrTel) == false) return false;
            if (Equals(AddrTname, obj.AddrTname) == false) return false;
            if (Equals(AddrTroad, obj.AddrTroad) == false) return false;
            if (Equals(AddrWww, obj.AddrWww) == false) return false;
            //if (Equals(AddrZipcode, obj.AddrZipcode) == false) return false;
            //if (Equals(Amphoe, obj.Amphoe) == false) return false;
            if (Equals(CreateBy, obj.CreateBy) == false) return false;
            if (Equals(CreateDate, obj.CreateDate) == false) return false;
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

            //result = (result * 397) ^ (AddrEaddress != null ? AddrEaddress.GetHashCode() : 0);
            result = (result * 397) ^ (AddrEmail != null ? AddrEmail.GetHashCode() : 0);
            result = (result * 397) ^ (AddrEname != null ? AddrEname.GetHashCode() : 0);
            result = (result * 397) ^ (AddrEroad != null ? AddrEroad.GetHashCode() : 0);
            result = (result * 397) ^ (AddrFax != null ? AddrFax.GetHashCode() : 0);
            result = (result * 397) ^ Id.GetHashCode();
            //result = (result * 397) ^ (AddrTaddress != null ? AddrTaddress.GetHashCode() : 0);
            result = (result * 397) ^ (AddrTel != null ? AddrTel.GetHashCode() : 0);
            result = (result * 397) ^ (AddrTname != null ? AddrTname.GetHashCode() : 0);
            result = (result * 397) ^ (AddrTroad != null ? AddrTroad.GetHashCode() : 0);
            result = (result * 397) ^ (AddrWww != null ? AddrWww.GetHashCode() : 0);
            //result = (result * 397) ^ (AddrZipcode != null ? AddrZipcode.GetHashCode() : 0);
            //result = (result * 397) ^ (Amphoe != null ? Amphoe.GetHashCode() : 0);
            result = (result * 397) ^ (CreateBy != null ? CreateBy.GetHashCode() : 0);
            result = (result * 397) ^ (CreateDate != null ? CreateDate.GetHashCode() : 0);
            //result = (result * 397) ^ (DueId != null ? DueId.GetHashCode() : 0);
            //result = (result * 397) ^ (Province != null ? Province.GetHashCode() : 0);
            //result = (result * 397) ^ (Tambol != null ? Tambol.GetHashCode() : 0);
            result = (result * 397) ^ (UpdateBy != null ? UpdateBy.GetHashCode() : 0);
            result = (result * 397) ^ (UpdateDate != null ? UpdateDate.GetHashCode() : 0);
            result = (result * 397) ^ (AddressShort != null ? AddressShort.GetHashCode() : 0);
            return result;
        }




        
    }
}