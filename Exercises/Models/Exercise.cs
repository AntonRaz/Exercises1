using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Exercises.Models
{
    public class Exercise
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class ExerciseDBContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
    }
}