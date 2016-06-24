using System;

namespace Booking.API.Dto
{
    public class Availability
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int EventId { get; set; }
    }
}