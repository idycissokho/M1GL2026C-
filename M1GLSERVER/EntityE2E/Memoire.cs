using System;
using System.ComponentModel.DataAnnotations;

namespace M1GLSERVER.EntityE2E
{
    public class Memoire
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Titre { get; set; }

        [Required]
        [StringLength(200)]
        public string Auteur { get; set; }

        [Required]
        [StringLength(200)]
        public string Contenu { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string Statut { get; set; } = "En attente"; // En attente, Validé, Rejeté

        // Relation avec Filiere
        public int FiliereId { get; set; }
        public Filiere Filiere { get; set; }

        // Relation avec Encadreur
        public int EncadreurId { get; set; }
        public Encadreur Encadreur { get; set; }
    }
}
