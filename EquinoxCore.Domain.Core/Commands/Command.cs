﻿using EquinoxCore.Domain.Core.Events;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
