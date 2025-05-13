namespace AI_Agent_WebApp.Models.ViewModels
{
    public class RegisterSupplierViewModel
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string FullName { get; set; }
        public required string Password { get; set; }
        public required string CompanyName { get; set; }
        public required string CompanyWebsite { get; set; }
    }
}
