
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/15/2022 15:31:58
-- Generated from EDMX file: C:\Users\sachinsaharan\Downloads\MVC (1)\MVC\Nagarro.BookReadingEvent\Nagarro.BookReadingEvent.EntityDataModel\BookReadingEvent.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BookReadingEvent];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Event_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Event_Address];
GO
IF OBJECT_ID(N'[dbo].[FK_BookEvent_BookAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events1] DROP CONSTRAINT [FK_BookEvent_BookAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingEnrollment_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingEnrollments] DROP CONSTRAINT [FK_BookingEnrollment_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_Comment_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comment_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_BookComment_BookEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments1] DROP CONSTRAINT [FK_BookComment_BookEvent];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Addresses1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses1];
GO
IF OBJECT_ID(N'[dbo].[BookingEnrollments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingEnrollments];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[Comments1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments1];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Events1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events1];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Venue] varchar(max)  NOT NULL,
    [City] varchar(max)  NOT NULL,
    [State] varchar(max)  NOT NULL
);
GO

-- Creating table 'Addresses1'
CREATE TABLE [dbo].[Addresses1] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'BookingEnrollments'
CREATE TABLE [dbo].[BookingEnrollments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(max)  NULL,
    [EventsId] int  NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Comment1] varchar(max)  NOT NULL,
    [DatePosted] datetime  NULL,
    [Username] varchar(max)  NULL,
    [EventId] int  NULL
);
GO

-- Creating table 'Comments1'
CREATE TABLE [dbo].[Comments1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Comment11] varchar(max)  NOT NULL,
    [DatePosted] datetime  NULL,
    [Username] varchar(max)  NULL,
    [EventId] int  NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(max)  NOT NULL,
    [AddressId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [StartTime] time  NOT NULL,
    [Type] varchar(50)  NULL,
    [Duration] int  NULL,
    [Description] varchar(50)  NULL,
    [OtherDetails] varchar(500)  NULL,
    [Invitations] varchar(5000)  NULL,
    [Creator] varchar(max)  NULL
);
GO

-- Creating table 'Events1'
CREATE TABLE [dbo].[Events1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(max)  NOT NULL,
    [AddressId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [StartTime] time  NOT NULL,
    [Type] varchar(50)  NULL,
    [Duration] int  NULL,
    [Description] varchar(50)  NULL,
    [OtherDetails] varchar(500)  NULL,
    [Invitations] varchar(5000)  NULL,
    [Creator] varchar(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] varchar(max)  NOT NULL,
    [Password] varchar(max)  NOT NULL,
    [Username] varchar(max)  NOT NULL,
    [Type] varchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Addresses1'
ALTER TABLE [dbo].[Addresses1]
ADD CONSTRAINT [PK_Addresses1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BookingEnrollments'
ALTER TABLE [dbo].[BookingEnrollments]
ADD CONSTRAINT [PK_BookingEnrollments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments1'
ALTER TABLE [dbo].[Comments1]
ADD CONSTRAINT [PK_Comments1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Events1'
ALTER TABLE [dbo].[Events1]
ADD CONSTRAINT [PK_Events1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AddressId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Event_Address]
    FOREIGN KEY ([AddressId])
    REFERENCES [dbo].[Addresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_Address'
CREATE INDEX [IX_FK_Event_Address]
ON [dbo].[Events]
    ([AddressId]);
GO

-- Creating foreign key on [AddressId] in table 'Events1'
ALTER TABLE [dbo].[Events1]
ADD CONSTRAINT [FK_BookEvent_BookAddress]
    FOREIGN KEY ([AddressId])
    REFERENCES [dbo].[Addresses1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookEvent_BookAddress'
CREATE INDEX [IX_FK_BookEvent_BookAddress]
ON [dbo].[Events1]
    ([AddressId]);
GO

-- Creating foreign key on [EventsId] in table 'BookingEnrollments'
ALTER TABLE [dbo].[BookingEnrollments]
ADD CONSTRAINT [FK_BookingEnrollment_Event]
    FOREIGN KEY ([EventsId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingEnrollment_Event'
CREATE INDEX [IX_FK_BookingEnrollment_Event]
ON [dbo].[BookingEnrollments]
    ([EventsId]);
GO

-- Creating foreign key on [EventId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comment_Event]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Comment_Event'
CREATE INDEX [IX_FK_Comment_Event]
ON [dbo].[Comments]
    ([EventId]);
GO

-- Creating foreign key on [EventId] in table 'Comments1'
ALTER TABLE [dbo].[Comments1]
ADD CONSTRAINT [FK_BookComment_BookEvent]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookComment_BookEvent'
CREATE INDEX [IX_FK_BookComment_BookEvent]
ON [dbo].[Comments1]
    ([EventId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------