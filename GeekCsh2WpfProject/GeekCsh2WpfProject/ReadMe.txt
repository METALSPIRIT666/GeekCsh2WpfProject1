1. Создать БД с именем Departments​, имя сервера (localdb)\MSSQLLocalDB​.

2. Создать таблицу Departments
CREATE TABLE [dbo].[Departments] (
    [Id]   INT        IDENTITY (1, 1) NOT NULL,
    [Name] NCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

3. Создать таблицу Employees
CREATE TABLE [dbo].[Employees] (
    [Id]           INT        IDENTITY (1, 1) NOT NULL,
    [Name]         NCHAR (50) NOT NULL,
    [Age]          INT        NOT NULL,
    [Salary]       REAL       NOT NULL,
    [DepartmentId] INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employees_ToDepartments] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([Id]) ON DELETE CASCADE
);