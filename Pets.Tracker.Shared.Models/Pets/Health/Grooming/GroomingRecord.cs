using Pets.Tracker.Shared.Models.Other.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Pets.Tracker.Shared.Models.Pets.Health.Base;

namespace Pets.Tracker.Shared.Models.Pets.Health.Grooming
{
    public class GroomingRecord : HealthRecord
    {
        public GroomingType Type { get; set; }
        public Pet Pet { get; internal set; }
    }
}
