using System.Collections.Generic;

namespace AI_Agent_WebApp.Models.ViewModels
{
    public class SystemStatisticsViewModel
    {
        public int TotalAgents { get; set; }
        public int TotalSuppliers { get; set; }
        public int TotalUsers { get; set; }
        public List<AgentsByCategory> AgentsByCategory { get; set; } = new();
    }
    public class AgentsByCategory
    {
        public string CategoryName { get; set; }
        public int Count { get; set; }
    }
}
