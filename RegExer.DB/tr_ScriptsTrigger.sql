create trigger [ScriptsTrigger]
	on [dbo].[Scripts]
	for update
	as
	begin
		set nocount on

		update t
			set t.modified = getdate()
			from [dbo].[Scripts] as t
			join inserted as i on (i.[scriptId] = t.[scriptId])

	end
