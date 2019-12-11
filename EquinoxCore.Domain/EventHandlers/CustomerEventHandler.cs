using EquinoxCore.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquinoxCore.Domain.EventHandlers
{
    public class CustomerEventHandler :
        INotificationHandler<CustomerRegisteredEvent>,
        INotificationHandler<CustomerRemovedEvent>,
        INotificationHandler<CustomerUpdatedEvent>
    {
        public Task Handle(CustomerRegisteredEvent message, CancellationToken cancellationToken)
        {
            //Send some notificaiton Email

            return Task.CompletedTask;
        }

        public Task Handle(CustomerRemovedEvent message, CancellationToken cancellationToken)
        {
            //Send sad to see you go email

            return Task.CompletedTask;
        }

        public Task Handle(CustomerUpdatedEvent message, CancellationToken cancellationToken)
        {
            //Send notification email

            return Task.CompletedTask;
        }
    }
}
