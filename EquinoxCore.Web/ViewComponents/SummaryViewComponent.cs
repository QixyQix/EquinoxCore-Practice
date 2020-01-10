using EquinoxCore.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquinoxCore.Web.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;

        public SummaryViewComponent(INotificationHandler<DomainNotification> notifications) {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var notifications = await Task.FromResult((_notifications.GetNotifications()));
            notifications.ForEach(n => ViewData.ModelState.AddModelError(string.Empty, n.Value));

            return View();
        }
    }
}
