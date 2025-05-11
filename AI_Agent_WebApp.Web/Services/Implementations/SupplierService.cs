using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using AI_Agent_WebApp.Services.Interfaces;
using System.Collections.Generic;

namespace AI_Agent_WebApp.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repo;
        public SupplierService(ISupplierRepository repo) { _repo = repo; }
        public Supplier GetSupplierById(int id) => _repo.GetById(id);
        public IEnumerable<Supplier> GetAllSuppliers() => _repo.GetAll();
        public void ToggleStatus(int id) => _repo.ToggleStatus(id);
        public void UpdateProfile(Supplier supplier) => _repo.UpdateProfile(supplier);
        public void UpdatePassword(int id, string newPasswordHash) => _repo.UpdatePassword(id, newPasswordHash);
    }
}
