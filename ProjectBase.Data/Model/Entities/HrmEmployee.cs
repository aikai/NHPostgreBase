using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class HrmEmployee : IHrmEmployee
	{
		public HrmEmployee()
		{
            //AppControls = new Iesi.Collections.Generic.HashedSet<IAppControl>();
            //HrmSigns = new Iesi.Collections.Generic.HashedSet<IHrmSign>();
		}
		public virtual string AddTimeManual
		{
			get;
			set;
		}
		public virtual double? DeptId
		{
			get;
			set;
		}
		public virtual string DeptOrg
		{
			get;
			set;
		}
        public virtual string EmpAddress
        {
            get;
            set;
        }
        public virtual string EmpAddress1
        {
            get;
            set;
        }
        public virtual string EmpAmp
        {
            get;
            set;
        }
        public virtual string EmpAmp1
        {
            get;
            set;
        }
        public virtual DateTime? EmpBegindate
        {
            get;
            set;
        }
        public virtual DateTime? EmpBorndate
        {
            get;
            set;
        }
        public virtual string EmpBornlocation
        {
            get;
            set;
        }
        public virtual string EmpBoss
        {
            get;
            set;
        }
        public virtual double? EmpChild
        {
            get;
            set;
        }
        public virtual string EmpCityId
        {
            get;
            set;
        }
		public virtual byte[] EmpCv
		{
			get;
			set;
		}
		public virtual string EmpCvExten
		{
			get;
			set;
		}
		public virtual string EmpDel
		{
			get;
			set;
		}
		public virtual DateTime? EmpDriveEnd
		{
			get;
			set;
		}
		public virtual string EmpDriveLicence
		{
			get;
			set;
		}
		public virtual string EmpDriveType
		{
			get;
			set;
		}
		public virtual string EmpEmail
		{
			get;
			set;
		}
		public virtual DateTime? EmpEndcontact
		{
			get;
			set;
		}
		public virtual DateTime? EmpEnddate
		{
			get;
			set;
		}
		public virtual string EmpEngname
		{
			get;
			set;
		}
		public virtual float? EmpHigh
		{
			get;
			set;
		}
		public virtual string EmpHospital
		{
			get;
			set;
		}
		public virtual string Id
		{
			get;
			set;
		}
		public virtual string EmpInten
		{
			get;
			set;
		}
		public virtual double? EmpLangr0
		{
			get;
			set;
		}
		public virtual double? EmpLangr1
		{
			get;
			set;
		}
		public virtual double? EmpLangr2
		{
			get;
			set;
		}
		public virtual double? EmpLangt0
		{
			get;
			set;
		}
		public virtual double? EmpLangt1
		{
			get;
			set;
		}
		public virtual double? EmpLangt2
		{
			get;
			set;
		}
		public virtual double? EmpLangw0
		{
			get;
			set;
		}
		public virtual double? EmpLangw1
		{
			get;
			set;
		}
		public virtual double? EmpLangw2
		{
			get;
			set;
		}
		public virtual string EmpMarry
		{
			get;
			set;
		}
		public virtual string EmpMobile
		{
			get;
			set;
		}
		public virtual string EmpNationality
		{
			get;
			set;
		}
		public virtual string EmpNick
		{
			get;
			set;
		}
		public virtual string EmpPassword
		{
			get;
			set;
		}
		public virtual byte[] EmpPic
		{
			get;
			set;
		}
        public virtual string EmpPicFlag
        {
            get;
            set;
        }
        public virtual string EmpPlace
        {
            get;
            set;
        }
        public virtual string EmpProv
        {
            get;
            set;
        }
        public virtual string EmpProv1
        {
            get;
            set;
        }
        public virtual string EmpReligion
        {
            get;
            set;
        }
        public virtual string EmpRoad
        {
            get;
            set;
        }
        public virtual string EmpRoad1
        {
            get;
            set;
        }
        public virtual string EmpSex
        {
            get;
            set;
        }
        public virtual string EmpSkill
        {
            get;
            set;
        }
        public virtual string EmpSlr
        {
            get;
            set;
        }
        public virtual string EmpSociePlace
        {
            get;
            set;
        }
        public virtual string EmpSocietyId
        {
            get;
            set;
        }
        public virtual string EmpSoi
        {
            get;
            set;
        }
        public virtual string EmpSoi1
        {
            get;
            set;
        }
        public virtual double? EmpSoilders0
        {
            get;
            set;
        }
        public virtual double? EmpSoilders1
        {
            get;
            set;
        }
        public virtual double? EmpSoilders2
        {
            get;
            set;
        }
        public virtual double? EmpSoilders3
        {
            get;
            set;
        }
		public virtual string EmpSoildersdetail
		{
			get;
			set;
		}
		public virtual DateTime? EmpStart
		{
			get;
			set;
		}
		public virtual string EmpStatus
		{
			get;
			set;
		}
		public virtual double? EmpStudychild
		{
			get;
			set;
		}
		public virtual string EmpTableNo
		{
			get;
			set;
		}
		public virtual string EmpTam
		{
			get;
			set;
		}
		public virtual string EmpTam1
		{
			get;
			set;
		}
		public virtual string EmpTelFax
		{
			get;
			set;
		}
		public virtual string EmpTelFax1
		{
			get;
			set;
		}
		public virtual string EmpThainame
		{
			get;
			set;
		}
		public virtual float? EmpWeight
		{
			get;
			set;
		}
		public virtual double? PsId
		{
			get;
			set;
		}

        //public virtual Iesi.Collections.Generic.ISet<IAppControl> AppControls
        //{
        //    get;
        //    set;
        //}

        public virtual IHrmSign HrmSign { get; set; }
        //public virtual Iesi.Collections.Generic.ISet<IHrmSign> HrmSigns { get; set; }

        public virtual IHrmPosition HrmPosition { get; set; }

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as IHrmEmployee);
		}
		
		public virtual bool Equals(IHrmEmployee obj)
		{
			if (obj == null) return false;

			if (Equals(AddTimeManual, obj.AddTimeManual) == false) return false;
			if (Equals(DeptId, obj.DeptId) == false) return false;
			if (Equals(DeptOrg, obj.DeptOrg) == false) return false;
			if (Equals(EmpAddress, obj.EmpAddress) == false) return false;
			if (Equals(EmpAddress1, obj.EmpAddress1) == false) return false;
			if (Equals(EmpAmp, obj.EmpAmp) == false) return false;
			if (Equals(EmpAmp1, obj.EmpAmp1) == false) return false;
			if (Equals(EmpBegindate, obj.EmpBegindate) == false) return false;
			if (Equals(EmpBorndate, obj.EmpBorndate) == false) return false;
			if (Equals(EmpBornlocation, obj.EmpBornlocation) == false) return false;
			if (Equals(EmpBoss, obj.EmpBoss) == false) return false;
			if (Equals(EmpChild, obj.EmpChild) == false) return false;
			if (Equals(EmpCityId, obj.EmpCityId) == false) return false;
			if (Equals(EmpCv, obj.EmpCv) == false) return false;
			if (Equals(EmpCvExten, obj.EmpCvExten) == false) return false;
			if (Equals(EmpDel, obj.EmpDel) == false) return false;
			if (Equals(EmpDriveEnd, obj.EmpDriveEnd) == false) return false;
			if (Equals(EmpDriveLicence, obj.EmpDriveLicence) == false) return false;
			if (Equals(EmpDriveType, obj.EmpDriveType) == false) return false;
			if (Equals(EmpEmail, obj.EmpEmail) == false) return false;
			if (Equals(EmpEndcontact, obj.EmpEndcontact) == false) return false;
			if (Equals(EmpEnddate, obj.EmpEnddate) == false) return false;
			if (Equals(EmpEngname, obj.EmpEngname) == false) return false;
			if (Equals(EmpHigh, obj.EmpHigh) == false) return false;
			if (Equals(EmpHospital, obj.EmpHospital) == false) return false;
            if (Equals(Id, obj.Id) == false) return false;
			if (Equals(EmpInten, obj.EmpInten) == false) return false;
			if (Equals(EmpLangr0, obj.EmpLangr0) == false) return false;
			if (Equals(EmpLangr1, obj.EmpLangr1) == false) return false;
			if (Equals(EmpLangr2, obj.EmpLangr2) == false) return false;
			if (Equals(EmpLangt0, obj.EmpLangt0) == false) return false;
			if (Equals(EmpLangt1, obj.EmpLangt1) == false) return false;
			if (Equals(EmpLangt2, obj.EmpLangt2) == false) return false;
			if (Equals(EmpLangw0, obj.EmpLangw0) == false) return false;
			if (Equals(EmpLangw1, obj.EmpLangw1) == false) return false;
			if (Equals(EmpLangw2, obj.EmpLangw2) == false) return false;
			if (Equals(EmpMarry, obj.EmpMarry) == false) return false;
			if (Equals(EmpMobile, obj.EmpMobile) == false) return false;
			if (Equals(EmpNationality, obj.EmpNationality) == false) return false;
			if (Equals(EmpNick, obj.EmpNick) == false) return false;
			if (Equals(EmpPassword, obj.EmpPassword) == false) return false;
			if (Equals(EmpPic, obj.EmpPic) == false) return false;
			if (Equals(EmpPicFlag, obj.EmpPicFlag) == false) return false;
			if (Equals(EmpPlace, obj.EmpPlace) == false) return false;
			if (Equals(EmpProv, obj.EmpProv) == false) return false;
			if (Equals(EmpProv1, obj.EmpProv1) == false) return false;
			if (Equals(EmpReligion, obj.EmpReligion) == false) return false;
			if (Equals(EmpRoad, obj.EmpRoad) == false) return false;
			if (Equals(EmpRoad1, obj.EmpRoad1) == false) return false;
			if (Equals(EmpSex, obj.EmpSex) == false) return false;
			if (Equals(EmpSkill, obj.EmpSkill) == false) return false;
			if (Equals(EmpSlr, obj.EmpSlr) == false) return false;
			if (Equals(EmpSociePlace, obj.EmpSociePlace) == false) return false;
			if (Equals(EmpSocietyId, obj.EmpSocietyId) == false) return false;
			if (Equals(EmpSoi, obj.EmpSoi) == false) return false;
			if (Equals(EmpSoi1, obj.EmpSoi1) == false) return false;
			if (Equals(EmpSoilders0, obj.EmpSoilders0) == false) return false;
			if (Equals(EmpSoilders1, obj.EmpSoilders1) == false) return false;
			if (Equals(EmpSoilders2, obj.EmpSoilders2) == false) return false;
			if (Equals(EmpSoilders3, obj.EmpSoilders3) == false) return false;
			if (Equals(EmpSoildersdetail, obj.EmpSoildersdetail) == false) return false;
			if (Equals(EmpStart, obj.EmpStart) == false) return false;
			if (Equals(EmpStatus, obj.EmpStatus) == false) return false;
			if (Equals(EmpStudychild, obj.EmpStudychild) == false) return false;
			if (Equals(EmpTableNo, obj.EmpTableNo) == false) return false;
			if (Equals(EmpTam, obj.EmpTam) == false) return false;
			if (Equals(EmpTam1, obj.EmpTam1) == false) return false;
			if (Equals(EmpTelFax, obj.EmpTelFax) == false) return false;
			if (Equals(EmpTelFax1, obj.EmpTelFax1) == false) return false;
			if (Equals(EmpThainame, obj.EmpThainame) == false) return false;
			if (Equals(EmpWeight, obj.EmpWeight) == false) return false;
			if (Equals(PsId, obj.PsId) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (AddTimeManual != null ? AddTimeManual.GetHashCode() : 0);
			result = (result * 397) ^ (DeptId != null ? DeptId.GetHashCode() : 0);
			result = (result * 397) ^ (DeptOrg != null ? DeptOrg.GetHashCode() : 0);
			result = (result * 397) ^ (EmpAddress != null ? EmpAddress.GetHashCode() : 0);
			result = (result * 397) ^ (EmpAddress1 != null ? EmpAddress1.GetHashCode() : 0);
			result = (result * 397) ^ (EmpAmp != null ? EmpAmp.GetHashCode() : 0);
			result = (result * 397) ^ (EmpAmp1 != null ? EmpAmp1.GetHashCode() : 0);
			result = (result * 397) ^ (EmpBegindate != null ? EmpBegindate.GetHashCode() : 0);
			result = (result * 397) ^ (EmpBorndate != null ? EmpBorndate.GetHashCode() : 0);
			result = (result * 397) ^ (EmpBornlocation != null ? EmpBornlocation.GetHashCode() : 0);
			result = (result * 397) ^ (EmpBoss != null ? EmpBoss.GetHashCode() : 0);
			result = (result * 397) ^ (EmpChild != null ? EmpChild.GetHashCode() : 0);
			result = (result * 397) ^ (EmpCityId != null ? EmpCityId.GetHashCode() : 0);
			result = (result * 397) ^ (EmpCv != null ? EmpCv.GetHashCode() : 0);
			result = (result * 397) ^ (EmpCvExten != null ? EmpCvExten.GetHashCode() : 0);
			result = (result * 397) ^ (EmpDel != null ? EmpDel.GetHashCode() : 0);
			result = (result * 397) ^ (EmpDriveEnd != null ? EmpDriveEnd.GetHashCode() : 0);
			result = (result * 397) ^ (EmpDriveLicence != null ? EmpDriveLicence.GetHashCode() : 0);
			result = (result * 397) ^ (EmpDriveType != null ? EmpDriveType.GetHashCode() : 0);
			result = (result * 397) ^ (EmpEmail != null ? EmpEmail.GetHashCode() : 0);
			result = (result * 397) ^ (EmpEndcontact != null ? EmpEndcontact.GetHashCode() : 0);
			result = (result * 397) ^ (EmpEnddate != null ? EmpEnddate.GetHashCode() : 0);
			result = (result * 397) ^ (EmpEngname != null ? EmpEngname.GetHashCode() : 0);
			result = (result * 397) ^ (EmpHigh != null ? EmpHigh.GetHashCode() : 0);
			result = (result * 397) ^ (EmpHospital != null ? EmpHospital.GetHashCode() : 0);
            result = (result * 397) ^ (Id != null ? Id.GetHashCode() : 0);
			result = (result * 397) ^ (EmpInten != null ? EmpInten.GetHashCode() : 0);
			result = (result * 397) ^ (EmpLangr0 != null ? EmpLangr0.GetHashCode() : 0);
			result = (result * 397) ^ (EmpLangr1 != null ? EmpLangr1.GetHashCode() : 0);
			result = (result * 397) ^ (EmpLangr2 != null ? EmpLangr2.GetHashCode() : 0);
			result = (result * 397) ^ (EmpLangt0 != null ? EmpLangt0.GetHashCode() : 0);
			result = (result * 397) ^ (EmpLangt1 != null ? EmpLangt1.GetHashCode() : 0);
			result = (result * 397) ^ (EmpLangt2 != null ? EmpLangt2.GetHashCode() : 0);
			result = (result * 397) ^ (EmpLangw0 != null ? EmpLangw0.GetHashCode() : 0);
			result = (result * 397) ^ (EmpLangw1 != null ? EmpLangw1.GetHashCode() : 0);
			result = (result * 397) ^ (EmpLangw2 != null ? EmpLangw2.GetHashCode() : 0);
			result = (result * 397) ^ (EmpMarry != null ? EmpMarry.GetHashCode() : 0);
			result = (result * 397) ^ (EmpMobile != null ? EmpMobile.GetHashCode() : 0);
			result = (result * 397) ^ (EmpNationality != null ? EmpNationality.GetHashCode() : 0);
			result = (result * 397) ^ (EmpNick != null ? EmpNick.GetHashCode() : 0);
			result = (result * 397) ^ (EmpPassword != null ? EmpPassword.GetHashCode() : 0);
			result = (result * 397) ^ (EmpPic != null ? EmpPic.GetHashCode() : 0);
			result = (result * 397) ^ (EmpPicFlag != null ? EmpPicFlag.GetHashCode() : 0);
			result = (result * 397) ^ (EmpPlace != null ? EmpPlace.GetHashCode() : 0);
			result = (result * 397) ^ (EmpProv != null ? EmpProv.GetHashCode() : 0);
			result = (result * 397) ^ (EmpProv1 != null ? EmpProv1.GetHashCode() : 0);
			result = (result * 397) ^ (EmpReligion != null ? EmpReligion.GetHashCode() : 0);
			result = (result * 397) ^ (EmpRoad != null ? EmpRoad.GetHashCode() : 0);
			result = (result * 397) ^ (EmpRoad1 != null ? EmpRoad1.GetHashCode() : 0);
			result = (result * 397) ^ (EmpSex != null ? EmpSex.GetHashCode() : 0);
			result = (result * 397) ^ (EmpSkill != null ? EmpSkill.GetHashCode() : 0);
			result = (result * 397) ^ (EmpSlr != null ? EmpSlr.GetHashCode() : 0);
			result = (result * 397) ^ (EmpSociePlace != null ? EmpSociePlace.GetHashCode() : 0);
			result = (result * 397) ^ (EmpSocietyId != null ? EmpSocietyId.GetHashCode() : 0);
			result = (result * 397) ^ (EmpSoi != null ? EmpSoi.GetHashCode() : 0);
			result = (result * 397) ^ (EmpSoi1 != null ? EmpSoi1.GetHashCode() : 0);
			result = (result * 397) ^ (EmpSoilders0 != null ? EmpSoilders0.GetHashCode() : 0);
			result = (result * 397) ^ (EmpSoilders1 != null ? EmpSoilders1.GetHashCode() : 0);
			result = (result * 397) ^ (EmpSoilders2 != null ? EmpSoilders2.GetHashCode() : 0);
			result = (result * 397) ^ (EmpSoilders3 != null ? EmpSoilders3.GetHashCode() : 0);
			result = (result * 397) ^ (EmpSoildersdetail != null ? EmpSoildersdetail.GetHashCode() : 0);
			result = (result * 397) ^ (EmpStart != null ? EmpStart.GetHashCode() : 0);
			result = (result * 397) ^ (EmpStatus != null ? EmpStatus.GetHashCode() : 0);
			result = (result * 397) ^ (EmpStudychild != null ? EmpStudychild.GetHashCode() : 0);
			result = (result * 397) ^ (EmpTableNo != null ? EmpTableNo.GetHashCode() : 0);
			result = (result * 397) ^ (EmpTam != null ? EmpTam.GetHashCode() : 0);
			result = (result * 397) ^ (EmpTam1 != null ? EmpTam1.GetHashCode() : 0);
			result = (result * 397) ^ (EmpTelFax != null ? EmpTelFax.GetHashCode() : 0);
			result = (result * 397) ^ (EmpTelFax1 != null ? EmpTelFax1.GetHashCode() : 0);
			result = (result * 397) ^ (EmpThainame != null ? EmpThainame.GetHashCode() : 0);
			result = (result * 397) ^ (EmpWeight != null ? EmpWeight.GetHashCode() : 0);
			result = (result * 397) ^ (PsId != null ? PsId.GetHashCode() : 0);
			return result;
		}
	}
}