--1
create table #Student
    (
      [Name] nvarchar(50),
      [Age] int
    )
go

execute dbo.UseTempStudentTable

insert  into #Student ( [Name], [Age] )
values  ( N'С��', 10 )
go

insert  into #Student ( [Name], [Age] )
values  ( N'С��', 11 )
go

select  [Name],
        [Age]
from    #Student
go

drop table #Student
go

--2
create table ##Student
    (
      [Name] nvarchar(50),
      [Age] int
    )
go

insert  into ##Student ( [Name], [Age] )
values  ( N'С��', 10 )
go

insert  into ##Student ( [Name], [Age] )
values  ( N'С��', 11 )
go

drop table ##Student
go

