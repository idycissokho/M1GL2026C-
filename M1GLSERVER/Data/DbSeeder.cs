using M1GLSERVER.EntityE2E;
using Microsoft.AspNetCore.Identity;

namespace M1GLSERVER.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(DbMemoireContextE2E context, UserManager<Utilisateur> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            // Seed rôle Admin
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole<int>("Admin"));

            // Seed Administrateurs
            var admins = new[]
            {
                new { Email = "admin@memoire.sn", Nom = "Admin", Prenom = "Principal", Password = "Admin@123" },
                new { Email = "admin2@memoire.sn", Nom = "Admin", Prenom = "Secondaire", Password = "Admin@123" }
            };

            foreach (var a in admins)
            {
                if (await userManager.FindByEmailAsync(a.Email) == null)
                {
                    var admin = new Utilisateur { Nom = a.Nom, Prenom = a.Prenom, Email = a.Email, UserName = a.Email, EmailConfirmed = true };
                    var result = await userManager.CreateAsync(admin, a.Password);
                    if (result.Succeeded)
                        await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            if (context.Filieres.Any() || context.Etudiants.Any() || context.Encadreurs.Any())
                return;

            // Seed Filières
            var filieres = new List<Filiere>
            {
                new Filiere { Nom = "Génie Logiciel" },
                new Filiere { Nom = "Réseaux et Télécommunications" },
                new Filiere { Nom = "Systèmes d'Information" },
                new Filiere { Nom = "Intelligence Artificielle" },
                new Filiere { Nom = "Cybersécurité" }
            };
            context.Filieres.AddRange(filieres);
            await context.SaveChangesAsync();

            // Seed Encadreurs
            var encadreurs = new List<Encadreur>
            {
                new Encadreur { Nom = "Diop", Prenom = "Amadou", Email = "amadou.diop@ucad.sn", UserName = "amadou.diop@ucad.sn" },
                new Encadreur { Nom = "Ndiaye", Prenom = "Fatou", Email = "fatou.ndiaye@ucad.sn", UserName = "fatou.ndiaye@ucad.sn" },
                new Encadreur { Nom = "Sall", Prenom = "Moussa", Email = "moussa.sall@ucad.sn", UserName = "moussa.sall@ucad.sn" },
                new Encadreur { Nom = "Fall", Prenom = "Aïssatou", Email = "aissatou.fall@ucad.sn", UserName = "aissatou.fall@ucad.sn" },
                new Encadreur { Nom = "Sy", Prenom = "Ousmane", Email = "ousmane.sy@ucad.sn", UserName = "ousmane.sy@ucad.sn" },
                new Encadreur { Nom = "Sarr", Prenom = "Mariama", Email = "mariama.sarr@ucad.sn", UserName = "mariama.sarr@ucad.sn" }
            };

            foreach (var encadreur in encadreurs)
            {
                var result = await userManager.CreateAsync(encadreur, "Passer@123");
                if (!result.Succeeded)
                    throw new Exception($"Erreur création encadreur: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            // Seed Étudiants
            var etudiants = new List<Etudiant>
            {
                new Etudiant { Nom = "Ba", Prenom = "Cheikh", Email = "cheikh.ba@esp.sn", UserName = "cheikh.ba@esp.sn" },
                new Etudiant { Nom = "Diallo", Prenom = "Aminata", Email = "aminata.diallo@esp.sn", UserName = "aminata.diallo@esp.sn" },
                new Etudiant { Nom = "Gueye", Prenom = "Ibrahima", Email = "ibrahima.gueye@esp.sn", UserName = "ibrahima.gueye@esp.sn" },
                new Etudiant { Nom = "Thiam", Prenom = "Khady", Email = "khady.thiam@esp.sn", UserName = "khady.thiam@esp.sn" },
                new Etudiant { Nom = "Cisse", Prenom = "Mamadou", Email = "mamadou.cisse@esp.sn", UserName = "mamadou.cisse@esp.sn" },
                new Etudiant { Nom = "Mbaye", Prenom = "Ndeye", Email = "ndeye.mbaye@esp.sn", UserName = "ndeye.mbaye@esp.sn" },
                new Etudiant { Nom = "Diouf", Prenom = "Abdoulaye", Email = "abdoulaye.diouf@esp.sn", UserName = "abdoulaye.diouf@esp.sn" },
                new Etudiant { Nom = "Kane", Prenom = "Sokhna", Email = "sokhna.kane@esp.sn", UserName = "sokhna.kane@esp.sn" },
                new Etudiant { Nom = "Faye", Prenom = "Modou", Email = "modou.faye@esp.sn", UserName = "modou.faye@esp.sn" },
                new Etudiant { Nom = "Seck", Prenom = "Awa", Email = "awa.seck@esp.sn", UserName = "awa.seck@esp.sn" }
            };

            foreach (var etudiant in etudiants)
            {
                var result = await userManager.CreateAsync(etudiant, "Passer@123");
                if (!result.Succeeded)
                    throw new Exception($"Erreur création étudiant: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            await context.SaveChangesAsync();

            var encadreursDb = context.Encadreurs.ToList();

            // Seed Mémoires avec statuts corrects
            var memoires = new List<Memoire>
            {
                new Memoire { Titre = "Développement d'une application mobile de gestion des transports urbains à Dakar", Auteur = "Cheikh Ba", Contenu = "Application mobile pour optimiser les transports en commun à Dakar avec géolocalisation et paiement mobile.", Date = DateTime.UtcNow.AddMonths(-6), Statut = "Validé", FiliereId = filieres[0].Id, EncadreurId = encadreursDb[0].Id },
                new Memoire { Titre = "Système de détection de fraudes bancaires par intelligence artificielle", Auteur = "Aminata Diallo", Contenu = "Utilisation du machine learning pour détecter les transactions frauduleuses dans les banques sénégalaises.", Date = DateTime.UtcNow.AddMonths(-4), Statut = "En attente", FiliereId = filieres[3].Id, EncadreurId = encadreursDb[1].Id },
                new Memoire { Titre = "Plateforme e-learning pour l'enseignement à distance au Sénégal", Auteur = "Ibrahima Gueye", Contenu = "Conception d'une plateforme d'apprentissage en ligne adaptée au contexte sénégalais.", Date = DateTime.UtcNow.AddMonths(-3), Statut = "En attente", FiliereId = filieres[2].Id, EncadreurId = encadreursDb[2].Id },
                new Memoire { Titre = "Sécurisation des réseaux Wi-Fi publics dans les universités", Auteur = "Khady Thiam", Contenu = "Étude et mise en place de solutions de sécurité pour les réseaux sans fil universitaires.", Date = DateTime.UtcNow.AddMonths(-5), Statut = "Validé", FiliereId = filieres[4].Id, EncadreurId = encadreursDb[3].Id },
                new Memoire { Titre = "Application de gestion agricole pour les producteurs sénégalais", Auteur = "Mamadou Cisse", Contenu = "Solution digitale pour aider les agriculteurs à gérer leurs cultures et prévisions météo.", Date = DateTime.UtcNow.AddMonths(-2), Statut = "En attente", FiliereId = filieres[0].Id, EncadreurId = encadreursDb[4].Id },
                new Memoire { Titre = "Système de télémédecine pour les zones rurales du Sénégal", Auteur = "Ndeye Mbaye", Contenu = "Plateforme de consultation médicale à distance pour améliorer l'accès aux soins.", Date = DateTime.UtcNow.AddMonths(-7), Statut = "Validé", FiliereId = filieres[2].Id, EncadreurId = encadreursDb[5].Id },
                new Memoire { Titre = "Optimisation des réseaux 5G pour les télécommunications au Sénégal", Auteur = "Abdoulaye Diouf", Contenu = "Étude sur le déploiement et l'optimisation de la 5G dans le contexte sénégalais.", Date = DateTime.UtcNow.AddMonths(-1), Statut = "En attente", FiliereId = filieres[1].Id, EncadreurId = encadreursDb[0].Id },
                new Memoire { Titre = "Chatbot intelligent pour l'administration publique sénégalaise", Auteur = "Sokhna Kane", Contenu = "Assistant virtuel basé sur l'IA pour faciliter les démarches administratives des citoyens.", Date = DateTime.UtcNow.AddMonths(-8), Statut = "Validé", FiliereId = filieres[3].Id, EncadreurId = encadreursDb[1].Id },
                new Memoire { Titre = "Blockchain pour la traçabilité des produits locaux sénégalais", Auteur = "Modou Faye", Contenu = "Utilisation de la blockchain pour garantir l'authenticité des produits Made in Senegal.", Date = DateTime.UtcNow.AddMonths(-3), Statut = "En attente", FiliereId = filieres[0].Id, EncadreurId = encadreursDb[2].Id },
                new Memoire { Titre = "Système de surveillance intelligente pour la sécurité urbaine", Auteur = "Awa Seck", Contenu = "Solution de vidéosurveillance avec reconnaissance faciale pour améliorer la sécurité à Dakar.", Date = DateTime.UtcNow.AddMonths(-4), Statut = "Rejeté", FiliereId = filieres[4].Id, EncadreurId = encadreursDb[3].Id }
            };

            context.memoires.AddRange(memoires);
            await context.SaveChangesAsync();
        }
    }
}
