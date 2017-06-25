create procedure [dbo].[sp_updateScript]
	@scriptId int,
	@name nvarchar(50),
	@description nvarchar(200),
	@searchPattern nvarchar(4000),
	@replacePattern nvarchar(4000)
as
	update [dbo].[Scripts]
		set
			[name] = @name,
			[description] = @description,
			[SearchPattern] = @searchPattern,
			[ReplacePattern] = @replacePattern
		where
			[scriptId] = @scriptId
return 0
