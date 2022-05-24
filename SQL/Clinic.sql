create database
Clinic
use Clinic 
go

Create table User_Setup
(
UserName varchar(20),
Passcode varchar(20),
FirstName varchar(10),
LastName varchar(10)
)
create proc Userpro
@User varchar(20),
@pass varchar(20)
as
select * from User_Setup where UserName like @User and Passcode like @pass


insert User_Setup values('GLORIYA21','gloriya@stone','Gloriya','G')
insert User_Setup values('YOGA22','yoga@stone','yogalakshmi','S')
select * from Add_Patient


----------------------------------------------------------------------------------------------------------------------------------------------------------------
create table Add_Doctor
(
DoctorID int identity(1,1),
FirstName varchar(20),
LastName varchar(20),
Sex varchar(10)  ,
Specialisation varchar(30)  ,
VisitingHours varchar(20)
constraint pk_doc primary key(DoctorID)
)

create proc Docpro
@docfn varchar(20),
@docln varchar(20),
@docsex varchar(10),
@docspl varchar(20),
@doctime varchar(20)
as
insert into Add_Doctor(FirstName,LastName,Sex,Specialisation,VisitingHours)
values(@docfn,@docln,@docsex,@docspl,@doctime)

select * from Add_Doctor
-------------------------------------------------------------------------------------------------------------------------------------------------------------
create table Add_Patient   
(
PatientID int identity(1,1),
FirstName varchar(20),
LastName varchar(10),
Sex varchar(10)  ,
Age int,
DateOfBirth varchar(20),
constraint ck_Age Check( Age<120),
constraint pk_pat primary key(PatientID)
)
add constraint ck_Age Check( Age<=120)

select * from Add_Patient

create proc Patpro
@patfn varchar(20),
@patln varchar(20),
@patsex varchar(20),
@patage int, 
@patdob varchar(20)
as
insert into Add_Patient(FirstName,LastName,Sex,Age,DateOfBirth)
values(@patfn,@patln,@patsex,@patage,@patdob)


select * from Add_Patient
------------------------------------------------------------------------------------------------------------------------------------------

create table Schedule_Appointment
(
Patient_ID int ,
Specialisation_Required varchar(20)  ,
Doctor varchar(20),
AppointmentDate varchar(20),
AppointmentTime varchar(20)
constraint fk_PatID foreign key (Patient_ID) references Add_Patient(PatientID)
)
   drop table Schedule_Appointment     
--insert into Schedule_Appointment value(1,'General','swetha',
create proc Schedulepro       
@patid int,
@spl varchar(20),
@doc varchar(20),
@appdate varchar(20),
@apptime varchar(20)
as
insert into Schedule_Appointment(Patient_ID,Specialisation_Required,Doctor,AppointmentDate,AppointmentTime)
values(@patid,@spl,@doc,@appdate,@apptime)
drop proc Schedulepro

select * from Schedule_Appointment
-------------------------------------------------------------------------------------------------------------------------------------------------
create table Cancel_Appointment
(
Pat_ID int
constraint fk_Patient foreign key (Pat_ID) references Add_Patient(PatientID)
)

create proc cancelpro
@pat int
as
delete from Schedule_Appointment where Patient_ID=@pat

select * from Schedule_Appointment












