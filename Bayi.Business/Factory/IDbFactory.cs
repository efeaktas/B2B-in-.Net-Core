using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.Factory
{
    public interface IDbFactory
    {
        BayiDbContext Init();
    }
}
