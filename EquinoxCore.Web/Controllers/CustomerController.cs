using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquinoxCore.Application.Interfaces;
using EquinoxCore.Application.ViewModels;
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

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/register-new")]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] CustomerViewModel customerViewModel) {
            if (!ModelState.IsValid) return View(customerViewModel);

            _customerAppService.Register(customerViewModel);

            if (IsValidOperation())
                ViewBag.Success = "Customer Registered!";

            return View(customerViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/edit-customer/{id:guid}")]
        public IActionResult Edit(Guid? id) {
            if (id == null) {
                return NotFound();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null) {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/edit-customer/{id:guid}")]
        public IActionResult Edit([FromBody] CustomerViewModel customerViewModel) {
            if (!ModelState.IsValid) return View(customerViewModel);

            _customerAppService.Update(customerViewModel);

            if (IsValidOperation())
                ViewBag.Success = "Customer updated";

            return View();
        }

    }
}
