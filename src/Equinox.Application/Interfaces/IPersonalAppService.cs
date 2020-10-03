using Equinox.Application.EventSourcedNormalizers.Personal;
using Equinox.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface IPersonalAppService : IDisposable
    {
        Task<IEnumerable<PersonalViewModel>> GetAll();

        Task<PersonalViewModel> GetById(Guid id);

        Task<ValidationResult> Register(PersonalViewModel customerViewModel);

        Task<ValidationResult> Update(PersonalViewModel customerViewModel);

        Task<ValidationResult> Remove(Guid id);

        Task<IList<PersonalHistoryData>> GetAllHistory(Guid id);
    }
}
