using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;
using System;
using System.Threading.Tasks;

namespace Equinox.UI.Web.Controllers
{
    public class PersonalController : BaseController
    {
        private readonly IPersonalAppService _personalAppService;

        public PersonalController(IPersonalAppService personalAppService)
        {
            _personalAppService = personalAppService;
        }

        [CustomAuthorize("Personals", "Write")]
        [HttpGet("personal-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [CustomAuthorize("Personals", "Write")]
        [HttpPost("personal-management/register-new")]
        public async Task<IActionResult> Create(PersonalViewModel personalViewModel)
        {
            if (!ModelState.IsValid) return View(personalViewModel);

            if (ResponseHasErrors(await _personalAppService.Register(personalViewModel)))
                return View(personalViewModel);

            ViewBag.Sucesso = "Personal Registered!";

            return View(personalViewModel);
        }

        [CustomAuthorize("Personals", "Write")]
        [HttpGet("personal-management/edit-personal/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var personalViewModel = await _personalAppService.GetById(id.Value);

            if (personalViewModel == null) return NotFound();

            return View(personalViewModel);
        }

        [CustomAuthorize("Personals", "Write")]
        [HttpPost("personal-management/edit-personal/{id:guid}")]
        public async Task<IActionResult> Edit(PersonalViewModel personalViewModel)
        {
            if (!ModelState.IsValid) return View(personalViewModel);

            if (ResponseHasErrors(await _personalAppService.Update(personalViewModel)))
                return View(personalViewModel);

            ViewBag.Sucesso = "Personal Updated!";

            return View(personalViewModel);
        }

        [CustomAuthorize("Personals", "Remove")]
        [HttpGet("personal-management/remove-personal/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var personalViewModel = await _personalAppService.GetById(id.Value);

            if (personalViewModel == null) return NotFound();

            return View(personalViewModel);
        }
    }
}