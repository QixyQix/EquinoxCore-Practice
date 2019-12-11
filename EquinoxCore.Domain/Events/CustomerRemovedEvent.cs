using EquinoxCore.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.Events
{
    class CustomerRemovedEvent : Event
    {
        public Guid Id { get; set; }

        public CustomerRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
