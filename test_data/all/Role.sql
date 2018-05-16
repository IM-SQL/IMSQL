CREATE VIEW [dbo].[Role]
	 AS SELECT RoleId, Name  
FROM Role_AccessRule
INNER JOIN AccessRule ON AccessRule.Id = Role_AccessRule.RoleId
GROUP BY RoleId, Name