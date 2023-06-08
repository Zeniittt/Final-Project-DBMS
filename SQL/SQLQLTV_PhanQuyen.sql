--Phan Quyen
USE QLThuVien
GO

--Quyen Hanh Cua Quan Ly
Create ROLE QuanLy

--view 
GRANT SELECT ON [Danh Sách Đọc Giả Mượn Sách Của Thư Viện] TO QuanLy
GRANT SELECT ON [Thông Tin Sách] TO QuanLy
GRANT SELECT ON [Danh sách tài khoản] TO QuanLy

--function
GRANT SELECT ON [dbo].[KiemTraTenDangNhap] TO QuanLy
GRANT EXECUTE ON [dbo].[MaDGThanhTenDG] TO QuanLy
GRANT SELECT ON [dbo].[TatCaSachDocGiaMuon] TO QuanLy
GRANT SELECT ON [dbo].[TimSachTheoMaSach] TO QuanLy
GRANT SELECT ON [dbo].[TimSachTheoTenSach] TO QuanLy
GRANT SELECT ON [dbo].[TimSachTheoTheLoai] TO QuanLy
GRANT SELECT ON [dbo].[TimSachTheoTacGia] TO QuanLy
GRANT SELECT ON [dbo].[TimSachTheoNgonNgu] TO QuanLy
GRANT SELECT ON [dbo].[InPhieuMuon] TO QuanLy
GRANT SELECT ON [dbo].[InPhieuTra] TO QuanLy
GRANT EXECUTE ON [dbo].[TongTienPhat] TO QuanLy


--stored procedure
GRANT EXECUTE ON [dbo].[ThemAccount] TO QuanLy
GRANT EXECUTE ON [dbo].[XoaAccount] TO QuanLy
GRANT EXECUTE ON [dbo].[LoginAsQuanLy] TO QuanLy
--GRANT EXECUTE ON [dbo].[LoginAsNhanVien] TO QuanLy
GRANT EXECUTE ON [dbo].[SoLanSachDuocMuon] TO QuanLy
GRANT EXECUTE ON [dbo].[CapNhatTienPhat] TO QuanLy
GRANT EXECUTE ON [dbo].[Proc_ThemNhanVien] TO QuanLy
GRANT EXECUTE ON [dbo].[Proc_XoaNhanVien] TO QuanLy
GRANT EXECUTE ON [dbo].[Proc_SuaNhanVien] TO QuanLy
GRANT EXECUTE ON [dbo].[Proc_ThemSach] TO QuanLy
GRANT EXECUTE ON [dbo].[Proc_XoaSach] TO QuanLy
GRANT EXECUTE ON [dbo].[Proc_SuaSach] TO QuanLy
GRANT EXECUTE ON [dbo].[Proc_ThemDocGia] TO QuanLy
GRANT EXECUTE ON [dbo].[Proc_XoaDocGia] TO QuanLy
GRANT EXECUTE ON [dbo].[Proc_SuaDocgia] TO QuanLy
GRANT EXECUTE ON [dbo].[Proc_ThemPhieuSach] TO QuanLy
GRANT EXECUTE ON [dbo].[Proc_UpdateMaSach] TO QuanLy
GRANT EXECUTE ON [dbo].[Proc_TraSach] TO QuanLy
GRANT EXECUTE ON [dbo].[USP_Login] TO QuanLy


----------------------------------------------------------------------------------------------------------------------------------------
--Quyen Hanh Cua Nhan Vien
Create ROLE NhanVien

--view 
--GRANT SELECT ON [Danh Sách Đọc Giả Mượn Sách Của Thư Viện] TO NhanVien
GRANT SELECT ON [Thông Tin Sách] TO NhanVien
--GRANT SELECT ON [Danh sách tài khoản] TO NhanVien

--function
--GRANT SELECT ON [dbo].[KiemTraTenDangNhap] TO NhanVien
--GRANT EXECUTE ON [dbo].[MaDGThanhTenDG] TO NhanVien
--GRANT SELECT ON [dbo].[TatCaSachDocGiaMuon] TO NhanVien
GRANT SELECT ON [dbo].[TimSachTheoMaSach] TO NhanVien
GRANT SELECT ON [dbo].[TimSachTheoTenSach] TO NhanVien
GRANT SELECT ON [dbo].[TimSachTheoTheLoai] TO NhanVien
GRANT SELECT ON [dbo].[TimSachTheoTacGia] TO NhanVien
GRANT SELECT ON [dbo].[TimSachTheoNgonNgu] TO NhanVien
GRANT SELECT ON [dbo].[InPhieuMuon] TO NhanVien
GRANT SELECT ON [dbo].[InPhieuTra] TO NhanVien
GRANT EXECUTE ON [dbo].[TongTienPhat] TO NhanVien


--stored procedure
--GRANT EXECUTE ON [dbo].[ThemAccount] TO NhanVien
--GRANT EXECUTE ON [dbo].[XoaAccount] TO NhanVien
--GRANT EXECUTE ON [dbo].[LoginAsQuanLy] TO NhanVien
GRANT EXECUTE ON [dbo].[LoginAsNhanVien] TO NhanVien
--GRANT EXECUTE ON [dbo].[SoLanSachDuocMuon] TO NhanVien
GRANT EXECUTE ON [dbo].[CapNhatTienPhat] TO NhanVien
--GRANT EXECUTE ON [dbo].[Proc_ThemNhanVien] TO NhanVien
--GRANT EXECUTE ON [dbo].[Proc_XoaNhanVien] TO NhanVien
--GRANT EXECUTE ON [dbo].[Proc_SuaNhanVien] TO NhanVien
--GRANT EXECUTE ON [dbo].[Proc_ThemSach] TO NhanVien
--GRANT EXECUTE ON [dbo].[Proc_XoaSach] TO NhanVien
--GRANT EXECUTE ON [dbo].[Proc_SuaSach] TO NhanVien
GRANT EXECUTE ON [dbo].[Proc_ThemDocGia] TO NhanVien
GRANT EXECUTE ON [dbo].[Proc_XoaDocGia] TO NhanVien
GRANT EXECUTE ON [dbo].[Proc_SuaDocgia] TO NhanVien
GRANT EXECUTE ON [dbo].[Proc_ThemPhieuSach] TO NhanVien
GRANT EXECUTE ON [dbo].[Proc_UpdateMaSach] TO NhanVien
GRANT EXECUTE ON [dbo].[Proc_TraSach] TO NhanVien
GRANT EXECUTE ON [dbo].[USP_Login] TO NhanVien

