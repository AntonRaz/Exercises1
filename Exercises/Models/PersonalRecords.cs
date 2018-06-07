using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exercises.Models
{
    public class PersonalRecords
    {
        [Key]
        public int PRId { get; set; }

        public int Load { get; set; }
                
        public int SessionId { get; set; }

        public int SetNumber { get; set; }

        [ForeignKey("SessionId, SetNumber")]
        public Set Set { get; set; }
    }
}