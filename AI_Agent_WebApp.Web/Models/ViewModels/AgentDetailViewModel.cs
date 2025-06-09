using System.Collections.Generic;

namespace AI_Agent_WebApp.Models.ViewModels
{
    public class AgentDetailViewModel
    {
        public required Entities.Agent Agent { get; set; }
        public int ReviewCount { get; set; }
        public int FollowerCount { get; set; }
        public List<Entities.Review> Reviews { get; set; } = new();
        public bool IsFollowed { get; set; } // Đánh dấu user đã follow agent này chưa
        public bool IsOwner { get; set; } // Đánh dấu user có phải là supplier sở hữu agent này không
        public bool IsSupplier { get; set; } // Đánh dấu user là supplier (dùng cho nút xem tất cả bài viết)
    }
}
