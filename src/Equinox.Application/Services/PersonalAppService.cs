using AutoMapper;
using Equinox.Application.EventSourcedNormalizers.Personal;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.Personal;
using Equinox.Domain.Interfaces;
using Equinox.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equinox.Application.Services
{
    public class PersonalAppService : IPersonalAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonalRepository _personalRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public async Task<IEnumerable<PersonalViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<PersonalViewModel>>(await _personalRepository.GetAll());
        }

        public async Task<PersonalViewModel> GetById(Guid id)
        {
            return _mapper.Map<PersonalViewModel>(await _personalRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(PersonalViewModel personalViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewPersonalCommand>(personalViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemovePersonalCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<ValidationResult> Update(PersonalViewModel personalViewModel)
        {
            var updateCommand = _mapper.Map<UpdatePersonalCommand>(personalViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<IList<PersonalHistoryData>> GetAllHistory(Guid id)
        {
            return PersonalHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}