using System.Collections.Generic;

namespace Booking.DAL.Entities
{
    public class Event : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ThumbnailUrl { get; set; }

        public virtual ICollection<Availability> Availabilities { get; set; }
    }
}
