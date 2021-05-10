IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Lancamento] (
    [Id] uniqueidentifier NOT NULL,
    [Data] datetime2 NOT NULL,
    [Valor] decimal(10,2) NOT NULL,
    [Descricao] nvarchar(300) NULL,
    [Conta] nvarchar(50) NOT NULL,
    [Tipo] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Lancamento] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210509030047_Initial', N'2.1.1-rtm-30846');

GO