using Equinox.Domain.Commands.Personal.Validations;
using System;

namespace Equinox.Domain.Commands.Personal
{
    public class UpdatePersonalCommand : PersonalCommand
    {
        public UpdatePersonalCommand(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePersonalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}