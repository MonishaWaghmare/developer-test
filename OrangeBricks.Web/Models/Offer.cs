using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrangeBricks.Web.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public OfferStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int Property_Id { get; set; }

        [ForeignKey("Property_Id")]
        public virtual Property ProperyRef { get; set; }

        public string BuyerUserId { get; set; }
    }
}