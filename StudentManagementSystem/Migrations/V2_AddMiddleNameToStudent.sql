BEGIN TRANSACTION;
ALTER TABLE [Students] ADD [MiddleName] nvarchar(max) NOT NULL DEFAULT N'';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250307001544_AddMiddleNameToStudent', N'9.0.2');

COMMIT;
GO

