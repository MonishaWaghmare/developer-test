using OrangeBricks.Web.Controllers.Bookings.ViewModels;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;

namespace OrangeBricks.Web.Controllers.Bookings.Builders
{
    public class BookViewingViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public BookViewingViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public BookingViewModel Build(int id)
        {
            var property = _context.Properties.Find(id);

            return new BookingViewModel
            {
                 Status = BookingStatus.Requested,
                 Property = PropertiesViewModelBuilder.MapViewModel(property),
                 ViewingAt = DateTime.Now.ToUniversalTime()
            };
        }
    }
}