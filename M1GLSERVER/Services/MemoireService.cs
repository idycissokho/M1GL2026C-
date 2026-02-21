using M1GLSERVER.DTOs;
using M1GLSERVER.EntityE2E;
using M1GLSERVER.Repositories;
using M1GLSERVER.Services.interfaces;

namespace M1GLSERVER.Services
{
    public class MemoireService : IMemoireService
    {
        private readonly IMemoireRepository _repository;

        public MemoireService(IMemoireRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MemoireDto>> GetAllAsync()
        {
            var memoires = await _repository.GetAllAsync();
            return memoires.Select(m => new MemoireDto
            {
                Id = m.Id,
                Titre = m.Titre,
                Auteur = m.Auteur,
                Contenu = m.Contenu,
                Date = m.Date,
                Statut = m.Statut,
                FiliereId = m.FiliereId,
                FiliereNom = m.Filiere?.Nom,
                EncadreurId = m.EncadreurId,
                EncadreurNom = m.Encadreur?.Nom
            });
        }

        public async Task<MemoireDto?> GetByIdAsync(int id)
        {
            var memoire = await _repository.GetByIdAsync(id);
            if (memoire == null) return null;

            return new MemoireDto
            {
                Id = memoire.Id,
                Titre = memoire.Titre,
                Auteur = memoire.Auteur,
                Contenu = memoire.Contenu,
                Date = memoire.Date,
                Statut = memoire.Statut,
                FiliereId = memoire.FiliereId,
                FiliereNom = memoire.Filiere?.Nom,
                EncadreurId = memoire.EncadreurId,
                EncadreurNom = memoire.Encadreur?.Nom
            };
        }

        public async Task<MemoireDto> CreateAsync(CreateMemoireDto dto)
        {
            var memoire = new Memoire
            {
                Titre = dto.Titre.Trim(),
                Auteur = dto.Auteur.Trim(),
                Contenu = dto.Contenu.Trim(),
                Date = DateTime.UtcNow,
                Statut = "En attente",
                FiliereId = dto.FiliereId,
                EncadreurId = dto.EncadreurId
            };

            var created = await _repository.CreateAsync(memoire);
            var result = await _repository.GetByIdAsync(created.Id);

            return new MemoireDto
            {
                Id = result!.Id,
                Titre = result.Titre,
                Auteur = result.Auteur,
                Contenu = result.Contenu,
                Date = result.Date,
                Statut = result.Statut,
                FiliereId = result.FiliereId,
                FiliereNom = result.Filiere?.Nom,
                EncadreurId = result.EncadreurId,
                EncadreurNom = result.Encadreur?.Nom
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateMemoireDto dto)
        {
            var memoire = await _repository.GetByIdAsync(id);
            if (memoire == null) return false;

            memoire.Titre = dto.Titre.Trim();
            memoire.Auteur = dto.Auteur.Trim();
            memoire.Contenu = dto.Contenu.Trim();
            memoire.Statut = dto.Statut.Trim();
            memoire.FiliereId = dto.FiliereId;
            memoire.EncadreurId = dto.EncadreurId;

            return await _repository.UpdateAsync(memoire);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
