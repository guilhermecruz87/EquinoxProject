using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equinox.Infra.Data.Repository
{
    public class PersonalRepository : IPersonalRepository
    {
        protected readonly EquinoxContext Db;
        protected readonly DbSet<Personal> DbSet;

        public IUnitOfWork UnitOfWork => Db;

        public void Add(Personal personal)
        {
            DbSet
                .Add(personal);
        }

        public async Task<IEnumerable<Personal>> GetAll()
        {
            return await DbSet
                             .ToListAsync();
        }

        public async Task<Personal> GetByEmail(string email)
        {
            return await DbSet
                             .AsNoTracking()
                             .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Personal> GetById(Guid id)
        {
            return await DbSet
                             .FindAsync(id);
        }

        public void Remove(Personal personal)
        {
            DbSet
                .Remove(personal);
        }

        public void Update(Personal personal)
        {
            DbSet
                .Update(personal);
        }

        public void Dispose()
        {
            Db
             .Dispose();
        }
    }
}