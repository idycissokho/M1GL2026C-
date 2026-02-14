using M1GLSERVER.DTOs;
using M1GLSERVER.EntityE2E;
using M1GLSERVER.Repositories;

namespace M1GLSERVER.Services
{
    public class FiliereService : IFiliereService
    {
        private readonly IFiliereRepository _repository;

        public FiliereService(IFiliereRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FiliereDto>> GetAllAsync()
        {
            var filieres = await _repository.GetAllAsync();
            return filieres.Select(f => new FiliereDto
            {
                Id = f.Id,
                Nom = f.Nom
            });
        }

        public async Task<FiliereDto?> GetByIdAsync(int id)
        {
            var filiere = await _repository.GetByIdAsync(id);
            if (filiere == null) return null;

            return new FiliereDto
            {
                Id = filiere.Id,
                Nom = filiere.Nom
            };
        }

        public async Task<FiliereDto> CreateAsync(CreateFiliereDto dto)
        {
            var filiere = new Filiere
            {
                Nom = dto.Nom.Trim()
            };

            var created = await _repository.CreateAsync(filiere);

            return new FiliereDto
            {
                Id = created.Id,
                Nom = created.Nom
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateFiliereDto dto)
        {
            var filiere = await _repository.GetByIdAsync(id);
            if (filiere == null) return false;

            filiere.Nom = dto.Nom.Trim();

            return await _repository.UpdateAsync(filiere);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
