CREATE VIEW [dbo].[LogAudit]
	AS SELECT l.id as Id, l.timestamp, l.message AS action, l.entity, u.name AS [user], s.value AS session, ip.value AS ip
	FROM Log l
	LEFT JOIN LogProperty ip ON ip.log = l.id AND ip.name = 'IP'
	LEFT JOIN LogProperty s ON s.log = l.id AND s.name = 'SessionId'
	LEFT JOIN LogUser u ON l.[user] = u.id
	WHERE level = 2
