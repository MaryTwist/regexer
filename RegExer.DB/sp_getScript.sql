create procedure [dbo].[sp_getScript]
	@scriptId int
as
	select [scriptId], [name], [description], [SearchPattern], [ReplacePattern], [made], [modified]
		from [dbo].[Scripts]
return 0