using System.Collections.Generic;

namespace Booking.API.Dto
{
    public class Order
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public string Confirmation { get; set; }

        public ICollection<Person> People { get; set; }

        public Event Event { get; set; }
    }
}