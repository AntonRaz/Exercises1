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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionId { get; set;}

        [Display(Name = "Session Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime SessionDate { get; set; }

        public string Commentary { get; set; }

        public virtual BiopsychosocialState BiopsychosocialState { get; set; }

        public ICollection<SessionSet> Sets { get; set; }
    }

    public class SessionDBContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
    }
}