using EquinoxCore.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.Validations
{
    class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation() {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
