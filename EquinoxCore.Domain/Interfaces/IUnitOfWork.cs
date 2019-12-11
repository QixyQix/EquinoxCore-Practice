using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
