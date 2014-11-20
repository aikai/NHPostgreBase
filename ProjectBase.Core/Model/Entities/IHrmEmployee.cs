using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;

namespace ProjectBase.Core.Model
{
    public interface IHrmEmployee
    {
        string Id { get; set; }
        string AddTimeManual { get; set; }
        double? DeptId { get; set; }
        string DeptOrg { get; set; }
        string EmpAddress { get; set; }
        string EmpAddress1 { get; set; }
        string EmpAmp { get; set; }
        string EmpAmp1 { get; set; }
        DateTime? EmpBegindate { get; set; }
        DateTime? EmpBorndate { get; set; }
        string EmpBornlocation { get; set; }
        string EmpBoss { get; set; }
        double? EmpChild { get; set; }
        string EmpCityId { get; set; }
        byte[] EmpCv { get; set; }
        string EmpCvExten { get; set; }
        string EmpDel { get; set; }
        DateTime? EmpDriveEnd { get; set; }
        string EmpDriveLicence { get; set; }
        string EmpDriveType { get; set; }
        string EmpEmail { get; set; }
        DateTime? EmpEndcontact { get; set; }
        DateTime? EmpEnddate { get; set; }
        string EmpEngname { get; set; }
        float? EmpHigh { get; set; }
        string EmpHospital { get; set; }
        string EmpInten { get; set; }
        double? EmpLangr0 { get; set; }
        double? EmpLangr1 { get; set; }
        double? EmpLangr2 { get; set; }
        double? EmpLangt0 { get; set; }
        double? EmpLangt1 { get; set; }
        double? EmpLangt2 { get; set; }
        double? EmpLangw0 { get; set; }
        double? EmpLangw1 { get; set; }
        double? EmpLangw2 { get; set; }
        string EmpMarry { get; set; }
        string EmpMobile { get; set; }
        string EmpNationality { get; set; }
        string EmpNick { get; set; }
        string EmpPassword { get; set; }
        byte[] EmpPic { get; set; }
        string EmpPicFlag { get; set; }
        string EmpPlace { get; set; }
        string EmpProv { get; set; }
        string EmpProv1 { get; set; }
        string EmpReligion { get; set; }
        string EmpRoad { get; set; }
        string EmpRoad1 { get; set; }
        string EmpSex { get; set; }
        string EmpSkill { get; set; }
        string EmpSlr { get; set; }
        string EmpSociePlace { get; set; }
        string EmpSocietyId { get; set; }
        string EmpSoi { get; set; }
        string EmpSoi1 { get; set; }
        double? EmpSoilders0 { get; set; }
        double? EmpSoilders1 { get; set; }
        double? EmpSoilders2 { get; set; }
        double? EmpSoilders3 { get; set; }
        string EmpSoildersdetail { get; set; }
        DateTime? EmpStart { get; set; }
        string EmpStatus { get; set; }
        double? EmpStudychild { get; set; }
        string EmpTableNo { get; set; }
        string EmpTam { get; set; }
        string EmpTam1 { get; set; }
        string EmpTelFax { get; set; }
        string EmpTelFax1 { get; set; }
        string EmpThainame { get; set; }
        float? EmpWeight { get; set; }
        double? PsId { get; set; }

        //Iesi.Collections.Generic.ISet<IAppControl> AppControls { get; set; }
        //Iesi.Collections.Generic.ISet<IHrmSign> HrmSigns { get; set; }
        IHrmSign HrmSign { get; set; }

        IHrmPosition HrmPosition { get; set; }

        bool Equals(object obj);
        bool Equals(IHrmEmployee obj);
        int GetHashCode();
    }
}
