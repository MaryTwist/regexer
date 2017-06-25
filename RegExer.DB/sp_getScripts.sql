create procedure [dbo].[sp_getScripts]
as
	select [scriptId], [name], [description], [SearchPattern], [ReplacePattern], [made], [modified]
		from [dbo].[Scripts]
return 0
