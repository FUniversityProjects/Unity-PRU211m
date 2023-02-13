# PRN211 - AudioStore - MVC

## Hướng dẫn sử dụng git cho repo chung
- **Clone this repo** --> `git clone https://github.com/FUniversityProjects/PRN211-AudioStore.git`
- **Kiểm tra trạng thái file/folder sau khi code** --> `git status`
- **Add các file/folder đã thay đổi** --> `git add .` hoặc `git add <folder/file>`
- **Tạo commit sau khi add file/folder vào stage** --> `git commit -m "<message>"`
- *Lưu ý khi tạo commit: message phải có commit convension và thông tin tổng quát về commit*
  - VD: *script: add monster moving*
- **Tạo nhánh mới (dành cho lần đầu trước khi push code, các lần sau không cần)** --> `git checkout -b <nhánh tạo> <nhánh cha>`
- **Di chuyển sang các nhánh khác** --> `git checkout <tên nhánh>`
- **Kéo code từ trên github về** --> `git pull`
- **Đẩy code lên nhánh (dành cho lần đầu push lên nhánh mới)** --> `git push origin -u <tên nhánh>`
- **Đẩy code lên nhánh (dành cho các lần sau)** --> `git push`
- *Phải xử lý các conflict trước khi push code -> Click to <kbd>resolve conflict</kbd> in vscode when it notify conflict code.*
- *Lưu ý về merge code: các thành viên phải tạo nhánh riêng cho cá nhân, sau khi push code -> tạo pull request về nhánh develop; nếu có lỗi gì về git, báo về leader để xử lý.*

## Hướng dẫn sử dụng các folder/file trong dự án chung

**1. Các quy định về folders/files chung cần lưu ý**
- Thư mục `Animations`:
  - Các file *Animation* phải được wrap bởi thư mục cha trùng tên với character hiện tại.
- Thư mục `Prefabs`:
  - Đây là thư mục chứa các models/sprites được dụng sẵn.
  - *Lưu ý: như ở mục animations, các file prefabs được đặt bên trong thư mục cha.*
- Thư mục `Scenes`:
  - Chứa các scenes cho 1 màn chơi.
  - *Lưu ý: nhóm mình sẽ sử dụng 1 scene cho 1 cảnh nhất định. Mỗi scene sẽ được đặt tên theo màn chơi.*
- Thư mục `Scripts`:
  - Chứa các file .cs script. Tương tác với GameObject.
  - *Lưu ý: như ở mục animations, các file prefabs được đặt bên trong thư mục cha.*
- File `Sprites`:
  - Chứa các hoạt ảnh tĩnh của character/map.
  - *Lưu ý: như ở mục animations, các file prefabs được đặt bên trong thư mục cha.*
- File `Models`:
  - *Chưa dùng tới, không cần lưu ý.*
- Folder `Audio`:
  - *Chưa dùng tới, không cần lưu ý.*

**2. Quy định việc tạo các folder/file mới**
- Tại project chung, có thể tạo thêm folders khác như *Models, Audio, Cameras...* để hỗ trợ.
- *Lưu ý: không tuỳ ý tạo các file đơn lẻ, các files phải được wrap lại bên trong 1 folder cụ thể.*
