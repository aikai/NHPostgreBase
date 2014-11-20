using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;

namespace ProjectBase.Core
{
    public interface IAppProjectDao : IDao<IAppProject>
    {
        IList<IAppProject> Search(string appName);
    }
}
