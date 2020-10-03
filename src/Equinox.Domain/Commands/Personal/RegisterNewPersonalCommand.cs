using Equinox.Domain.Commands.Personal.Validations;
using System;

namespace Equinox.Domain.Commands.Personal
{
    public class RegisterNewPersonalCommand : PersonalCommand
    {
        public RegisterNewPersonalCommand(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPersonalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
