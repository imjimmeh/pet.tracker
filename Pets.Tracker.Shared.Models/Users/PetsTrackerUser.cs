using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pets.Tracker.Shared.Models.Pets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pets.Tracker.Shared.Models.Users
{
    public class PetsTrackerUser : IdentityUser
    {
        [Column(TypeName ="nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        public virtual DbSet<Pet> UserPets { get; set; }
    }
}
