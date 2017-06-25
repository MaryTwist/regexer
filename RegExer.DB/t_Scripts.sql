create table [dbo].[Scripts]
(
	[ScriptId] int not null identity(1,1) primary key,
	[Name] nvarchar(50) not null,
	[Description] nvarchar(200) null,
	[SearchPattern] nvarchar(4000) null,
	[ReplacePattern] nvarchar(4000) null,
	[Made] datetime not null default(getdate()),
	[Modified] datetime null
)
