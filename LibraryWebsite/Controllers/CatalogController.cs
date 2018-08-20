using LibraryWebsite.Models.Catalog;
using LibraryWebsiteData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebsite.Controllers
{
    public class CatalogController : Controller
    {
        private ILibraryAsset _assets;
        public CatalogController(ILibraryAsset assets)
        {
            _assets = assets;
        }
        public IActionResult Index()
        {
            var assetModels = _assets.GetAll();

            var listingResult = assetModels
                .Select(result => new AssetIndexListingModel
                {
                    id = result.ID, 
                    ImageUrl = result.imageURL,
                    AuthorOrDirector =_assets.getAuthorOrDirector(result.ID),
                    DeweyCallNumber = _assets.getDeweyIndex(result.ID),
                    Title = result.Title,
                    Type = _assets.getType(result.ID)
            });


            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };
            return View(model);
        }
    }
}
