using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Models
{
    public class SessionSet
    {
        [Key, Column(Order = 0)]
        [HiddenInput(DisplayValue = false)]
        public int SessionId { get; set; }

        [ForeignKey("SessionId")]
        public virtual Session Session { get; set; }

        [Key, Column(Order = 1)]
        public int SetNumber { get; set; }

        public int ExerciseID { get; set; }

        [ForeignKey("ExerciseID")]
        public Exercise Exercise { get; set; }

        public int Reps { get; set; }

        [Range(0, 10)]
        public decimal RPE { get; set; }

        public decimal Load { get; set; }

        public string Commentary { get; set; }

        public bool PersonalRecord { get; set; }
    }
}