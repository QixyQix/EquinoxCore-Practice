using EquinoxCore.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.Events
{
    class CustomerUpdatedEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public CustomerUpdatedEvent(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            AggregateId = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
    }
}
