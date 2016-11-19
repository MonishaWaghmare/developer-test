using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Property.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Controllers.Offers.Builders;

namespace OrangeBricks.Web.Controllers.Offers
{
	
    public partial class OffersController
	{

        [OrangeBricksAuthorize(Roles = "Buyer")]
        //[Authorize]
        public ActionResult Index(PropertiesQuery query)
        {
            var builder = new OffersViewModelBuilder(_context);
            var viewModel = builder.Build(query, User.Identity.GetUserId());

            return View(viewModel);
        }
        
        
	}
}