BEGIN TRANSACTION;
ALTER TABLE [Courses] DROP CONSTRAINT [FK_Courses_Instructor_InstructorId];

ALTER TABLE [Instructor] DROP CONSTRAINT [PK_Instructor];

EXEC sp_rename N'[Instructor]', N'Instructors', 'OBJECT';

ALTER TABLE [Instructors] ADD CONSTRAINT [PK_Instructors] PRIMARY KEY ([Id]);

CREATE TABLE [Departments] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Budget] decimal(18,2) NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [DepartmentHeadId] int NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Departments_Instructors_DepartmentHeadId] FOREIGN KEY ([DepartmentHeadId]) REFERENCES [Instructors] ([Id]) ON DELETE SET NULL
);

CREATE INDEX [IX_Departments_DepartmentHeadId] ON [Departments] ([DepartmentHeadId]);

ALTER TABLE [Courses] ADD CONSTRAINT [FK_Courses_Instructors_InstructorId] FOREIGN KEY ([InstructorId]) REFERENCES [Instructors] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250307003918_AddDepartmentRelation', N'9.0.2');

COMMIT;
GO

