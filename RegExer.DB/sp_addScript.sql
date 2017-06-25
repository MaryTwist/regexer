create procedure [dbo].[sp_AddScript]
	@name nvarchar(50),
	@description nvarchar(200),
	@searchPattern nvarchar(4000),
	@replacePattern nvarchar(4000)
as
	declare @result as table (
		scriptId int
	)

	insert into [dbo].[Scripts]([name], [description], [SearchPattern], [ReplacePattern])
		output inserted.[scriptId] into @result
		values(@name, @description, @searchPattern, @replacePattern)

	select scriptId
		from @result

return 0