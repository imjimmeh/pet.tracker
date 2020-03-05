using System;
using System.Collections.Generic;
using System.Text;

namespace Pets.Tracker.Shared.Models.Pets.Tricks
{
    public class TrickRecord
    {
        public int Id { get; set; }

        public virtual Trick Trick { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }

        public int Rating { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
