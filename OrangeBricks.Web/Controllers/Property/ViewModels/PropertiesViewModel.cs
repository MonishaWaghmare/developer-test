using OrangeBricks.Web.Controllers.Offers.ViewModels;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class PropertiesViewModel
    {
        public List<PropertyViewModel> Properties { get; set; }
        public string Search { get; set; }
    }

    public class OffersViewModel
    {
        public List<OfferViewModel> Offers { get; set; }
        public string Search { get; set; }
    }
}