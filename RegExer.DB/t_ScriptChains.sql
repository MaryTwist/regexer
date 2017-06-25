create table [dbo].[ScriptChains]
(
	[scriptChainId] int not null identity(1,1) primary key,
	[chainId] int not null,
	[scriptId] int not null,
	[orderId] int not null default(0),

	foreign key ([chainId]) references [dbo].[Chains]([chainId]) on delete cascade,
	foreign key ([scriptId]) references [dbo].[Scripts]([scriptId]) on delete cascade
)
