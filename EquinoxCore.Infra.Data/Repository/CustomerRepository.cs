using EquinoxCore.Domain.Interfaces;
using EquinoxCore.Domain.Models;
using EquinoxCore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EquinoxCore.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EquinoxContext context) : base(context) { }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
