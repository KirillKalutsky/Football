using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace first.Models
{
    [BindProperties]
    public class Footballer
    {
        public String Name { get;  set; }

        public String Surname { get;  set; }

        public Sex Sex { get;  set; }

        public DateTime DateOfBirth { get;  set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Team Team { get; set; }

        public Country Country { get;  set; }

    }
}
