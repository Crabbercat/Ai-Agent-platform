using System;

namespace AI_Agent_WebApp.Models.Entities
{
    public class SystemLog
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
