1. Создать БД с именем MyCompanyDB​, имя сервера (localdb)\MSSQLLocalDB​.

2. Создать таблицу Departments
CREATE TABLE [dbo].[Departments]
(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
    [Name] NCHAR(50) NOT NULL
)

3. Создать таблицу Employees
CREATE TABLE [dbo].[Employees]
(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
    [Name] NCHAR(50) NOT NULL, 
    [Age] INT NOT NULL, 
    [Salary] DECIMAL(18, 2) NOT NULL, 
    [DepartmentId] INT NOT NULL, 
    CONSTRAINT [FK_Employees_ToDepartments]
		FOREIGN KEY ([DepartmentId]) REFERENCES [Departments]([Id]) ON DELETE CASCADE
)