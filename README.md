# Ai-Agent-platform

Web app help connect user to AI-agent supplier

Contributors:

* Nguyễn Trọng Hiếu(Crabbercat)
* Huỳnh Phước Lộc(lochuynhphuoc)
* Huỳnh Phước Mạnh



# AI_Agent_WebApp

## Cấu trúc thư mục

```
AI_Agent_WebApp/
│
├── Controllers/                # Lớp điều khiển: Giao tiếp với người dùng
│   ├── AgentController.cs
│   ├── ReviewController.cs
│   ├── ArticleController.cs
│   ├── UserController.cs
│   ├── SupplierController.cs
│   ├── StaffController.cs
│   └── AuthController.cs
│
├── Models/                     # Lớp Entity / DTO / ViewModel
│   ├── Entities/              # Thực thể tương ứng với bảng DB
│   │   ├── Agent.cs
│   │   ├── Review.cs
│   │   ├── Article.cs
│   │   ├── User.cs
│   │   ├── Supplier.cs
│   │   ├── Staff.cs
│   │   └── SystemLog.cs
│   │
│   ├── ViewModels/            # Dữ liệu truyền giữa Controller và View
│   │   ├── AgentViewModel.cs
│   │   ├── CreateReviewViewModel.cs
│   │   ├── ProfileViewModel.cs
│   │   └── ...
│   │
│   └── DbContext.cs           # Cấu hình EF Core DbContext
│
├── Repositories/              # Lớp truy cập dữ liệu (Data Access)
│   ├── Interfaces/            # Interface cho các repository
│   │   ├── IAgentRepository.cs
│   │   ├── IUserRepository.cs
│   │   └── ...
│   │
│   ├── Implementations/       # Các class triển khai interface
│   │   ├── AgentRepository.cs
│   │   ├── UserRepository.cs
│   │   └── ...
│
├── Services/                  # Lớp xử lý nghiệp vụ (Business Layer)
│   ├── Interfaces/
│   │   ├── IAgentService.cs
│   │   ├── IUserService.cs
│   │   └── ...
│   │
│   └── Implementations/
│       ├── AgentService.cs
│       ├── UserService.cs
│       └── ...
│
├── Views/                     # Giao diện (Razor .cshtml)
│   ├── Shared/                # Layout, Partial view dùng chung
│   ├── Agent/                 # View liên quan đến Agent
│   ├── Review/
│   ├── Article/
│   ├── User/
│   ├── Supplier/
│   ├── Staff/
│   └── Auth/
│
├── wwwroot/                   # Tài nguyên tĩnh (JS, CSS, ảnh...)
│   ├── css/
│   ├── js/
│   └── images/
│
├── appsettings.json           # File cấu hình (connection string, logging...)
├── Program.cs                 # Điểm khởi chạy ứng dụng
└── Startup.cs                 # Cấu hình service, middleware, DI container
```

## Mô tả các thư mục chính

- **Controllers/**: Chứa các controller xử lý request/response giữa người dùng và hệ thống.
- **Models/**: Chứa các lớp Entity (tương ứng bảng DB), DTO, ViewModel và DbContext.
  - **Entities/**: Định nghĩa các thực thể ánh xạ với bảng dữ liệu.
  - **ViewModels/**: Định nghĩa các lớp truyền dữ liệu giữa Controller và View.
- **Repositories/**: Lớp truy cập dữ liệu, gồm interface và các class triển khai.
- **Services/**: Lớp xử lý nghiệp vụ, gồm interface và các class triển khai.
- **Views/**: Chứa các Razor view (.cshtml) cho giao diện người dùng.
- **wwwroot/**: Chứa tài nguyên tĩnh như JS, CSS, hình ảnh.
- **appsettings.json**: File cấu hình ứng dụng.
- **Program.cs**: Điểm khởi chạy ứng dụng.
- **Startup.cs**: Cấu hình service, middleware, DI container.
