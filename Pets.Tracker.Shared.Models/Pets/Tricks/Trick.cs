using System;
using System.Collections.Generic;
using System.Text;

namespace Pets.Tracker.Shared.Models.Pets.Tricks
{
    public class Trick
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Difficulty { get; set; }

        public string Description { get; set; }

        public virtual List<TrickRecord> TrickRecords { get; set; }
    }
}
