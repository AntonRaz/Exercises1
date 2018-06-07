using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models
{
    public class Session
    {
        [Key]
        public int SessionId { get; set;}

        public DateTime SessionDate { get; set; }

        public string Commentary { get; set; }

        public int BPSId { get; set; }

        [ForeignKey("BPSId")]
        public BiopsychosocialState BiopsychosocialState { get; set; }

        public List<Set> Sets { get; set; }
    }

    public class SessionDBContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
    }
}