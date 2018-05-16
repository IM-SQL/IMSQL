CREATE TABLE [dbo].[ProductionPlanItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CAA] NVARCHAR(50) NOT NULL,
    [Line] NVARCHAR(10) NOT NULL,
    [ProductId] INT NOT NULL, 
    [Qty] INT NOT NULL, 
    [Fecha] DATE NOT NULL, 
    [Week] INT NOT NULL, 
    [ProductionPlanId] INT NOT NULL, 
    CONSTRAINT [FK_ProductionPlanItem_ToProduct] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_ProductionPlanItem_ToProductionPlan] FOREIGN KEY ([ProductionPlanId]) REFERENCES [ProductionPlan]([Id])
)
