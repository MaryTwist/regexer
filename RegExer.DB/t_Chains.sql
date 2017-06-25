create table [dbo].[Chains]
(
	[chainId] int not null identity(1,1) primary key,
	[name] nvarchar(50) not null,
	[description] nvarchar(200) null,
	[made] datetime not null default(getdate()),
	[modified] datetime null
)
