using M1GLSERVER.DTOs;
using M1GLSERVER.EntityE2E;
using M1GLSERVER.Repositories;

namespace M1GLSERVER.Services
{
    public class EncadreurService : IEncadreurService
    {
        private readonly IEncadreurRepository _repository;

        public EncadreurService(IEncadreurRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EncadreurDto>> GetAllAsync()
        {
            var encadreurs = await _repository.GetAllAsync();
            return encadreurs.Select(e => new EncadreurDto
            {
                Id = e.Id,
                Nom = e.Nom,
                Email = e.Email
            });
        }

        public async Task<EncadreurDto?> GetByIdAsync(int id)
        {
            var encadreur = await _repository.GetByIdAsync(id);
            if (encadreur == null) return null;

            return new EncadreurDto
            {
                Id = encadreur.Id,
                Nom = encadreur.Nom,
                Email = encadreur.Email
            };
        }

        public async Task<EncadreurDto> CreateAsync(CreateEncadreurDto dto)
        {
            var encadreur = new Encadreur
            {
                Nom = dto.Nom.Trim(),
                Email = dto.Email.Trim()
            };

            var created = await _repository.CreateAsync(encadreur);

            return new EncadreurDto
            {
                Id = created.Id,
                Nom = created.Nom,
                Email = created.Email
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateEncadreurDto dto)
        {
            var encadreur = await _repository.GetByIdAsync(id);
            if (encadreur == null) return false;

            encadreur.Nom = dto.Nom.Trim();
            encadreur.Email = dto.Email.Trim();

            return await _repository.UpdateAsync(encadreur);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
