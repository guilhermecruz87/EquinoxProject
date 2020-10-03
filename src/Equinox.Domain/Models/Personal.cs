using NetDevPack.Domain;
using System;

namespace Equinox.Domain.Models
{
    public class Personal : Entity, IAggregateRoot
    {
        public Personal(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        // Empty constructor for EF
        protected Personal() { }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
