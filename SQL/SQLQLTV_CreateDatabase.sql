--drop database QLThuVien

--create Database QLThuVien
GO

CREATE TABLE AccountRole
(
	id INT NOT NULL,
	RoleName NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_AccountRole PRIMARY KEY (id)
);
GO

CREATE TABLE Account
(
	id INT IDENTITY PRIMARY KEY,
	Username NVARCHAR(100) NOT NULL UNIQUE,
	Password NVARCHAR(1000) NOT NULL,
	RoleID INT NOT NULL,			  --ID phân vai trò: 0 là admin, 1 là nhan viên
	CONSTRAINT FK_Account FOREIGN KEY (RoleID) REFERENCES AccountRole(id)
);
GO

--select * from Account
--select * from AccountRole
--insert into AccountRole values(0, N'Quản Lý')
--insert into AccountRole values(1, N'Nhân Viên')
--insert into Account values('admin', 'admin', 0)
----insert into Account values('NV01', 'huy', 1)
--drop table AccountRole
--drop table Account

create table dbo.Sach(
		MaSach int PRIMARY KEY,
		TenSach nvarchar(30),
		MaTG nvarchar(20),
		MaTL int,
		MaNN int,		
		MaNXB nvarchar(20),
		MaVT nvarchar(20),
		MaTT int,
		SoLuong int,
		GiaTien int,
)
GO

create table dbo.NXB(
	MaNXB nvarchar(20) PRIMARY KEY,
	TenNXB nvarchar(30),
	DiaChi nvarchar(30)
)
GO 

create table dbo.TheLoai(
	MaTL int PRIMARY KEY,
	TenTheLoai nvarchar(20)
)
GO

create table dbo.TacGia(
	MaTG nvarchar(20) PRIMARY KEY,
	TenTG nvarchar(20)
)
GO 

create table dbo.ViTri(
	MaVT nvarchar(20) PRIMARY KEY,
	Khu nvarchar(10),
	Ngan nvarchar(10),
	Ke nvarchar(10)
)
GO

create table dbo.NgonNgu(
	MaNN int PRIMARY KEY,
	TenNN nvarchar(20)
)
GO 

create table dbo.TinhTrangSach(
	MaTT int PRIMARY KEY,
	TinhTrang nvarchar(20)
)
GO

create table dbo.NhanVien(
	MaNV nvarchar(10) PRIMARY KEY,
	TenNV nvarchar(20),
	NgaySinh Date,
	GioiTinh nvarchar(3),
	SDT nvarchar(15)
)
GO

create table dbo.DocGia(
	MaDG nvarchar(10) PRIMARY KEY,
	TenDG nvarchar(30),
	GioiTinh nvarchar(5),
	NgaySinh Date,
	DiaChi nvarchar(50),
	SDT nvarchar(11)
)
GO

create table dbo.TheDG(
	MaDG nvarchar(10),
	TenDG nvarchar(30),
	NgayBatDau Date,
	NgayHetHan Date
)
GO

create table dbo.PhieuSach(
	MaPhieu int PRIMARY KEY IDENTITY,
	MaNV nvarchar(10),
	MaDG nvarchar(10),
	SoSachMuon int
)
GO

create table dbo.PhieuSachCT(
	MaPhieu int,
	STT int,
	MaSach int,
	MaTT int,
	TenNV nvarchar(20),
	TenDG nvarchar(30),
	NgayMuon Date,
	NgayTra Date,
	TienPhat int
)
GO

--lưu tất cả thông tin của dọc giả đã trả sách
create table dbo.LuuTatCaPhieuDaTraSach(
	MaPhieu int,
	STT int,
	MaSach int,
	MaTT int,
	TenNV nvarchar(20),
	TenDG nvarchar(30),
	NgayMuon Date,
	NgayTra Date,
	TienPhat int
)
GO

--CONSTRAINT
Alter table NhanVien ADD CONSTRAINT KyTuMaNV CHECK (MaNV LIKE 'NV%')
Alter table DocGia ADD CONSTRAINT KyTuMaDG CHECK (MaDG LIKE 'dg%')
Alter table TacGia ADD CONSTRAINT KyTuTacGia CHECK (MaTG LIKE 'TG%')
Alter table sach ADD CONSTRAINT Constraint_TT CHECK (MaTT = 0)
GO
  --KHÓA NGOẠI
alter table Sach with check add foreign key(MaTG) references TacGia(MaTG) ON DELETE SET NULL ON UPDATE CASCADE
alter table Sach with check add foreign key(MaTL) references TheLoai(MaTL) ON DELETE SET NULL ON UPDATE CASCADE
alter table Sach with check add foreign key(MaNXB) references NXB(MaNXB) ON DELETE SET NULL ON UPDATE CASCADE
alter table Sach with check add foreign key(MaVT) references ViTri(MaVT) ON DELETE SET NULL ON UPDATE CASCADE
alter table Sach with check add foreign key(MaNN) references NgonNgu(MaNN) ON DELETE SET NULL ON UPDATE CASCADE
alter table Sach with check add foreign key(MaTT) references TinhTrangSach(MaTT)
alter table TheDG with check add foreign key(MaDG) references DocGia(MaDG)
alter table PhieuSach with check add foreign key(MaDG) references DocGia(MaDG)
alter table PhieuSach with check add foreign key(MaNV) references NhanVien(MaNV)
alter table PhieuSachCT with check add foreign key(MaSach) references Sach(MaSach) ON DELETE SET NULL ON UPDATE CASCADE
alter table PhieuSachCT with check add foreign key(MaTT) references TinhTrangSach(MaTT)
GO

-----------------------------------TRIGGER-----------------------------------------------------
create TRIGGER [dbo].[CreateUserLogin] ON Account
FOR INSERT
AS
BEGIN
	DECLARE @user NVARCHAR(50), @password NVARCHAR(50), @type int, @db_name NVARCHAR(MAX)
	SET @db_name = DB_NAME()
	SELECT @user = Username, @password = Password, @type = RoleID FROM inserted

	EXEC('CREATE LOGIN [' + @user + '] WITH PASSWORD = '''+ @password +''', DEFAULT_DATABASE=[' + @db_name + ']')
	EXEC('CREATE USER [' + @user + '] FOR LOGIN [' + @user + ']')

	IF @type = 0
	BEGIN
		EXEC sp_addsrvrolemember @user, 'sysadmin'
		EXEC sp_addsrvrolemember @user, 'SecurityAdmin'
		EXEC sp_addsrvrolemember @user, 'ProcessAdmin'
		EXEC sp_addrolemember 'db_owner', @user
		EXEC sp_addrolemember 'db_accessadmin', @user
		EXEC sp_addrolemember 'db_securityadmin', @user
		EXEC sp_addrolemember 'QuanLy', @user
		EXEC('USE master; GRANT ALTER ANY LOGIN TO [' + @user + '] WITH GRANT OPTION')
	END
	ELSE IF @type = 1
	BEGIN
		EXEC sp_addrolemember 'NhanVien', @user
		EXEC sp_addrolemember 'db_datareader', @user
	END
END
go

-- trigger thêm nhân viên
create trigger ThemNhanVien on NhanVien
After insert
As
BeGin
declare @NgaySinh date
select @NgaySinh = NgaySinh from inserted
Begin tran
if(year(getdate()) - year(@NgaySinh) < 18)
Begin 
	Raiserror(N'Nhân viên không đủ tuổi!', 16, 1)
	Rollback
End
Else
Begin
	Raiserror(N'Thêm nhân viên thành công!!',16,1)
	commit
End
End
Go

-- trigger xóa nhân viên
create trigger XoaNhanVien on NhanVien
after DELETE
As
declare @nv nvarchar(10)
declare @Sonvxoa int
select @Sonvxoa = count(*) from deleted
if @Sonvxoa > 0
	set @nv = 'Co'
else
	set @nv = 'temp'
BEGIN
if (@nv = 'temp')
	begin
		Raiserror(N'Mã nhân viên không tồn tại!', 16, 1)
	end
else
	begin
		Raiserror(N'Xóa nhân viên thành công!', 16, 1)
		commit
	end
END
GO

-- trigger xóa sách
create trigger XoaSach on Sach
after DELETE
As
declare @sach nvarchar(10)
declare @Sosachxoa int
select @Sosachxoa = count(*) from deleted
if @Sosachxoa > 0
	set @sach = 'Co'
else
	set @sach = 'temp'
BEGIN
if (@sach = 'temp')
	begin
		Raiserror(N'Sách không tồn tại!', 16, 1)
	end
else
	begin
		Raiserror(N'Xóa sách thành công!', 16, 1)
		commit
	end
END
GO

-- trigger Cập nhật sách mới cho thư viện
create trigger CapNhatSach on Sach
After Insert
As
declare @SoLuong int, @MaSach int
select @SoLuong = SoLuong from inserted
select @MaSach = MaSach from inserted
Begin tran
if(@SoLuong = 0)
Begin 
	Raiserror(N'Số lượng sách phải lớn hơn không!', 16, 1)
	Rollback
End
Else
Begin
	Raiserror(N'Thêm sách thành công!', 16, 1)
	Commit
End
Go

-- trigger insert vào độc giả thì sẽ tự tạo thẻ đọc gỉả
create trigger ThemTheDG on DocGia
After INSERT
As
Declare @MaDG nvarchar(10), @TenDG nvarchar(30), @batdau Date = GetDate(), @ketthuc Date
select @MaDG = MaDG from inserted
select @TenDG = TenDG from inserted
set @ketthuc = DATEADD(year, 1, @batdau)
insert into TheDG values (@MaDG, @TenDG, @batdau, @ketthuc)
Go

-- trigger insert vào phiếu sách (đọc giả mượn sách) thì sẽ tự insert vào Phiếu Sách chi tiết
create trigger SachMuon on PhieuSach
AFTER INSERT
As
Declare @MaPhieu int, @MaNV nvarchar(10), @MaDG nvarchar(30), @TenNV nvarchar(20) , @TenDG nvarchar(30), @NgayMuon date, @NgayTra date, @SoSachMuon int
select @MaPhieu = MaPhieu from inserted
select @MaNV = MaNV from inserted
select @MaDG = MaDG from inserted
select @SoSachMuon = SoSachMuon from inserted
select @TenNV = TenNV from NhanVien where @MaNV = NhanVien.MaNV
select @TenDG = TenDG from DocGia where @MaDG = DocGia.MaDG
set @NgayMuon = GetDate()
set @NgayTra = DATEADD(day, 20, @NgayMuon)
Declare @NgayHetHanTheDG date
select @NgayHetHanTheDG = NgayHetHan from TheDG where MaDG = @MaDG
if getdate() <= @NgayHetHanTheDG
BEGIN
	declare @dem int = 1; WHILE @dem <= @SoSachMuon
	BeGin
		insert into PhieuSachCT values (@MaPhieu, @dem, null, 0, @TenNV, @TenDG, @NgayMuon, @NgayTra, 0);
		set @dem += 1;
	End
END
else
BEGIN
	Raiserror(N'Không thể mượn sách vì đã hết hạn thẻ thư viện!', 16, 1)
	delete from PhieuSach where MaPhieu = @MaPhieu
END
Go

-- trigger xóa ở phiếu sách (sau khi đọc giả trả sách HẾT SÁCH)
create trigger XoaSachMuon on PhieuSachCT
AFTER DELETE
As
Declare @MaPhieu int
Declare @dem int = 0	
select @MaPhieu = MaPhieu from deleted
select @dem = count (*) from PhieuSachCT where MaPhieu = @MaPhieu
if @dem = 0		-- đã trả hết sách
Begin
	Delete from PhieuSach where MaPhieu = @MaPhieu
End
Go

--giảm số lượng sách (ở table Sach) khi cho mượn sách
create trigger GiamKhiMuon on PhieuSachCT
FOR UPDATE
As
Declare @MaSach int, @SoLuong int, @MaPhieu int, @TienPhat int
select @MaSach = MaSach from inserted
select @SoLuong = SoLuong from Sach where MaSach = @MaSach
select @MaPhieu = MaPhieu from inserted
select @TienPhat = TienPhat from inserted
if @TienPhat = 0
Begin
	if @SoLuong > 0
	begin
		Set @SoLuong -=1
		update Sach set SoLuong = @SoLuong where MaSach = @MaSach
	end
	else
	begin
		Raiserror(N'Đã hết sách này!', 16, 1)
		update PhieuSachCT set MaSach = NULL where MaSach = @MaSach and MaPhieu = @MaPhieu
	end	
End
Go

-- tăng số lượng sách lại (ở table Sach) khi trả sách (sách có tình trạng bình thường mới tăng lại)
create trigger TangKhiTra on PhieuSachCT
FOR DELETE
As
Declare @MaSach int, @SoLuong int, @MaTT int
select @MaTT = MaTT from deleted
if @MaTT = 0
Begin
	select @MaSach = MaSach from deleted
	select @SoLuong = SoLuong from Sach where MaSach = @MaSach
	Set @SoLuong +=1
	update Sach set SoLuong = @SoLuong where MaSach = @MaSach
End
Go

-----------------------------------VIEW-----------------------------------------------------

CREATE VIEW [Danh sách tài khoản] 
as
select Username, Password, RoleID, RoleName as LoaiTaiKhoan
from Account, AccountRole
where Account.RoleID = AccountRole.id
Go



-- tạo view để xem thông tin sách
create view [Thông Tin Sách] 
as
select MaSach, TenSach, TenTG as TacGia, TenTheLoai as TheLoai, TenNN as NgonNgu, TenNXB as NXB, Khu, Ngan, Ke, TinhTrang, SoLuong, GiaTien
from Sach, TacGia, TheLoai, NgonNgu, NXB, ViTri, TinhTrangSach
Where Sach.MaTG = TacGia.MaTG
and Sach.MaTL = TheLoai.MaTL
and Sach.MaNN = NgonNgu.MaNN
and Sach.MaNXB = NXB.MaNXB
and Sach.MaVT = ViTri.MaVT
and Sach.MaTT = TinhTrangSach.MaTT
Go

-- tạo view để xem tất cả thông tin tất cả đọc giả đã và đang mượn sách----------------------------------------------------------------------
create view [Danh Sách Đọc Giả Mượn Sách Của Thư Viện] 
as
select * from 
((select * from PhieuSachCT) UNION (select * from LuuTatCaPhieuDaTraSach)) as temp
Go

-----------------------------------PROCEDURE-----------------------------------------------------

-- Them tai khoan
CREATE PROC ThemAccount
@userName NVARCHAR(50), @password NVARCHAR(50), @roleID INT
AS
BEGIN
    INSERT INTO dbo.Account VALUES( @userName, @password, @roleID )
END
GO

-- Xoa tai khoan
CREATE PROC XoaAccount
@userName NVARCHAR(50)
AS
BEGIN
    delete from Account where Username = @userName
END
GO


-- Dang nhap với tư cách là quản lý
CREATE PROC LoginAsQuanLy
@userName NVARCHAR(100),
@passWord NVARCHAR(100),
@role INT = 0
AS
BEGIN
	SELECT * FROM dbo.Account WHERE Username = @userName AND Password = @passWord AND RoleID = @role
END
GO

-- Proc kiểm tra nhân viên có tồn tại không
CREATE PROC LoginAsNhanVien
@userName  NVARCHAR(100),
@passWord NVARCHAR(100),
@role INT = 1
AS
BEGIN
	SELECT * FROM dbo.Account WHERE Username = @userName AND Password = @passWord AND RoleID = @role
END
GO

--Proc có tác dụng là để hạn chế SQL Injection
create proc USP_Login
@userName nvarchar(100), @password nvarchar(1000)
as
BEGIN
	SELECT * FROM dbo.Account WHERE Username = @userName AND Password = @password
END
GO


--Proc cho biết sách được bao nhiêu lần mượn
create proc SoLanSachDuocMuon
as
Begin
select [Danh Sách Đọc Giả Mượn Sách Của Thư Viện].MaSach, TenSach, count([Danh Sách Đọc Giả Mượn Sách Của Thư Viện] .MaSach) as SoLanMuon 
from [Danh Sách Đọc Giả Mượn Sách Của Thư Viện] , Sach 
where Sach.MaSach = [Danh Sách Đọc Giả Mượn Sách Của Thư Viện] .MaSach 
group by [Danh Sách Đọc Giả Mượn Sách Của Thư Viện] .MaSach, TenSach 
End
Go



--Proc cập nhật tiền phạt nếu mượn lố ngày và sách không nguyên vẹn
create proc CapNhatTienPhat
@MaPhieu int, @STT int, @MaSach int, @MaTT int
as
Begin
declare @tienphattemp1 int = 0
declare @tienphattemp2 int = 0
declare @NgayHomNay date = getdate(), @TienPhat int
update PhieuSachCT 
set @tienphattemp1 = TienPhat = TienPhat + (DATEDIFF(day, NgayTra, @NgayHomNay)) * 10000	 --lố hạn trả 1 ngày phạt 10000
where @NgayHomNay > NgayTra and MaPhieu = @MaPhieu and STT = @STT
select @TienPhat = GiaTien from Sach where MaSach = @MaSach
if @MaTT > 0   -- sách trả không nguyên vẹn
	Begin
	update PhieuSachCT 
	set @tienphattemp2 = TienPhat = TienPhat + @TienPhat, MaTT = @MaTT 
	where MaPhieu = @MaPhieu and STT = @STT
	End
if @tienphattemp1 > 0 and @tienphattemp2 > @tienphattemp1
	begin
	Raiserror(N'Bạn đã bị phạt tiền do đã trả quá thời hạn quy định và làm hư hại sách!', 16, 1)
	end
if @tienphattemp1 = 0 and  @tienphattemp2 > 0
	begin
	Raiserror(N'Bạn đã bị phạt tiền do đã làm hư hại sách!', 16, 1)
	end
if @tienphattemp1 > 0 and @tienphattemp2 = 0
	begin
	Raiserror(N'Bạn đã bị phạt tiền do đã trả quá thời hạn quy định!', 16, 1)
	end
if @tienphattemp1 = 0 and @tienphattemp2 = 0
	begin
	Raiserror(N'Bạn không bị phạt tiền!', 16, 1)
	end
End
Go

--Proc thêm nhân viên
create proc Proc_ThemNhanVien
@MaNV nvarchar(10), @TenNV nvarchar(20), @NgaySinh Date, @GioiTinh nvarchar(3), @SDT nvarchar(15)
As
insert into NhanVien values (@MaNV, @TenNV, @NgaySinh, @GioiTinh, @SDT)
Go

--Proc xóa nhân viên
create proc Proc_XoaNhanVien
@MaNV nvarchar(10)
As
delete from NhanVien where MaNV = @MaNV
Go

--Proc sửa thông tin nhân viên
create proc Proc_SuaNhanVien
@MaNV nvarchar(10), @TenNV nvarchar(20), @NgaySinh Date, @GioiTinh nvarchar(3), @SDT nvarchar(15)
As
begin tran
Update NhanVien
set MaNV = @MaNV, TenNV = @TenNV, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, SDT = @SDT 
where MaNV = @MaNV
if(year(getdate()) - year(@NgaySinh) < 18)
Begin 
	Raiserror(N'Không thể sửa nhân viên, nhân viên không đủ tuổi!', 16, 1)
	Rollback
End
Else
Begin
	Raiserror(N'Sửa nhân viên thành công!!',16,1)
	commit
End
Go

--Proc thêm sách vào thư viện
create proc Proc_ThemSach
@MaSach int, @TenSach nvarchar(30), @MaTG nvarchar(20), @MaTL int, @MaNN int, 
@MaNXB nvarchar(20), @MaVT nvarchar(20), @MaTT int, @SoLuong int, @GiaTien int
As
insert into Sach values (@MaSach, @TenSach, @MaTG, @MaTL, @MaNN, @MaNXB, @MaVT, @MaTT, @SoLuong, @GiaTien)
Go

--Proc xóa sách
create proc Proc_XoaSach
@MaSach int
As
delete from Sach where MaSach = @MaSach
Go

--Proc sửa thông tin sách
create proc Proc_SuaSach
@MaSach int, @TenSach nvarchar(30), @MaTG nvarchar(20), @MaTL int, @MaNN int, 
@MaNXB nvarchar(20), @MaVT nvarchar(20), @MaTT int, @SoLuong int, @GiaTien int
As
Begin tran
Update Sach 
set MaSach = @MaSach, TenSach = @TenSach, MaTG = @MaTG, MaTL = @MaTL, MaNN = @MaNN, 
MaNXB = @MaNXB, MaVT = @MaVT, MaTT = @MaTT, SoLuong = @SoLuong, GiaTien = @GiaTien 
where MaSach = @MaSach
if(@SoLuong = 0)
Begin 
	Raiserror(N'Số lượng sách phải lớn hơn không!', 16, 1)
	Rollback
End
Else
Begin
	Raiserror(N'Sửa sách thành công!', 16, 1)
	Commit
End
Go

--Proc thêm đọc giả
create proc Proc_ThemDocGia
@MaDG nvarchar(10), @TenDG nvarchar(30), @GioiTinh nvarchar(5), 
@NgaySinh Date, @DiaChi nvarchar(50), @SDT nvarchar(11)
As
Begin
	insert into DocGia values (@MaDG, @TenDG, @GioiTinh, @NgaySinh, @DiaChi, @SDT)
	Raiserror(N'Thêm đọc giả thành công!',16,1)
End
Go

--Proc xóa đọc giả
create proc Proc_XoaDocGia
@MaDG nvarchar(10)
As
Begin
declare @demtruocxoa int
declare @demsauxoa int
select @demtruocxoa = count(MaDG) from TheDG
declare @dg nvarchar(10) = 'temp'
select @dg = MaDG from PhieuSach where MaDG = @MaDG
if (@dg = 'temp')
	Begin
		delete from TheDG where MaDG = @MaDG
		delete from DocGia where MaDG = @MaDG
		select @demsauxoa = count(MaDG) from TheDG
		if (@demtruocxoa = @demsauxoa)
			begin
				Raiserror(N'Mã đọc giả không tồn tại!', 16, 1)
			end
		else
			begin
				Raiserror(N'Đã xóa đọc giả thành công!', 16, 1)
			end
	End
else
	Begin
		Raiserror(N'Không thể xóa, Đọc giả này đang mượn sách!', 16, 1)
	End
End
Go

--Proc sửa thông tin đọc giả
create proc Proc_SuaDocgia
@MaDG nvarchar(10), @TenDG nvarchar(30), @GioiTinh nvarchar(5), 
@NgaySinh Date, @DiaChi nvarchar(50), @SDT nvarchar(11)
As
Begin
	Update DocGia 
	set MaDG = @MaDG, TenDG = @TenDG, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, DiaChi = @DiaChi, SDT = @SDT
	where MaDG = @MaDG
	Raiserror(N'Sửa đọc giả thành công!', 16, 1)
	Update TheDG
	set MaDG = @MaDG, TenDG = @TenDG
	where MaDG = @MaDG
End
Go

--Proc tạo phiếu sách cho đọc giả mượn sách
create proc Proc_ThemPhieuSach
@MaNV nvarchar(10), @MaDG nvarchar(10), @SoSachMuon int
As
insert into PhieuSach values (@MaNV, @MaDG, @SoSachMuon)
Go

--Proc thêm mã sách đọc giả mượn vào PhieuSachCT
create proc Proc_UpdateMaSach
@MaPhieu int, @STT int, @MaSach int
As
Update PhieuSachCT set MaSach = @MaSach where MaPhieu = @MaPhieu and STT = @STT
Go

--Proc xóa PhieuSachCT với MaPhieu và STT nhập vào (trả sách sau khi mượn)
create proc Proc_TraSach
@MaPhieu int, @STT int
As
Begin
Declare @MaSach int, @MaTT int, @TenNV nvarchar(20) , @TenDG nvarchar(30), @NgayMuon date, @NgayTra date, @TienPhat int
select @Masach = MaSach from PhieuSachCT where MaPhieu = @MaPhieu and STT = @STT
select @MaTT = MaTT from PhieuSachCT where MaPhieu = @MaPhieu and STT = @STT
select @TenNV = TenNV from PhieuSachCT where MaPhieu = @MaPhieu and STT = @STT
select @TenDG = TenDG from PhieuSachCT where MaPhieu = @MaPhieu and STT = @STT
select @NgayMuon = NgayMuon from PhieuSachCT where MaPhieu = @MaPhieu and STT = @STT
select @NgayTra = NgayTra from PhieuSachCT where MaPhieu = @MaPhieu and STT = @STT
select @TienPhat = TienPhat from PhieuSachCT where MaPhieu = @MaPhieu and STT = @STT
insert into LuuTatCaPhieuDaTraSach values (@MaPhieu, @STT, @MaSach, @MaTT, @TenNV, @TenDG, @NgayMuon, @NgayTra, @TienPhat)
Delete from PhieuSachCT where MaPhieu = @MaPhieu and STT = @STT
Raiserror(N'Thao tác thành công!', 16, 1)
End
Go

------------------------------------FUNCTION-----------------------------------------------------
--kiểm tra trùng tên đăng nhập
CREATE FUNCTION KiemTraTenDangNhap (@userName NVARCHAR(50) )
RETURNS TABLE
AS 
RETURN
(
	SELECT * FROM dbo.Account WHERE username = @userName
)
GO

-- function đưa vào mã đọc giả thì cho ra tên đọc giả
create function MaDGThanhTenDG (@MaDG nvarchar(10))
returns nvarchar(30)
As
Begin
declare @TenDG nvarchar(30)
select @TenDG = TenDG from DocGia where MaDG = @MaDG
return @TenDG
End
Go


-- function đưa ra tất cả các sách mà đọc giả đã mượn 
create function TatCaSachDocGiaMuon (@TenDG nvarchar(30))
returns table
As
return
select * 
from [Danh Sách Đọc Giả Mượn Sách Của Thư Viện] 
where TenDG = @TenDG
Go

-- function tìm kiếm sách theo mã sách
create function TimSachTheoMaSach (@MaSach nvarchar(10))
returns table 
As
return
select *
from [Thông Tin Sách]
where MaSach = @MaSach
Go

-- function tìm kiếm sách theo tên sách
create function TimSachTheoTenSach (@TenSach nvarchar(30))
returns table 
As
return
(
	select * from [Thông Tin Sách] where dbo.fuConvertToUnsign1(TenSach) like N'%' + dbo.fuConvertToUnsign1(@TenSach) + '%'
)
Go

-- function đưa ra các sách có cùng thể loại nhập vào
create function TimSachTheoTheLoai (@TenTheLoai nvarchar(20))
returns table 
As
return
(
	select * from [Thông Tin Sách] where dbo.fuConvertToUnsign1(TheLoai) like N'%' + dbo.fuConvertToUnsign1(@TenTheLoai) + '%'
)
Go

-- function đưa ra các sách có cùng tác giả nhập vào
create function TimSachTheoTacGia (@TenTacGia nvarchar(20))
returns table 
As
return
(
	select * from [Thông Tin Sách] where dbo.fuConvertToUnsign1(TacGia) like N'%' + dbo.fuConvertToUnsign1(@TenTacGia) + '%'
)
Go


-- function đưa ra các sách có cùng ngôn ngữ nhập vào
create function TimSachTheoNgonNgu (@NgonNgu nvarchar(20))
returns table 
As
return
(
	select * from [Thông Tin Sách] where dbo.fuConvertToUnsign1(NgonNgu) like N'%' + dbo.fuConvertToUnsign1(@NgonNgu) + '%'
)
Go


-- function in ra phiếu mượn cho đọc giả (sau khi đọc giả mượn sách)
create function InPhieuMuon (@MaPhieu int)
returns table 
As
return
(
select MaPhieu, STT, TenSach, TenNV, TenDG, NgayMuon, NgayTra 
from PhieuSachCT, Sach 
where MaPhieu = @MaPhieu and PhieuSachCT.MaSach = Sach.MaSach
)
Go

-- function in ra phiếu trả cho đọc giả (sau khi đọc giả trả sách)
create function InPhieuTra (@MaPhieu int)
returns table 
As
return
(
select MaPhieu, STT, TenSach, LuuTatCaPhieuDaTraSach.MaTT, TenNV, TenDG, NgayMuon, NgayTra, TienPhat 
from LuuTatCaPhieuDaTraSach, Sach 
where MaPhieu = @MaPhieu and LuuTatCaPhieuDaTraSach.MaSach = Sach.MaSach
)
Go

-- function tính tổng tiền phạt của đọc giả khi trả sách
create function TongTienPhat (@MaPhieu int)
returns int
As
Begin
declare @TienPhat int
select @TienPhat = sum(TienPhat) from LuuTatCaPhieuDaTraSach where MaPhieu = @MaPhieu
return @TienPhat
end
Go

-- Loại bỏ dấu trong tiếng Việt để tìm kiếm sách
CREATE FUNCTION [dbo].[fuConvertToUnsign1]
(
 @strInput NVARCHAR(4000)
)
RETURNS NVARCHAR(4000)
AS
BEGIN 
 IF @strInput IS NULL RETURN @strInput
 IF @strInput = '' RETURN @strInput
 DECLARE @RT NVARCHAR(4000)
 DECLARE @SIGN_CHARS NCHAR(136)
 DECLARE @UNSIGN_CHARS NCHAR (136)
 SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế
 ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý
 ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ
 ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ'
 +NCHAR(272)+ NCHAR(208)
 SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee
 iiiiiooooooooooooooouuuuuuuuuuyyyyy
 AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII
 OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
 DECLARE @COUNTER int
 DECLARE @COUNTER1 int
 SET @COUNTER = 1
 WHILE (@COUNTER <=LEN(@strInput))
 BEGIN 
 SET @COUNTER1 = 1
 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1)
 BEGIN
 IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1))
 = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
 BEGIN 
 IF @COUNTER=1
 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1)
 + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
 ELSE
 SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1)
 +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1)
 + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER)
 BREAK
 END
 SET @COUNTER1 = @COUNTER1 +1
 END
 SET @COUNTER = @COUNTER +1
 END
 SET @strInput = replace(@strInput,' ','-')
 RETURN @strInput
END
Go

