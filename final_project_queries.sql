
/*create database final_project;

use final_project;

create table Departments(
	DepId int identity(1,1) primary key,
	Dep_name varchar(30) not null,
	Descrption varchar(255),
	);

create table Employees(
	EId int identity(1000,1) primary key,
	f_name varchar(20) not null,
	l_name varchar(20) not null,
	dob date not null,
	email varchar(30),
	p_number varchar(10),
	DepId int not null foreign key references Departments(DepId)
	);



create table RLs(
	RLId int identity primary key,
	RLType varchar(30) not null,
	C_date date not null,
	DepId int not null foreign key references Departments(DepId),
	details varchar(255)
	);

create table Compliance(
RLid int not null,
Eid int not null,
Comment varchar(255) not null,
C_date date not null
);
*/
use final_project;

go
/*
create procedure GetAllEmployee
as
begin
select * from Employees 
end
go

create procedure AddEmployee @fname varchar(20), @lname varchar(20), @dob date, @email varchar(30), @p_number varchar(10), @DepId int
as
insert into Employees(f_name,l_name,dob,email,p_number,DepId)
values(@fname,@lname,@dob,@email,@p_number,@DepId)
go

create procedure EditEmployee @EId int,@fname varchar(20),@lname varchar(20),@dob date,@email varchar(30),@p_number varchar(10),@DepId int
as
update Employees
set f_name=@fname,l_name=@lname,dob=@dob,email=@email,p_number=@p_number,DepId=@DepId
where EId=@EId
go

create procedure DeleteEmployee @EId int
as 
delete from Employees
where EId=@EId
go


create procedure GetAllDepartments
as
select* from Departments
go

create procedure AddDepartment @Dep_name varchar(30),@Description varchar(255)
as 
insert into Departments(Dep_name,Descrption)
values(@Dep_name,@Description)
go

create procedure EditDepartment @DepId int, @Dep_name varchar(30),@Description varchar(255)
as
update Departments
set Dep_name=@Dep_name,Descrption=@Description
where DepId=@DepId
go

create procedure DeleteDepartment @DepId int
as
delete from Departments 
where DepId=@DepId
go




drop procedure GetAllRLs;
go
create procedure GetAllRLs 
as
select * from RLs
go


create procedure AddRL @RLType varchar(30),@details varchar(255),@DepId int,@C_date date
as 
insert into RLs(RLType,C_date,DepId,details)
values(@RLType,@C_date,@DepId,@details)
go

create table Comments(
 EId int ,
 RLId int,
 comment varchar(255),
 C_date date
 );
 
 go

 create procedure GetAllComments @EId int, @RLId int
 as 
 select * from Comments
 where EId=@EId and RLId=@RLId
 go

 
 create procedure GetMyRLs @EId int
 as
 select * from RLs
 where DepId in ( select DepId from Employees where EId=@Eid)
 go
 

 create procedure AddComment @EId int, @RLId int, @comment varchar(255),@C_date date
 as
 insert into Comments(EId,RLId,comment,C_date)
 values(@EId,@RLId,@comment,@C_date)
 go
  
 AddComment @EId=1002,@RLId=2,@comment="new ", @C_date="2018-08-08";
 */
/*exec GetMyRLs @EId=1002;
exec GetAllComments @EId=1002,@RLId=1; 
exec GetAllDepartments
exec GetAllRLs
drop procedure AddEmployee;
go


alter table Employees
drop column password;

alter table Employees 
add _password varchar(30);
select * from Comments;
exec GetAllComments @EId=1002,@RLId=1;
go

drop table Employees;
go

create table Employees(
	EId int identity(1000,1) primary key,
	f_name varchar(20) not null,
	l_name varchar(20) not null,
	dob date not null,
	email varchar(30),
	p_number varchar(10),
	DepId int not null foreign key references Departments(DepId),
	password_ varchar(30) not null
	);
select * from Employees;
go
*/
use final_project;

go

/*
create procedure AddEmployee @fname varchar(20), @lname varchar(20), @dob date, @email varchar(30), @p_number varchar(10), @DepId int, @_password varchar(30)
as
insert into Employees(f_name,l_name,dob,email,p_number,DepId,password_)
values(@fname,@lname,@dob,@email,@p_number,@DepId,@_password)
go


exec AddEmployee @fname="Nikhil",@lname="kumar",@dob="2018-08-08",@email="a",@p_number="678",@DepId=1,@_password="12345";

select * from Departments;
go
create procedure Validate @Eid int,@password varchar(30)
as 
select count(EId)
from Employees
where EId=@Eid and password_=@password

exec Validate @Eid=1001, @password="12345";
*/
select * from Employees;

