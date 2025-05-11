using System;

namespace AI_Agent_WebApp.Models.Entities
{
    public class Supplier : User
    {
        public required string CompanyName { get; set; }
        public required string CompanyWebsite { get; set; }
        public bool Status { get; set; }
    }
}
