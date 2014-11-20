using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;
using ProjectBase.Core.Model;

namespace ProjectBase.Core.Model
{
    public interface ICusMaster
    {
        Guid Id { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string CusCode { get; set; }
        string CusComment { get; set; }
        double? CusCredit { get; set; }
        string CusCreditDetail { get; set; }
        //string CusEaddress { get; set; }
        string CusEmail { get; set; }
        string CusEname { get; set; }
        string CusEroad { get; set; }
        string CusEtel { get; set; }
        string CusFax { get; set; }
        //string CusTaddress { get; set; }
        string CusTel { get; set; }
        string CusTname { get; set; }
        string CusTroad { get; set; }
        string CusTtel { get; set; }
        string CusWww { get; set; }
        //string CusZipcode { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        int CusIndex { get; set; }

        Iesi.Collections.Generic.ISet<ICusAdd> CusAdds { get; set; }
        Iesi.Collections.Generic.ISet<ICusCon> CusCons { get; set; }
        Iesi.Collections.Generic.ISet<ICusDue> CusDues { get; set; }

        ICusType CusType { get; set; }
        ICusBustype CusBustype { get; set; }
        ICusBusgroup CusBusgroup { get; set; }
        //ITambol Tambol { get; set; }
        //IAmphoe Amphoe { get; set; }
        //IProvince Province { get; set; }
        IAddressShort AddressShort { get; set; }

        bool Equals(object obj);
        bool Equals(ICusMaster obj);
        int GetHashCode();
    }
}
