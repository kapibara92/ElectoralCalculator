
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/20/2016 11:30:07
-- Generated from EDMX file: C:\Users\Kapibara\documents\visual studio 2015\Projects\ElectoralCalculator\ElectoralCalculator\ElectionData.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ElectionTest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[CandidateSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CandidateSet];
GO
IF OBJECT_ID(N'[dbo].[VoteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VoteSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Pesel] bigint  NOT NULL,
    [Vote] bit  NOT NULL
);
GO

-- Creating table 'CandidateSet'
CREATE TABLE [dbo].[CandidateSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Party] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'VoteSet'
CREATE TABLE [dbo].[VoteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Valid] bit  NOT NULL,
    [IsEntitled] bit  NOT NULL,
    [CandidateId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CandidateSet'
ALTER TABLE [dbo].[CandidateSet]
ADD CONSTRAINT [PK_CandidateSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VoteSet'
ALTER TABLE [dbo].[VoteSet]
ADD CONSTRAINT [PK_VoteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------