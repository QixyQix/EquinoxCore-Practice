using EquinoxCore.Domain.Core.Commands;
using EquinoxCore.Domain.Core.Notifications;
using EquinoxCore.Domain.Core.Bus;
using EquinoxCore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.CommandHandlers
{
    class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) {
            _uow = uow;
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected void NotifyValidationErrors(Command message) {
            foreach (var error in message.ValidationResult.Errors) {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }
    }
}
