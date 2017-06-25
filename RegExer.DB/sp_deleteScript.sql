create procedure [dbo].[sp_deleteScript]
	@scriptId int
as
	delete from [dbo].[Scripts]
		where
			[scriptId] =  @scriptId
return 0
