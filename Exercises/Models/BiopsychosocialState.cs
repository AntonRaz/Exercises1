using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exercises.Models
{
    public class BiopsychosocialState
    {
        [Key]
        [ForeignKey("session")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BPSId { get; set; }

        [Range(0, 10)]
        public int SleepQuality { get; set; }

        [Range(0, 10)]
        public int TrustInSelf { get; set; }

        [Range(0, 10)]
        public int Stress { get; set; }

        [Range(0, 10)]
        public int Fatigue { get; set; }

        [Range(0, 10)]
        public int Stiffness { get; set; }

        [Range(0, 10)]
        public int Motivation { get; set; }

        public virtual Session session { get; set; }
    }
}