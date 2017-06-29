CREATE DATABASE QLCuaHangCD
GO

USE QLCuaHangCD
GO

CREATE TABLE LoaiTaiKhoan
(
	MaLoai VARCHAR(2) PRIMARY KEY,
	TenLoai NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE TaiKhoan
(
	TenDangNhap VARCHAR(50) PRIMARY KEY,
	TenHienThi NVARCHAR(100),
	MatKhau NVARCHAR(100) NOT NULL,
	MaLoaiTaiKhoan VARCHAR(2) NOT NULL

	FOREIGN KEY (MaLoaiTaiKhoan) REFERENCES dbo.LoaiTaiKhoan(MaLoai)
)
GO

CREATE TABLE LoaiDia
(
	MaSo INT IDENTITY PRIMARY KEY,
	TenLoai NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE Dia
(
	MaSo INT IDENTITY PRIMARY KEY,
	TenDia NVARCHAR(100) NOT NULL,
	SoLuong INT NOT NULL DEFAULT 0,
	GiaBan INT NOT NULL,
	GiaThue INT NOT NULL,
	MaLoai INT NOT NULL

	FOREIGN KEY (MaLoai) REFERENCES dbo.LoaiDia(MaSo)
)
GO

CREATE TABLE HoaDon
(
	MaHD INT IDENTITY PRIMARY KEY,
	NgayLap DATE NOT NULL DEFAULT GETDATE(),
	GiamGia INT DEFAULT 0,
	GiaTri INT NOT NULL DEFAULT 0,
	TrangThai BIT NOT NULL
)
GO

CREATE TABLE ChiTietHoaDon
(
	MaSo INT IDENTITY PRIMARY KEY,
	MaDia INT NOT NULL,
	MaHD INT NOT NULL,
	SoLuong INT NOT NULL,

	FOREIGN KEY (MaDia) REFERENCES dbo.Dia(MaSo),
	FOREIGN KEY (MaHD) REFERENCES dbo.HoaDon(MaHD)
)
GO

CREATE TABLE KhachHang
(
	CMND CHAR(9) PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL,
	SoDienThoai VARCHAR(11) NOT NULL
)
GO

CREATE TABLE PhieuThue
(
	MaPhieu INT IDENTITY PRIMARY KEY,
	NgayThue DATE NOT NULL DEFAULT GETDATE(),
	NgayTra DATE NOT NULL,
	TrangThai BIT NOT NULL, -- 0: Chua tra/ 1: Da tra
	TienPhat INT,
	ThanhTien INT NOT NULL,
	CMND CHAR(9) NOT NULL

	FOREIGN KEY (CMND) REFERENCES dbo.KhachHang(CMND)
)
GO

CREATE TABLE ChiTietPhieuThue
(
	MaSo INT IDENTITY PRIMARY KEY,
	MaDia INT NOT NULL,
	MaPhieu INT NOT NULL,
	SoLuong INT NOT NULL

	FOREIGN KEY (MaDia) REFERENCES dbo.Dia(MaSo),
	FOREIGN KEY (MaPhieu) REFERENCES dbo.PhieuThue(MaPhieu)
)
GO

-- Add data into dbo.LoaiTaiKhoan
INSERT dbo.LoaiTaiKhoan( MaLoai, TenLoai ) VALUES  ('QL', N'Quản lý')
INSERT dbo.LoaiTaiKhoan( MaLoai, TenLoai ) VALUES  ('NV', N'Nhân viên')

-- Add data into dbo.TaiKhoan
INSERT dbo.TaiKhoan
        ( TenDangNhap ,
          TenHienThi ,
          MatKhau ,
          MaLoaiTaiKhoan
        )
VALUES  ( 'admin' , -- TenDangNhap - varchar(50)
          N'Quản lý' , -- TenHienThi - nvarchar(100)
          N'admin' , -- MatKhau - nvarchar(100)
          'QL'  -- MaLoaiTaiKhoan - varchar(2)
        )

INSERT dbo.TaiKhoan
        ( TenDangNhap ,
          TenHienThi ,
          MatKhau ,
          MaLoaiTaiKhoan
        )
VALUES  ( 'nhanvien' , -- TenDangNhap - varchar(50)
          N'Nhân viên' , -- TenHienThi - nvarchar(100)
          N'nhanvien' , -- MatKhau - nvarchar(100)
          'NV'  -- MaLoaiTaiKhoan - varchar(2)
        )

-- add data into dbo.KhachHang
INSERT dbo.KhachHang
        ( CMND, HoTen, SoDienThoai )
VALUES  ( '123456789', -- CMND - char(9)
          N'Nguyễn Văn A', -- HoTen - nvarchar(100)
          '01234567890'  -- SoDienThoai - varchar(11)
          )

INSERT dbo.KhachHang
        ( CMND, HoTen, SoDienThoai )
VALUES  ( '987654321', -- CMND - char(9)
          N'Trần Thị B', -- HoTen - nvarchar(100)
          '09876543210'  -- SoDienThoai - varchar(11)
          )

-- add data into dbo.LoaiDia
INSERT dbo.LoaiDia ( TenLoai ) VALUES  ( N'Phim' )
INSERT dbo.LoaiDia ( TenLoai ) VALUES  ( N'Hài kịch' )
INSERT dbo.LoaiDia ( TenLoai ) VALUES  ( N'Ca nhạc' )

-- add data into dbo.Dia
INSERT dbo.Dia
        ( TenDia ,
          SoLuong ,
          GiaBan ,
          GiaThue ,
          MaLoai
        )
VALUES  ( N'Cô dâu 8 tuổi' , -- TenDia - nvarchar(100)
          15 , -- SoLuong - int
          10000 , -- GiaBan - int
          3000 , -- GiaThue - int
          1  -- MaLoai - int
        )

INSERT dbo.Dia
        ( TenDia ,
          SoLuong ,
          GiaBan ,
          GiaThue ,
          MaLoai
        )
VALUES  ( N'The Walking Dead' , -- TenDia - nvarchar(100)
          20 , -- SoLuong - int
          12000 , -- GiaBan - int
          3000 , -- GiaThue - int
          1  -- MaLoai - int
        )

INSERT dbo.Dia
        ( TenDia ,
          SoLuong ,
          GiaBan ,
          GiaThue ,
          MaLoai
        )
VALUES  ( N'Hài Hoài Linh - Chí Tài' , -- TenDia - nvarchar(100)
          5 , -- SoLuong - int
          15000 , -- GiaBan - int
          2500 , -- GiaThue - int
          2  -- MaLoai - int
        )
GO

CREATE PROC USP_DangNhap
@TenDangNhap VARCHAR(50), @MatKhau NVARCHAR(100)
AS
	SELECT * FROM dbo.TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau
GO

CREATE PROC USP_LayDiaTheoMaDanhMuc
@MaLoai INT
AS
	SELECT * FROM dbo.Dia WHERE MaLoai = @MaLoai
GO

CREATE PROC USP_XoaLoaiDia
@MaLoai INT
AS
BEGIN
	DECLARE @Dia INT = 0
	SELECT @Dia = COUNT(*) FROM dbo.Dia WHERE MaLoai = @MaLoai

	IF (@Dia = 0)
		DELETE dbo.LoaiDia WHERE MaSo = @MaLoai
END
GO

CREATE PROC USP_ThemChiTietHoaDon
@MaDia INT, @MaHoaDon INT, @SoLuong INT
AS
BEGIN
	DECLARE @MaChiTietHoaDon INT = -1
	DECLARE @SoLuongDia INT = 1

	SELECT @MaChiTietHoaDon = MaSo, @SoLuongDia = SoLuong
	FROM dbo.ChiTietHoaDon
	WHERE MaDia = @MaDia AND MaHD = @MaHoaDon

	PRINT @MaChiTietHoaDon

	IF (@MaChiTietHoaDon = -1)
	BEGIN
		IF (@SoLuong > 0)
			INSERT dbo.ChiTietHoaDon ( MaDia, MaHD, SoLuong ) VALUES  ( @MaDia, @MaHoaDon, @SoLuong )
	END
	ELSE
		BEGIN
			DECLARE @SoLuongMoi INT = @SoLuong + @SoLuongDia
			IF (@SoLuongMoi > 0)
				UPDATE dbo.ChiTietHoaDon SET SoLuong = @SoLuong + @SoLuongDia WHERE MaDia = @MaDia AND MaHD = @MaHoaDon
			ELSE
				DELETE dbo.ChiTietHoaDon WHERE MaDia = @MaDia AND MaHD = @MaHoaDon
		END
END
GO

CREATE PROC USP_MuaDia
@MaHoaDon INT, @GiamGia INT, @ThanhToan INT
AS
	UPDATE dbo.HoaDon SET GiamGia = @GiamGia, GiaTri = @ThanhToan, TrangThai = 1 WHERE MaHD = @MaHoaDon
GO

CREATE PROC USP_DoiMatKhau
@MatKhauMoi NVARCHAR(100), @TenDangNhap VARCHAR(50)
AS
	UPDATE dbo.TaiKhoan SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap
GO

CREATE PROC USP_ThemDia
@TenDia NVARCHAR(100), @SoLuong INT, @GiaBan INT, @GiaThue INT, @MaLoai INT
AS
	INSERT dbo.Dia ( TenDia, SoLuong, GiaBan, GiaThue, MaLoai )
	VALUES  ( @TenDia, @SoLuong, @GiaBan, @GiaThue, @MaLoai )
GO

CREATE PROC USP_CapNhatDia
@TenDia NVARCHAR(100), @SoLuong INT, @GiaBan INT, @GiaThue INT, @MaLoai INT, @MaSo INT
AS
	DECLARE @MaHoaDonChuaThanhToan INT = -1
	SELECT @MaHoaDonChuaThanhToan = hd.MaHD
	FROM dbo.HoaDon AS hd, dbo.ChiTietHoaDon AS ct
	WHERE ct.MaDia = @MaSo AND ct.MaHD = hd.MaHD AND hd.TrangThai = 0

	IF (@MaHoaDonChuaThanhToan = -1)
			UPDATE dbo.Dia SET TenDia = @TenDia, SoLuong = @SoLuong, GiaBan = @GiaBan, GiaThue = @GiaThue, MaLoai = @MaLoai
			WHERE MaSo = @MaSo
GO

CREATE PROC USP_XoaDia
@MaDia INT
AS
	DECLARE @MaHoaDonChuaThanhToan INT = -1
	SELECT @MaHoaDonChuaThanhToan = hd.MaHD
	FROM dbo.HoaDon AS hd, dbo.ChiTietHoaDon AS ct
	WHERE ct.MaDia = @MaDia AND ct.MaHD = hd.MaHD AND hd.TrangThai = 0

	IF (@MaHoaDonChuaThanhToan = -1)
		BEGIN
			DELETE dbo.ChiTietHoaDon WHERE MaDia = @MaDia
			DELETE dbo.Dia WHERE MaSo = @MaDia
		END
GO

CREATE PROC USP_CapNhatSoLuongDia
@MaSo INT, @SoLuong INT
AS
	UPDATE dbo.Dia SET SoLuong = @SoLuong WHERE MaSo = @MaSo
GO