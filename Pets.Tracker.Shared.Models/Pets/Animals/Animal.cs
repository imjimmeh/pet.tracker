using Pets.Tracker.Shared.Models.Pets.Breeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pets.Tracker.Shared.Models.Pets.Animals
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Breed> Breeds { get; set; }

        public virtual List<Pet> Pets { get; set; }
    }
}
