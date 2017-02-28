using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Day2Authentification.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        protected virtual ApplicationUser User { get; set; }

        public double Amount { get; set; }
        public DateTime Created { get; set; }

    }
}