using NetDevPack.Messaging;
using System;

namespace Equinox.Domain.Events.Personal
{
    public class PersonalRemovedEvent : Event
    {
        public PersonalRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}