using Equinox.Domain.Commands.Personal.Validations;
using System;

namespace Equinox.Domain.Commands.Personal
{
    public class RemovePersonalCommand : PersonalCommand
    {
        public RemovePersonalCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemovePersonalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}