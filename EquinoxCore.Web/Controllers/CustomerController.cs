using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquinoxCore.Application.Interfaces;
using EquinoxCore.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EquinoxCore.Web.Controllers
{
    [Authorize]
    public class CustomerController : BaseController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService, INotificationHandler<DomainNotification> notifications) : base(notifications) {
            _customerAppService = customerAppService;
        }
    }
}
