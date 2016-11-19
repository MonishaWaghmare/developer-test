using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Bookings.Commands
{
    public class BookingCommandBase
    {
        public int PropertyId { get; set; }

        public int BookingId { get; set; }
    }
}