using System;
using System.Collections.Generic;
using System.Text;

namespace Pets.Tracker.Shared.Models.Pets.Health.Toilet
{
    public class Colour
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<ToiletRecord> ToiletRecords { get; set; }
    }
}
