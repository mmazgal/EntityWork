using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityWork
{
    public class Kurs
    {
        [Key]
        public int KursId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
