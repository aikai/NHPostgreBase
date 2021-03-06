using System;
using System.Collections.Generic;

namespace ProjectBase.Core.Model
{
    public interface IAppMenu
	{
        Guid Id { get; set; }

        string EnglishName { get; set; }
        string ThaiName { get; set; }
        string Url { get; set; }
        int Index { get; set; }

        Iesi.Collections.Generic.ISet<IAppMenu> AppMenus { get; set; }
        IAppMenu Parent { get; set; }
        //IAppRole AppRole { get; set; }

        bool Equals(object obj);
        bool Equals(IAppMenu obj);
        int GetHashCode();
	}
}