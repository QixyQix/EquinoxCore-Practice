﻿using EquinoxCore.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.Validations
{
    public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand>
    {
        public RemoveCustomerCommandValidation() {
            ValidateId();
        }
    }
}
