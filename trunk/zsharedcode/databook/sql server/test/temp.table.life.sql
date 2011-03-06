--1
execute dbo.CreateTempStudentTable

select  [Name],
        [Age]
from    #Student
go

--2
execute dbo.CreateGlobalTempStudentTable

select  [Name],
        [Age]
from    ##Student
go
