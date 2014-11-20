using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;
using ProjectBase.Utils.Components;

namespace ProjectBase.Data.Model
{
    [Serializable]
    public class AddressShort : IAddressShort
    {   
        public virtual string ThaiAddress { get; set; }
        public virtual string EngAddress { get; set; }

        public virtual ITambol Tambol { get; set; }
        public virtual IAmphoe Amphoe { get; set; }
        public virtual IProvince Province { get; set; }
        public virtual IValueValidation PostCode { get; set; }

        public string ToStringThai()
        {
            try
            {
                #region Add To String
                var sb = new StringBuilder();
                var flag = false;

                if (string.IsNullOrEmpty(ThaiAddress))
                {
                    flag = false;
                }
                else
                {
                    //sb.AppendFormat("บ้านเลขที่ {0}", ThaiAddress);
                    sb.AppendFormat("{0}", ThaiAddress);
                    flag = true;
                }

                if (null == Tambol)
                {
                    flag = false;
                }
                else
                {
                    if (flag)
                    {
                        sb.Append(" ");
                    }

                    //sb.AppendFormat("ตำบล/แขวง {0}", Amphoe.AmpTname);
                    sb.AppendFormat("{0}", Tambol.TamTname);

                    flag = true;
                }

                if (null == Amphoe)
                {
                    flag = false;
                }
                else
                {
                    if (flag)
                    {
                        sb.Append(" ");
                    }

                    //sb.AppendFormat("อำเภอ/เขต {0}", Amphoe.AmpTname);
                    sb.AppendFormat("{0}", Amphoe.AmpTname);

                    flag = true;
                }

                if (null == Province)
                {
                    flag = false;
                }
                else
                {
                    if (flag)
                    {
                        sb.Append(" ");
                    }

                    //sb.AppendFormat("จังหวัด {0}", Province.ProvTname);
                    sb.AppendFormat("{0}", Province.ProvTname);
                    flag = true;
                }

                if (null != PostCode)
                {
                    if (flag)
                    {
                        sb.Append(" ");
                    }

                    //sb.AppendFormat("รหัสไปรษณีย์ {0}", PostCode.ToString());
                    sb.AppendFormat("{0}", PostCode.ToString());
                }

                return sb.ToString();
                #endregion
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        public string ToStringEng()
        {
            try
            {
                #region Add To String
                var sb = new StringBuilder();
                var flag = false;

                if (string.IsNullOrEmpty(EngAddress))
                {
                    flag = false;
                }
                else
                {
                    sb.AppendFormat("{0}", EngAddress);
                    flag = true;
                }

                if (null == Tambol)
                {
                    flag = false;
                }
                else
                {
                    if (flag)
                    {
                        sb.Append(" ");
                    }

                    sb.AppendFormat("{0}", Tambol.TamEname);
                    flag = true;
                }

                if (null == Amphoe)
                {
                    flag = false;
                }
                else
                {
                    if (flag)
                    {
                        sb.Append(" ");
                    }

                    sb.AppendFormat("{0}", Amphoe.AmpEname);
                    flag = true;
                }

                if (null == Province)
                {
                    flag = false;
                }
                else
                {
                    if (flag)
                    {
                        sb.Append(" ");
                    }

                    sb.AppendFormat("{0}", Province.ProvEname);
                    flag = true;
                }

                if (null != PostCode)
                {
                    if (flag)
                    {
                        sb.Append(" ");
                    }

                    sb.AppendFormat("{0}", PostCode.ToString());
                }

                return sb.ToString();
                #endregion
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        /// <summary>
        /// Default Return Eng Format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            var flag = false;

            if (string.IsNullOrEmpty(EngAddress))
            {
                flag = false;
            }
            else
            {
                sb.AppendFormat("บ้านเลขที่ {0}", EngAddress);
                flag = true;
            }

            if (null == Tambol)
            {
                flag = false;
            }
            else
            {
                if (flag)
                {
                    sb.Append(" ");
                }

                sb.AppendFormat("ตำบล/แขวง {0}", Amphoe.AmpTname);
                flag = true;
            }

            if (null == Amphoe)
            {
                flag = false;
            }
            else
            {
                if (flag)
                {
                    sb.Append(" ");
                }

                sb.AppendFormat("อำเภอ/เขต {0}", Amphoe.AmpTname);
                flag = true;
            }

            if (null == Province)
            {
                flag = false;
            }
            else
            {
                if (flag)
                {
                    sb.Append(" ");
                }

                sb.AppendFormat("จังหวัด {0}", Province.ProvTname);
                flag = true;
            }

            if (null != PostCode)
            {
                if (flag)
                {
                    sb.Append(" ");
                }

                sb.AppendFormat("รหัสไปรษณีย์ {0}", PostCode.ToString());
            }

            return sb.ToString();
        }

    }
}
