namespace Equinox.Domain.Commands.Personal.Validations
{
    public class RegisterNewPersonalCommandValidation : PersonalValidation<RegisterNewPersonalCommand>
    {
        public RegisterNewPersonalCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
