using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Events.Personal
{
    public class PersonalEventHandler :
        INotificationHandler<PersonalRegisteredEvent>,
        INotificationHandler<PersonalUpdatedEvent>,
        INotificationHandler<PersonalRemovedEvent>
    {
        public Task Handle(PersonalRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(PersonalUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(PersonalRemovedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }
    }
}