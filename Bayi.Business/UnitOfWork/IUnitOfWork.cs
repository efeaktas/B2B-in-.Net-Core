using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.UnitOfWork
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
