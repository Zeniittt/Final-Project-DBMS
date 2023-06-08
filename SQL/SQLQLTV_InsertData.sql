-----------------------Insert DaTa-----------------------------------------

insert into Account Values('admin', 'admin', 'admin')
GO

insert into NXB Values('NXB1', N'Kim Đồng', N'2 Võ Văn Ngân')
insert into NXB Values('NXB2', N'Trần Phát', N'23 Nguyễn Thị Thập')
insert into NXB Values('NXB3', N'Trương Thị', N'10 Cách Mạng Tháng Tám')
GO

insert into TheLoai Values(01, N'Kỹ năng')
insert into TheLoai Values(02, N'Truyện tranh')
insert into TheLoai Values(03, N'Phiêu lưu')
GO

insert into TacGia Values('TG01', N'Nguyễn Văn A')
insert into TacGia Values('TG02', N'Nguyễn Văn B')
insert into TacGia Values('TG03', N'Nguyễn Văn C')
GO

insert into ViTri Values('A11', 'A','1','1')
insert into ViTri Values('A12', 'A','1','2')
insert into ViTri Values('B11', 'B','1','1')
GO

insert into NgonNgu Values(01, N'Tiếng Anh')
insert into NgonNgu Values(02, N'Tiếng Việt')
insert into NgonNgu Values(03, N'Tiếng Nga')
GO

insert into TinhTrangSach Values(0, N'Nguyên vẹn')
insert into TinhTrangSach Values(1, N'Rách')
insert into TinhTrangSach Values(2, N'Mất sách')
GO

--Thêm nhân viên
exec Proc_ThemNhanVien 'NV01', N'Trần Mạnh Huy', '2002-07-24', N'Nam', 0943586173
exec Proc_ThemNhanVien 'NV02', N'Phùng Huy Hoàng', '2002-07-23', N'Nam', 0496358861
exec Proc_ThemNhanVien'NV03', N'Triệu Phúc Định', '2002-08-24', N'Nam', 0346258914
exec Proc_ThemNhanVien'NV04', N'Nguyễn Quốc Đức Tín', '2002-07-01', N'Nam', 0932863396
Go

--thêm sách 
exec Proc_ThemSach 1,N'Một năm tư duy tích cực', 'TG01', 01, 01, 'NXB1','A11', 0, 15, 25000
exec Proc_ThemSach 2,N'One Piece chap 1062', 'TG02',02, 02,'NXB2','A12', 0, 23, 12000
exec Proc_ThemSach 3, N'Nhà giả kim', 'TG03',03,03, 'NXB3','B11' ,0, 10, 160000
Go

--thêm đọc giả
exec Proc_ThemDocGia 'dg01', N'Lê Thẩm Dương', N'Nam','2002-07-24', 'HCM', '02365296212'
exec Proc_ThemDocGia 'dg02', N'Trần Đăng Khoa',N'Nam','2002-07-23', 'HCM', '02496114523'
exec Proc_ThemDocGia 'dg03', N'Trần Huy Tín', N'Nam', '2002-07-01', 'HCM', '0324953375'
exec Proc_ThemDocGia 'dg04', N'Lê Phương Anh', N'Nữ','2002-07-24', 'HCM', '02365296212'
exec Proc_ThemDocGia 'dg05', N'Trần Mạnh Hoàng',N'Nam','2002-07-23', 'HCM', '02496114523'
exec Proc_ThemDocGia 'dg06', N'Trịnh Quốc Bỉ', N'Nam', '2002-07-01', 'HCM', '0324953375'
exec Proc_ThemDocGia 'dg07', N'Nguyễn Văn Kiệt', N'Nam', '2010-07-01', 'HCM', '0324953375'
Go