use
[UniversitySql]

create table Student
(
    Id        int identity(1,1) constraint PK_Student primary key,
    FirstName nvarchar(100),
    LastName  nvarchar(100)
)

create table StudentGroup
(
    Id   int identity(1,1) constraint PK_Group primary key,
    Name nvarchar(100)
)

create table StudentInGroup
(
    Id        int identity(1,1) constraint PK_StudentsInGroup primary key,
    StudentId int
        constraint FK_StudentInGroup_Student references Student (id),
    GroupId   int
        constraint FR_StudentInGroup_StudentGroup references StudentGroup (id)
) insert into Student values
('Efim','Kotov'), ('Ivan', 'Ivanov'), ('Efim','Kotov'), ('Ivan', 'Ivanov')

insert into StudentGroup values
('English'), ('Programming'), ('Math')

insert into StudentInGroup values
(1,1),(1,3),(2,1),(2,1),(3,3),(4,2)