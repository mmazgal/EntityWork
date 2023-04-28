using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityWork
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Yas { get; set; }
    }
}
