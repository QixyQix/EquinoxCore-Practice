using EquinoxCore.Domain.Interfaces;
using EquinoxCore.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly EquinoxContext _context;

        public UnitOfWork(EquinoxContext context)
        {
            _context = context;
        }
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
