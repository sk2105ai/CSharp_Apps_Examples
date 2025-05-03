using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models;
// ParksController.cs
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace MVCWebApp.Controllers
{
    public class ParkSummaryController : Controller
    {
        // GET: Parks
        public ActionResult ParkSummary()
        {
            var viewModel = new ParkViewModel
            {
                Countries = LocationService.GetCountries(),
                SelectedCountry = "USA",
                States = LocationService.GetStates("USA"),
                SelectedState = "California",
                Cities = LocationService.GetCities("California"),
                SelectedCity = "Los Angeles"
            };

            int totalItems;
            viewModel.Parks = ParkService.GetParks(
                viewModel.SelectedCountry,
                viewModel.SelectedState,
                viewModel.SelectedCity,
                viewModel.SortColumn,
                viewModel.SortOrder,
                viewModel.CurrentPage,
                viewModel.PageSize,
                out totalItems
            );
            viewModel.TotalItems = totalItems;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ParkViewModel model)
        {
            // Refresh dropdown data
            model.Countries = LocationService.GetCountries();
            model.States = LocationService.GetStates(model.SelectedCountry);
            model.Cities = LocationService.GetCities(model.SelectedState);

            int totalItems;
            model.Parks = ParkService.GetParks(
                model.SelectedCountry,
                model.SelectedState,
                model.SelectedCity,
                model.SortColumn,
                model.SortOrder,
                model.CurrentPage,
                model.PageSize,
                out totalItems
            );
            model.TotalItems = totalItems;

            return View(model);
        }

        // Ajax call to get states for a country
        [HttpGet]
        public JsonResult GetStates(string country)
        {
            var states = LocationService.GetStates(country);
            return Json(states);
        }

        // Ajax call to get cities for a state
        [HttpGet]
        public JsonResult GetCities(string state)
        {
            var cities = LocationService.GetCities(state);
            return Json(cities);
        }

        // Ajax call to reload park data with sorting and paging
        [HttpGet]
        public ActionResult GetParks(string country, string state, string city,
                                     string sortColumn, string sortOrder, int page, int pageSize)
        {
            int totalItems;
            var parks = ParkService.GetParks(country, state, city, sortColumn, sortOrder, page, pageSize, out totalItems);

            var viewModel = new ParkViewModel
            {
                SelectedCountry = country,
                SelectedState = state,
                SelectedCity = city,
                Parks = parks,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                SortColumn = sortColumn,
                SortOrder = sortOrder
            };

            return PartialView("_ParksGrid", viewModel);
        }
    }


}
