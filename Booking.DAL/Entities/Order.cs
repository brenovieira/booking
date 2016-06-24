﻿using System.Collections.Generic;

namespace Booking.DAL.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public string Confirmation { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int Weight { get; set; }

        public virtual ICollection<HealthIssue> HealthIssues { get; set; }
    }
}
