using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IQuoTermJobLabDao : IDao<IQuoTermJobLab>
    {
        void Update(IList<IQuoTermJobLab> entities, IQuoTermpayment entity);
        IList<IQuoTermJobLab> GetFileByParent(IQuoTermpayment TermpaymentEntity, IQuoMaster entity);// รอแก้ไฟล์ของบัญชีใน Method นี้
    }
}
