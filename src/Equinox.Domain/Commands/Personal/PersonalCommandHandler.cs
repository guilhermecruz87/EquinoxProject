using Equinox.Domain.Events.Personal;
using Equinox.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Personal
{
    public class PersonalCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewPersonalCommand, ValidationResult>,
        IRequestHandler<UpdatePersonalCommand, ValidationResult>,
        IRequestHandler<RemovePersonalCommand, ValidationResult>
    {
        private readonly IPersonalRepository _personalRepository;

        public PersonalCommandHandler(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }

        public async Task<ValidationResult> Handle(RemovePersonalCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _personalRepository.GetById(message.Id);

            if (customer is null)
            {
                AddError("The customer doesn't exists.");
                return ValidationResult;
            }

            customer.AddDomainEvent(new PersonalRemovedEvent(message.Id));

            _personalRepository.Remove(customer);

            return await Commit(_personalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdatePersonalCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var personal = new Domain.Models.Personal(message.Id, message.Name, message.Email, message.BirthDate);
            var existingCustomer = await _personalRepository.GetByEmail(personal.Email);

            if (existingCustomer != null && existingCustomer.Id != personal.Id)
            {
                if (!existingCustomer.Equals(personal))
                {
                    AddError("The customer e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            personal.AddDomainEvent(new PersonalUpdatedEvent(personal.Id, personal.Name, personal.Email, personal.BirthDate));

            _personalRepository.Update(personal);

            return await Commit(_personalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RegisterNewPersonalCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var personal = new Domain.Models.Personal(Guid.NewGuid(), message.Name, message.Email, message.BirthDate);

            if (await _personalRepository.GetByEmail(personal.Email) != null)
            {
                AddError("The customer e-mail has already been taken.");
                return ValidationResult;
            }

            personal.AddDomainEvent(new PersonalRegisteredEvent(personal.Id, personal.Name, personal.Email, personal.BirthDate));

            _personalRepository.Add(personal);

            return await Commit(_personalRepository.UnitOfWork);
        }
    }
}