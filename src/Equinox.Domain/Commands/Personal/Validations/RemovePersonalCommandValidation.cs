namespace Equinox.Domain.Commands.Personal.Validations
{
    public class RemovePersonalCommandValidation : PersonalValidation<RemovePersonalCommand>
    {
        public RemovePersonalCommandValidation()
        {
            ValidateId();
        }
    }
}