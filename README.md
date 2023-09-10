# WhoruBackend
### GrenNMC
---
# Cài đặt
1. Công cụ
- Visual studio IDE
- Postgresql (Database)
- Postman (Test API)
2. Configuration
- Tạo cơ sở dữ liệu rỗng trong Postgresql theo tên muốn đặt.
- Vào WhoruBackend\appsettings.json chỉnh sửa chuỗi "ConnectionStrings" bao gồm Password và tên Database như trên trong Postgresql theo cấu hình.
3. Tạo Cơ sở dữ liệu
- Clone dự án theo link https://github.com/GrenNMC/Whoru_Backend
- Mở dự án trên Visual studio
- Vào Tools -> Nuget Package Manager -> Package Manager Console
- Nhập dòng:
  ```
  add-migration "Tên file bạn muốn đặt (lưu ý không trùng tên các file trong thư mực migration)"
  ```
  Chờ cho đến khi khởi tạo file migration.
- Nhập dòng:
  ``
  update-database
  ``
  Chờ cập nhập database
- Vào Postgresql kiểm tra dữ liệu đã tạo.
4. Khởi động dự án
- Vào giao diện visual studio code nhấn F5 hoặc Ctrl F5 để chạy chương trình.
- Vào Postman để thực hiện Test các API.
