using System;
using System.Collections.Generic;
using System.Text;
using EquinoxCore.Domain.Core.Events;
using EquinoxCore.Domain.Interfaces;
using EquinoxCore.Infra.Data.Repository.EventSourcing;
using Newtonsoft.Json;

namespace EquinoxCore.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IUser _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository, IUser user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serialisedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(theEvent, serialisedData, _user.Name);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
