using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.Core.Events
{
    interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
