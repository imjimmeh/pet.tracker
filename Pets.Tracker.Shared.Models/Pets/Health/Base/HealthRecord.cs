using System;
using System.Collections.Generic;
using System.Text;

namespace Pets.Tracker.Shared.Models.Pets.Health.Base
{
    public abstract class HealthRecord
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
