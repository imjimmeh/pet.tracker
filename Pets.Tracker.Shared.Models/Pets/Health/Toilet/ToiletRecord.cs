using Pets.Tracker.Shared.Models.Other.Enums;
using Pets.Tracker.Shared.Models.Pets.Health.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;

namespace Pets.Tracker.Shared.Models.Pets.Health.Toilet
{
    public class ToiletRecord : HealthRecord
    {
        public ToiletType Type { get; set; }

        [Range(0,100)]
        public int? Quantity { get; set; }

        public Colour Colour { get; set; }
    }
}
