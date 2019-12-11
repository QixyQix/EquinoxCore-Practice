using System;
using EquinoxCore.Domain.Core.Models;

namespace EquinoxCore.Domain.Models
{

    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        //Empty constructor for EF
        protected Customer() { }

        public Customer(Guid id, string name, string email, DateTime birthDate) {
            Id = id;
            Name = name;
            Email = email;
            DateOfBirth = birthDate;
        }

    }
}
