using M1GLSERVER.EntityE2E;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace M1GLSERVER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly DbMemoireContextE2E _context;

        public DatabaseController(DbMemoireContextE2E context)
        {
            _context = context;
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetDatabase()
        {
            // Supprimer toutes les données
            _context.memoires.RemoveRange(_context.memoires);
            _context.Etudiants.RemoveRange(_context.Etudiants);
            _context.Encadreurs.RemoveRange(_context.Encadreurs);
            _context.Filieres.RemoveRange(_context.Filieres);
            
            await _context.SaveChangesAsync();

            return Ok(new { message = "Base de données réinitialisée avec succès" });
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedDatabase()
        {
            try
            {
                // Récupérer les filières et encadreurs existants
                var filieres = await _context.Filieres.ToListAsync();
                var encadreurs = await _context.Encadreurs.ToListAsync();

                // Ajouter des étudiants seulement
                var etudiants = new List<Etudiant>
                {
                    new() { Nom = "Sow", Prenom = "Ousmane", Email = "ousmane.sow@etudiant.sn", Memoires = new List<Memoire>() },
                    new() { Nom = "Fall", Prenom = "Aissatou", Email = "aissatou.fall@etudiant.sn", Memoires = new List<Memoire>() },
                    new() { Nom = "Sarr", Prenom = "Moussa", Email = "moussa.sarr@etudiant.sn", Memoires = new List<Memoire>() },
                    new() { Nom = "Gueye", Prenom = "Mariama", Email = "mariama.gueye@etudiant.sn", Memoires = new List<Memoire>() }
                };
                _context.Etudiants.AddRange(etudiants);
                await _context.SaveChangesAsync();

                // Ajouter des mémoires seulement
                var memoires = new List<Memoire>
                {
                    new() { 
                        Titre = "Intelligence Artificielle appliquée à l'agriculture sénégalaise",
                        Auteur = "Ousmane Sow",
                        Contenu = "Ce mémoire explore l'utilisation de l'IA pour optimiser la production agricole au Sénégal.",
                        Date = DateTime.UtcNow,
                        Statut = "En attente",
                        FiliereId = filieres.FirstOrDefault()?.Id ?? 0,
                        EncadreurId = encadreurs.FirstOrDefault()?.Id ?? 0
                    },
                    new() { 
                        Titre = "Digitalisation des PME au Sénégal",
                        Auteur = "Aissatou Fall",
                        Contenu = "Analyse de la transformation digitale des PME sénégalaises.",
                        Date = DateTime.UtcNow.AddDays(-5),
                        Statut = "Validé",
                        FiliereId = filieres.Skip(1).FirstOrDefault()?.Id ?? filieres.FirstOrDefault()?.Id ?? 0,
                        EncadreurId = encadreurs.Skip(1).FirstOrDefault()?.Id ?? encadreurs.FirstOrDefault()?.Id ?? 0
                    },
                    new() { 
                        Titre = "Blockchain et traçabilité agricole",
                        Auteur = "Moussa Sarr",
                        Contenu = "Étude de l'implémentation de la blockchain pour la traçabilité.",
                        Date = DateTime.UtcNow.AddDays(-10),
                        Statut = "En attente",
                        FiliereId = filieres.FirstOrDefault()?.Id ?? 0,
                        EncadreurId = encadreurs.Skip(2).FirstOrDefault()?.Id ?? encadreurs.FirstOrDefault()?.Id ?? 0
                    },
                    new() { 
                        Titre = "Droit foncier et développement rural",
                        Auteur = "Mariama Gueye",
                        Contenu = "Analyse juridique des réformes foncières au Sénégal.",
                        Date = DateTime.UtcNow.AddDays(-15),
                        Statut = "Rejeté",
                        FiliereId = filieres.Skip(2).FirstOrDefault()?.Id ?? filieres.FirstOrDefault()?.Id ?? 0,
                        EncadreurId = encadreurs.FirstOrDefault()?.Id ?? 0
                    }
                };
                _context.memoires.AddRange(memoires);
                await _context.SaveChangesAsync();

                return Ok(new { 
                    message = "Données insérées avec succès",
                    etudiants = etudiants.Count,
                    memoires = memoires.Count
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, details = ex.InnerException?.Message });
            }
        }
    }
}
