namespace Equinox.Domain.Commands.Personal.Validations
{
    public class UpdatePersonalCommandValidation : PersonalValidation<UpdatePersonalCommand>
    {
        public UpdatePersonalCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}