using AutoMapper;
using AutoMapper.QueryableExtensions;
using EquinoxCore.Application.EventSourcedNormalisers;
using EquinoxCore.Application.Interfaces;
using EquinoxCore.Application.ViewModels;
using EquinoxCore.Domain.Commands;
using EquinoxCore.Domain.Core.Bus;
using EquinoxCore.Domain.Interfaces;
using EquinoxCore.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public CustomerAppService(IMapper mapper, ICustomerRepository customerRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler bus) {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return _customerRepository.GetAll().ProjectTo<CustomerViewModel>(_mapper.ConfigurationProvider);
        }

        public IList<CustomerHistoryData> GetAllHistory(Guid id)
        {
            return CustomerHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        }

        public CustomerViewModel GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        public void Register(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(Guid id)
        {
            var removeCustomerCommand = new RemoveCustomerCommand(id);
            Bus.SendCommand(removeCustomerCommand);
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var updateCustomerCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            Bus.SendCommand(updateCustomerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
