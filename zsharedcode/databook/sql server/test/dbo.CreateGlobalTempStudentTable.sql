CREATE PROCEDURE [dbo].[CreateGlobalTempStudentTable]
AS
BEGIN
create table ##Student
    (
      [Name] nvarchar(50),
      [Age] int
    )
insert  into ##Student ( [Name], [Age] )
values  ( N'С��', 10 )

insert  into ##Student ( [Name], [Age] )
values  ( N'С��', 11 )

select * from ##Student

END

GO


