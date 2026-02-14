using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace M1GLSERVER.EntityE2E
{
    public class Filiere
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        public ICollection<Memoire> Memoires { get; set; }
    }
}
