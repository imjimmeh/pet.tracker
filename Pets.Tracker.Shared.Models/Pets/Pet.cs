using Pets.Tracker.Shared.Models.Other.Enums;
using Pets.Tracker.Shared.Models.Pets.Animals;
using Pets.Tracker.Shared.Models.Pets.Breeds;
using Pets.Tracker.Shared.Models.Pets.Health.Grooming;
using Pets.Tracker.Shared.Models.Pets.Health.Measurements;
using Pets.Tracker.Shared.Models.Pets.Health.Toilet;
using Pets.Tracker.Shared.Models.Pets.Health.Vet;
using Pets.Tracker.Shared.Models.Pets.Tricks;
using Pets.Tracker.Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pets.Tracker.Shared.Models.Pets
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public virtual Breed Breed { get; set; }
        public int BreedId { get; set; }

        public virtual Animal Animal { get; set; }
        public int AnimalId { get; set;}

        public virtual PetsTrackerUser Owner { get; set; }
        public string OwnerId { get; set; }
        public virtual List<GroomingRecord> GroomingRecords { get; set; }
        public virtual List<MeasurementsRecord> MeasurementRecords { get; set; }
        public virtual List<ToiletRecord> ToiletRecords { get; set; }
        public virtual List<VetVisit> VetRecords { get; set; }
        public virtual List<Trick> TrickRecords { get; set; }
    }
}
