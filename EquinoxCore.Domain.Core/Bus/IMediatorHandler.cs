using EquinoxCore.Domain.Core.Commands;
using EquinoxCore.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquinoxCore.Domain.Core.Bus
{
    interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
