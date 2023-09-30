use master
go
CREATE DATABASE QL_ThietBi
GO
USE QL_ThietBi
GO
--drop database QL_ThietBi
--go

CREATE TABLE LOAIHANG
(
	MALH int NOT NULL,
	TENLH NVARCHAR(100),
	CONSTRAINT PK_LOAIHANG PRIMARY KEY (MALH)
)
INSERT INTO LOAIHANG
VALUES
(1,N'Thiết bị văn phòng'),
(2,N'Thiết bị chuyên dùng'),
(3,N'Thiết bị gia dụng'),
(4,N'Thiết bị y tế')

CREATE TABLE LOAISP
(
	MALSP int NOT NULL,
	TENLSP NVARCHAR(100),
	MALH int,
	constraint PK_LSP primary key(MALSP),
	CONSTRAINT FK_LSP_LOAIHANG FOREIGN KEY (MALH) REFERENCES LOAIHANG(MALH)
)
INSERT INTO LOAISP
VALUES
(1,N'Máy vi tính',1),
(2,N'Máy photocopy',1),
(3,N'Điện thoại',2),
(4,N'Tủ lạnh',3),
(5,N'Quạt',3),
(6,N'Lò vi sóng',3),
(7,N'Máy lạnh',2),
(8,N'Máy chiếu',3),
(9,N'Máy x-quang',4),
(10,N'Máy in',1),
(11,N'Tivi',2)

CREATE TABLE NHAXUATXU
(
	MANXX INT NOT NULL,
	TENNXX NVARCHAR(100),
	DIENTHOAI NVARCHAR(50),
	CONSTRAINT PK_NXX PRIMARY KEY(MANXX)
)
INSERT INTO NHAXUATXU
VALUES
(1,N'Việt Nam','0909000001'),
(2,N'Mỹ','0909000002'),
(3,N'Nhật Bản','0909000003')


CREATE TABLE SANPHAM
(
	MASP int NOT NULL,
	TENSP NVARCHAR (max),
	MOTA NVARCHAR (max),
	HINHSANPHAM VARCHAR(30),
	GIABAN decimal (18, 0),
	SOLUONG int,
	MALSP INT,
	MANXX INT,
	CONSTRAINT PK_SP PRIMARY KEY(MASP),
	CONSTRAINT FK_SP_LSP FOREIGN KEY(MALSP) REFERENCES LOAISP(MALSP),
	CONSTRAINT FK_SP_NXX FOREIGN KEY (MANXX) REFERENCES NHAXUATXU(MANXX)
)
insert into SANPHAM
values
(1, N'Máy tính IMac 2021', N'Năng suất công việc được nâng cao tối đa.',N'Hinh1.jpg',CAST(18500000 AS Decimal(18, 0)),45,1, 1),
(2, N'Máy photocopy Canon', N'Năng suất công việc được nâng cao tối đa.',N'Hinh2.jpg',CAST(17500000 AS Decimal(18, 0)),60, 2, 3),
(3, N'Điện thoại Vivo Y23s', N'Năng suất cấu hình siêu mạnh dung lượng lưu trữ thoải mái pin sử dụng thả ga',N'Hinh3.jpg', CAST(5500000 AS Decimal(18, 0)),87, 2, 2),
(4, N'Tủ lạnh LG', N'Tiết kiệm hiệu năng tiêu thụ điện năng suất cao',N'Hinh4.jpg',CAST(16000000 AS Decimal(18, 0)),20, 4, 3),
(5, N'QUạt đứng cao cấp SunHouse', N'Năng suất cao tiết kiệm hiệu năng tiêu thụ điện .',N'Hinh5.jpg',CAST(620000 AS Decimal(18, 0)),46, 5, 1),
(6, N'Lò vi sóng Panasonic', N'Giúp nhưng món ăn có thể làm nóng nhanh hơn.',N'Hinh6.jpg',CAST(710000 AS Decimal(18, 0)),30, 6, 1),
(7, N'Máy lạnh Funiki', N'Năng suất cao tiết kiệm hiệu năng tiêu thụ điện.',N'Hinh7.jpg',CAST(18000000 AS Decimal(18, 0)),15, 7, 3),
(8, N'Máy chiếu Wanbo', N'Giúp tận hưởng những bộ phim hay nhất.',N'Hinh8.jpg',CAST(3700000 AS Decimal(18, 0)),27, 8, 2),
(9, N'Máy X-Quang', N'Giúp phát hiện nhiều loại bệnh với tỉ lệ chính xác cao.',N'Hinh9.jpg',CAST(670000000 AS Decimal(18, 0)),10, 9, 1),
(10, N'Máy in HP', N'Năng suất cao tiết kiệm hiệu năng tiêu thụ điện.',N'Hinh10.jpg',CAST(690000 AS Decimal(18, 0)),100, 10, 2),
(11, N'TiVi màn hình led Casper', N'Giúp tăng sự trải nghiệm của người dùng với những thước phim sống động.',N'Hinh11.jpg',CAST(6900000 AS Decimal(18, 0)),67, 11, 3),
(12, N'Máy tính IMac 2022', N'năng suất công việc được nâng cao tối đa.',N'Hinh12.jpg',CAST(1900000 AS Decimal(18, 0)),45, 1, 1),
(13, N'Máy tính Asus 2022', N'năng suất công việc được nâng cao tối đa.',N'Hinh13.jpg',CAST(2000000 AS Decimal(18, 0)),45, 1, 1),
(14, N'Máy photocopy Ricoh', N'năng suất công việc được nâng cao tối đa.',N'Hinh14.jpg',CAST(18000000 AS Decimal(18, 0)),60, 2, 3),
(15, N'Máy photocopy Toshiba', N'năng suất công việc được nâng cao tối đa.',N'Hinh15.jpg',CAST(15000000 AS Decimal(18, 0)),60, 2, 3),
(16, N'Điện thoại IPhone 14 ProMax', N'Năng suất cấu hình siêu mạnh dung lượng lưu trữ thoải mái pin sử dụng thả ga',N'Hinh16.jpg', CAST(35000000 AS Decimal(18, 0)),87, 3, 2),
(17, N'Điện thoại SamSung A23', N'Năng suất cấu hình siêu mạnh dung lượng lưu trữ thoải mái pin sử dụng thả ga',N'Hinh17.jpg', CAST(5000000 AS Decimal(18, 0)),87, 3, 2),
(18, N'Tủ lạnh Toshiba', N'Tiết kiệm hiệu năng tiêu thụ điện năng suất cao',N'Hinh18.jpg',CAST(20000000 AS Decimal(18, 0)),20, 4, 3),
(19, N'Tủ lạnh Funiki', N'Tiết kiệm hiệu năng tiêu thụ điện năng suất cao',N'Hinh19.jpg',CAST(26000000 AS Decimal(18, 0)),20, 4, 3),
(20, N'QUạt  Senko', N'Năng suất cao tiết kiệm hiệu năng tiêu thụ điện .',N'Hinh20.jpg',CAST(50000 AS Decimal(18, 0)),46, 5, 1),
(21, N'QUạt công nghiệp cao cấp', N'Năng suất cao tiết kiệm hiệu năng tiêu thụ điện .',N'Hinh21.jpg',CAST(1000000 AS Decimal(18, 0)),46, 5, 1),
(22, N'Lò vi sóng Sharp', N'Giúp nhưng món ăn có thể làm nóng nhanh hơn.',N'Hinh22.jpg',CAST(1000000 AS Decimal(18, 0)),30, 6, 1),
(23, N'Lò vi sóng LG', N'Giúp nhưng món ăn có thể làm nóng nhanh hơn.',N'Hinh23.jpg',CAST(900000 AS Decimal(18, 0)),30,  6, 1),
(24, N'Máy lạnh Toshiba', N'Năng suất cao tiết kiệm hiệu năng tiêu thụ điện.',N'Hinh24.jpg',CAST(20000000 AS Decimal(18, 0)),15, 7, 3),
(25, N'Máy lạnh Alaska', N'Năng suất cao tiết kiệm hiệu năng tiêu thụ điện.',N'Hinh25.jpg',CAST(30000000 AS Decimal(18, 0)),15, 7, 3),
(26, N'Máy chiếu BenQ', N'Giúp tận hưởng những bộ phim hay nhất.',N'Hinh26.jpg',CAST(3000000 AS Decimal(18, 0)),27, 8, 2),
(27, N'Máy chiếu Espon', N'Giúp tận hưởng những bộ phim hay nhất.',N'Hinh27.jpg',CAST(4000000 AS Decimal(18, 0)),27, 8, 2),
(28, N'Máy X-Quang thế hệ mới 2022', N'Giúp phát hiện nhiều loại bệnh với tỉ lệ chính xác cao.',N'Hinh8.jpg',CAST(800000000 AS Decimal(18, 0)),10, 9, 1),
(29, N'Máy in Canon', N'Năng suất cao tiết kiệm hiệu năng tiêu thụ điện.',N'Hinh29.jpg',CAST(500000 AS Decimal(18, 0)),100, 10, 2),
(30, N'Máy in Brother', N'Năng suất cao tiết kiệm hiệu năng tiêu thụ điện.',N'Hinh30.jpg',CAST(900000 AS Decimal(18, 0)),100, 10, 2),
(31, N'TiVi màn hình led SamSung', N'Giúp tăng sự trải nghiệm của người dùng với những thước phim sống động.',N'Hinh31.jpg',CAST(10000000 AS Decimal(18, 0)),67, 11, 3),
(32, N'TiVi màn hình led Akino', N'Giúp tăng sự trải nghiệm của người dùng với những thước phim sống động.',N'Hinh32.jpg',CAST(800000 AS Decimal(18, 0)),67, 11, 3)


CREATE TABLE LOAITAIKHOAN
(
	MALOAITK INT NOT NULL,
	TENLOAITK NVARCHAR(50),
	CONSTRAINT PK_LTK PRIMARY KEY(MALOAITK)
)
insert into LOAITAIKHOAN
values
(1, N'Admin'),
(2, N'Khách Hàng')

CREATE TABLE TAIKHOAN
(
	TENDANGNHAP NVARCHAR(50) not null,
	PASS NVARCHAR(100),
	MALOAITK INT,
	CONSTRAINT PK_TK PRIMARY KEY(TENDANGNHAP),
	CONSTRAINT FK_TK_LTK FOREIGN KEY(MALOAITK) REFERENCES LOAITAIKHOAN(MALOAITK)
)
insert into TAIKHOAN
values
(N'admin', N'123456', 1),
(N'0123456789', N'dd321', 2),
(N'0123456777', N'dd546', 2),
(N'0123456543', N'dd789', 2),
(N'0987654321', N'123123', 2)


CREATE TABLE KHACHHANG
(
	MAKH INT NOT NULL,
	TENKH NVARCHAR(100),
	NGSINH DATETIME,
	GENDER NVARCHAR(3),
	DIENTHOAI NVARCHAR(50),
	EMAIL NVARCHAR(100),
	DIACHI NVARCHAR(100),
	CONSTRAINT PK_KH PRIMARY KEY(MAKH),
	CONSTRAINT FK_KH_TK FOREIGN KEY(DIENTHOAI) REFERENCES TAIKHOAN(TENDANGNHAP)
)
INSERT INTO KHACHHANG
VALUES
(1, N'Phạm An', CAST(0x0000836100000000 AS DateTime), N'Nữ', N'0123456789', N'dsa321@gmail.com', N'Quận 2'),
(2, N'Nguyễn Bảo', CAST(0x000088C500000000 AS DateTime), N'Nam', N'0123456777', N'dsa546@gmail.com', N'Quận 9'),
(3, N'Trần Thị Bé', NULL, N'Nữ', N'0123456543', N'dsa789@gmail.com', N'Quận 1'),
(4, N'Đỗ Văn Nghiệp', CAST(0x0000834200000000 AS DateTime), N'Nam', N'0987654321', N'123@yahoo.com', N'Quận Tân Bình')


CREATE TABLE DONHANG
(
	MADH INT NOT NULL,
	NGAYDAT DATETIME,
	NGAYGIAO DATETIME,
	DATHANHTOAN NVARCHAR(50),
	TINHTRANGGIAOHANG NVARCHAR(50),
	MAKH INT,
	CONSTRAINT PK_DH PRIMARY KEY(MADH),
	CONSTRAINT FK_KHACHHANG_DONHANG FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH)
)
set dateformat dmy
INSERT INTO DONHANG
VALUES
(1, '19/12/2022', '21/12/2022', N'Đã thanh toán', N'Giao hàng thành công', 1),
(2, '20/12/2022', '25/12/2022', N'Chưa thanh toán', N'Đang giao hàng', 3),
(3, '22/12/2022', '30/12/2022', N'Chưa thanh toán', N'Đang giao hàng', 2)

CREATE TABLE CHITIETDONHANG
(
	MADH INT NOT NULL,
	MASP INT NOT NULL,
	SOLUONG INT,
	DONGIA decimal (18, 0),
	CONSTRAINT PK_CTDH PRIMARY KEY(MADH, MASP),
	CONSTRAINT FK_CTDH_DONHANG FOREIGN KEY (MADH) REFERENCES DONHANG(MADH),
	CONSTRAINT FK_CTDH_SP FOREIGN KEY (MASP) REFERENCES LOAISP(MALSP)
)
INSERT INTO CHITIETDONHANG
VALUES
(2, 1, 1, CAST(18500000 AS Decimal(18, 0))),
(1, 2, 2, CAST(17500000 AS Decimal(18, 0))),
(3, 3, 1, CAST(5500000 AS Decimal(18, 0)))

SELECT * from LOAIHANG
SELECT * from LOAISP
SELECT * from SANPHAM
SELECT * from NHAXUATXU
SELECT * from LOAITAIKHOAN
SELECT * from TAIKHOAN
SELECT * from KHACHHANG
SELECT * from DONHANG
SELECT * from CHITIETDONHANG
