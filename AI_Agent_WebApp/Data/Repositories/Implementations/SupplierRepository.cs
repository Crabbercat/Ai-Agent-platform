using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class SupplierRepository : ISupplierRepository
    {
        public void ToggleStatus(int id) => throw new NotImplementedException();
        public IEnumerable<Supplier> GetAll() => throw new NotImplementedException();
        public void UpdateProfile(Supplier supplier) => throw new NotImplementedException();
        public void UpdatePassword(int id, string newPasswordHash) => throw new NotImplementedException();
    }
}
