using EquinoxCore.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquinoxCore.Domain.Commands
{
    class RemoveCustomerCommand : CustomerCommand
    {
        public RemoveCustomerCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
