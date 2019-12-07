using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace EquinoxCore.Domain.Core.Event
{
    public abstract class Message : IRequest<bool>
    {

    }
}
