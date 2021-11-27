create database CanHo;
use CanHo;

-- tao bang --
create table NhanVien 
(
	MaNV varchar(5) primary key,
    TenNV varchar(50) not null,
    SoDT varchar(10),
    GioiTinh varchar(5)
);

create table CanHo
(
	MaCH varchar(5) primary key,
    TenCH varchar(50) not null
);

create table ThietBi
(
	MaTB varchar(5) primary key,
    TenTB varchar(50) not null
);

create table NV_BT
(
	MaNV varchar(5) not null,
    MaTB varchar(5) not null,
    MaCH varchar(5) not null,
    LanThu int not null,
    NgBT datetime
);

-- KHoa chinh

alter table NV_BT
add constraint PK_NV_BT primary key(MaNV, MaTB, MaCH, LanThu);

-- Khoa Ngoai
alter table NV_BT 
add constraint FK_NV_BT1 foreign key(MaNV) references NhanVien(MaNV);

alter table NV_BT 
add constraint FK_NV_BT2 foreign key(MaTB) references ThietBi(MaTB);

alter table NV_BT 
add constraint FK_NV_BT3 foreign key(MaCH) references CanHo(MaCH);

select nv.manv, tennv, sum(a.lanthu) as solan
from nhanvien nv,  (select manv, matb, mach, max(lanthu) as lanthu from nv_bt group by manv, matb, mach) a
where nv.manv=a.manv
group by nv.manv, tennv
having sum(a.lanthu)>=100;

-- insert du lieu
insert into nhanvien values 
("nv01", "Nguyen Thi Ai Linh", "0398667273", "nu"),
("nv02", "Nguyen Thi Minh", "0398667263", "nu"),
("nv03", "Nguyen Dang Nam", "0398667245", "nam"),
("nv04", "Pham Dang Khoa", "0398667254", "nam");

insert into CanHo values
("1", "VinHome"),
("2", "HomeTown"),
("3", "Go"),
("4", "Hotel"),
("5", "Vinhome1");

insert into ThietBi values
("1", "Dieu hoa"),
("2", "Tu lanh"),
("3", "Voi sen"),
("4", "May tinh"),
("5", "May in"),
("6", "Ti vi");

insert into NV_BT values 
("nv01", "1", "1", 1, "2021-11-26"),
("nv01", "2", "2", 100, "2021-11-26"),
("nv02", "3", "1", 1, "2021-11-26"),
("nv03", "4", "1", 100, "2021-11-26"),
("nv03", "4", "1", 1,"2021-11-26"),
("nv04", "5", "1", 1, "2021-11-26");
insert into NV_BT values 
("nv01", "1", "1", 101, "2021-11-26");
