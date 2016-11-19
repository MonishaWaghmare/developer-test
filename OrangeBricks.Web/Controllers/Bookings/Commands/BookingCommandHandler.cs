using OrangeBricks.Web.Controllers.Bookings.ViewModels;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Bookings.Commands
{
    public class BookingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public BookingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Save(BookingViewModel command, string buyerUserId)
        {
            var property = _context.Properties.Find(command.Property.Id);

            var aBooking = new Booking
            {
                Status = (int)BookingStatus.Requested,
                BuyerUserId = buyerUserId,
                ViewingAt = command.ViewingAt
            };

            if (property.Bookings == null)
            {
                property.Bookings = new List<Booking>();
            }
                
            property.Bookings.Add(aBooking);
            
            _context.SaveChanges();
        }

        public void Confirmed(BookingCommandBase command)
        {
            var booking = _context.Bookings.Find(command.BookingId);
            booking.Status = (int)BookingStatus.Confirmed;

            _context.SaveChanges();
        }

        public void Cancelled(BookingCommandBase command)
        {
            var booking = _context.Bookings.Find(command.BookingId);
            booking.Status = (int)BookingStatus.Cancelled;

            _context.SaveChanges();
        }
    }
}