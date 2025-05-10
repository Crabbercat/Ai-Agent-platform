using System;

namespace AI_Agent_WebApp.Models.Entities
{
    public class Supplier : User
    {
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
        public bool Status { get; set; }
    }
}
