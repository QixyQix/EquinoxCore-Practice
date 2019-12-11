using EquinoxCore.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.Events
{
    class CustomerRegisteredEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public CustomerRegisteredEvent(Guid id, string name, string email, DateTime birthDate) {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

    }
}
