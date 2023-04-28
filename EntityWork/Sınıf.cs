using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityWork
{
    public class Sınıf
    {
        [Key]
        public int SınıfId { get; set; }
        [Required]
        public int No { get; set; }
        public string Tahta { get; set; }
        public string Projeksiyon { get; set; }
        public string Bilgisayar { get; set; }

    }
}
