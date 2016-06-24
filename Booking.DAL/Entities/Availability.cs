using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.DAL.Entities
{
    public class Availability : IEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}