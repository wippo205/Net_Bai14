create database bai14

use bai14

CREATE TABLE COSO
(
    macoso NVARCHAR(20) PRIMARY KEY,
    tencoso NVARCHAR(50) 
);

CREATE TABLE DONVI
(
    madonvi NVARCHAR(20) PRIMARY KEY,
    tendonvi NVARCHAR(50),
    macoso NVARCHAR(20),
    FOREIGN KEY (macoso) REFERENCES COSO(macoso)
);

CREATE TABLE GV
(
    magv NVARCHAR(20) PRIMARY KEY,
    hoten NVARCHAR(100),
    sdt INT,
    ghichu NVARCHAR(100),
    madonvi NVARCHAR(20),
    FOREIGN KEY (madonvi) REFERENCES DONVI(madonvi)
);


INSERT INTO COSO (macoso, tencoso) VALUES
('CS003', 'Co so 3'),
('CS004', 'Co so 4');

-- Thêm dữ liệu vào bảng DONVI
INSERT INTO DONVI (madonvi, tendonvi, macoso) VALUES
('DV005', 'Đơn vị 1', 'CS003'),
('DV006', 'Đơn vị 2', 'CS003'),
('DV007', 'Đơn vị 3', 'CS004'),
('DV008', 'Đơn vị 4', 'CS004');

-- Thêm dữ liệu vào bảng GV
INSERT INTO GV (magv, hoten, sdt, ghichu, madonvi) VALUES
('GV001', 'Giáo viên 1', 123456789, 'Ghi chú GV1', 'DV001'),
('GV002', 'Giáo viên 2', 987654321, 'Ghi chú GV2', 'DV001'),
('GV003', 'Giáo viên 3', 111222333, 'Ghi chú GV3', 'DV002'),
('GV004', 'Giáo viên 4', 444555666, 'Ghi chú GV4', 'DV002'),
('GV005', 'Giáo viên 5', 777888999, 'Ghi chú GV5', 'DV003'),
('GV006', 'Giáo viên 6', 666555444, 'Ghi chú GV6', 'DV003'),
('GV007', 'Giáo viên 7', 333222111, 'Ghi chú GV7', 'DV004'),
('GV008', 'Giáo viên 8', 999888777, 'Ghi chú GV8', 'DV004');

