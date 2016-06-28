using System;
using System.Web.Mvc;
using CriminalsSearcher.Site.Models;
using CriminalsSearcher.Site.SearchService;
using Microsoft.AspNet.Identity;

namespace CriminalsSearcher.Site.Controllers {

    [Authorize]
    public class HomeController : Controller {

        public ActionResult Search() {
            return View(new SearchViewModel { MaxResults = 100 });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            DoSearch(model);            
            return Search();
        }

        private void DoSearch(SearchViewModel model) {
            var searchService = new SearchServiceClient();
            var parameters = CreateServiceSearchParameters(model);
            if (!searchService.Search(parameters, User.Identity.GetUserId(), model.MaxResults)) {
                ModelState.AddModelError("", "Sorry, it wasn't possible to do your search. Please review your search parameters.");
            }
        }

        private SearchParameters CreateServiceSearchParameters(SearchViewModel model) {
            return new SearchParameters {
                Name = model.Name,
                MinimumAge = model.MinimumAge,
                MaximumAge = model.MaximumAge,
                Gender = model.Gender,
                MinimumHeight = model.MinimumHeight,
                MaximumHeight = model.MaximumHeight,
                MinimumWeight = model.MinimumWeight,
                MaximumWeight = model.MaximumWeight,
                Nationality = model.Nationality,
                FatherName = model.FatherName,
                MotherName = model.MotherName,
                PassportNumber = model.PassportNumber,
                DriverLicenseNumber = model.DriverLicenseNumber
            };
        }
    }
}