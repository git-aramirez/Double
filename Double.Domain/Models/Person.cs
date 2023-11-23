using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.Domain.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PersonId { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string NumberIdentification { get; set; }
        public string Email { get; set; }
        public string TypeIdentification { get; set; }
        public string TypeAndNumberIdentification { get; set; }
        public string fullName { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
