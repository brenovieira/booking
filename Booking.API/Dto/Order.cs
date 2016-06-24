using System.Collections.Generic;

namespace Booking.API.Dto
{
    public class Order
    {
        public int Id { get; set; }

        public string Confirmation { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int Weight { get; set; }

        public ICollection<HealthIssue> HealthIssues { get; set; }

        public bool IsConfirmed
        {
            get
            {
                return !string.IsNullOrEmpty(Confirmation);
            }
        }
    }
}