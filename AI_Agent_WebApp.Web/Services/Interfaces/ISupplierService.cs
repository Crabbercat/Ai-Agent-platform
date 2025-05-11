using AI_Agent_WebApp.Models.Entities;
using System.Collections.Generic;

namespace AI_Agent_WebApp.Services.Interfaces
{
    public interface ISupplierService
    {
        Supplier GetSupplierById(int id);
        IEnumerable<Supplier> GetAllSuppliers();
        void ToggleStatus(int id);
        void UpdateProfile(Supplier supplier);
        void UpdatePassword(int id, string newPasswordHash);
    }
}
