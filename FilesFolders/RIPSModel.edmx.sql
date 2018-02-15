
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/14/2018 11:25:33
-- Generated from EDMX file: C:\Users\USER-XPS\source\repos\FilesFolders\FilesFolders\RIPSModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RIPS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EntidadSet'
CREATE TABLE [dbo].[EntidadSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Regimen] nvarchar(max)  NOT NULL,
    [RegimenId1] int  NOT NULL
);
GO

-- Creating table 'RegimenSet'
CREATE TABLE [dbo].[RegimenSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tipo] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EntidadSet'
ALTER TABLE [dbo].[EntidadSet]
ADD CONSTRAINT [PK_EntidadSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RegimenSet'
ALTER TABLE [dbo].[RegimenSet]
ADD CONSTRAINT [PK_RegimenSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RegimenId1] in table 'EntidadSet'
ALTER TABLE [dbo].[EntidadSet]
ADD CONSTRAINT [FK_EntidadRegimen]
    FOREIGN KEY ([RegimenId1])
    REFERENCES [dbo].[RegimenSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntidadRegimen'
CREATE INDEX [IX_FK_EntidadRegimen]
ON [dbo].[EntidadSet]
    ([RegimenId1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------