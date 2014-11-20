using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProjectBase.Core.Model
{
    public enum QuoFileType
    {
        [Description("None/ไม่ระบุ")]
        None = 0,

        [Description("Quotation")]
        Quotation = 1,

        [Description("Purchase Order (PO)")]
        PurchaseOrder = 2,

        [Description("Report")]
        Report = 3,

        [Description("Other/อื่นๆ")]
        Other = 4
    }
}