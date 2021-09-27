using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace first.Models
{
    public class Team
    {
        public string Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public List<Footballer> Footballers { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
