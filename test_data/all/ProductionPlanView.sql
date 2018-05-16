CREATE VIEW [dbo].[ProductionPlanView]
	AS select 
	ppi.Id, ppi.ProductionPlanId, c.InternalId as MARCA, ppi.Line as LINEA, 
	ppi.CAA as [PI], p.SKU as SKU, p.Model as MODELO, ppi.Qty as QTY, 
	ppi.Fecha as FECHA, ppi.[Week] as [WEEK]
	from ProductionPlanItem ppi
	inner join ProductionPlan pp on pp.Id = ppi.ProductionPlanId
	inner join Client c on c.Id = pp.ClientId
	inner join Product p on p.Id = ppi.ProductId
