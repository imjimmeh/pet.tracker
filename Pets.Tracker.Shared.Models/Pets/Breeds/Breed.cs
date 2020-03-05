using Pets.Tracker.Shared.Models.Pets.Animals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pets.Tracker.Shared.Models.Pets.Breeds
{
    public class Breed
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("AnimalId")]
        public virtual Animal Animal { get; set; }
        public int AnimalId { get; set; }
        public virtual List<Pet> Pets { get; set; }
    }
}
