using Pets.Tracker.Shared.Models.Pets.Health.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pets.Tracker.Shared.Models.Pets.Health.Measurements
{
    public class MeasurementsRecord : HealthRecord
    {
        [Column(TypeName = "decimal(7,2)")]
        public decimal? Weight { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal? Height { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal? Length { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal? Depth { get; set; }
    }
}
