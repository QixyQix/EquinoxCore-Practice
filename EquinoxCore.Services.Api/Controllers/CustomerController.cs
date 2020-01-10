using EquinoxCore.Application.Interfaces;
using EquinoxCore.Application.ViewModels;
using EquinoxCore.Domain.Core.Bus;
using EquinoxCore.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquinoxCore.Services.Api.Controllers
{
    [Authorize]
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService,INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management")]
        public IActionResult Get() {
            return Response(_customerAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/{id:guid}")]
        public IActionResult Get(Guid id) {
            var customerViewModel = _customerAppService.GetById(id);
            return Response(customerViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management")]
        public IActionResult Post([FromBody] CustomerViewModel customerViewModel) {
            if (!ModelState.IsValid) {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.Register(customerViewModel);

            return Response(customerViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanUpdateCustomerData")]
        [Route("customer-management")]
        public IActionResult Put([FromBody] CustomerViewModel customerViewModel) {
            if (!ModelState.IsValid) {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.Update(customerViewModel);

            return Response(customerViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanDeleteCustomerData")]
        [Route("customer-mangement/{guid:id}")]
        public IActionResult Delete(Guid id) {
            _customerAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/history/{id:guid}")]
        public IActionResult GetHistory(Guid id) {
            var customerHistoryData = _customerAppService.GetAllHistory(id);
            return Response(customerHistoryData);
        }


    }
}
