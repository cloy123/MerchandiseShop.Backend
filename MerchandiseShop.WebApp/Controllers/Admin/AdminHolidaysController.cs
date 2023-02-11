using AutoMapper;
using MerchandiseShop.Application.Holidays.Commands.CreateHoliday;
using MerchandiseShop.Application.Holidays.Commands.DeleteHoliday;
using MerchandiseShop.Application.Holidays.Commands.UpdateHoliday;
using MerchandiseShop.Application.Holidays.Queries.GetHolidayDetails;
using MerchandiseShop.Application.Holidays.Queries.GetHolidaysList;
using MerchandiseShop.Domain.Models;
using MerchandiseShop.Domain.User;
using MerchandiseShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MerchandiseShop.WebApp.Controllers.Admin
{
    [Route("admin/holidays/{action=Index}/")]
    public class AdminHolidaysController : BaseController
    {
        private readonly IMapper _mapper;

        public AdminHolidaysController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetHolidayListQuery();
            var list = await Mediator.Send(query);
            return View("~/Views/Admin/Holidays/Index.cshtml", list);
        }

        public IActionResult Create()
        {
            var types = Enumeration.GetAll<UserType>().ToList();
            var genders = Enumeration.GetAll<UserGender>().ToList();

            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");
            ViewData["GenderId"] = new SelectList(genders, "Id", "Name");
            return View("~/Views/Admin/Holidays/Create.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(HolidayDto holidayDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateHolidayCommand>(holidayDto);
                var holidayId = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            var types = Enumeration.GetAll<UserType>().ToList();
            var genders = Enumeration.GetAll<UserGender>().ToList();

            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");
            ViewData["GenderId"] = new SelectList(genders, "Id", "Name");
            return View("~/Views/Admin/Holidays/Create.cshtml", holidayDto);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetHolidayDetailsQuery
            {
                Id = id.Value
            };
            var holidayDetails = await Mediator.Send(query);
            if (holidayDetails == null)
            {
                return NotFound();
            }

            var holidayDto = _mapper.Map<HolidayDto>(holidayDetails);

            return View("~/Views/Admin/Holidays/Delete.cshtml", holidayDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var command = new DeleteHolidayCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetHolidayDetailsQuery
            {
                Id = id.Value
            };
            var holidayDetails = await Mediator.Send(query);
            var holidayDto = _mapper.Map<HolidayDto>(holidayDetails);

            var types = Enumeration.GetAll<UserType>().ToList();
            var genders = Enumeration.GetAll<UserGender>().ToList();

            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");
            ViewData["GenderId"] = new SelectList(genders, "Id", "Name");
            return View("~/Views/Admin/Holidays/Edit.cshtml", holidayDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HolidayDto holidayDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateHolidayCommand>(holidayDto);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            var types = Enumeration.GetAll<UserType>().ToList();
            var genders = Enumeration.GetAll<UserGender>().ToList();

            ViewData["UserTypeId"] = new SelectList(types, "Id", "Name");
            ViewData["GenderId"] = new SelectList(genders, "Id", "Name");
            return View("~/Views/Admin/Holidays/Edit.cshtml", holidayDto);
        }
    }
}
