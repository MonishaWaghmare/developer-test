using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Bookings.ViewModels
{
    public class BookingViewModel 
    {
        public int Id { get; set; }
        public PropertyViewModel Property { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime ViewingAt { get; set; }
        public BookingStatus Status { get; set; }
        public string BuyerUserId { get; set; }
        public bool IsRequested { get; set; }
    }
}