namespace AI_Agent_WebApp.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        void ToggleStatus(int id);
        IEnumerable<Models.Entities.Supplier> GetAll();
        void UpdateProfile(Models.Entities.Supplier supplier);
        void UpdatePassword(int id, string newPasswordHash);
    }
}
