IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327024940_CreateTables')
BEGIN
    CREATE TABLE [Empleados] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NULL,
        [Rol] int NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_Empleados] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327024940_CreateTables')
BEGIN
    CREATE TABLE [Sueldos] (
        [Id] int NOT NULL IDENTITY,
        [EmpleadoId] int NOT NULL,
        [Mes] int NOT NULL,
        [Entregas] int NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_Sueldos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Sueldos_Empleados_EmpleadoId] FOREIGN KEY ([EmpleadoId]) REFERENCES [Empleados] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327024940_CreateTables')
BEGIN
    CREATE INDEX [IX_Sueldos_EmpleadoId] ON [Sueldos] ([EmpleadoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327024940_CreateTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230327024940_CreateTables', N'6.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230328041642_script')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230328041642_script', N'6.0.15');
END;
GO

COMMIT;
GO

