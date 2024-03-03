using TrentinoClassLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using TrentinoWebApplicationMVC.Models;

namespace TrentinoWebApplication.Controllers {
    public class MeteoController : Controller {

        private TrentinoService _service;

        public MeteoController(TrentinoService service) {
            this._service = service;
        }

        public async Task<IActionResult> Index() {
            var cities = await _service.GetCitiesNames();
            var vm = new CityNamesViewModel(){ names = cities };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Previsione(string id) {
            var previsione = await _service.GetCityMeteo(id);
            var vm = new PrevisioneViewModel() { PrevisioneDellaLocalita = previsione ?? new()};
            return View(vm);
        }

    }
}
