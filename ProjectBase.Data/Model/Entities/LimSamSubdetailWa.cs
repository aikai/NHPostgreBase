using System;
using System.Collections.Generic;
using ProjectBase.Core.Model;

namespace ProjectBase.Data.Model
{
	[Serializable]
    public partial class LimSamSubdetailWa : ILimSamSubdetailWa
	{
		public LimSamSubdetailWa()
		{		
		}
		public virtual string SasAsetic1
		{
			get;
			set;
		}
		public virtual string SasAsetic250
		{
			get;
			set;
		}
		public virtual string SasAsetic500
		{
			get;
			set;
		}
		public virtual string SasContainer
		{
			get;
			set;
		}
		public virtual string SasFosface
		{
			get;
			set;
		}
		public virtual string SasGlass1
		{
			get;
			set;
		}
		public virtual string SasGlass250
		{
			get;
			set;
		}
		public virtual string SasGlass425
		{
			get;
			set;
		}
		public virtual Guid Id
		{
			get;
			set;
		}
		public virtual int? SasItem
		{
			get;
			set;
		}
		public virtual string SasSterite
		{
			get;
			set;
		}
		public virtual ILimSamDetailWa LimSamDetailWa
		{
			get;
			set;
		}
		public virtual ILimSamPreserv LimSamPreserv
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ILimSamSubdetailWa);
		}
		
		public virtual bool Equals(ILimSamSubdetailWa obj)
		{
			if (obj == null) return false;

			if (Equals(SasAsetic1, obj.SasAsetic1) == false) return false;
			if (Equals(SasAsetic250, obj.SasAsetic250) == false) return false;
			if (Equals(SasAsetic500, obj.SasAsetic500) == false) return false;
			if (Equals(SasContainer, obj.SasContainer) == false) return false;
			if (Equals(SasFosface, obj.SasFosface) == false) return false;
			if (Equals(SasGlass1, obj.SasGlass1) == false) return false;
			if (Equals(SasGlass250, obj.SasGlass250) == false) return false;
			if (Equals(SasGlass425, obj.SasGlass425) == false) return false;
			if (Equals(Id, obj.Id) == false) return false;
			if (Equals(SasItem, obj.SasItem) == false) return false;
			if (Equals(SasSterite, obj.SasSterite) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (SasAsetic1 != null ? SasAsetic1.GetHashCode() : 0);
			result = (result * 397) ^ (SasAsetic250 != null ? SasAsetic250.GetHashCode() : 0);
			result = (result * 397) ^ (SasAsetic500 != null ? SasAsetic500.GetHashCode() : 0);
			result = (result * 397) ^ (SasContainer != null ? SasContainer.GetHashCode() : 0);
			result = (result * 397) ^ (SasFosface != null ? SasFosface.GetHashCode() : 0);
			result = (result * 397) ^ (SasGlass1 != null ? SasGlass1.GetHashCode() : 0);
			result = (result * 397) ^ (SasGlass250 != null ? SasGlass250.GetHashCode() : 0);
			result = (result * 397) ^ (SasGlass425 != null ? SasGlass425.GetHashCode() : 0);
			result = (result * 397) ^ Id.GetHashCode();
			result = (result * 397) ^ (SasItem != null ? SasItem.GetHashCode() : 0);
			result = (result * 397) ^ (SasSterite != null ? SasSterite.GetHashCode() : 0);
			return result;
		}
	}
}