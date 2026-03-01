using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace M1GLSERVER.EntityE2E
{
    public class Utilisateur : IdentityUser<int>
    {
        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [StringLength(100)]
        public string Prenom { get; set; }
    }
}
