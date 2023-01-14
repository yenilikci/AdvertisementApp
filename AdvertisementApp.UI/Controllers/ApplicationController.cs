using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Dtos;
using AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ApplicationController : Controller
    {
        private readonly IAdvertisementService _advertisementService;

        public ApplicationController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> List()
        {
            var response = await _advertisementService.GetAllAsync();
            return this.ResponseView(response);
        }
        public IActionResult Create()
        {
            return View(new AdvertisementCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdvertisementCreateDto dto)
        {
            var response = await _advertisementService.CreateAsync(dto);
            return this.ResponseRedirectAction(response, "List");
        }
    }

}
