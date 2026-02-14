using M1GLSERVER.DTOs;
using M1GLSERVER.EntityE2E;
using M1GLSERVER.Repositories;

namespace M1GLSERVER.Services
{
    public class EtudiantService : IEtudiantService
    {
        private readonly IEtudiantRepository _repository;

        public EtudiantService(IEtudiantRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EtudiantDto>> GetAllAsync()
        {
            var etudiants = await _repository.GetAllAsync();
            return etudiants.Select(e => new EtudiantDto
            {
                Id = e.Id,
                Nom = e.Nom,
                Prenom = e.Prenom,
                Email = e.Email
            });
        }

        public async Task<EtudiantDto?> GetByIdAsync(int id)
        {
            var etudiant = await _repository.GetByIdAsync(id);
            if (etudiant == null) return null;

            return new EtudiantDto
            {
                Id = etudiant.Id,
                Nom = etudiant.Nom,
                Prenom = etudiant.Prenom,
                Email = etudiant.Email
            };
        }

        public async Task<EtudiantDto> CreateAsync(CreateEtudiantDto dto)
        {
            var etudiant = new Etudiant
            {
                Nom = dto.Nom.Trim(),
                Prenom = dto.Prenom.Trim(),
                Email = dto.Email.Trim()
            };

            var created = await _repository.CreateAsync(etudiant);

            return new EtudiantDto
            {
                Id = created.Id,
                Nom = created.Nom,
                Prenom = created.Prenom,
                Email = created.Email
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateEtudiantDto dto)
        {
            var etudiant = await _repository.GetByIdAsync(id);
            if (etudiant == null) return false;

            etudiant.Nom = dto.Nom.Trim();
            etudiant.Prenom = dto.Prenom.Trim();
            etudiant.Email = dto.Email.Trim();

            return await _repository.UpdateAsync(etudiant);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
