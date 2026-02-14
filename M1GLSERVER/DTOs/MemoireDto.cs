namespace M1GLSERVER.DTOs
{
    public class MemoireDto
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public string Contenu { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Statut { get; set; } = "En attente";
        public int FiliereId { get; set; }
        public string? FiliereNom { get; set; }
        public int EncadreurId { get; set; }
        public string? EncadreurNom { get; set; }
    }

    public class CreateMemoireDto
    {
        public string Titre { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public string Contenu { get; set; } = string.Empty;
        public int FiliereId { get; set; }
        public int EncadreurId { get; set; }
    }

    public class UpdateMemoireDto
    {
        public string Titre { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public string Contenu { get; set; } = string.Empty;
        public string Statut { get; set; } = string.Empty;
        public int FiliereId { get; set; }
        public int EncadreurId { get; set; }
    }
}
