create database QuanLyNhanSu
GO
use QuanLyNhanSu
GO
CREATE TABLE ChucVu (
	MaCV NVARCHAR(10) PRIMARY KEY,
	TenCV NVARCHAR(50) NOT NULL
);
GO
CREATE TABLE NhanVien (
    MaNV NVARCHAR(10) PRIMARY KEY,
    Ho NVARCHAR(50) NOT NULL,
    Ten NVARCHAR(50) NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    NgaySinh DATE NOT NULL,
    DiaChi NVARCHAR(100) NOT NULL,
    SDT NVARCHAR(20) NOT NULL UNIQUE,
    Email NVARCHAR(50) NOT NULL UNIQUE,
    CCCD NVARCHAR(12) NOT NULL UNIQUE,
    MaPB NVARCHAR(10),
    MaCV NVARCHAR(10) NOT NULL,
    MaHD NVARCHAR(10),
	CONSTRAINT RightPhoneNum CHECK (LEN(SDT) = 10)
);
GO
CREATE TABLE PhongBan (
    MaPB NVARCHAR(10) PRIMARY KEY,
    TenPB NVARCHAR(50) NOT NULL,
    SDT NVARCHAR(20) NOT NULL,
    MaTrP NVARCHAR(10),
    CONSTRAINT ValidPhoneNum CHECK (LEN(SDT) = 10)
);
GO
CREATE TABLE HopDong (
    MaHD NVARCHAR(10) PRIMARY KEY,
    MaNV NVARCHAR(10) UNIQUE NOT NULL,
    LuongCoBan INT NOT NULL,
    NgayBD DATE NOT NULL,
    NgayKT DATE NOT NULL
);
GO
-- Khóa ngoại bảng PhongBan
ALTER TABLE PhongBan ADD CONSTRAINT fk_MaTrP
	FOREIGN KEY (MaTrP) REFERENCES NhanVien(MaNV)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;
GO
-- Khóa ngoại bảng Hợp đồng
ALTER TABLE HopDong ADD CONSTRAINT fk_HD_MaNV
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
	ON UPDATE NO ACTION
	ON DELETE CASCADE;
GO
-- Khóa ngoại bảng Nhân viên
ALTER TABLE NhanVien ADD CONSTRAINT fk_NV_MaPB
	FOREIGN KEY (MaPB) REFERENCES PhongBan (MaPB)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;
ALTER TABLE NhanVien ADD CONSTRAINT fk_NV_MaCV
	FOREIGN KEY (MaCV) REFERENCES ChucVu (MaCV)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;
ALTER TABLE NhanVien ADD CONSTRAINT fk_NV_MaHD
	FOREIGN KEY (MaHD) REFERENCES HopDong (MaHD)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;
GO
CREATE TABLE NguoiPhuThuoc (
    MaNV NVARCHAR(10) NOT NULL,
    HoTen NVARCHAR(50) NOT NULL,
    NgaySinh DATE NOT NULL,
    QuanHe NVARCHAR(50) NOT NULL,
    PRIMARY KEY (MaNV, HoTen),
    CONSTRAINT fK_NPT_MaNV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
	ON UPDATE NO ACTION
    ON DELETE CASCADE
);
GO
CREATE TABLE ThongBao (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TieuDe NVARCHAR(100),
    NoiDung NVARCHAR(MAX),
    MaPB NVARCHAR(10),
    NgayGui DATETIME,
    CONSTRAINT fK_TB_MaPB FOREIGN KEY (MaPB) REFERENCES PhongBan(MaPB)
);
GO
CREATE TABLE Thang (
    MaThang NVARCHAR(6) PRIMARY KEY,
    MoTa NVARCHAR(MAX),
    SoNgayCongChuan INT NOT NULL CHECK(SoNgayCongChuan BETWEEN 1 AND 31)
);
GO
CREATE TABLE ThuongPhat (
    MaThuongPhat NVARCHAR(10) PRIMARY KEY,
    Loai NVARCHAR(50) NOT NULL,
    SoTien INT NOT NULL,
    LyDo NVARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE ctThuongPhat (
    MaNV NVARCHAR(10) NOT NULL,
    MaThuongPhat NVARCHAR(10) NOT NULL,
    MaThang NVARCHAR(6) NOT NULL,
    NgayThuongPhat INT NOT NULL,
    PRIMARY KEY (MaNV, MaThuongPhat, MaThang, NgayThuongPhat),
    CONSTRAINT ValidNgay CHECK (NgayThuongPhat BETWEEN 1 AND 31),
    CONSTRAINT fK_ctTP_MaNV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
	ON UPDATE CASCADE
    ON DELETE CASCADE,
    CONSTRAINT fK_ctTP_MaThuongPhat FOREIGN KEY (MaThuongPhat) REFERENCES ThuongPhat(MaThuongPhat)
	ON UPDATE CASCADE
    ON DELETE NO ACTION,
    CONSTRAINT fK_ctTP_MaThang FOREIGN KEY (MaThang) REFERENCES Thang(MaThang)
	ON UPDATE CASCADE
    ON DELETE NO ACTION
);
GO
CREATE TABLE ChamCong (
    MaCC NVARCHAR(10) PRIMARY KEY,
    MoTa NVARCHAR(MAX),
    HeSo FLOAT NOT NULL
);
GO
CREATE TABLE ctChamCong (
    MaNV NVARCHAR(10) NOT NULL,
    MaCC NVARCHAR(10) NOT NULL,
    MaThang NVARCHAR(6) NOT NULL,
    NgayChamCong INT NOT NULL CHECK(NgayChamCong BETWEEN 1 AND 31),
    PRIMARY KEY (MaNV, MaThang, NgayChamCong),
    CONSTRAINT fK_ctCC_MaNV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
	ON UPDATE CASCADE
    ON DELETE CASCADE,
    CONSTRAINT fK_ctCC_MaCC FOREIGN KEY (MaCC) REFERENCES ChamCong(MaCC)
	ON UPDATE CASCADE
    ON DELETE NO ACTION,
    CONSTRAINT fK_ctCC_MaThang FOREIGN KEY (MaThang) REFERENCES Thang(MaThang)
	ON UPDATE CASCADE
    ON DELETE NO ACTION
);
GO
CREATE TABLE BaoHiem (
    MaLoai NVARCHAR(10) PRIMARY KEY,
    TenBH NVARCHAR(50) NOT NULL
);
GO
CREATE TABLE ctBaoHiem (
	MaNV NVARCHAR(10) NOT NULL,
    MaBH NVARCHAR(10) PRIMARY KEY,
    MaLoai NVARCHAR(10) NOT NULL,
    NgayBD DATE NOT NULL,
    NgayKT DATE NOT NULL,
    CONSTRAINT fK_ctBH_MaNV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
	ON UPDATE CASCADE
    ON DELETE CASCADE,
    CONSTRAINT fK_ctBH_MaLoai FOREIGN KEY (MaLoai) REFERENCES BaoHiem(MaLoai)
	ON UPDATE CASCADE
    ON DELETE NO ACTION
);
GO
CREATE TABLE NghiPhep (
    MaNV NVARCHAR(10) NOT NULL,
    MaThang NVARCHAR(6) NOT NULL,
    NgayNghiPhep INT NOT NULL CHECK(NgayNghiPhep BETWEEN 1 AND 31),
    GhiChu NVARCHAR(MAX) NOT NULL,
    PRIMARY KEY (MaNV, MaThang, NgayNghiPhep),
    CONSTRAINT fK_NP_MaNV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
	ON UPDATE CASCADE
    ON DELETE CASCADE,
    CONSTRAINT fK_NP_MaThang FOREIGN KEY (MaThang) REFERENCES Thang(MaThang)
	ON UPDATE CASCADE
    ON DELETE NO ACTION
);
GO
CREATE TABLE LoaiTaiKhoan (
    MaLoai NVARCHAR(10) PRIMARY KEY,
    Ten NVARCHAR(50) NOT NULL
);
GO
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(10) PRIMARY KEY,
    MatKhau NVARCHAR(255) NOT NULL,
    MaLoai NVARCHAR(10) NOT NULL,
    CONSTRAINT fK_TK_TenDangNhap FOREIGN KEY (TenDangNhap) REFERENCES NhanVien(MaNV)
	ON UPDATE CASCADE
    ON DELETE CASCADE,
    CONSTRAINT fK_TK_MaLoai FOREIGN KEY (MaLoai) REFERENCES LoaiTaiKhoan(MaLoai)
	ON UPDATE CASCADE
    ON DELETE NO ACTION
);
GO
CREATE TABLE PhuCap (
	MaPhuCap NVARCHAR(10) PRIMARY KEY,
	LoaiPhuCap NVARCHAR(10) NOT NULL
);
GO
CREATE TABLE ctPhuCap (
    MaNV NVARCHAR(10) NOT NULL,
    MaPhuCap NVARCHAR(10) NOT NULL,
    MaThang NVARCHAR(6) NOT NULL,
    NgayPhuCap INT NOT NULL CHECK(NgayPhuCap BETWEEN 1 AND 31),
    SoTien INT NOT NULL,
    PRIMARY KEY (MaNV, MaPhuCap, MaThang, NgayPhuCap),
    CONSTRAINT fK_PC_MaNV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
	ON UPDATE CASCADE
    ON DELETE CASCADE,
    CONSTRAINT fK_PC_MaPhuCap FOREIGN KEY (MaPhuCap) REFERENCES PhuCap(MaPhuCap)
	ON UPDATE CASCADE
    ON DELETE NO ACTION,
    CONSTRAINT fK_PC_MaThang FOREIGN KEY (MaThang) REFERENCES Thang(MaThang)
	ON UPDATE CASCADE
    ON DELETE NO ACTION
);
-- Thêm dữ liệu cho bảng ChucVu
INSERT INTO ChucVu (MaCV, TenCV)
VALUES
('CV01', N'Giám Đốc'),
('CV02', N'Trưởng Phòng'),
('CV03', N'Nhân Viên'),
('CV04', N'Thực Tập Sinh');
GO
-- Thêm dữ liệu cho bảng NhanVien
INSERT INTO NhanVien (MaNV, Ho, Ten, GioiTinh, NgaySinh, DiaChi, SDT, Email, CCCD, MaPB, MaCV, MaHD)
VALUES
('NV01', N'Nguyễn Ngọc Hiếu', N'Hảo', N'Nam', '1990-05-12', 'Thủ Đức, TP. Hồ Chí Minh', '0123456789', 'hao.nguyen@gmail.com', '087304000481',NULL, 'CV01', NULL),
('NV02', N'Nguyễn Thị Hồng', N'Thơ', N'Nữ', '1985-10-23', 'Hà Nội', '0987654321', 'tho.nguyen@gmail.com', '087304000482', NULL, 'CV02', NULL),
('NV03', N'Trần Kim', N'Phượng', N'Nữ', '1992-07-15', 'Linh Chiểu, TP. Thủ Đức', '0123456790', 'phuong.tran@gmail.com', '087304000483', NULL, 'CV03', NULL),
('NV04', N'Trịnh Trần Phương', N'Tuấn', N'Nam', '1995-03-10', 'Đồng Nai', '0987654322', 'tuan.tran@gmail.com', '087304000484', NULL, 'CV04', NULL);
GO
-- Thêm dữ liệu cho bảng PhongBan
INSERT INTO PhongBan (MaPB, TenPB, SDT, MaTrP)
VALUES 
('PB01', N'Phòng Nhân Sự', '0123456789', 'NV01'),
('PB02', N'Phòng Kế Toán', '0987654321', 'NV02'),
('PB03', N'Phòng IT', '0123456790', NULL),
('PB04', N'Phòng Kỹ Thuật', '0924250122', 'NV04'),
('PB05', N'Phòng Y Tế', '0123456789', NULL);
GO
-- Thêm dữ liệu cho bảng HopDong
INSERT INTO HopDong (MaHD, MaNV, LuongCoBan, NgayBD, NgayKT)
VALUES
('HD01', 'NV01', 20000000, '2023-01-01', '2024-01-01'),
('HD02', 'NV02', 15000000, '2022-06-15', '2023-06-15'),
('HD03', 'NV03', 18000000, '2021-09-01', '2022-09-01'),
('HD04', 'NV04', 10000000, '2023-03-10', '2024-03-10');
GO
-- Cập nhật MaPB, MaCV, MaHD cho MaNV = 'NV01'
UPDATE NhanVien
SET MaPB = 'PB01', MaCV = 'CV02', MaHD = 'HD01'
WHERE MaNV = 'NV01';

GO
-- Cập nhật MaPB, MaCV, MaHD cho MaNV = 'NV02'
UPDATE NhanVien
SET MaPB = 'PB02', MaCV = 'CV02', MaHD = 'HD02'
WHERE MaNV = 'NV02';

GO
-- Cập nhật MaPB, MaCV, MaHD cho MaNV = 'NV03'
UPDATE NhanVien
SET MaPB = 'PB03', MaCV = 'CV03', MaHD = 'HD03'
WHERE MaNV = 'NV03';

GO
-- Cập nhật MaPB, MaCV, MaHD cho MaNV = 'NV04'
UPDATE NhanVien
SET MaPB = 'PB04', MaCV = 'CV02', MaHD = 'HD04'
WHERE MaNV = 'NV04';
GO
-- Thêm dữ liệu cho bảng NguoiPhuThuoc
INSERT INTO NguoiPhuThuoc (MaNV, HoTen, NgaySinh, QuanHe)
VALUES
('NV01', N'Nguyễn Thị Minh', '2015-06-12', 'Con'),
('NV02', N'Lê Văn Phúc', '2018-04-25', 'Con'),
('NV03', N'Trần Văn Hải', '2017-12-19', 'Em trai'),
('NV04', N'Phạm Thị Hà', '2020-01-01', 'Con');
GO
-- Thêm dữ liệu cho bảng Thang
INSERT INTO Thang (MaThang, MoTa, SoNgayCongChuan)
VALUES
('102024', N'Tháng 10 Năm 2024', 22),
('022023', N'Tháng 02 Năm 2023', 20),
('032023', N'Tháng 03 Năm 2023', 23),
('042023', N'Tháng 04 Năm 2023', 21);
GO
-- Thêm dữ liệu cho bảng ThuongPhat
INSERT INTO ThuongPhat (MaThuongPhat, Loai, SoTien, LyDo)
VALUES
('TP01', N'Thưởng', 5000000, N'Hoàn thành công việc xuất sắc'),
('TP02', N'Phạt', 1000000, N'Đi làm muộn'),
('TP03', N'Thưởng', 2000000, N'Đóng góp ý tưởng tốt'),
('TP04', N'Phạt', 500000, N'Không hoàn thành công việc đúng hạn');
-- Thêm dữ liệu cho bảng ctThuongPhat
-- nếu là 05 thì sai
GO
INSERT INTO ctThuongPhat (MaNV, MaThuongPhat, MaThang, NgayThuongPhat)
VALUES
('NV01', 'TP01', '102024', '15'),
('NV02', 'TP02', '022023', '10'),
('NV03', 'TP03', '032023', '20'),
('NV04', 'TP04', '042023', '05');
GO
-- drop table ctThuongPhat
-- Thêm dữ liệu cho bảng ChamCong
INSERT INTO ChamCong (MaCC, MoTa, HeSo)
VALUES
('CC01', N'Đi làm đủ', 1),
('CC02', N'Nghỉ phép năm', 0.5),
('CC03', N'Đi làm muộn', 0.75),
('CC04', N'Nghỉ không lương', 0);
GO
-- nếu là 05 thì sai
-- check MaThang
-- Thêm dữ liệu cho bảng ctChamCong
INSERT INTO ctChamCong (MaNV, MaCC, MaThang, NgayChamCong)
VALUES
('NV02', 'CC01', '102024', 1),
('NV02', 'CC01', '102024', 2),
('NV02', 'CC01', '102024', 3),
('NV02', 'CC01', '102024', 4),
('NV02', 'CC01', '102024', 5),
('NV02', 'CC01', '102024', 6),
('NV02', 'CC01', '102024', 7),
('NV02', 'CC01', '102024', 8),
('NV02', 'CC01', '102024', 9),
('NV02', 'CC01', '102024', 10),
('NV02', 'CC01', '102024', 11),
('NV02', 'CC01', '102024', 12),
('NV02', 'CC01', '102024', 13),
('NV02', 'CC01', '102024', 14),
('NV02', 'CC01', '102024', 15),
('NV02', 'CC01', '102024', 16),
('NV02', 'CC01', '102024', 17),
('NV02', 'CC01', '102024', 18),
('NV02', 'CC01', '102024', 19),
('NV02', 'CC01', '102024', 20),
('NV02', 'CC01', '102024', 21),
('NV02', 'CC01', '102024', 22);

GO
-- Thêm dữ liệu cho bảng BaoHiem
INSERT INTO BaoHiem (MaLoai, TenBH)
VALUES
('BH01', N'Bảo Hiểm Y Tế'),
('BH02', N'Bảo Hiểm Xã Hội'),
('BH03', N'Bảo Hiểm Tai Nạn');
GO
-- Thêm dữ liệu cho bảng ctBaoHiem
INSERT INTO ctBaoHiem (MaNV, MaBH, MaLoai, NgayBD, NgayKT)
VALUES
('NV01', 'HC9981234', 'BH01', '2023-01-01', '2024-01-01'),
('NV02', '8723436537', 'BH02', '2022-06-15', '2023-06-15'),
('NV03', 'TN20200003', 'BH03', '2021-09-01', '2022-09-01'),
('NV04', 'SV20001234', 'BH01', '2023-03-10', '2024-03-10');
GO
-- check MaThang
-- Thêm dữ liệu cho bảng NghiPhep
INSERT INTO NghiPhep (MaNV, MaThang, NgayNghiPhep, GhiChu)
VALUES
('NV01', '102024', 2, N'Nghỉ phép thường niên'),
('NV02', '022023', 3, N'Nghỉ ốm'),
('NV03', '032023', 1, N'Nghỉ việc riêng'),
('NV04', '042023', 4, N'Nghỉ phép thường niên');
GO
-- Thêm dữ liệu cho bảng LoaiTaiKhoan
INSERT INTO LoaiTaiKhoan (MaLoai, Ten)
VALUES
('LTK01', 'QuanTriVien'),
('LTK02', 'TruongPhong'),
('LTK03', 'NhanVien');
GO
-- Thêm dữ liệu cho bảng TaiKhoan
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaLoai)
VALUES
('NV01', 'password1', 'LTK01'),
('NV02', 'password2', 'LTK02'),
('NV03', 'password3', 'LTK03'),
('NV04', 'password4', 'LTK03');
GO
-- Thêm dữ liệu cho bảng PhuCap
INSERT INTO PhuCap (MaPhuCap, LoaiPhuCap)
VALUES
('PC01', N'Đi lại'),
('PC02', N'Ăn trưa'),
('PC03', N'Chỗ ở');
GO
-- Check MaThang
-- Thêm dữ liệu cho bảng ctPhuCap
INSERT INTO ctPhuCap (MaNV, MaPhuCap, MaThang, NgayPhuCap, SoTien)
VALUES
('NV01', 'PC01', '102024', 10, 500000),
('NV02', 'PC02', '022023', 15, 300000),
('NV03', 'PC03', '032023', 20, 400000),
('NV04', 'PC01', '042023', 25, 200000);
GO
-- Chèn dữ liệu cho bảng Thông báo
INSERT INTO ThongBao (TieuDe, NoiDung, MaPB, NgayGui)
VALUES 
-- Thông báo của Phòng Kế Toán
(N'Thông báo họp định kỳ', 
 N'Phòng Kế Toán sẽ tổ chức họp định kỳ vào ngày 20/11/2024 tại phòng họp A. Nội dung: Báo cáo tài chính quý 4 và kế hoạch năm tới.', 
 'PB01', GETDATE()),
-- Thông báo của Phòng Nhân Sự
(N'Thông báo nghỉ lễ', 
 N'Tất cả nhân viên được nghỉ lễ Giáng sinh từ ngày 24/12/2024 đến hết ngày 26/12/2024. Đề nghị hoàn thành công việc trước kỳ nghỉ.', 
 'PB02', GETDATE()),
(N'Triển khai dự án mới', 
 N'Phòng Kỹ Thuật sẽ triển khai dự án cải tiến hệ thống quản lý nhân sự từ tháng 12/2024. Liên hệ Trưởng phòng để biết thêm chi tiết.', 
 'PB03', GETDATE());
GO


-- TRIGGER --
-- Triggers thêm nhân viên thì thêm tài khoản--
/* CREATE OR ALTER TRIGGER tg_NhanVien_ThemTaiKhoan
ON NhanVien
AFTER INSERT
AS
BEGIN
	INSERT INTO TaiKhoan(TenDangNhap, MatKhau, MaLoai)
	SELECT
        inserted.MaNV,'123',
        CASE
            WHEN NhanVien.MaCV = 'CV01' THEN 'LTK01'
            WHEN NhanVien.MaCV = 'CV02' THEN 'LTK02'
		ELSE 'LTK03'
        END AS MaLoai
	FROM inserted
	JOIN NhanVien ON inserted.MaNV = NhanVien.MaNV;
END;
GO
-- Trigger thêm tài khoản thì thêm phân quyền --
CREATE OR ALTER TRIGGER tg_TaiKhoan_ThemQuyen 
ON TaiKhoan
AFTER INSERT
AS
BEGIN
    DECLARE @tendangnhap NVARCHAR(10), 
            @matkhau NVARCHAR(255), 
            @maloai NVARCHAR(10),
            @sqlString NVARCHAR(2000);

    SELECT @tendangnhap = TenDangNhap, 
           @matkhau = MatKhau, 
           @maloai = MaLoai
    FROM inserted;

    BEGIN TRY
        -- Create Login
        SET @sqlString = 'CREATE LOGIN ' + QUOTENAME(@tendangnhap) + 
                         ' WITH PASSWORD = ''' + @matkhau + ''', DEFAULT_DATABASE = [QLNSG21], CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF';
        EXEC sp_executesql @sqlString;

        -- Create User
        SET @sqlString = 'CREATE USER ' + QUOTENAME(@tendangnhap) + ' FOR LOGIN ' + QUOTENAME(@tendangnhap);
        EXEC sp_executesql @sqlString;

        -- Assign Role 
        IF @maloai = 'LTK01'
        BEGIN
            SET @sqlString = 'ALTER SERVER ROLE sysadmin ADD MEMBER ' + QUOTENAME(@tendangnhap);
            EXEC sp_executesql @sqlString;
        END
	 IF @maloai = 'LTK02'
        BEGIN
            SET @sqlString = 'ALTER ROLE DepartmentHead ADD MEMBER ' + QUOTENAME(@tendangnhap);
            EXEC sp_executesql @sqlString;
        END
        ELSE 
        BEGIN
            SET @sqlString = 'ALTER ROLE Employee ADD MEMBER ' + QUOTENAME(@tendangnhap);
            EXEC sp_executesql @sqlString;
        END
    END TRY
    BEGIN CATCH
        PRINT 'Loi khi them quyen cho tai khoan';
    END CATCH
END;
GO
--Trigger đồng bộ mật khẩu khi nhân viên đổi mật khẩu--
CREATE OR ALTER TRIGGER tg_TaiKhoan_UpdateMatKhauLogin
ON TaiKhoan
AFTER UPDATE
AS
BEGIN
  SET NOCOUNT ON;

  IF UPDATE(MatKhau)
  BEGIN
    DECLARE @TenDangNhap nvarchar(10);
    DECLARE @MatKhau nvarchar(255);

    SELECT @TenDangNhap = i.TenDangNhap, @MatKhau = i.MatKhau
    FROM inserted i;

    DECLARE @sqlString nvarchar(2000);
    SET @sqlString = 'ALTER LOGIN [' + @TenDangNhap + '] WITH PASSWORD=''' + @MatKhau + '''';
    EXEC (@sqlString);
  END
END;
GO

-- Trigger tự động chấm công nghỉ phép có lương hoặc không lương khi nhân viên đăng ký nghỉ phép--
CREATE OR ALTER TRIGGER tr_NghiPhep_ctChamCong_CheckNghiPhep
ON NghiPhep
AFTER INSERT
AS
BEGIN
    DECLARE @MaNV NVARCHAR(10),
		@MaThang NVARCHAR(6),
		@NgayNghiPhep INT,
		@Nam NVARCHAR(4),
		@SoNgayDaNghi INT,
		@MaCC NVARCHAR(10);

    -- Lấy thông tin từ bản ghi mới được thêm vào
    SELECT @MaNV = i.MaNV,
           @MaThang = i.MaThang,
           @NgayNghiPhep = i.NgayNghiPhep
    FROM inserted i;

	-- Tách năm từ 4 ký tự cuối trong MaThang
    SELECT @Nam = SUBSTRING(@MaThang, 3, 4);

    -- Đếm số ngày nghỉ phép trong năm của nhân viên đó
    SELECT @SoNgayDaNghi = COUNT(*)
    FROM NghiPhep
    WHERE MaNV = @MaNV AND RIGHT(MaThang, 4) = @Nam;

    -- Xác định MaCC dựa trên số ngày đã nghỉ phép, 13 là do tính inserted
    IF (@SoNgayDaNghi >= 13)
        SELECT @MaCC = MaCC FROM ChamCong WHERE MoTa LIKE N'%ghỉ không lương%';
    ELSE
        SELECT @MaCC = MaCC FROM ChamCong WHERE MoTa LIKE N'%ghỉ phép năm%';

    -- Thêm bản ghi vào bảng ctChamCong
    INSERT INTO ctChamCong (MaNV, MaCC, MaThang, NgayChamCong) 
    VALUES (@MaNV, @MaCC, @MaThang, @NgayNghiPhep);
END;
GO
-- Trigger kiểm tra ngày bắt đầu và ngày kết thúc bảo hiểm:
CREATE OR ALTER TRIGGER tr_ctBaoHiem_KiemTraNgay
ON ctBaoHiem
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @NgayBD date,
            @NgayKT date;

    SELECT @NgayBD = i.NgayBD, @NgayKT = i.NgayKT
    FROM inserted i;

    IF @NgayBD >= @NgayKT
    BEGIN
        RAISERROR('Ngày bắt đầu phải trước ngày kết thúc', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO
-- Trigger kiểm tra mỗi phòng ban chỉ có một trưởng phòng, đảm bảo MaTrP là duy nhất giữa các phòng ban và đồng bộ MaTrP 
--trong bảng PhongBan khi có nhân viên được cập nhật--
CREATE OR ALTER TRIGGER tr_NhanVien_CapNhatThongTinTruongPhong
ON NhanVien
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Đảm bảo mỗi phòng ban chỉ có một trưởng phòng
    IF EXISTS (
        SELECT nv.MaPB
        FROM NhanVien nv
        WHERE nv.MaCV IN (SELECT cv.MaCV FROM ChucVu cv WHERE cv.TenCV LIKE N'Trưởng Phòng')
        GROUP BY nv.MaPB
        HAVING COUNT(*) > 1
    )
    BEGIN
        RAISERROR ('Mỗi phòng ban chỉ được có duy nhất một trưởng phòng.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
	-- Đảm bảo các trưởng phòng không giống nhau giữa các phòng ban (unique xử lý có null)
	IF EXISTS (
        SELECT pb.MaTrP, COUNT(*)
        FROM PhongBan pb
		WHERE pb.MaTrP IS NOT NULL
        GROUP BY MaTrP
		HAVING COUNT(*)>1
    )
    BEGIN
        RAISERROR ('Trưởng phòng của các phòng ban phải khác nhau', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Cập nhật thông tin trưởng phòng cho phòng ban mới
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN PhongBan pb ON i.MaPB = pb.MaPB
    )
    BEGIN
        -- Đặt MaTrP thành NULL nếu phòng ban không có nhân viên
        UPDATE PhongBan
        SET MaTrP = NULL
        WHERE MaPB IN (
            SELECT pb.MaPB
            FROM PhongBan pb
            LEFT JOIN NhanVien nv ON pb.MaPB = nv.MaPB
            WHERE nv.MaPB IS NULL
        );

        -- Cập nhật MaTrP nếu phòng ban có nhân viên
        UPDATE PhongBan
        SET MaTrP = (
            SELECT TOP 1 nv.MaNV
            FROM NhanVien nv
            JOIN ChucVu cv ON nv.MaCV = cv.MaCV
            WHERE nv.MaPB = PhongBan.MaPB
              AND cv.TenCV LIKE N'Trưởng Phòng'
        )
        WHERE MaPB IN (SELECT i.MaPB FROM inserted i)
          AND EXISTS (
              SELECT 1
              FROM NhanVien nv
              WHERE nv.MaPB = PhongBan.MaPB
          );
    END

    -- Kiểm tra và cập nhật thông tin trưởng phòng nếu nhân viên không còn thuộc phòng ban đó
    IF EXISTS (
        SELECT 1
        FROM deleted d
        JOIN PhongBan pb ON d.MaPB = pb.MaPB
    )
    BEGIN
        -- Đặt MaTrP thành NULL nếu phòng ban không có nhân viên
        UPDATE PhongBan
        SET MaTrP = NULL
        WHERE MaPB IN (
            SELECT pb.MaPB
            FROM PhongBan pb
            LEFT JOIN NhanVien nv ON pb.MaPB = nv.MaPB
            WHERE nv.MaPB IS NULL
        );

        -- Cập nhật MaTrP nếu phòng ban có nhân viên
        UPDATE PhongBan
        SET MaTrP = (
            SELECT TOP 1 nv.MaNV
            FROM NhanVien nv
            JOIN ChucVu cv ON nv.MaCV = cv.MaCV
            WHERE nv.MaPB = PhongBan.MaPB
              AND cv.TenCV LIKE N'Trưởng Phòng'
        )
        WHERE MaPB IN (SELECT d.MaPB FROM deleted d)
          AND EXISTS (
              SELECT 1
              FROM NhanVien nv
              WHERE nv.MaPB = PhongBan.MaPB
          );
    END
END;
GO
-- TRIGGER THÊM THÔNG BÁO CHO NHÂN VIÊN NẾU CÓ THÊM THƯỞNG PHẠT--
CREATE OR ALTER TRIGGER tr_ctThuongPhat_ThemThongBaoThuongPhat
ON ctThuongPhat
AFTER INSERT
AS
BEGIN
    DECLARE @MaNV NVARCHAR(10);
    DECLARE @MaPB NVARCHAR(10);
    DECLARE @NgayGui DATETIME;
    DECLARE @TieuDe NVARCHAR(100);
    DECLARE @NoiDung NVARCHAR(MAX);
    DECLARE @Loai NVARCHAR(50);
	DECLARE @Ho NVARCHAR(50);
	DECLARE @Ten NVARCHAR(50);

    -- Lấy thông tin từ bản ghi vừa được thêm
    SELECT @MaNV = inserted.MaNV, @Loai = tp.Loai, @Ho = nv.Ho, @Ten = nv.Ten
    FROM inserted
    JOIN ThuongPhat tp ON inserted.MaThuongPhat = tp.MaThuongPhat
	JOIN NhanVien nv ON nv.MaNV = inserted.MaNV

    -- Lấy mã phòng ban
    SELECT @MaPB = MaPB
    FROM NhanVien
    WHERE MaNV = @MaNV;

    -- Tạo thông báo
    SET @NgayGui = GETDATE();
    IF @Loai = N'Phạt'
    BEGIN
        SET @TieuDe = N'Có hình phạt';
        SET @NoiDung = @Ho + ' ' + @Ten + N' đã nhận được một hình phạt.';
    END
    ELSE IF @Loai = N'Thưởng'
    BEGIN
        SET @TieuDe = N'Có thưởng';
        SET @NoiDung = @Ho + ' ' + @Ten + N' đã nhận được thưởng.';
    END

    -- Gọi thủ tục lưu trữ
    EXEC sp_ThemThongBao @TieuDe, @NoiDung, @MaPB, @NgayGui;
END;
GO
-- TRIGGER THÊM THÔNG BÁO CHO NHÂN VIÊN NẾU NHẬN ĐƯỢC PHỤ CẤP--
CREATE OR ALTER TRIGGER tr_ctPhuCap_ThemThongBaoPhuCap
ON ctPhuCap
AFTER INSERT
AS
BEGIN
    DECLARE @MaNV NVARCHAR(10),
            @MaPhuCap NVARCHAR(10),
            @LoaiPhuCap NVARCHAR(50),
			@TieuDe NVARCHAR(100),
            @NgayPhuCap INT,
			@MaPB NVARCHAR(10),
			@NgayGui DATE,
            @NoiDung NVARCHAR(MAX),
			@Ho NVARCHAR(50),
			@Ten NVARCHAR(50);

    SELECT @MaNV = i.MaNV, @MaPhuCap = i.MaPhuCap, @NgayPhuCap = i.NgayPhuCap, @Ho = nv.Ho, @Ten = nv.Ten
    FROM inserted i JOIN NhanVien nv ON i.MaNV = nv.MaNV;

    SELECT @LoaiPhuCap = p.LoaiPhuCap
    FROM PhuCap p 
    WHERE p.MaPhuCap = @MaPhuCap;

	-- Lấy mã phòng ban
    SELECT @MaPB = MaPB
    FROM NhanVien
    WHERE MaNV = @MaNV;

    -- Tạo thông báo
    SET @NgayGui = GETDATE();

	SET @TieuDe =N'Thông báo phụ cấp';
    SET @NoiDung = @Ho + ' ' + @Ten + N' đã nhận được phụ cấp: ' + @LoaiPhuCap;

    -- Gọi thủ tục lưu trữ
    EXEC sp_ThemThongBao @TieuDe, @NoiDung, @MaPB, @NgayGui;
END;
GO
-- Trigger thông báo cho nhân viên nếu nhân viên đăng ký nghỉ phép thành công--
CREATE OR ALTER TRIGGER tr_NghiPhep_ThongBao
ON NghiPhep
AFTER INSERT
AS
BEGIN
    DECLARE @MaNV NVARCHAR(10), @Ho NVARCHAR(50), @Ten NVARCHAR(50), @NgayNghiPhep INT, @MaPB NVARCHAR(10);
    DECLARE @TieuDe NVARCHAR(100), @NoiDung NVARCHAR(MAX);
    
    -- Lấy thông tin nhân viên từ bảng NhanVien và thông tin ngày nghỉ phép
    SELECT 
        @MaNV = MaNV,
        @NgayNghiPhep = NgayNghiPhep
    FROM inserted;

    -- Lấy tên, phòng ban và các thông tin khác của nhân viên
    SELECT 
        @Ho = Ho, 
        @Ten = Ten, 
        @MaPB = MaPB
    FROM NhanVien nv 
    WHERE nv.MaNV = @MaNV;
    
    -- Tạo tiêu đề và nội dung thông báo
    SET @TieuDe = N'Thông Báo Nghỉ Phép: ' + @Ho + ' ' + @Ten;
    SET @NoiDung = @Ho + ' ' + @Ten + N' đã đăng ký nghỉ phép vào ngày ' + CAST(@NgayNghiPhep AS NVARCHAR(10))

    -- Chèn thông báo vào bảng ThongBao
    INSERT INTO ThongBao (TieuDe, NoiDung, MaPB, NgayGui)
    VALUES (@TieuDe, @NoiDung, @MaPB, GETDATE());
END;
GO
-- TRIGGER THÊM THÔNG BÁO CHO NHÂN VIÊN NẾU NHÂN VIÊN CHẤM CÔNG--
CREATE OR ALTER TRIGGER tr_ctChamCong_ThongBao
ON ctChamCong
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Tạo bảng tạm để xử lý tập hợp
    DECLARE @ThongBao TABLE (
        TieuDe NVARCHAR(100),
        NoiDung NVARCHAR(MAX),
        MaPB NVARCHAR(10),
        NgayGui DATETIME
    );

    -- Lấy thông tin từ bảng inserted và liên kết với bảng NhanVien
    INSERT INTO @ThongBao (TieuDe, NoiDung, MaPB, NgayGui)
    SELECT 
        N'Thông Báo Chấm Công: ' + nv.Ho + ' ' + nv.Ten AS TieuDe,
        nv.Ho + ' ' + nv.Ten + N' đã chấm công thành công vào Ngày ' + 
        CAST(i.NgayChamCong AS NVARCHAR(10)) + ' ' + ISNULL(t.MoTa, '') + '.' AS NoiDung,
        nv.MaPB,
        GETDATE()
    FROM 
        inserted i
    LEFT JOIN NhanVien nv ON i.MaNV = nv.MaNV
    LEFT JOIN Thang t ON i.MaThang = t.MaThang;

    -- Chèn thông báo vào bảng ThongBao
    INSERT INTO ThongBao (TieuDe, NoiDung, MaPB, NgayGui)
    SELECT TieuDe, NoiDung, MaPB, NgayGui
    FROM @ThongBao;

    SET NOCOUNT OFF;
END;

GO
-- Trigger thông báo cho nhân viên nếu nhân viên đổi chức vụ--
CREATE OR ALTER TRIGGER tr_NhanVien_DoiChucVu
ON NhanVien
AFTER UPDATE
AS
BEGIN
    DECLARE @MaNV NVARCHAR(10), @Ho NVARCHAR(50), @Ten NVARCHAR(50), @MaCVOld NVARCHAR(10), @MaCVNew NVARCHAR(10), @TieuDe NVARCHAR(100), @NoiDung NVARCHAR(MAX), @MaPB NVARCHAR(10);

    -- Lấy thông tin từ bảng inserted (cập nhật mới)
    SELECT 
        @MaNV = MaNV,
        @MaCVOld = (SELECT MaCV FROM deleted WHERE MaNV = inserted.MaNV),  -- Lấy MaCV cũ từ bảng deleted
        @MaCVNew = MaCV
    FROM inserted
    WHERE MaNV IN (SELECT MaNV FROM inserted);

    -- Kiểm tra nếu MaCV có thay đổi (thăng chức)
    IF @MaCVOld <> @MaCVNew
    BEGIN
        -- Lấy thông tin nhân viên như Họ, Tên, Phòng ban
        SELECT 
            @Ho = Ho, 
            @Ten = Ten, 
            @MaPB = MaPB
        FROM NhanVien
        WHERE MaNV = @MaNV;

        -- Tạo tiêu đề và nội dung thông báo
        SET @TieuDe = N'Thông Báo Chuyển Chức Vụ: ' + @Ho + ' ' + @Ten;
        SET @NoiDung = @Ho + ' ' + @Ten + N' đã được chuyển từ chức vụ ' + 
                       (SELECT TenCV FROM ChucVu WHERE MaCV = @MaCVOld) + N' sang ' + 
                       (SELECT TenCV FROM ChucVu WHERE MaCV = @MaCVNew) + '.';

        -- Chèn thông báo vào bảng ThongBao
        INSERT INTO ThongBao (TieuDe, NoiDung, MaPB, NgayGui)
        VALUES (@TieuDe, @NoiDung, @MaPB, GETDATE());
    END
END;
GO
--
GO
--
-- TEST--
INSERT INTO ctPhuCap (MaNV, MaPhuCap, MaThang, NgayPhuCap, SoTien)
VALUES
('NV04', 'PC01', '102024', 23, 500000);
GO
INSERT INTO NghiPhep (MaNV, MaThang, NgayNghiPhep, GhiChu)
VALUES ('NV04', '102024', 18, 'Bệnh');
GO
INSERT INTO ctChamCong (MaNV, MaCC, MaThang, NgayChamCong)
VALUES ('NV01', 'CC01', '032023', 11);
GO 
UPDATE NhanVien
SET MaCV = 'CV02'  -- Chức vụ mới
WHERE MaNV = 'NV03'

SELECT * FROM PhongBan
SELECT * FROM dbo.ft_NhanVienNhanThongBao('NV01')
SELECT * FROM ThongBao
UPDATE NhanVien
SET MaPB = 'PB02'
WHERE MaNV = 'NV01';
--
GO
--Trigger kiểm tra đăng ký nghỉ phép nếu trùng với ngày nghỉ chính thức của công ty thì thông báo cho nhân viên--
CREATE OR ALTER TRIGGER tr_NghiPhep_CheckNgayLe
ON NghiPhep
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @MaNV NVARCHAR(10), @MaThang NVARCHAR(6), @NgayNghiPhep INT, @NgayPhepFull DATE;
    SELECT @MaNV = i.MaNV, @MaThang = i.MaThang, @NgayNghiPhep = i.NgayNghiPhep
    FROM inserted i;
    -- Chuyển đổi ngày và tháng thành kiểu DATE để kiểm tra với ngày nghỉ lễ
    SET @NgayPhepFull = DATEFROMPARTS(CONVERT(INT, RIGHT(@MaThang, 4)), CONVERT(INT, LEFT(@MaThang, 2)), @NgayNghiPhep);
    -- Danh sách các ngày lễ cố định
    IF @NgayPhepFull IN (
        '2024-01-01',  -- Tết Dương lịch
        '2024-04-30',  -- Ngày Giải phóng miền Nam
        '2024-05-01',  -- Ngày Quốc tế Lao động
        '2024-09-02',  -- Quốc khánh Việt Nam
        '2024-12-31'   -- Ngày cuối năm
        -- Thêm các ngày lễ khác vào đây nếu cần
    )
    BEGIN
        RAISERROR('Ngày này là ngày lễ chính thức của công ty, không cần đăng ký nghỉ phép.', 16, 1);
        RETURN;
    END
    ELSE
    BEGIN
        -- Chèn dữ liệu nếu ngày không trùng với ngày lễ
        INSERT INTO NghiPhep (MaNV, MaThang, NgayNghiPhep, GhiChu)
        SELECT MaNV, MaThang, NgayNghiPhep, GhiChu
        FROM inserted;
    END
END;

-- Trigger tự động tạo tháng và tính số ngày công chuẩn nếu tháng nhân viên thực hiện chấm công chưa tồn tại--
CREATE OR ALTER TRIGGER [dbo].[tr_AddctChamCong]
ON [dbo].[ctChamCong]
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @MaNV VARCHAR(10),
            @MaCC VARCHAR(10),
            @MaThang VARCHAR(6),
            @NgayChamCong INT,
			@SoNgayCongChuan INT = 0;

	BEGIN TRANSACTION;
	BEGIN TRY

		SELECT @MaNV = inserted.MaNV, 
			   @MaCC = inserted.MaCC, 
			   @MaThang = inserted.MaThang, 
			   @NgayChamCong = inserted.NgayChamCong
		FROM inserted; 

		-- Kiểm tra Thang Cham Cong đã tồn tại trong bảng tháng chưa
		IF NOT EXISTS (SELECT 1 FROM Thang WHERE MaThang = @MaThang)
		BEGIN
			DECLARE @Thang NVARCHAR(2) = LEFT(@MaThang, 2);
			DECLARE @Nam NVARCHAR(4) = RIGHT(@MaThang, 4);

			SET @SoNgayCongChuan = dbo.ft_SoNgayCongChuan(@MaThang);

			INSERT INTO Thang (MaThang, MoTa, SoNgayCongChuan) 
			VALUES (@MaThang, N'Tháng ' + @Thang + N' năm ' + @Nam, @SoNgayCongChuan);
		END

		DECLARE @NgayHienTai DATE = GETDATE(), @NgayCCFull DATE

    SET @NgayCCFull = CONVERT(DATE, RIGHT(@MaThang, 4) + LEFT(@MaThang, 2) + RIGHT('00' + CAST(@NgayChamCong AS VARCHAR), 2), 112)

    IF @NgayCCFull > @NgayHienTai and ( @MaCC = 'CC01' or @MaCC = 'CC03')
        BEGIN
			RAISERROR('Không thể chấm công đi làm cho ngày ở tương lai', 16, 1);
			ROLLBACK TRANSACTION;
			RETURN;
		END
    ELSE
        BEGIN
			-- Kiểm tra và Thêm record vào bảng ctChamCong
			IF NOT EXISTS (SELECT 1 FROM ctChamCong WHERE MaNV = @MaNV 
													 AND MaThang = @MaThang 
													 AND NgayChamCong = @NgayChamCong)
			BEGIN
				INSERT INTO ctChamCong (MaNV, MaCC, MaThang, NgayChamCong)
				VALUES (@MaNV, @MaCC, @MaThang, @NgayChamCong);
			END
			ELSE
			BEGIN
				RAISERROR('Đã chấm công cho ngày này', 16, 1);
				ROLLBACK TRANSACTION;
				RETURN;
			END
			COMMIT TRANSACTION;
		END
	END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);
    SET @ErrorMessage = ERROR_MESSAGE();
    PRINT 'Error Message: ' + @ErrorMessage;

    ROLLBACK TRANSACTION;
  END CATCH;
END;
--- HÀM TIỀM KIẾM NV THEO MÃ NV--
CREATE OR ALTER FUNCTION [dbo].[TimKiemNhanVien]
(
    @MaNV nvarchar(10)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM NhanVien
    WHERE MaNV = @MaNV
);
GO
--HÀM TÍNH THÂM NIÊN--
ALTER   FUNCTION [dbo].[TimKiemNhanVien]
(
    @MaNV nvarchar(10)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM NhanVien
    WHERE MaNV = @MaNV
);
GO
-- Hàm tính số ngày công chuẩn (số ngày làm việc không tính thứ bảy, chủ nhật):--
CREATE OR ALTER FUNCTION dbo.ft_SoNgayCongChuan (@MaThang VARCHAR(6))
RETURNS INT
AS
BEGIN
    DECLARE @SoNgayLamViec INT = 0;
    DECLARE @NgayBatDau DATE;
    DECLARE @NgayKetThuc DATE;
    DECLARE @NgayHienTai DATE;
    DECLARE @Thang INT;
    DECLARE @Nam INT;

    -- Lấy tháng và năm từ MaThang
    SET @Thang = CAST(SUBSTRING(@MaThang, 1, 2) AS INT);
    SET @Nam = CAST(SUBSTRING(@MaThang, 3, 4) AS INT);

    -- Xác định ngày bắt đầu và ngày kết thúc của tháng
    SET @NgayBatDau = DATEFROMPARTS(@Nam, @Thang, 1);
    SET @NgayKetThuc = EOMONTH(@NgayBatDau);

    -- Duyệt qua từng ngày trong tháng
    SET @NgayHienTai = @NgayBatDau;
    WHILE @NgayHienTai <= @NgayKetThuc
    BEGIN
        -- Nếu là thứ Hai đến thứ Sáu tăng biến đếm số ngày làm việc
        IF DATEPART(WEEKDAY, @NgayHienTai) BETWEEN 2 AND 6
        BEGIN
            SET @SoNgayLamViec = @SoNgayLamViec + 1;
        END
        -- Chuyển sang ngày tiếp theo
        SET @NgayHienTai = DATEADD(DAY, 1, @NgayHienTai);
    END

    RETURN @SoNgayLamViec;
END;
GO
--------- END TRIGGER -------------

---------- VIEW -----------------
-- Hiển thị thông tin nhân viên-- 
CREATE OR ALTER VIEW vw_ThongTinNhanVien AS 
SELECT nv.MaNV, nv.Ho, nv.Ten, nv.GioiTinh, nv.NgaySinh, nv.DiaChi, nv.SDT, nv.Email, nv.CCCD, pb.TenPB AS TenPhongBan, cv.TenCV AS TenChucVu
FROM NhanVien nv JOIN PhongBan pb ON nv.MaPB = pb.MaPB JOIN ChucVu cv ON nv.MaCV = cv.MaCV;
GO
-- Hiển thị thông tin các loại bảo hiểm --
CREATE OR ALTER VIEW vw_QuanLyBaoHiem AS
SELECT nv.MaNV, nv.Ho, nv.Ten, bh.TenBH, ctbh.MaBH, ctbh.NgayBD, ctbh.NgayKT
FROM NhanVien nv JOIN ctBaoHiem ctbh ON nv.MaNV = ctbh.MaNV JOIN BaoHiem bh ON ctbh.MaLoai = bh.MaLoai;
GO
--  Hiển thị thông tin hợp đồng của nhân viên 
CREATE OR ALTER VIEW vw_ThongTinHopDong AS 
SELECT nv.MaNV,hd.MaHD, hd.LuongCoBan, hd.NgayBD AS NgayBatDauHopDong, hd.NgayKT AS NgayKetThucHopDong, pb.TenPB AS TenPhongBan, cv.TenCV AS TenChucVu 
FROM NhanVien nv 
JOIN HopDong hd ON nv.MaHD = hd.MaHD
JOIN ChucVu cv ON nv.MaCV = cv.MaCV
JOIN PhongBan pb ON pb.MaPB = nv.MaPB;
GO
--- END VIEW ----

-- PROCEDURE --

-- QUAN LY NHAN VIEN --
CREATE OR ALTER PROCEDURE sp_AddNhanVien
    @MaNV NVARCHAR(10),
    @Ho NVARCHAR(50),
    @Ten NVARCHAR(50),
    @GioiTinh NVARCHAR(10),
    @NgaySinh DATE,
    @DiaChi NVARCHAR(100),
    @SDT NVARCHAR(20),
    @Email NVARCHAR(50),
    @CCCD NVARCHAR(12),
    @MaPB NVARCHAR(10) = NULL, 
    @MaCV NVARCHAR(10),
    @MaHD NVARCHAR(10) = NULL 
AS
BEGIN
    -- Kiểm tra xem mã nhân viên đã tồn tại hay chưa
    IF EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @MaNV)
    BEGIN
        THROW 50000, 'Đã tồn tại mã nhân viên', 1;
        RETURN; 
    END

    -- Thực hiện việc chèn dữ liệu
    INSERT INTO NhanVien(MaNV, Ho, Ten, GioiTinh, NgaySinh, DiaChi, SDT, Email, CCCD, MaPB, MaCV, MaHD)
    VALUES (@MaNV, @Ho, @Ten, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @Email, @CCCD, @MaPB, @MaCV, @MaHD);
END;

GO
CREATE OR ALTER PROCEDURE sp_UpdateNhanVien
    @MaNV NVARCHAR(10), 
    @Ho NVARCHAR(50),
    @Ten NVARCHAR(50),
    @GioiTinh NVARCHAR(10),
    @NgaySinh DATE,
    @DiaChi NVARCHAR(100),
    @CCCD NVARCHAR(12),
    @Email NVARCHAR(50),
    @SDT NVARCHAR(10),
    @MaPB NVARCHAR(10),
    @MaCV NVARCHAR(10)
AS
BEGIN
    -- Kiểm tra dữ liệu không được bỏ trống
    IF 
        @Ho IS NULL OR
        @Ten IS NULL OR
        @GioiTinh IS NULL OR
        @NgaySinh IS NULL OR
        @DiaChi IS NULL OR
        @CCCD IS NULL OR
        @Email IS NULL OR
        @SDT IS NULL OR
        @MaCV IS NULL
    BEGIN
        -- Trả về một lỗi hoặc thông báo tùy thuộc vào yêu cầu
        RAISERROR('Vui lòng điền đầy đủ thông tin cho các trường bắt buộc', 16, 1);
        RETURN;
    END

    -- Kiểm tra độ dài của SDT
    IF LEN(@SDT) <> 10
    BEGIN
        RAISERROR('Số điện thoại phải có độ dài 10 ký tự', 16, 1);
        RETURN;
    END

    -- Kiểm tra tính duy nhất của CCCD, Email và SDT
    IF EXISTS (SELECT 1 FROM NhanVien WHERE CCCD = @CCCD AND MaNV <> @MaNV)
    BEGIN
        RAISERROR('CCCD đã tồn tại', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM NhanVien WHERE Email = @Email AND MaNV <> @MaNV)
    BEGIN
        RAISERROR('Email đã tồn tại', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM NhanVien WHERE SDT = @SDT AND MaNV <> @MaNV)
    BEGIN
        RAISERROR('Số điện thoại đã tồn tại', 16, 1);
        RETURN;
    END

    -- Thực hiện cập nhật thông tin nhân viên trong bảng NhanVien dựa trên MaNV
    UPDATE NhanVien
    SET 
        Ho = @Ho,
        Ten = @Ten,
        GioiTinh = @GioiTinh,
        NgaySinh = @NgaySinh,
        DiaChi = @DiaChi,
        CCCD = @CCCD,
        Email = @Email,
        SDT = @SDT,
        MaPB = @MaPB,
        MaCV = @MaCV
    WHERE MaNV = @MaNV;
END;

GO

CREATE OR ALTER PROCEDURE sp_DeleteNhanVien
    @MaNV nvarchar(10)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @TenTaiKhoan varchar(10);
	SELECT @TenTaiKhoan=TenDangNhap FROM TaiKhoan WHERE TenDangNhap=@MaNV
	DECLARE @sql varchar(100)
	DECLARE @SessionID INT;
	SELECT @SessionID = session_id
	FROM sys.dm_exec_sessions
	WHERE login_name = @TenTaiKhoan;
	IF @SessionID IS NOT NULL
	BEGIN
		SET @sql = 'kill ' + Convert(NVARCHAR(20), @SessionID)
		exec(@sql)
	END
	BEGIN TRANSACTION;
	BEGIN TRY
		DELETE FROM NhanVien WHERE MaNV = @MaNV;
		--
		SET @sql = 'DROP USER '+ @TenTaiKhoan
		exec (@sql)
		--
		SET @sql = 'DROP LOGIN '+ @TenTaiKhoan
		exec (@sql)
	END TRY
	BEGIN CATCH
		DECLARE @err NVARCHAR(MAX)
		SELECT @err = N'Lỗi ' + ERROR_MESSAGE()
		RAISERROR(@err, 16, 1)
		ROLLBACK TRANSACTION;
	THROW;
	END CATCH
	COMMIT TRANSACTION;
END;
GO 


-- QUAN LY PHONG BAN
CREATE OR ALTER PROCEDURE sp_ThemPhongBan
    @MaPB nvarchar(10),
    @TenPB nvarchar(50),
    @SDT nvarchar(20),
    @MaTrP nvarchar(10)
AS
BEGIN
    INSERT INTO PhongBan (MaPB, TenPB, MaTrP, SDT)
    VALUES (@MaPB, @TenPB, @MaTrP, @SDT);
END
GO

CREATE OR ALTER PROCEDURE sp_CapNhatPhongBan
	@MaPB nvarchar(10),
	@TenPB nvarchar(50),
   	@SDT nvarchar(20),
	@MaTrP nvarchar(10)
AS
BEGIN
   	IF @MaPB IS NULL OR @MaPB = '' OR @TenPB IS NULL OR @TenPB = '' OR @MaTrP IS NULL OR @MaTrP ='' or
   	@SDT IS NULL OR @SDT = ''
	BEGIN
    	RAISERROR('Vui lòng điền đầy đủ thông tin', 16, 1)
    	RETURN;
	END
   	ELSE
   	UPDATE PhongBan
   	SET TenPB = @TenPB, MaTrP = @MaTrP, SDT = @SDT
   	WHERE MaPB = @MaPB;   
END
GO

CREATE OR ALTER PROCEDURE sp_XoaPhongBan
	@MaPB nvarchar(10)
AS
BEGIN
   	DELETE FROM PhongBan
   	WHERE MaPB = @MaPB;
END
GO
-- Pro
CREATE OR ALTER  PROCEDURE sp_XemThongTinChiTietPhongBan
    @MaPB nvarchar(10)
AS
BEGIN
    SELECT * FROM vw_ThongTinPhongBan WHERE MaPB = @MaPB;
END;
GO
--- Hàm XemChiTietPhongBan - Multible statement table-valued không para
CREATE OR ALTER FUNCTION dbo.ft_XemChiTietPhongBan()
RETURNS @PhongBanChiTiet TABLE (
    MaPB nvarchar(10),
    MaTrP nvarchar(10),
    SoNV INT,
    SoNVNam INT,
    SoNVNu INT,
	SoThongBao INT
)
AS
BEGIN
    INSERT INTO @PhongBanChiTiet (MaPB, MaTrP, SoNV, SoNVNam, SoNVNu, SoThongBao)
    SELECT 
        t.MaPB,
		t.MaTrP,
        COUNT(nv.MaNV) AS SoNV, 
        COUNT(CASE WHEN nv.GioiTinh LIKE  N'Nam' THEN 1 END) AS SoNV_Nam,
        COUNT(CASE WHEN nv.GioiTinh LIKE N'Nữ' THEN 1 END) AS SoNV_Nu,
		t.SoThongBao
    FROM 
        (SELECT pb.MaPB, pb.MaTrP, COUNT (tb.Id) as SoThongBao  
		FROM	
		PhongBan pb 
		LEFT JOIN 
		ThongBao tb ON tb.MaPB = pb.MaPB 
		GROUP BY pb.MaPB, pb.MaTrP) as t 
		LEFT JOIN
        NhanVien nv ON t.MaPB = nv.MaPB
		GROUP BY t.MaPB, t.SoThongBao, t.MaTrP
    RETURN;
END;
GO
SELECT * FROM dbo.ft_XemChiTietPhongBan()
GO

---//------
-- Hàm nhận nhân viên nhận thông báo _ multi statement table-valued có para 
CREATE OR ALTER FUNCTION dbo.ft_NhanVienNhanThongBao(@MaNV NVARCHAR(10))
RETURNS @ThongBaoNhanVien TABLE (
    TieuDe NVARCHAR(100),
    NoiDung NVARCHAR(MAX),
    NgayGui DATE
)
AS
BEGIN
    -- Lấy thông báo từ bảng ThongBao và PhongBan
    INSERT INTO @ThongBaoNhanVien (TieuDe, NoiDung, NgayGui)
    SELECT 
        tb.TieuDe, 
        -- Thay thế tên nhân viên trong Nội Dung thành "Bạn"
        CASE 
            WHEN tb.NoiDung IS NOT NULL THEN 
                REPLACE(tb.NoiDung, (SELECT Ho + ' ' + Ten FROM NhanVien WHERE MaNV = @MaNV), N'Bạn')
            ELSE tb.NoiDung 
        END AS NoiDung, 
        tb.NgayGui
    FROM 
        PhongBan pb
    LEFT JOIN 
        ThongBao tb ON tb.MaPB = pb.MaPB
    JOIN
        NhanVien nv ON pb.MaPB = nv.MaPB
    WHERE 
        nv.MaNV = @MaNV;
    RETURN;
END;
GO

GO
-- Trưởng phòng xem thông báo tất cả nhân viên  -- 
CREATE OR ALTER FUNCTION dbo.ft_TruongPhongNhanThongBao(@MaNV NVARCHAR(10))
RETURNS @ThongBao TABLE (
    TieuDe NVARCHAR(100),
    NoiDung NVARCHAR(MAX),
    NgayGui DATETIME
)
AS
BEGIN
    -- Kiểm tra xem người dùng có phải là trưởng phòng không
    IF EXISTS (
        SELECT 1 
        FROM NhanVien nv 
        JOIN PhongBan pb ON nv.MaNV = pb.MaTrP 
        WHERE nv.MaNV = @MaNV
    )
    BEGIN
        -- Nếu là trưởng phòng, lấy thông báo của tất cả phòng ban
        INSERT INTO @ThongBao (TieuDe, NoiDung, NgayGui)
        SELECT DISTINCT
            tb.TieuDe, 
            tb.NoiDung, 
            tb.NgayGui
        FROM ThongBao tb
        
        ORDER BY tb.NgayGui DESC;
    END
    RETURN;
END;
GO
-- Example usage:
SELECT * FROM dbo.ft_NhanVienNhanThongBao('NV03');
SELECT * FROM dbo.ft_TruongPhongNhanThongBao('NV03');
SELECT * FROM ThongBao
GO
-- QUAN LY THONG BAO PRECEDURE --
CREATE OR ALTER PROCEDURE sp_ThemThongBao
    @TieuDe NVARCHAR(100),
    @NoiDung NVARCHAR(MAX),
    @MaPB NVARCHAR(10),
    @NgayGui DATETIME
AS
BEGIN
    INSERT INTO ThongBao (TieuDe, NoiDung, MaPB, NgayGui)
    VALUES (@TieuDe, @NoiDung, @MaPB, @NgayGui);
END;
GO
-- Trigger Cập Nhật Thông Báo--
CREATE OR ALTER PROCEDURE sp_CapNhatThongBao
    @Id INT,
    @TieuDe NVARCHAR(100),
    @NoiDung NVARCHAR(MAX),
    @MaPB nvarchar(10),
    @NgayGui DATETIME
AS
BEGIN
    UPDATE ThongBao
    SET TieuDe = @TieuDe, NoiDung = @NoiDung, MaPB = @MaPB, NgayGui = @NgayGui
    WHERE Id = @Id;
END;
GO
-- TRIGGER Xóa Thông Báo--
--
CREATE OR ALTER PROCEDURE sp_XoaThongBao
    @Id INT
AS
BEGIN
    -- Xóa thông báo dựa trên Id
    DELETE FROM ThongBao WHERE Id = @Id;

    -- Tạo bảng tạm để lưu trữ các thông báo còn lại
    DECLARE @ThongBaoTemp TABLE (
        NewId INT IDENTITY(1,1),
        TieuDe NVARCHAR(100),
        NoiDung NVARCHAR(MAX),
        MaPB NVARCHAR(10),
        NgayGui DATETIME
    );

    -- Chèn các thông báo còn lại vào bảng tạm
    INSERT INTO @ThongBaoTemp (TieuDe, NoiDung, MaPB, NgayGui)
    SELECT TieuDe, NoiDung, MaPB, NgayGui
    FROM ThongBao
    ORDER BY Id;

    -- Xóa tất cả các thông báo trong bảng ThongBao
    DELETE FROM ThongBao;

    -- Bật IDENTITY_INSERT để chèn giá trị cụ thể vào cột IDENTITY
    SET IDENTITY_INSERT ThongBao ON;

    -- Chèn lại các thông báo từ bảng tạm vào bảng ThongBao với Id mới
    INSERT INTO ThongBao (Id, TieuDe, NoiDung, MaPB, NgayGui)
    SELECT NewId, TieuDe, NoiDung, MaPB, NgayGui
    FROM @ThongBaoTemp;

    -- Tắt IDENTITY_INSERT sau khi chèn xong
    SET IDENTITY_INSERT ThongBao OFF;
END;
GO
EXEC sp_XoaThongBao @Id = 1;
GO
-- QUAN LY HOP DONG -- 
CREATE OR ALTER PROCEDURE sp_AddHopDong 
    @MaHD NVARCHAR(10),
    @MaNV NVARCHAR(10),
    @LuongCoBan INT,
    @NgayBD DATE,
    @NgayKT DATE
AS
BEGIN
    -- Kiểm tra các tham số có trống hoặc NULL không
    IF (@MaHD = '' OR @MaNV = '' OR @LuongCoBan IS NULL OR @NgayBD IS NULL OR @NgayKT IS NULL)
    BEGIN
        THROW 50000, 'Các thuộc tính bắt buộc không được để trống', 1;
        RETURN;
    END
    
    -- Chèn dữ liệu vào bảng HopDong
    INSERT INTO HopDong (MaHD, MaNV, LuongCoBan, NgayBD, NgayKT)
    VALUES (@MaHD, @MaNV, @LuongCoBan, @NgayBD, @NgayKT);
END;

GO
CREATE OR ALTER   PROCEDURE sp_UpdateHopDong
    @MaHD nvarchar(10),
    @NgayBD DATE,
    @NgayKT DATE,
	@LuongCoBan int
AS
BEGIN

	IF @NgayBD IS NULL OR @NgayBD = '' OR @NgayKT IS NULL OR @NgayKT = ''
    BEGIN
        RAISERROR('Vui lòng điền đầy đủ thông tin cho tất cả các trường', 16, 1)
        RETURN;
    END
	ELSE
	UPDATE HopDong 
	SET NgayBD = @NgayBD, NgayKT = @NgayKT, LuongCoBan = @LuongCoBan 
	WHERE MaHD = @MaHD;    
END
GO

CREATE OR ALTER   PROCEDURE sp_DeleteHopDong
    @MaHD nvarchar(10)
AS
BEGIN
	DELETE FROM HopDong 
	WHERE MaHD = @MaHD;
END;
GO
-- QUAN LY THUONG PHAT --

CREATE OR ALTER PROCEDURE sp_ThemThuongPhat
    @MaThuongPhat nvarchar(10),
	@Loai nvarchar(50),
	@SoTien int,
	@LyDo nvarchar(MAX)
AS
BEGIN
	-- Kiểm tra nếu một hoặc nhiều tham số là NULL hoặc rỗng
    IF @MaThuongPhat IS NULL OR @MaThuongPhat = '' OR @Loai IS NULL OR @Loai = '' OR 
	@SoTien IS NULL OR @SoTien ='' OR @LyDo ='' OR @LyDo IS NULL
    BEGIN
        RAISERROR('Dữ liệu không được bỏ trống', 16, 1)
        RETURN;
    END
	ELSE
    
    IF EXISTS (SELECT 1 FROM ThuongPhat WHERE MaThuongPhat = @MaThuongPhat)
    BEGIN
        RAISERROR('Mã Thưởng phạt đã tồn tại', 16, 1)
        RETURN;
    END
	ELSE
    -- Nếu không trùng mã và không có dữ liệu rỗng, thực hiện INSERT
    INSERT INTO ThuongPhat(MaThuongPhat, Loai, SoTien, LyDo)
    VALUES (@MaThuongPhat, @Loai, @SoTien, @LyDo);
END 
GO

CREATE OR ALTER PROCEDURE sp_ThemctThuongPhat
    @MaNV nvarchar(10),
	@MaThuongPhat nvarchar(10),
	@MaThang nvarchar(6),
	@NgayThuongPhat int
AS
BEGIN
    IF EXISTS (SELECT 1 FROM ctThuongPhat WHERE MaNV = @MaNV and MaThang = @MaThang and NgayThuongPhat = @NgayThuongPhat and MaThuongPhat = @MaThuongPhat)
    BEGIN
        RAISERROR('Dữ liệu đã tồn tại', 16, 1)
        RETURN;
    END
    ELSE
	INSERT INTO ctThuongPhat(MaNV, MaThuongPhat, MaThang, NgayThuongPhat)
    VALUES (@MaNV, @MaThuongPhat, @MaThang, @NgayThuongPhat);
END;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatThuongPhat
    @MaThuongPhat nvarchar(10),
	@Loai nvarchar(20),
	@SoTien int,
	@LyDo nvarchar(30)
AS
BEGIN
	IF @MaThuongPhat IS NULL OR @MaThuongPhat = '' OR @Loai IS NULL OR @Loai = '' OR 
	@SoTien IS NULL OR @SoTien ='' OR @LyDo ='' OR @LyDo IS NULL
    BEGIN
        RAISERROR('Dữ liệu không được bỏ trống', 16, 1)
        RETURN;
    END
	ELSE
    -- Thực hiện cập nhật thông tin nhân viên trong bảng NhanVien dựa trên MaNV
    UPDATE ThuongPhat
    SET 
		MaThuongPhat = @MaThuongPhat,
		Loai = @Loai,
		SoTien = @SoTien,
		LyDo = @LyDo
    WHERE MaThuongPhat = @MaThuongPhat
END
GO
-- PROCEDURE CÓ TRANSACTION:
CREATE OR ALTER PROCEDURE sp_CapNhatNgayThangThuongPhat
    @MaNV NVARCHAR(10),
    @MaThuongPhat NVARCHAR(10),	 
    @MaThang NVARCHAR(6),
    @NgayThuongPhat INT
AS
BEGIN 
    BEGIN TRANSACTION;
    DECLARE @OldMaThang NVARCHAR(6);
    DECLARE @OldNgayThuongPhat INT;
    SELECT @OldMaThang = MaThang, @OldNgayThuongPhat = NgayThuongPhat
    FROM ctThuongPhat
    WHERE MaThuongPhat = @MaThuongPhat AND MaNV = @MaNV;

    -- Kiểm tra xem có dữ liệu cũ hay không
    IF @OldMaThang IS NULL OR @OldNgayThuongPhat IS NULL
    BEGIN
        -- Nếu không có dữ liệu cũ, rollback giao dịch và trả về lỗi
        ROLLBACK TRANSACTION;
        RAISERROR('Không tìm thấy thông tin thưởng phạt để cập nhật.', 16, 1);
        RETURN;
    END

    -- Cập nhật thông tin
    UPDATE ctThuongPhat
    SET 
        MaThang = @MaThang, 
        NgayThuongPhat = @NgayThuongPhat
    WHERE MaThuongPhat = @MaThuongPhat AND MaNV = @MaNV;

    -- Commit giao dịch nếu cập nhật thành công
    COMMIT TRANSACTION;
END
GO

CREATE OR ALTER PROCEDURE sp_XoaThuongPhat
    @MaThuongPhat nvarchar(10)
AS
BEGIN
	DELETE FROM ThuongPhat 
	WHERE MaThuongPhat = @MaThuongPhat;
END 
GO

CREATE OR ALTER PROCEDURE sp_XoactThuongPhat
    @MaNV nvarchar(10),
	@NgayThuongPhat int,
	@MaTP nvarchar (10),
	@MaThang nvarchar(6)
AS
BEGIN
	DELETE FROM ctThuongPhat 
	WHERE MaNV=@MaNV and NgayThuongPhat = @NgayThuongPhat and MaThuongPhat = @MaTP and MaThang = @MaThang
END
GO
-- Hàm trả về 1 bảng có tham số - Inline table-valued
CREATE OR ALTER FUNCTION dbo.ft_LocThuongPhatNhanVien(@MaNV NVARCHAR(10), @Loai NVARCHAR(50))
RETURNS TABLE
AS
RETURN 
(
    SELECT 
        nv.MaNV AS MaNhanVien, 
        nv.Ho AS Ho, 
        nv.Ten AS Ten,  
        tp.Loai AS Loai, 
        tp.LyDo AS LyDo, 
        tp.SoTien AS TienThuongPhat, 
        cttp.MaThang AS MaThang,
        cttp.NgayThuongPhat AS NgayThuongPhat,
        cv.TenCV AS TenChucVu,
        pb.TenPB AS TenPhongBan
    FROM 
        ctThuongPhat cttp
    JOIN 
        ThuongPhat tp ON cttp.MaThuongPhat = tp.MaThuongPhat
    JOIN 
        NhanVien nv ON cttp.MaNV = nv.MaNV
    LEFT JOIN 
        ChucVu cv ON nv.MaCV = cv.MaCV
    LEFT JOIN 
        PhongBan pb ON nv.MaPB = pb.MaPB
    WHERE 
        tp.Loai = @Loai AND nv.MaNV = @MaNV
);
GO
-- QUAN LY CHUC VU --

CREATE OR ALTER PROCEDURE sp_AddChucVu
  @MaCV nvarchar(10),
  @TenCV nvarchar(50)
AS
BEGIN
  -- Kiểm tra nếu một hoặc nhiều tham số là NULL hoặc rỗng
    IF @MaCV IS NULL OR @MaCV = '' OR @TenCV IS NULL OR @TenCV = ''
    BEGIN
        RAISERROR('Dữ liệu không được bỏ trống', 16, 1)
        RETURN;
    END
  ELSE
    INSERT INTO ChucVu(MaCV, TenCV)
    VALUES (@MaCV, @TenCV);
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateChucVu
    @MaCV nvarchar(10),
  @TenCV nvarchar(50)
AS
BEGIN
  IF @MaCV IS NULL OR @MaCV = '' OR @TenCV IS NULL OR @TenCV = ''
    BEGIN
        RAISERROR('Dữ liệu không được bỏ trống', 16, 1)
        RETURN;
    END
  ELSE
    UPDATE ChucVu
    SET
    MaCV = @MaCV,
    TenCV = @TenCV
    WHERE MaCV = @MaCV;
END;
GO

CREATE OR ALTER PROCEDURE sp_DeleteChucVu
    @MaCV nvarchar(10)
AS
BEGIN
  DELETE FROM ChucVu
  WHERE MaCV = @MaCV;
END
GO

-- QUAN LY PHU CAP --
CREATE OR ALTER PROCEDURE sp_AddPhuCap
    @MaPhuCap NVARCHAR(10),
    @LoaiPhuCap NVARCHAR(10)
AS
BEGIN
        INSERT INTO PhuCap (MaPhuCap, LoaiPhuCap)
        VALUES (@MaPhuCap, @LoaiPhuCap);
       
        PRINT 'Thêm thành công!';
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdatePhuCap
    @MaPhuCap NVARCHAR(10),
    @LoaiPhuCap NVARCHAR(10)
AS
BEGIN
        UPDATE PhuCap
        SET LoaiPhuCap = @LoaiPhuCap
        WHERE MaPhuCap = @MaPhuCap;
       
        PRINT 'Cập nhật thành công!';
END;
GO

CREATE OR ALTER PROCEDURE sp_DeletePhuCap
    @MaPhuCap NVARCHAR(10)
AS
    BEGIN
        -- Xóa bản ghi phụ cấp
        DELETE FROM PhuCap
        WHERE MaPhuCap = @MaPhuCap;

        PRINT 'Xóa thành công!';
END;
GO
---
CREATE OR ALTER PROCEDURE sp_AddctPhuCap
  @MaNV NVARCHAR(10),
  @MaPhuCap NVARCHAR(10),
  @MaThang NVARCHAR(6),
  @NgayPhuCap INT,
  @SoTien INT
AS
BEGIN
    INSERT INTO ctPhuCap (MaNV, MaPhuCap, MaThang, NgayPhuCap, SoTien)
        VALUES (@MaNV, @MaPhuCap, @MaThang, @NgayPhuCap, @SoTien);
        PRINT 'Thêm thành công!';
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdatectPhuCap
  @MaNV NVARCHAR(10),
  @MaPhuCap NVARCHAR(10),
  @MaThang NVARCHAR(6),
  @NgayPhuCap INT,
  @SoTien INT
AS
BEGIN
      UPDATE ctPhuCap
      SET MaNV = @MaNV,
      MaPhuCap=@MaPhuCap,
      MaThang=@MaThang,
      NgayPhuCap=@NgayPhuCap,
      SoTien=@SoTien
      WHERE MaNV = @MaNV AND MaPhuCap = @MaPhuCap AND MaThang=@MaThang AND NgayPhuCap=@NgayPhuCap;
       
      PRINT 'Cập nhật thành công!';
END;
GO

CREATE OR ALTER PROCEDURE sp_DeletectPhuCap
  @MaNV NVARCHAR(10),
  @MaPhuCap NVARCHAR(10),
  @MaThang NVARCHAR(6),
  @NgayPhuCap INT
AS
BEGIN
    DELETE FROM ctPhuCap
    WHERE MaNV = @MaNV AND MaPhuCap=@MaPhuCap AND MaThang=@MaThang AND NgayPhuCap=@NgayPhuCap;
    PRINT 'Xóa thành công!';
END;
GO

-- QUAN LY CHAM CONG --
CREATE OR ALTER PROCEDURE sp_AddctChamCong
    @MaNV VARCHAR(10),
    @MaCC VARCHAR(10),
    @MaThang VARCHAR(6),
    @NgayChamCong int
AS
BEGIN
	IF EXISTS (SELECT 1 FROM ctChamCong WHERE MaNV = @MaNV AND MaThang = @MaThang AND NgayChamCong = @NgayChamCong)
		BEGIN
			RAISERROR('Đã chấm công cho ngày này', 16, 1);
		END
    ELSE
		BEGIN
			INSERT INTO ctChamCong (MaNV, MaCC, MaThang, NgayChamCong)
			VALUES (@MaNV, @MaCC, @MaThang, @NgayChamCong);
		END    
END;
GO
--
CREATE OR ALTER PROCEDURE sp_UpdatectChamCong
    @MaNV VARCHAR(10),
    @MaCC VARCHAR(10),
    @MaThang VARCHAR(6),
    @NgayChamCong int
AS
BEGIN
    -- Kiểm tra xem bản ghi có tồn tại trước khi cập nhật
    IF EXISTS (SELECT 1 FROM ctChamCong WHERE MaNV = @MaNV AND MaThang = @MaThang AND NgayChamCong = @NgayChamCong)
    BEGIN
        UPDATE ctChamCong
        SET MaCC = @MaCC
        WHERE MaNV = @MaNV AND MaThang = @MaThang AND NgayChamCong = @NgayChamCong;
    END
    ELSE
    BEGIN
        RAISERROR('Không tìm thấy chi tiết chấm công theo yêu cầu.', 16, 1);
    END
END;
GO

CREATE OR ALTER PROCEDURE sp_DeletectChamCong
    @MaNV VARCHAR(10),
    @MaThang VARCHAR(6),
    @NgayChamCong int
AS
BEGIN
        DELETE FROM ctChamCong WHERE MaNV = @MaNV AND MaThang = @MaThang AND NgayChamCong = @NgayChamCong;
END;
GO

-- NHAN VIEN CHAM CONG --

CREATE OR ALTER PROCEDURE sp_GetChamCongByMaNV
    @MaNV VARCHAR(10)
AS
BEGIN
    SELECT 
        ct.NgayChamCong, 
        thg.MoTa AS Thang, 
        cong.MoTa AS MoTa, 
        cong.HeSo
    FROM 
        ctChamCong ct
    JOIN 
        ChamCong cong ON cong.MaCC = ct.MaCC
    JOIN 
        Thang thg ON thg.MaThang = ct.MaThang
    WHERE 
        ct.MaNV = @MaNV;
END;

GO
--- Xem danh sách chấm công của tất cả nhân viên --
CREATE OR ALTER PROCEDURE sp_GetAllctChamCong
AS
BEGIN
    SELECT 
		ct.MaNV,
        ct.NgayChamCong, 
        thg.MoTa AS Thang, 
        cong.MoTa AS MoTa, 
        cong.HeSo
    FROM 
        ctChamCong ct
    JOIN 
        ChamCong cong ON cong.MaCC = ct.MaCC
    JOIN 
        Thang thg ON thg.MaThang = ct.MaThang
END;

GO

CREATE OR ALTER PROCEDURE sp_GetctChamCong
    @MaNV VARCHAR(10),
	@MaThang VARCHAR(6)
AS
BEGIN
	IF (@MaThang IS NULL)
		BEGIN
			SELECT 
				ct.MaNV,
				ct.NgayChamCong, 
				thg.MoTa AS Thang, 
				cong.MoTa AS MoTa, 
				cong.HeSo
			FROM 
				ctChamCong ct
			JOIN 
				ChamCong cong ON cong.MaCC = ct.MaCC
			JOIN 
				Thang thg ON thg.MaThang = ct.MaThang
			WHERE 
				ct.MaNV = @MaNV
			ORDER BY thg.MaThang, ct.NgayChamCong DESC;
		END
	ELSE
	   	BEGIN
			SELECT 
				ct.MaNV,
				ct.NgayChamCong, 
				thg.MoTa AS Thang, 
				cong.MoTa AS MoTa, 
				cong.HeSo
			FROM 
				ctChamCong ct
			JOIN 
				ChamCong cong ON cong.MaCC = ct.MaCC
			JOIN 
				Thang thg ON thg.MaThang = ct.MaThang
			WHERE 
				ct.MaNV = @MaNV and ct.MaThang = @MaThang
			ORDER BY thg.MaThang, ct.NgayChamCong DESC;
		END
END;
GO
-- QUAN LY NGUOI PHU THUOC
CREATE OR ALTER PROCEDURE sp_AddNguoiPhuThuoc
    @MaNV NVARCHAR(10),
    @HoTen NVARCHAR(50),
    @NgaySinh DATE,
    @QuanHe NVARCHAR(50)
AS
BEGIN
    -- Thêm thông tin người phụ thuộc mới
    INSERT INTO NguoiPhuThuoc (MaNV, HoTen, NgaySinh, QuanHe)
    VALUES (@MaNV, @HoTen, @NgaySinh, @QuanHe);
END;
GO
CREATE OR ALTER PROCEDURE sp_DeleteNguoiPhuThuoc
    @MaNV NVARCHAR(10),
    @HoTen NVARCHAR(50)
AS
BEGIN
    DELETE FROM NguoiPhuThuoc
    WHERE MaNV = @MaNV AND HoTen = @HoTen;
END;
GO	
-- QUAN LY BAO HIEM --
CREATE OR ALTER PROCEDURE sp_GetctBaoHiemByMaNV
    @MaNV VARCHAR(10)
AS
BEGIN
    SELECT * FROM vw_QuanLyBaoHiem WHERE MaNV = @MaNV;
END;

GO

CREATE OR ALTER PROCEDURE sp_AddctBaoHiem
    @MaNV VARCHAR(10),
	@MaLoai VARCHAR(10),
	@MaBH VARCHAR(10),
	@NgayBD DATE,
	@NgayKT DATE
AS
BEGIN
    INSERT INTO ctBaoHiem (MaNV, MaBH, MaLoai, NgayBD, NgayKT) VALUES (@MaNV, @MaBH, @MaLoai, @NgayBD, @NgayKT);
END;

GO

CREATE OR ALTER PROCEDURE sp_UpdatectBaoHiem
	@LoaiBH VARCHAR(10),
	@MaBH VARCHAR(10),
	@NgayBD DATE,
	@NgayKT DATE
AS
BEGIN
    UPDATE ctBaoHiem SET MaLoai=@LoaiBH, NgayBD=@NgayBD, NgayKT=@NgayKT WHERE MaBH=@MaBH;
END;

GO

CREATE OR ALTER PROCEDURE sp_DeletectBaoHiem
    @MaBH VARCHAR(10)
AS
BEGIN
    DELETE FROM ctBaoHiem WHERE MaBH=@MaBH;
END;
GO

-- NHAN VIEN DANG KY NGHI PHEP -------------------
CREATE OR ALTER PROCEDURE sp_AddNghiPhep
    @MaNV VARCHAR(10),
    @MaThang VARCHAR(6),
    @NgayNghiPhep int,
	@GhiChu NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO NghiPhep (MaNV, MaThang, NgayNghiPhep, GhiChu) VALUES (@MaNV, @MaThang, @NgayNghiPhep, @GhiChu);
END;

GO

CREATE OR ALTER PROCEDURE sp_GetNghiPhepByMaNV
    @MaNV VARCHAR(10)
AS
BEGIN
    SELECT 
        NgayNghiPhep, 
        thg.MoTa AS Thang, 
        GhiChu
    FROM 
        NghiPhep np
    JOIN 
        Thang thg ON thg.MaThang = np.MaThang
    WHERE 
        MaNV = @MaNV;
END;

GO

------ THANG --------
CREATE OR ALTER PROCEDURE sp_GetThang
AS
SELECT MaThang, MoTa
FROM Thang
ORDER BY MaThang DESC;
GO
-------- TINH LUONG -------------
CREATE OR ALTER PROCEDURE sp_TinhLuongTheoThang 
    @MaThang VARCHAR(6),
    @MaNV VARCHAR(10) = NULL -- Thêm MaNV để chỉ tính lương cho nhân viên cụ thể
AS
BEGIN
    -- Bảng tạm chứa số ngày công
    DECLARE @ChamCongThang TABLE (
        MaNV VARCHAR(10),
        SoNgayCong FLOAT
    );
    INSERT INTO @ChamCongThang (MaNV, SoNgayCong)
    SELECT MaNV, SUM(HeSo)
    FROM ctChamCong ct 
    JOIN ChamCong cc ON ct.MaCC = cc.MaCC
    WHERE MaThang = @MaThang 
    AND (@MaNV IS NULL OR ct.MaNV = @MaNV) -- Lọc theo MaNV nếu có
    GROUP BY MaNV, MaThang;

    -- Bảng tạm chứa thông tin người phụ thuộc
    DECLARE @NguoiPhuThuoc TABLE (
        MaNV VARCHAR(10),
        SoNguoiPhuThuoc INT,
        GiamTruGiaCanh INT
    );
    INSERT INTO @NguoiPhuThuoc (MaNV, SoNguoiPhuThuoc, GiamTruGiaCanh)
    SELECT MaNV, COUNT(*), ISNULL(COUNT(*), 0) * 4400000
    FROM NguoiPhuThuoc
    WHERE (@MaNV IS NULL OR MaNV = @MaNV) -- Lọc theo MaNV nếu có
    GROUP BY MaNV;

    -- Bảng tạm chứa phụ cấp tháng
    DECLARE @PhuCapThang TABLE (
        MaNV VARCHAR(10),
        TongPhuCap INT DEFAULT 0
    );
    INSERT INTO @PhuCapThang (MaNV, TongPhuCap)
    SELECT MaNV, ISNULL(SUM(SoTien), 0)
    FROM ctPhuCap
    WHERE MaThang = @MaThang
    AND (@MaNV IS NULL OR MaNV = @MaNV) -- Lọc theo MaNV nếu có
    GROUP BY MaNV, MaThang;

    -- Bảng tạm chứa thưởng phạt tháng
    DECLARE @ThuongPhatThang TABLE (
        MaNV VARCHAR(10),
        TongThuongPhat INT DEFAULT 0
    );
    INSERT INTO @ThuongPhatThang (MaNV, TongThuongPhat)
    SELECT MaNV, ISNULL(SUM(SoTien), 0)
    FROM ctThuongPhat ctp
    JOIN ThuongPhat tp ON ctp.MaThuongPhat = tp.MaThuongPhat
    WHERE MaThang = @MaThang
    AND (@MaNV IS NULL OR ctp.MaNV = @MaNV) -- Lọc theo MaNV nếu có
    GROUP BY MaNV, MaThang;

    -- Bảng tạm chứa bảo hiểm
    DECLARE @BaoHiem TABLE (
        MaNV VARCHAR(10),
        BH01 FLOAT DEFAULT 0,
        BH02 FLOAT DEFAULT 0,
        BH03 FLOAT DEFAULT 0
    );
    INSERT INTO @BaoHiem (MaNV, BH01, BH02, BH03)
    SELECT bh.MaNV,
           SUM(CASE WHEN bh.MaLoai = 'BH01' THEN 0.015 * hd.LuongCoBan ELSE 0 END),
           SUM(CASE WHEN bh.MaLoai = 'BH02' THEN 0.01 * hd.LuongCoBan ELSE 0 END),
           SUM(CASE WHEN bh.MaLoai = 'BH03' THEN 0.08 * hd.LuongCoBan ELSE 0 END)
    FROM ctBaoHiem bh
    JOIN HopDong hd ON bh.MaNV = hd.MaNV
    WHERE (@MaNV IS NULL OR bh.MaNV = @MaNV) -- Lọc theo MaNV nếu có
    GROUP BY bh.MaNV;

    -- Số ngày công chuẩn
    DECLARE @SoNgayCongChuan INT;
    SELECT @SoNgayCongChuan = SoNgayCongChuan
    FROM Thang WHERE MaThang = @MaThang;

    -- Tính lương chịu thuế
    DECLARE @LuongChiuThue TABLE (
        MaNV VARCHAR(10),
        LuongCoBan INT,
        GiamTruGiaCanh INT,
        TongPhuCap INT,
        TongThuongPhat INT,
        BH01 INT, BH02 INT, BH03 INT,
        TongTienBaoHiem INT,
        SoNgayCong INT,
        LuongChiuThue INT
    );
    INSERT INTO @LuongChiuThue (MaNV, LuongCoBan, GiamTruGiaCanh, TongPhuCap, TongThuongPhat, BH01, BH02, BH03, TongTienBaoHiem, SoNgayCong, LuongChiuThue)
    SELECT 
        nv.MaNV, LuongCoBan, ISNULL(npt.GiamTruGiaCanh, 0), ISNULL(pc.TongPhuCap, 0), ISNULL(tp.TongThuongPhat, 0),
        BH01, BH02, BH03, ISNULL(bhct.BH01, 0) + ISNULL(bhct.BH02, 0) + ISNULL(bhct.BH03, 0), ISNULL(SoNgayCong, 0),
        ( ( (hd.LuongCoBan / @SoNgayCongChuan * ISNULL(cc.SoNgayCong, 0)) + ISNULL(pc.TongPhuCap, 0) + ISNULL(tp.TongThuongPhat, 0) )
    - (ISNULL(bhct.BH01, 0) + ISNULL(bhct.BH02, 0) + ISNULL(bhct.BH03, 0)) - ISNULL(npt.GiamTruGiaCanh, 0))
    FROM NhanVien nv
    JOIN HopDong hd ON nv.MaNV = hd.MaNV
    LEFT JOIN @ChamCongThang cc ON nv.MaNV = cc.MaNV
    LEFT JOIN @NguoiPhuThuoc npt ON nv.MaNV = npt.MaNV
    LEFT JOIN @PhuCapThang pc ON nv.MaNV = pc.MaNV
    LEFT JOIN @ThuongPhatThang tp ON nv.MaNV = tp.MaNV
    LEFT JOIN @BaoHiem bhct ON nv.MaNV = bhct.MaNV
    WHERE @MaNV IS NULL OR nv.MaNV = @MaNV; -- Lọc theo MaNV nếu có

    -- Tính thuế thu nhập cá nhân
    DECLARE @ThueThuNhapCaNhan TABLE (
        MaNV VARCHAR(10),
        Thue INT
    );
    INSERT INTO @ThueThuNhapCaNhan (MaNV, Thue)
    SELECT nv.MaNV,
        CASE
			WHEN LuongChiuThue <= 0 
				THEN 0
            WHEN LuongChiuThue <= 5000000
                THEN LuongChiuThue * 5 / 100
            WHEN LuongChiuThue <= 10000000
                THEN LuongChiuThue * 10 / 100
            WHEN LuongChiuThue <= 18000000
                THEN LuongChiuThue * 15 / 100
            WHEN LuongChiuThue <= 32000000
                THEN LuongChiuThue * 20 / 100
            WHEN LuongChiuThue <= 52000000
                THEN LuongChiuThue * 25 / 100
            WHEN LuongChiuThue <= 80000000
                THEN LuongChiuThue * 30 / 100
            ELSE LuongChiuThue * 35 / 100
        END AS ThueThuNhapCaNhan
    FROM NhanVien nv
    LEFT JOIN @LuongChiuThue lct ON nv.MaNV = lct.MaNV
    WHERE @MaNV IS NULL OR nv.MaNV = @MaNV; -- Lọc theo MaNV nếu có

    -- Kết quả lương của nhân viên
    SELECT nv.MaNV, Ho, Ten, LuongCoBan, BH01, BH02, BH03,
            (BH01 + BH02 + BH03) AS TongTienBaoHiem,
            @SoNgayCongChuan AS SoNgayCongChuan,
            TongPhuCap, GiamTruGiaCanh, LuongChiuThue, 
            SoNgayCong, Thue, TongThuongPhat, (LuongChiuThue - Thue) AS LuongThucLanh
    FROM NhanVien nv
    LEFT JOIN @LuongChiuThue lct ON nv.MaNV = lct.MaNV
    LEFT JOIN @ThueThuNhapCaNhan thue ON nv.MaNV = thue.MaNV
    WHERE @MaNV IS NULL OR nv.MaNV = @MaNV; -- Lọc theo MaNV nếu có
END;

GO

-----TINH LUONG TRA VE NHỈU BANG
CREATE OR ALTER PROCEDURE sp_TinhLuongTheoThangTraVeNhieuBang
    @MaThang VARCHAR(6),
    @MaNV VARCHAR(10) = NULL 
AS
BEGIN
    DECLARE @ChamCongThang TABLE (
        MaNV VARCHAR(10),
        SoNgayCong FLOAT
    );
    INSERT INTO @ChamCongThang (MaNV, SoNgayCong)
    SELECT MaNV, SUM(HeSo)
    FROM ctChamCong ct 
    JOIN ChamCong cc ON ct.MaCC = cc.MaCC
    WHERE MaThang = @MaThang 
    AND (@MaNV IS NULL OR ct.MaNV = @MaNV) 
    GROUP BY MaNV;

    DECLARE @NguoiPhuThuoc TABLE (
        MaNV VARCHAR(10),
        SoNguoiPhuThuoc INT,
        GiamTruGiaCanh INT
    );
    INSERT INTO @NguoiPhuThuoc (MaNV, SoNguoiPhuThuoc, GiamTruGiaCanh)
    SELECT MaNV, COUNT(*), COUNT(*) * 4400000
    FROM NguoiPhuThuoc
    WHERE (@MaNV IS NULL OR MaNV = @MaNV)
    GROUP BY MaNV;

    DECLARE @PhuCapThang TABLE (
        MaNV VARCHAR(10),
        TongPhuCap INT DEFAULT 0
    );
    INSERT INTO @PhuCapThang (MaNV, TongPhuCap)
    SELECT MaNV, ISNULL(SUM(SoTien), 0)
    FROM ctPhuCap
    WHERE MaThang = @MaThang
    AND (@MaNV IS NULL OR MaNV = @MaNV)
    GROUP BY MaNV;

    DECLARE @ThuongPhatThang TABLE (
        MaNV VARCHAR(10),
        TongThuongPhat INT DEFAULT 0
    );
    INSERT INTO @ThuongPhatThang (MaNV, TongThuongPhat)
    SELECT MaNV, ISNULL(SUM(SoTien), 0)
    FROM ctThuongPhat ctp
    JOIN ThuongPhat tp ON ctp.MaThuongPhat = tp.MaThuongPhat
    WHERE MaThang = @MaThang
    AND (@MaNV IS NULL OR ctp.MaNV = @MaNV)
    GROUP BY MaNV;

    DECLARE @BaoHiem TABLE (
        MaNV VARCHAR(10),
        BH01 FLOAT DEFAULT 0,
        BH02 FLOAT DEFAULT 0,
        BH03 FLOAT DEFAULT 0
    );
    INSERT INTO @BaoHiem (MaNV, BH01, BH02, BH03)
    SELECT bh.MaNV,
           SUM(CASE WHEN bh.MaLoai = 'BH01' THEN 0.015 * hd.LuongCoBan ELSE 0 END),
           SUM(CASE WHEN bh.MaLoai = 'BH02' THEN 0.01 * hd.LuongCoBan ELSE 0 END),
           SUM(CASE WHEN bh.MaLoai = 'BH03' THEN 0.08 * hd.LuongCoBan ELSE 0 END)
    FROM ctBaoHiem bh
    JOIN HopDong hd ON bh.MaNV = hd.MaNV
    WHERE (@MaNV IS NULL OR bh.MaNV = @MaNV)
    GROUP BY bh.MaNV;

    DECLARE @SoNgayCongChuan INT;
    SELECT @SoNgayCongChuan = SoNgayCongChuan
    FROM Thang WHERE MaThang = @MaThang;

    DECLARE @LuongChiuThue TABLE (
        MaNV VARCHAR(10),
        LuongCoBan INT,
        GiamTruGiaCanh INT,
        TongPhuCap INT,
        TongThuongPhat INT,
        BH01 INT, BH02 INT, BH03 INT,
        TongTienBaoHiem INT,
        SoNgayCong INT,
        LuongChiuThue INT
    );
    INSERT INTO @LuongChiuThue (MaNV, LuongCoBan, GiamTruGiaCanh, TongPhuCap, TongThuongPhat, BH01, BH02, BH03, TongTienBaoHiem, SoNgayCong, LuongChiuThue)
    SELECT 
        nv.MaNV, LuongCoBan, ISNULL(npt.GiamTruGiaCanh, 0), ISNULL(pc.TongPhuCap, 0), ISNULL(tp.TongThuongPhat, 0),
        BH01, BH02, BH03, ISNULL(bhct.BH01, 0) + ISNULL(bhct.BH02, 0) + ISNULL(bhct.BH03, 0), ISNULL(cc.SoNgayCong, 0),
        ( ( (hd.LuongCoBan / @SoNgayCongChuan * ISNULL(cc.SoNgayCong, 0)) + ISNULL(pc.TongPhuCap, 0) + ISNULL(tp.TongThuongPhat, 0) )
    - (ISNULL(bhct.BH01, 0) + ISNULL(bhct.BH02, 0) + ISNULL(bhct.BH03, 0)) - ISNULL(npt.GiamTruGiaCanh, 0))
    FROM NhanVien nv
    JOIN HopDong hd ON nv.MaNV = hd.MaNV
    LEFT JOIN @ChamCongThang cc ON nv.MaNV = cc.MaNV
    LEFT JOIN @NguoiPhuThuoc npt ON nv.MaNV = npt.MaNV
    LEFT JOIN @PhuCapThang pc ON nv.MaNV = pc.MaNV
    LEFT JOIN @ThuongPhatThang tp ON nv.MaNV = tp.MaNV
    LEFT JOIN @BaoHiem bhct ON nv.MaNV = bhct.MaNV
    WHERE @MaNV IS NULL OR nv.MaNV = @MaNV;

    DECLARE @ThueThuNhapCaNhan TABLE (
        MaNV VARCHAR(10),
        Thue INT
    );
    INSERT INTO @ThueThuNhapCaNhan (MaNV, Thue)
    SELECT nv.MaNV,
        CASE
			WHEN LuongChiuThue <= 0 
				THEN 0
            WHEN LuongChiuThue <= 5000000
                THEN LuongChiuThue * 5 / 100
            WHEN LuongChiuThue <= 10000000
                THEN LuongChiuThue * 10 / 100
            WHEN LuongChiuThue <= 18000000
                THEN LuongChiuThue * 15 / 100
            WHEN LuongChiuThue <= 32000000
                THEN LuongChiuThue * 20 / 100
            WHEN LuongChiuThue <= 52000000
                THEN LuongChiuThue * 25 / 100
            WHEN LuongChiuThue <= 80000000
                THEN LuongChiuThue * 30 / 100
            ELSE LuongChiuThue * 35 / 100
        END AS Thue
    FROM NhanVien nv
    LEFT JOIN @LuongChiuThue lct ON nv.MaNV = lct.MaNV
    WHERE @MaNV IS NULL OR nv.MaNV = @MaNV;

    SELECT nv.MaNV, Ho, Ten, LuongCoBan, BH01, BH02, BH03,
            (BH01 + BH02 + BH03) AS TongTienBaoHiem,
            @SoNgayCongChuan AS SoNgayCongChuan,
            TongPhuCap, GiamTruGiaCanh, LuongChiuThue, 
            SoNgayCong, Thue, TongThuongPhat, (LuongChiuThue - Thue) AS LuongThucLanh
    FROM NhanVien nv
    LEFT JOIN @LuongChiuThue lct ON nv.MaNV = lct.MaNV
    LEFT JOIN @ThueThuNhapCaNhan thue ON nv.MaNV = thue.MaNV
    WHERE @MaNV IS NULL OR nv.MaNV = @MaNV;

    SELECT * FROM @ChamCongThang; 
    SELECT * FROM @PhuCapThang; 
    SELECT * FROM @ThuongPhatThang; 
    SELECT * FROM @BaoHiem; 
END;
GO
-- EXEC sp_TinhLuongTheoThangTraVeNhieuBang @MaThang = '032023'
GO
-- TÍNH LƯƠNG CHI TIẾT TẤT CẢ NHÂN VIÊN--
CREATE OR ALTER PROCEDURE sp_TinhLuongChiTietTatCaNhanVien
AS
BEGIN
    -- Bảng phụ tính toán chấm công
    DECLARE @ChamCong TABLE (
        MaNV VARCHAR(10),
        MaThang VARCHAR(6),
        SoNgayLamViec INT
    );

    INSERT INTO @ChamCong (MaNV, MaThang, SoNgayLamViec)
    SELECT MaNV, MaThang, COUNT(*) AS SoNgayLamViec
    FROM ctChamCong
    WHERE MaCC = 'CC01'
    GROUP BY MaNV, MaThang;

    -- Bảng phụ người phụ thuộc
    DECLARE @NguoiPhuThuoc TABLE (
        MaNV VARCHAR(10),
        SoNguoiPhuThuoc INT
    );

    INSERT INTO @NguoiPhuThuoc (MaNV, SoNguoiPhuThuoc)
    SELECT MaNV, COUNT(*) AS SoNguoiPhuThuoc
    FROM NguoiPhuThuoc
    GROUP BY MaNV;

    -- Bảng phụ phụ cấp
    DECLARE @PhuCap TABLE (
        MaNV VARCHAR(10),
        MaThang VARCHAR(6),
        TongPhuCap INT
    );

    INSERT INTO @PhuCap (MaNV, MaThang, TongPhuCap)
    SELECT MaNV, MaThang, ISNULL(SUM(SoTien), 0)
    FROM ctPhuCap
    GROUP BY MaNV, MaThang;

    -- Bảng phụ thưởng phạt
    DECLARE @ThuongPhat TABLE (
        MaNV VARCHAR(10),
        MaThang VARCHAR(6),
        TongThuongPhat INT
    );

    INSERT INTO @ThuongPhat (MaNV, MaThang, TongThuongPhat)
    SELECT MaNV, MaThang, ISNULL(SUM(tp.SoTien), 0)
    FROM ctThuongPhat ctp 
    JOIN ThuongPhat tp ON ctp.MaThuongPhat = tp.MaThuongPhat
    GROUP BY MaNV, MaThang;

    -- Bảng phụ bảo hiểm
    DECLARE @BaoHiem TABLE (
        MaNV VARCHAR(10),
        BH01 FLOAT,
        BH02 FLOAT,
        BH03 FLOAT
    );

    INSERT INTO @BaoHiem (MaNV, BH01, BH02, BH03)
    SELECT bh.MaNV, 
           SUM(CASE WHEN bh.MaLoai = 'BH01' THEN 0.015 * hd.LuongCoBan ELSE 0 END), 
           SUM(CASE WHEN bh.MaLoai = 'BH02' THEN 0.01 * hd.LuongCoBan ELSE 0 END), 
           SUM(CASE WHEN bh.MaLoai = 'BH03' THEN 0.08 * hd.LuongCoBan ELSE 0 END)
    FROM ctBaoHiem bh
    JOIN HopDong hd ON bh.MaNV = hd.MaNV
    GROUP BY bh.MaNV;

    -- Bảng phụ lương chịu thuế
    DECLARE @LuongChiuThue TABLE (
        MaNV VARCHAR(10),
        MaThang VARCHAR(6),
        LuongCoBan INT,
        TongPhuCap INT,
        TongThuongPhat INT,
        TongTienBaoHiem INT,
        SoNgayLamViec INT,
        GiamTruGiaCanh INT,
        ThuNhapChiuThue INT
    );

    INSERT INTO @LuongChiuThue (MaNV, MaThang, LuongCoBan, TongPhuCap, TongThuongPhat, TongTienBaoHiem, SoNgayLamViec, GiamTruGiaCanh, ThuNhapChiuThue)
    SELECT  
        nv.MaNV, th.MaThang, hd.LuongCoBan, 
        ISNULL(pc.TongPhuCap, 0), ISNULL(tp.TongThuongPhat, 0),
        ISNULL(bhct.BH01, 0) + ISNULL(bhct.BH02, 0) + ISNULL(bhct.BH03, 0) AS TongTienBaoHiem,
        ISNULL(cc.SoNgayLamViec, 0),
        ISNULL(npt.SoNguoiPhuThuoc, 0) * 4400000 AS GiamTruGiaCanh,
        ( ( (hd.LuongCoBan / th.SoNgayCongChuan * ISNULL(cc.SoNgayLamViec, 0)) 
          + ISNULL(pc.TongPhuCap, 0) + ISNULL(tp.TongThuongPhat, 0))
          - (ISNULL(bhct.BH01, 0) + ISNULL(bhct.BH02, 0) + ISNULL(bhct.BH03, 0))
- ISNULL(npt.SoNguoiPhuThuoc, 0) * 4400000
        ) AS ThuNhapChiuThue
    FROM NhanVien nv
    JOIN HopDong hd ON nv.MaNV = hd.MaNV 
    JOIN Thang th ON 1 = 1 
    LEFT JOIN @ChamCong cc ON nv.MaNV = cc.MaNV AND cc.MaThang = th.MaThang
    LEFT JOIN @NguoiPhuThuoc npt ON nv.MaNV = npt.MaNV
    LEFT JOIN @PhuCap pc ON nv.MaNV = pc.MaNV AND pc.MaThang = th.MaThang
    LEFT JOIN @ThuongPhat tp ON nv.MaNV = tp.MaNV AND tp.MaThang = th.MaThang
    LEFT JOIN @BaoHiem bhct ON nv.MaNV = bhct.MaNV;

    -- Bảng phụ tính lương thực lãnh
    DECLARE @LuongThucLanh TABLE (
        MaNV VARCHAR(10),
        MaThang VARCHAR(6),
        LuongThucTe INT,
        ThueThuNhapCaNhan INT,
        LuongThucLanh INT
    );

    INSERT INTO @LuongThucLanh (MaNV, MaThang, LuongThucTe, ThueThuNhapCaNhan, LuongThucLanh)
    SELECT 
        lct.MaNV, lct.MaThang,
        ( (lct.LuongCoBan / th.SoNgayCongChuan * lct.SoNgayLamViec) 
          + lct.TongPhuCap + lct.TongThuongPhat
        ) AS LuongThucTe,
        CASE 
            WHEN lct.ThuNhapChiuThue <= 5000000 THEN lct.ThuNhapChiuThue * 5 / 100
            WHEN lct.ThuNhapChiuThue <= 10000000 THEN lct.ThuNhapChiuThue * 10 / 100
            WHEN lct.ThuNhapChiuThue <= 18000000 THEN lct.ThuNhapChiuThue * 15 / 100
            WHEN lct.ThuNhapChiuThue <= 32000000 THEN lct.ThuNhapChiuThue * 20 / 100
            WHEN lct.ThuNhapChiuThue <= 52000000 THEN lct.ThuNhapChiuThue * 25 / 100
            WHEN lct.ThuNhapChiuThue <= 80000000 THEN lct.ThuNhapChiuThue * 30 / 100
            ELSE lct.ThuNhapChiuThue * 35 / 100
        END AS ThueThuNhapCaNhan,
        ( lct.ThuNhapChiuThue - CASE 
            WHEN lct.ThuNhapChiuThue <= 5000000 THEN lct.ThuNhapChiuThue * 5 / 100
            WHEN lct.ThuNhapChiuThue <= 10000000 THEN lct.ThuNhapChiuThue * 10 / 100
            WHEN lct.ThuNhapChiuThue <= 18000000 THEN lct.ThuNhapChiuThue * 15 / 100
            WHEN lct.ThuNhapChiuThue <= 32000000 THEN lct.ThuNhapChiuThue * 20 / 100
            WHEN lct.ThuNhapChiuThue <= 52000000 THEN lct.ThuNhapChiuThue * 25 / 100
            WHEN lct.ThuNhapChiuThue <= 80000000 THEN lct.ThuNhapChiuThue * 30 / 100
            ELSE lct.ThuNhapChiuThue * 35 / 100
          END
        ) AS LuongThucLanh
    FROM @LuongChiuThue lct
    JOIN Thang th ON lct.MaThang = th.MaThang;

    -- Trả về các bảng phụ
    SELECT * FROM @LuongChiuThue;
    SELECT * FROM @LuongThucLanh;
	SELECT * FROM @ChamCong; 
    SELECT * FROM @PhuCap; 
    SELECT * FROM @ThuongPhat; 
    SELECT * FROM @BaoHiem; 
END;

GO
--
CREATE OR ALTER FUNCTION ft_TinhThamNien (@NgayBD DATE)
RETURNS INT
AS
BEGIN
    DECLARE @ThamNien INT;
    SET @ThamNien = DATEDIFF(YEAR, @NgayBD, GETDATE());
    RETURN @ThamNien;
END;
GO
--
CREATE OR ALTER FUNCTION dbo.ft_SoNgayCongChuan (@MaThang VARCHAR(6))
RETURNS INT
AS
BEGIN
    DECLARE @SoNgayLamViec INT = 0;
    DECLARE @NgayBatDau DATE;
    DECLARE @NgayKetThuc DATE;
    DECLARE @NgayHienTai DATE;
    DECLARE @Thang INT;
    DECLARE @Nam INT;

    -- Lấy tháng và năm từ MaThang
    SET @Thang = CAST(SUBSTRING(@MaThang, 1, 2) AS INT);
    SET @Nam = CAST(SUBSTRING(@MaThang, 3, 4) AS INT);

    -- Xác định ngày bắt đầu và ngày kết thúc của tháng
    SET @NgayBatDau = DATEFROMPARTS(@Nam, @Thang, 1);
    SET @NgayKetThuc = EOMONTH(@NgayBatDau);

    -- Duyệt qua từng ngày trong tháng
    SET @NgayHienTai = @NgayBatDau;
    WHILE @NgayHienTai <= @NgayKetThuc
    BEGIN
        -- Nếu là thứ Hai đến thứ Sáu tăng biến đếm số ngày làm việc
        IF DATEPART(WEEKDAY, @NgayHienTai) BETWEEN 2 AND 6
        BEGIN
            SET @SoNgayLamViec = @SoNgayLamViec + 1;
        END
        -- Chuyển sang ngày tiếp theo
        SET @NgayHienTai = DATEADD(DAY, 1, @NgayHienTai);
    END

    RETURN @SoNgayLamViec;
END;
GO

-- Phan Quyen --

CREATE ROLE Employee
GO
GRANT SELECT, REFERENCES ON NhanVien TO Employee
GRANT SELECT, REFERENCES ON ctChamCong TO Employee
GRANT SELECT, REFERENCES ON ctBaoHiem TO Employee
GRANT SELECT, INSERT, REFERENCES ON NghiPhep TO Employee
GRANT SELECT, UPDATE, REFERENCES ON TaiKhoan TO Employee
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON ThongBao TO Employee

GRANT SELECT ON  vw_ThongTinNhanVien to Employee
GRANT SELECT ON  vw_ThongTinHopDong to Employee

Deny select on ft_TruongPhongNhanThongBao to Employee;
GRANT select on ft_NhanVienNhanThongBao to Employee;
GRANT EXECUTE ON sp_GetNghiPhepByMaNV to Employee;
GRANT EXECUTE ON sp_GetChamCongByMaNV to Employee;
GRANT EXECUTE ON sp_AddctChamCong to Employee; 
GRANT EXECUTE ON sp_TinhLuongTheoThang to Employee;
GRANT EXECUTE ON sp_GetThang to Employee;

CREATE ROLE DepartmentHead
GO
GRANT SELECT, REFERENCES ON NhanVien TO DepartmentHead
GRANT SELECT, REFERENCES ON ctChamCong TO DepartmentHead
GRANT SELECT, REFERENCES ON ctBaoHiem TO DepartmentHead
GRANT SELECT, INSERT, REFERENCES ON NghiPhep TO DepartmentHead
GRANT SELECT, UPDATE, REFERENCES ON TaiKhoan TO DepartmentHead
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON ThongBao TO DepartmentHead

GRANT SELECT ON  vw_ThongTinNhanVien to DepartmentHead
GRANT SELECT ON  vw_ThongTinHopDong to DepartmentHead

GRANT SELECT ON ft_TruongPhongNhanThongBao to DepartmentHead;
GRANT SELECT ON ft_NhanVienNhanThongBao TO DepartmentHead;
GRANT EXECUTE ON sp_GetNghiPhepByMaNV to DepartmentHead;
GRANT EXECUTE ON sp_GetChamCongByMaNV to DepartmentHead;
GRANT EXECUTE ON sp_AddctChamCong to DepartmentHead; 
GRANT EXECUTE ON sp_TinhLuongTheoThang to DepartmentHead;
GRANT EXECUTE ON sp_GetThang to DepartmentHead;
GO
-- Quan ly
CREATE LOGIN  NV01 WITH PASSWORD = 'password1', DEFAULT_DATABASE = [QLNSG21], CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF;
CREATE USER  NV01  FOR LOGIN  NV01;
ALTER SERVER ROLE sysadmin ADD MEMBER NV01
GO
-- Truong Phong
CREATE LOGIN  NV02 WITH PASSWORD = 'password2', DEFAULT_DATABASE = [QLNSG21], CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF;
CREATE USER  NV02  FOR LOGIN  NV02;
ALTER ROLE DepartmentHead ADD MEMBER NV02
GO
-- NhanVien
CREATE LOGIN  NV03 WITH PASSWORD = 'password3', DEFAULT_DATABASE = [QLNSG21], CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF;
CREATE USER  NV03  FOR LOGIN  NV03;
ALTER ROLE Employee ADD MEMBER NV03


-- 
CREATE OR ALTER PROCEDURE [dbo].[sp_UpdateTaiKhoan]
    @TenDangNhap NVARCHAR(10),
    @MatKhau NVARCHAR(255),
    @NhapLaiMatKhau NVARCHAR(255) 
AS
BEGIN
    -- Kiểm tra nếu @MatKhau hoặc @NhapLaiMatKhau bị trống
    IF @MatKhau IS NULL OR @MatKhau = '' OR @NhapLaiMatKhau IS NULL OR @NhapLaiMatKhau = ''
    BEGIN
        RAISERROR('Dữ liệu không được bỏ trống', 16, 1)
        RETURN;
    END

    -- Kiểm tra nếu @MatKhau và @NhapLaiMatKhau không khớp
    IF @MatKhau <> @NhapLaiMatKhau
    BEGIN
        RAISERROR('Mật khẩu và Nhập lại mật khẩu không khớp', 16, 1)
        RETURN;
    END

    -- Cập nhật thông tin trong bảng TaiKhoan nếu dữ liệu hợp lệ
    UPDATE TaiKhoan
    SET 
        MatKhau = @MatKhau
    WHERE TenDangNhap = @TenDangNhap;

    PRINT 'Cập nhật mật khẩu thành công';
END;
*/