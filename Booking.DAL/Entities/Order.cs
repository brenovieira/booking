using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.DAL.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        [Index(IsUnique = true)]
        public string Confirmation { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Person> People { get; set; }

        public virtual Event Event { get; set; }
    }
}
