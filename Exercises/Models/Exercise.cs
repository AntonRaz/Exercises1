using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Exercises.Models
{
    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExerciseID { get; set; }

        [Required]
        public string Name { get; set; }

        public List<SessionSet> Sets { get; set; }
    }

    public class GymJournalDBContext : DbContext
    {
        //public DbSet<GymJournalDBContext> Journals { get; set; }

        public System.Data.Entity.DbSet<Exercises.Models.Exercise> Exercises { get; set; }

        public System.Data.Entity.DbSet<Exercises.Models.Session> Sessions { get; set; }

        public System.Data.Entity.DbSet<Exercises.Models.BiopsychosocialState> BiopsychosocialStates { get; set; }

        public System.Data.Entity.DbSet<Exercises.Models.SessionSet> SessionSets { get; set; }

        public System.Data.Entity.DbSet<Exercises.Models.PersonalRecords> PersonalRecords { get; set; }

        public System.Data.Entity.DbSet<Exercises.ViewModels.SessionBPSViewModel> SessionBPSViewModels { get; set; }
    }
}