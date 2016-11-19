using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Bookings.Builders;
using OrangeBricks.Web.Controllers.Bookings.Commands;
using OrangeBricks.Web.Models;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Bookings
{
    public class BookingsController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public BookingsController(IOrangeBricksContext context)
        {
            _context = context;
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult BookingsOnProperty(int id)
        {
            
            var builder = new BookingsOnPropertyViewModelBuilder(_context);
            var viewModel = builder.Build(id);

            return View(viewModel);
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        [HttpPost]
        public ActionResult Confirmed(BookingCommandBase command)
        {
            var handler = new BookingCommandHandler(_context);
            handler.Confirmed(command);

            return RedirectToAction("BookingsOnProperty", new { id = command.PropertyId });
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        [HttpPost]
        public ActionResult Cancelled(BookingCommandBase command)
        {
            var handler = new BookingCommandHandler(_context);
            handler.Cancelled(command);

            return RedirectToAction("BookingsOnProperty", new { id = command.PropertyId });
        }
    }
}