using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseID { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Set> Sets { get; set; }
    }

    public class ExerciseDBContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }

        public System.Data.Entity.DbSet<Exercises.Models.Session> Sessions { get; set; }

        public System.Data.Entity.DbSet<Exercises.Models.BiopsychosocialState> BiopsychosocialStates { get; set; }
    }
}