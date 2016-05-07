
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/07/2016 14:22:34
-- Generated from EDMX file: C:\Users\migue\Code\sample-entity-framework\Ninja.Demo\EdmxFromDb\AWModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AdventureWorksSuperLT];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[SalesLT].[FK_Product_ProductCategory_ProductCategoryID]', 'F') IS NOT NULL
    ALTER TABLE [SalesLT].[Product] DROP CONSTRAINT [FK_Product_ProductCategory_ProductCategoryID];
GO
IF OBJECT_ID(N'[SalesLT].[FK_Product_ProductModel_ProductModelID]', 'F') IS NOT NULL
    ALTER TABLE [SalesLT].[Product] DROP CONSTRAINT [FK_Product_ProductModel_ProductModelID];
GO
IF OBJECT_ID(N'[SalesLT].[FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID]', 'F') IS NOT NULL
    ALTER TABLE [SalesLT].[ProductCategory] DROP CONSTRAINT [FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID];
GO
IF OBJECT_ID(N'[SalesLT].[FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID]', 'F') IS NOT NULL
    ALTER TABLE [SalesLT].[ProductModelProductDescription] DROP CONSTRAINT [FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID];
GO
IF OBJECT_ID(N'[SalesLT].[FK_ProductModelProductDescription_ProductModel_ProductModelID]', 'F') IS NOT NULL
    ALTER TABLE [SalesLT].[ProductModelProductDescription] DROP CONSTRAINT [FK_ProductModelProductDescription_ProductModel_ProductModelID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[SalesLT].[Product]', 'U') IS NOT NULL
    DROP TABLE [SalesLT].[Product];
GO
IF OBJECT_ID(N'[SalesLT].[ProductCategory]', 'U') IS NOT NULL
    DROP TABLE [SalesLT].[ProductCategory];
GO
IF OBJECT_ID(N'[SalesLT].[ProductDescription]', 'U') IS NOT NULL
    DROP TABLE [SalesLT].[ProductDescription];
GO
IF OBJECT_ID(N'[SalesLT].[ProductModel]', 'U') IS NOT NULL
    DROP TABLE [SalesLT].[ProductModel];
GO
IF OBJECT_ID(N'[SalesLT].[ProductModelProductDescription]', 'U') IS NOT NULL
    DROP TABLE [SalesLT].[ProductModelProductDescription];
GO
IF OBJECT_ID(N'[AdventureWorksSuperLTModelStoreContainer].[vGetAllCategories]', 'U') IS NOT NULL
    DROP TABLE [AdventureWorksSuperLTModelStoreContainer].[vGetAllCategories];
GO
IF OBJECT_ID(N'[AdventureWorksSuperLTModelStoreContainer].[vProductAndDescription]', 'U') IS NOT NULL
    DROP TABLE [AdventureWorksSuperLTModelStoreContainer].[vProductAndDescription];
GO
IF OBJECT_ID(N'[AdventureWorksSuperLTModelStoreContainer].[vProductModelCatalogDescription]', 'U') IS NOT NULL
    DROP TABLE [AdventureWorksSuperLTModelStoreContainer].[vProductModelCatalogDescription];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ProductNumber] nvarchar(25)  NOT NULL,
    [Color] nvarchar(15)  NULL,
    [StandardCost] decimal(19,4)  NOT NULL,
    [ListPrice] decimal(19,4)  NOT NULL,
    [Size] nvarchar(5)  NULL,
    [Weight] decimal(8,2)  NULL,
    [ProductCategoryID] int  NULL,
    [ProductModelID] int  NULL,
    [SellStartDate] datetime  NOT NULL,
    [SellEndDate] datetime  NULL,
    [DiscontinuedDate] datetime  NULL,
    [ThumbNailPhoto] varbinary(max)  NULL,
    [ThumbnailPhotoFileName] nvarchar(50)  NULL,
    [rowguid] uniqueidentifier  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'ProductCategories'
CREATE TABLE [dbo].[ProductCategories] (
    [ProductCategoryID] int IDENTITY(1,1) NOT NULL,
    [ParentProductCategoryID] int  NULL,
    [Name] nvarchar(50)  NOT NULL,
    [rowguid] uniqueidentifier  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'ProductDescriptions'
CREATE TABLE [dbo].[ProductDescriptions] (
    [ProductDescriptionID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(400)  NOT NULL,
    [rowguid] uniqueidentifier  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'ProductModels'
CREATE TABLE [dbo].[ProductModels] (
    [ProductModelID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [CatalogDescription] nvarchar(max)  NULL,
    [rowguid] uniqueidentifier  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'ProductModelProductDescriptions'
CREATE TABLE [dbo].[ProductModelProductDescriptions] (
    [ProductModelID] int  NOT NULL,
    [ProductDescriptionID] int  NOT NULL,
    [Culture] nchar(6)  NOT NULL,
    [rowguid] uniqueidentifier  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'vGetAllCategories'
CREATE TABLE [dbo].[vGetAllCategories] (
    [ParentProductCategoryName] nvarchar(50)  NOT NULL,
    [ProductCategoryName] nvarchar(50)  NULL,
    [ProductCategoryID] int  NULL
);
GO

-- Creating table 'vProductAndDescriptions'
CREATE TABLE [dbo].[vProductAndDescriptions] (
    [ProductID] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ProductModel] nvarchar(50)  NOT NULL,
    [Culture] nchar(6)  NOT NULL,
    [Description] nvarchar(400)  NOT NULL
);
GO

-- Creating table 'vProductModelCatalogDescriptions'
CREATE TABLE [dbo].[vProductModelCatalogDescriptions] (
    [ProductModelID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Summary] nvarchar(max)  NULL,
    [Manufacturer] nvarchar(max)  NULL,
    [Copyright] nvarchar(30)  NULL,
    [ProductURL] nvarchar(256)  NULL,
    [WarrantyPeriod] nvarchar(256)  NULL,
    [WarrantyDescription] nvarchar(256)  NULL,
    [NoOfYears] nvarchar(256)  NULL,
    [MaintenanceDescription] nvarchar(256)  NULL,
    [Wheel] nvarchar(256)  NULL,
    [Saddle] nvarchar(256)  NULL,
    [Pedal] nvarchar(256)  NULL,
    [BikeFrame] nvarchar(max)  NULL,
    [Crankset] nvarchar(256)  NULL,
    [PictureAngle] nvarchar(256)  NULL,
    [PictureSize] nvarchar(256)  NULL,
    [ProductPhotoID] nvarchar(256)  NULL,
    [Material] nvarchar(256)  NULL,
    [Color] nvarchar(256)  NULL,
    [ProductLine] nvarchar(256)  NULL,
    [Style] nvarchar(256)  NULL,
    [RiderExperience] nvarchar(1024)  NULL,
    [rowguid] uniqueidentifier  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ProductID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [ProductCategoryID] in table 'ProductCategories'
ALTER TABLE [dbo].[ProductCategories]
ADD CONSTRAINT [PK_ProductCategories]
    PRIMARY KEY CLUSTERED ([ProductCategoryID] ASC);
GO

-- Creating primary key on [ProductDescriptionID] in table 'ProductDescriptions'
ALTER TABLE [dbo].[ProductDescriptions]
ADD CONSTRAINT [PK_ProductDescriptions]
    PRIMARY KEY CLUSTERED ([ProductDescriptionID] ASC);
GO

-- Creating primary key on [ProductModelID] in table 'ProductModels'
ALTER TABLE [dbo].[ProductModels]
ADD CONSTRAINT [PK_ProductModels]
    PRIMARY KEY CLUSTERED ([ProductModelID] ASC);
GO

-- Creating primary key on [ProductModelID], [ProductDescriptionID], [Culture] in table 'ProductModelProductDescriptions'
ALTER TABLE [dbo].[ProductModelProductDescriptions]
ADD CONSTRAINT [PK_ProductModelProductDescriptions]
    PRIMARY KEY CLUSTERED ([ProductModelID], [ProductDescriptionID], [Culture] ASC);
GO

-- Creating primary key on [ParentProductCategoryName] in table 'vGetAllCategories'
ALTER TABLE [dbo].[vGetAllCategories]
ADD CONSTRAINT [PK_vGetAllCategories]
    PRIMARY KEY CLUSTERED ([ParentProductCategoryName] ASC);
GO

-- Creating primary key on [ProductID], [Name], [ProductModel], [Culture], [Description] in table 'vProductAndDescriptions'
ALTER TABLE [dbo].[vProductAndDescriptions]
ADD CONSTRAINT [PK_vProductAndDescriptions]
    PRIMARY KEY CLUSTERED ([ProductID], [Name], [ProductModel], [Culture], [Description] ASC);
GO

-- Creating primary key on [ProductModelID], [Name], [rowguid], [ModifiedDate] in table 'vProductModelCatalogDescriptions'
ALTER TABLE [dbo].[vProductModelCatalogDescriptions]
ADD CONSTRAINT [PK_vProductModelCatalogDescriptions]
    PRIMARY KEY CLUSTERED ([ProductModelID], [Name], [rowguid], [ModifiedDate] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProductCategoryID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_ProductCategory_ProductCategoryID]
    FOREIGN KEY ([ProductCategoryID])
    REFERENCES [dbo].[ProductCategories]
        ([ProductCategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_ProductCategory_ProductCategoryID'
CREATE INDEX [IX_FK_Product_ProductCategory_ProductCategoryID]
ON [dbo].[Products]
    ([ProductCategoryID]);
GO

-- Creating foreign key on [ProductModelID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_ProductModel_ProductModelID]
    FOREIGN KEY ([ProductModelID])
    REFERENCES [dbo].[ProductModels]
        ([ProductModelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_ProductModel_ProductModelID'
CREATE INDEX [IX_FK_Product_ProductModel_ProductModelID]
ON [dbo].[Products]
    ([ProductModelID]);
GO

-- Creating foreign key on [ParentProductCategoryID] in table 'ProductCategories'
ALTER TABLE [dbo].[ProductCategories]
ADD CONSTRAINT [FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID]
    FOREIGN KEY ([ParentProductCategoryID])
    REFERENCES [dbo].[ProductCategories]
        ([ProductCategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID'
CREATE INDEX [IX_FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID]
ON [dbo].[ProductCategories]
    ([ParentProductCategoryID]);
GO

-- Creating foreign key on [ProductDescriptionID] in table 'ProductModelProductDescriptions'
ALTER TABLE [dbo].[ProductModelProductDescriptions]
ADD CONSTRAINT [FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID]
    FOREIGN KEY ([ProductDescriptionID])
    REFERENCES [dbo].[ProductDescriptions]
        ([ProductDescriptionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID'
CREATE INDEX [IX_FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID]
ON [dbo].[ProductModelProductDescriptions]
    ([ProductDescriptionID]);
GO

-- Creating foreign key on [ProductModelID] in table 'ProductModelProductDescriptions'
ALTER TABLE [dbo].[ProductModelProductDescriptions]
ADD CONSTRAINT [FK_ProductModelProductDescription_ProductModel_ProductModelID]
    FOREIGN KEY ([ProductModelID])
    REFERENCES [dbo].[ProductModels]
        ([ProductModelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------