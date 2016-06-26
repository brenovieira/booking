using System.Collections.Generic;

namespace Booking.API.Dto
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int Weight { get; set; }

        public ICollection<HealthIssue> HealthIssues { get; set; }
    }
}