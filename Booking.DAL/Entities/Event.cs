using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.DAL.Entities
{
    public class Event : IEntity
    {
        public int Id { get; set; }

        [Index]
        public string Url { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public string ThumbnailUrl { get; set; }

        public virtual ICollection<Availability> Availability { get; set; }
    }
}
