using Equinox.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface IPersonalRepository : IRepository<Personal>
    {
        Task<Personal> GetById(Guid id);

        Task<Personal> GetByEmail(string email);

        Task<IEnumerable<Personal>> GetAll();

        void Add(Personal personal);

        void Update(Personal personal);

        void Remove(Personal personal);
    }
}