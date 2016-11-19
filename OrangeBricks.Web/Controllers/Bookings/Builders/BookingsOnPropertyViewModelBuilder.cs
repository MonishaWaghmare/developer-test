using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Controllers.Bookings.ViewModels;
using OrangeBricks.Web.Controllers.Property.Builders;

namespace OrangeBricks.Web.Controllers.Bookings.Builders
{
    public class BookingsOnPropertyViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public BookingsOnPropertyViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public BookingsOnPropertyViewModel Build(int id)
        {
            var aProperty = _context.Properties
                .Where(p => p.Id == id)
                .Include(x => x.Bookings)
                .SingleOrDefault();

            var bookings = aProperty.Bookings ?? new List<Booking>();


            return new BookingsOnPropertyViewModel
            {
                HasBookings = bookings.Any(),
                Bookings = bookings.Select(x => new BookingViewModel
                {
                    Id = x.Id,
                    ViewingAt = x.ViewingAt,
                    
                    IsRequested = x.Status == (int)BookingStatus.Requested,
                    Status = (BookingStatus)x.Status,

                    Property = null
                }),
                Property = PropertiesViewModelBuilder.MapViewModel(aProperty)
            };
        }
    }
}