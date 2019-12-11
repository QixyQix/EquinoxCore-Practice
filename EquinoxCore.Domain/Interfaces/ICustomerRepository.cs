using EquinoxCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.Interfaces
{
    interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}
