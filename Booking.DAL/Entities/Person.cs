using System.Collections.Generic;

namespace Booking.DAL.Entities
{
    public class Person : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int Weight { get; set; }

        public ICollection<HealthIssue> HealthIssues { get; set; }
    }
}
