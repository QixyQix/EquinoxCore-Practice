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

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/list-all")]
        public IActionResult Index()
        {
            return View(_customerAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/customer-details/{id:guid}")]
        public IActionResult Details(Guid? id) {
            if (id == null) {
                return NotFound();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null) {
                return NotFound();
            }

            return View(customerViewModel);
        }

    }
}
