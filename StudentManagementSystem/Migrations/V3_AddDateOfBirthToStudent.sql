BEGIN TRANSACTION;
ALTER TABLE [Students] ADD [DateOfBirth] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250307001823_AddDateOfBirthToStudent', N'9.0.2');

COMMIT;
GO

