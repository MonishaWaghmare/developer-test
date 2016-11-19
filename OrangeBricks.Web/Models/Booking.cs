using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
       
        public DateTime ViewingAt { get; set; }

        public String BuyerUserId { get; set; }

        public int PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public virtual Property ProperyRef { get; set; }

        public int Status { get; set; }
    }
}