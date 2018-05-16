CREATE VIEW [dbo].[UserView]
	AS 
select u.Id, u.DisplayName, u.[Description], u.Email, u.[Enabled], min(r.[Name]) as [Role]
from [User] u
inner join User_AccessRule ur on ur.UserId = u.Id
inner join AccessRule r on ur.AccessRuleId = r.Id
group by u.Id, u.DisplayName, u.[Description], u.Email, u.[Enabled]