using OrangeBricks.Web.Controllers.Property.ViewModels;
using System;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Bookings.ViewModels
{
    public class BookingsOnPropertyViewModel
    {
        public bool HasBookings { get; set; }
        public IEnumerable<BookingViewModel> Bookings { get; set; }
        public PropertyViewModel Property { get; set; }
        
    }

   
}