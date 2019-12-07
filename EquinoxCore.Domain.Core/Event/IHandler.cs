using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.Core.Event
{
    public interface IHandler<T> where T : Message
    {
        void Handle(T message);
    }
}
