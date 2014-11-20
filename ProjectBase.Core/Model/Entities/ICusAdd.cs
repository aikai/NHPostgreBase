using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Utils.Commons;
using ProjectBase.Utils.Components;
using ProjectBase.Core.Model;

namespace ProjectBase.Core.Model
{
    public interface ICusAdd
    {
        Guid Id { get; set; }
        //string AddrEaddress { get; set; }
        string AddrEmail { get; set; }
        string AddrEname { get; set; }
        string AddrEroad { get; set; }
        string AddrFax { get; set; }
        //string AddrTaddress { get; set; }
        string AddrTel { get; set; }
        string AddrTname { get; set; }
        string AddrTroad { get; set; }
        string AddrWww { get; set; }
        //string AddrZipcode { get; set; }
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }

        ICusMaster CusMaster { get; set; }
        ICusAddtype CusAddtype { get; set; }
        //ITambol Tambol { get; set; }
        //IAmphoe Amphoe { get; set; }
        //IProvince Province { get; set; }

        IAddressShort AddressShort { get; set; }

        bool Equals(object obj);
        bool Equals(ICusAdd obj);
        int GetHashCode();
    }
}
