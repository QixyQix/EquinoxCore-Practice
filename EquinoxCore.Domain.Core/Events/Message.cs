﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace EquinoxCore.Domain.Core.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message() 
        {
            MessageType = GetType().Name;
        }
    }
}
