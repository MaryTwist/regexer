create trigger [ChainsTrigger]
	on [dbo].[Chains]
	for update
	as
	begin
		set nocount on

		update t
			set t.modified = getdate()
			from [dbo].[Chains] as t
			join inserted as i on (i.[chainId] = t.[chainId])

	end
