using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProjectBase.Core.Model
{
    public enum RetentionType
    {
        [Description("None/ไม่ระบุ")]
        None = 0,

        [Description("เงินประกัน/Retention")]
        Retention = 1,

        [Description("แบงค์การันตี/Bank guarantee")]
        BankGuarantee  = 2
    }
}