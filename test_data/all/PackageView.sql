CREATE VIEW [dbo].[PackageView]
	AS SELECT p.Id, p.ClientId, i.Name AS InterfaceName, p.ProcessBeganTime, p.FilePath, p.FileCreatedTime, p.FileSentTime, p.RecordCount, r.[Timestamp] AS LastResendTime, u.DisplayName AS LastResendUser, COUNT(DISTINCT e.Id) AS ErrorCount
		FROM Package p
		INNER JOIN Interface i ON p.InterfaceId = i.Id
		LEFT JOIN Resending r ON r.PackageId = p.Id AND r.Id = (SELECT MAX(Id) FROM Resending WHERE PackageId = p.Id)
		LEFT JOIN [User] u ON r.UserId = u.Id
		LEFT JOIN Error e ON e.PackageId = p.Id
		GROUP BY p.Id, p.ClientId, i.Name, p.ProcessBeganTime, p.FilePath, p.FileCreatedTime, p.FileSentTime, p.RecordCount, r.[Timestamp], u.DisplayName