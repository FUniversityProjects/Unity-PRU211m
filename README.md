# PRU211m - HeroBase - Unity

## Hướng dẫn sử dụng git cho repo chung
- **Clone this repo** --> `git clone https://github.com/FUniversityProjects/Unity-PRU211m.git`
- **Kiểm tra trạng thái file/folder sau khi code** --> `git status`
- **Add các file/folder đã thay đổi** --> `git add .` hoặc `git add <folder/file>`
- **Tạo commit sau khi add file/folder vào stage** --> `git commit -m "<message>"`
- *Lưu ý khi tạo commit: message phải có commit convension và thông tin tổng quát về commit*
  - VD: *script: add monster moving*
- **Tạo nhánh mới (dành cho lần đầu trước khi push code, các lần sau không cần)** --> `git checkout -b <nhánh tạo>`
- **Di chuyển sang các nhánh khác** --> `git checkout <tên nhánh>`
- **Kéo code từ trên github về** --> `git pull`
- **Đẩy code lên nhánh (dành cho lần đầu push lên nhánh mới)** --> `git push origin -u <tên nhánh>`
- **Đẩy code lên nhánh (dành cho các lần sau)** --> `git push`
- *Phải xử lý các conflict trước khi push code -> Click to <kbd>resolve conflict</kbd> in vscode when it notify conflict code.*
- *Lưu ý về merge code: các thành viên phải tạo nhánh riêng cho cá nhân, sau khi push code -> tạo pull request về nhánh develop; nếu có lỗi gì về git, báo về leader để xử lý.*
