using EquinoxCore.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.Validations
{
    class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation() {
            ValidateId();
            ValidateName();
            ValidateEmail();
            ValidateBirthDate();
        }
    }
}
