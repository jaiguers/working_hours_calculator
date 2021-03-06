USE [IASHandyMan]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 23/02/2021 3:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 23/02/2021 3:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Externals] [bit] NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 23/02/2021 3:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 23/02/2021 3:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 23/02/2021 3:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 23/02/2021 3:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Id_Person] [bigint] NULL,
	[Password_Change_Date] [datetime] NULL,
	[External] [bit] NOT NULL,
	[Id_State] [bigint] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 23/02/2021 3:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 23/02/2021 3:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Area] [varchar](50) NULL,
	[Controller] [varchar](50) NULL,
	[Actions] [varchar](50) NULL,
	[Icons] [varchar](50) NULL,
	[OrderMenu] [int] NULL,
	[IdFather] [bigint] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 23/02/2021 3:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Second_Name] [varchar](100) NULL,
	[Surname] [varchar](100) NOT NULL,
	[Second_Surname] [varchar](100) NULL,
	[Identification] [varchar](20) NOT NULL,
	[Cellphone] [varchar](50) NOT NULL,
	[Registration_Date] [datetime] NOT NULL,
	[Id_State] [bigint] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person_Services]    Script Date: 23/02/2021 3:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person_Services](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Start_Date] [datetime] NOT NULL,
	[End_Date] [datetime] NOT NULL,
	[Id_Services] [bigint] NOT NULL,
	[Id_Person] [bigint] NOT NULL,
	[Week_Number] [int] NOT NULL,
	[Id_User] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Person_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolMenu]    Script Date: 23/02/2021 3:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolMenu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_Rol] [nvarchar](450) NOT NULL,
	[Id_Menu] [bigint] NOT NULL,
 CONSTRAINT [PK_Rol_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 23/02/2021 3:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Names] [varchar](50) NOT NULL,
	[Identification] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 23/02/2021 3:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Externals]) VALUES (N'1', N'Admin', N'Admin', NULL, 0)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Externals]) VALUES (N'2', N'Tecnico', N'Tecnico', NULL, 1)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Externals]) VALUES (N'3', N'Supervisor', N'Supervisor', NULL, 0)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'319446b9-c223-4015-bb7b-3a17958ccc29', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'80e865d3-aa9f-4e46-82c0-e1689dd5c1df', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9eec5925-2eba-47cd-a673-e76af3c88521', N'3')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a2fb1405-d60d-4d9b-b82b-3459aaa1fd76', N'2')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Id_Person], [Password_Change_Date], [External], [Id_State]) VALUES (N'319446b9-c223-4015-bb7b-3a17958ccc29', N'admin.abbott@yopmail.com', N'ADMIN.ABBOTT@YOPMAIL.COM', N'admin.abbott@yopmail.com', N'ADMIN.ABBOTT@YOPMAIL.COM', 0, N'AQAAAAEAACcQAAAAEO9WWn9/y9+WUcrvyuVIt5nCt+3I0p7KT+OLL4XNfqmnIPVT2796eKy2m262pQcAbg==', N'7JXUR7BMBWEWH5GCVTY2LQ4RP2GLESJV', N'9da39cae-3ee4-4a45-bcf3-2ceacf7a205d', NULL, 0, 0, NULL, 1, 0, 8, CAST(N'2021-11-18T03:36:22.157' AS DateTime), 0, 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Id_Person], [Password_Change_Date], [External], [Id_State]) VALUES (N'80e865d3-aa9f-4e46-82c0-e1689dd5c1df', N'jaiguers@yopmail.com', N'JAIGUERS@YOPMAIL.COM', N'jaiguers@yopmail.com', N'JAIGUERS@YOPMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAMCXIIjwg54eR2s34qCnn9xBryXwwfVoEhYwkqxA1zCjjKFlK1wFoG80O2Muysg7Q==', N'JZJNBSCK444YBUBXS3SK2TQFOQ2BB5RX', N'a3efe0eb-797a-4695-a8ab-e9fcaf89c127', NULL, 0, 0, NULL, 1, 0, 6, CAST(N'2021-03-08T15:22:29.083' AS DateTime), 1, 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Id_Person], [Password_Change_Date], [External], [Id_State]) VALUES (N'9eec5925-2eba-47cd-a673-e76af3c88521', N'supervisor.abbott@yopmail.com', N'SUPERVISOR.ABBOTT@YOPMAIL.COM', N'supervisor.abbott@yopmail.com', N'SUPERVISOR.ABBOTT@YOPMAIL.COM', 0, N'AQAAAAEAACcQAAAAED5+GbLZ0OuuY/+VBHK//ELrwZtbePVa7FYAu3PoUm/AwliqLwNRkkk1FH7QwhwsmA==', N'77L6ZHGICVZBD7N3DVGUX2TPWYLNQYAQ', N'9e0dd8d8-89b7-43dd-8c5e-e4d466d02a05', NULL, 0, 0, NULL, 1, 0, 7, CAST(N'2021-11-18T03:15:37.010' AS DateTime), 0, 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Id_Person], [Password_Change_Date], [External], [Id_State]) VALUES (N'a2fb1405-d60d-4d9b-b82b-3459aaa1fd76', N'proveedor1.abbott@yopmail.com', N'PROVEEDOR1.ABBOTT@YOPMAIL.COM', N'proveedor1.abbott@yopmail.com', N'PROVEEDOR1.ABBOTT@YOPMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPZ5Z/qCPsrZ4UC/q0oufWtvXQQnTBt3s/35VC52Tq1RRx+n6fABrogiawyhaKqxxQ==', N'2X5DWVRVREPMBZVMMH6MGRX3RGVH5EH4', N'b59abfbf-b762-4715-b83c-86aba47621c9', NULL, 0, 0, NULL, 1, 0, 9, CAST(N'2021-11-30T10:27:23.707' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([Id], [Name], [Area], [Controller], [Actions], [Icons], [OrderMenu], [IdFather]) VALUES (1, N'Reporte de servicio', N'Technician', N'Technician', N'Index', N'fas fa-tasks', 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Area], [Controller], [Actions], [Icons], [OrderMenu], [IdFather]) VALUES (2, N'Cálculo de horas', N'Reviews', N'Reviews', N'Index', N'fas fa-user-clock', 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Area], [Controller], [Actions], [Icons], [OrderMenu], [IdFather]) VALUES (3, N'Usuarios', N'Admin', N'Users', N'Index', N'fas fa-users', 1, NULL)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [Name], [Second_Name], [Surname], [Second_Surname], [Identification], [Cellphone], [Registration_Date], [Id_State]) VALUES (6, N'Tecnico', NULL, N'Uno', NULL, N'1130123456', N'3117298024', CAST(N'2020-12-08T15:22:26.143' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [Name], [Second_Name], [Surname], [Second_Surname], [Identification], [Cellphone], [Registration_Date], [Id_State]) VALUES (7, N'Supervisor', NULL, N'Uno', NULL, N'11302587', N'3117298025', CAST(N'2021-01-22T03:15:31.827' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [Name], [Second_Name], [Surname], [Second_Surname], [Identification], [Cellphone], [Registration_Date], [Id_State]) VALUES (8, N'admin', NULL, N'Admin', NULL, N'123456789', N'3117298025', CAST(N'2021-01-22T03:36:20.973' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [Name], [Second_Name], [Surname], [Second_Surname], [Identification], [Cellphone], [Registration_Date], [Id_State]) VALUES (9, N'Tecnico', NULL, N'Dos', NULL, N'1004308777', N'3118972589', CAST(N'2021-02-03T10:27:22.377' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Person_Services] ON 

INSERT [dbo].[Person_Services] ([Id], [Start_Date], [End_Date], [Id_Services], [Id_Person], [Week_Number], [Id_User]) VALUES (2, CAST(N'2021-02-22T07:00:00.000' AS DateTime), CAST(N'2021-02-22T12:00:00.000' AS DateTime), 1, 6, 9, N'80e865d3-aa9f-4e46-82c0-e1689dd5c1df')
INSERT [dbo].[Person_Services] ([Id], [Start_Date], [End_Date], [Id_Services], [Id_Person], [Week_Number], [Id_User]) VALUES (4, CAST(N'2021-02-22T13:00:00.000' AS DateTime), CAST(N'2021-02-22T20:00:00.000' AS DateTime), 1, 6, 9, N'80e865d3-aa9f-4e46-82c0-e1689dd5c1df')
INSERT [dbo].[Person_Services] ([Id], [Start_Date], [End_Date], [Id_Services], [Id_Person], [Week_Number], [Id_User]) VALUES (5, CAST(N'2021-02-23T07:00:00.000' AS DateTime), CAST(N'2021-02-23T12:00:00.000' AS DateTime), 1, 6, 9, N'80e865d3-aa9f-4e46-82c0-e1689dd5c1df')
INSERT [dbo].[Person_Services] ([Id], [Start_Date], [End_Date], [Id_Services], [Id_Person], [Week_Number], [Id_User]) VALUES (6, CAST(N'2021-02-23T13:00:00.000' AS DateTime), CAST(N'2021-02-23T20:00:00.000' AS DateTime), 2, 6, 9, N'80e865d3-aa9f-4e46-82c0-e1689dd5c1df')
INSERT [dbo].[Person_Services] ([Id], [Start_Date], [End_Date], [Id_Services], [Id_Person], [Week_Number], [Id_User]) VALUES (7, CAST(N'2021-02-24T07:00:00.000' AS DateTime), CAST(N'2021-02-24T12:00:00.000' AS DateTime), 3, 6, 9, N'80e865d3-aa9f-4e46-82c0-e1689dd5c1df')
INSERT [dbo].[Person_Services] ([Id], [Start_Date], [End_Date], [Id_Services], [Id_Person], [Week_Number], [Id_User]) VALUES (8, CAST(N'2021-02-24T13:00:00.000' AS DateTime), CAST(N'2021-02-24T20:00:00.000' AS DateTime), 1, 6, 9, N'80e865d3-aa9f-4e46-82c0-e1689dd5c1df')
INSERT [dbo].[Person_Services] ([Id], [Start_Date], [End_Date], [Id_Services], [Id_Person], [Week_Number], [Id_User]) VALUES (9, CAST(N'2021-02-25T07:00:00.000' AS DateTime), CAST(N'2021-02-25T12:00:00.000' AS DateTime), 2, 6, 9, N'80e865d3-aa9f-4e46-82c0-e1689dd5c1df')
INSERT [dbo].[Person_Services] ([Id], [Start_Date], [End_Date], [Id_Services], [Id_Person], [Week_Number], [Id_User]) VALUES (10, CAST(N'2021-02-25T13:00:00.000' AS DateTime), CAST(N'2021-02-25T20:00:00.000' AS DateTime), 1, 6, 9, N'80e865d3-aa9f-4e46-82c0-e1689dd5c1df')
SET IDENTITY_INSERT [dbo].[Person_Services] OFF
SET IDENTITY_INSERT [dbo].[RolMenu] ON 

INSERT [dbo].[RolMenu] ([Id], [Id_Rol], [Id_Menu]) VALUES (1, N'1', 2)
INSERT [dbo].[RolMenu] ([Id], [Id_Rol], [Id_Menu]) VALUES (3, N'1', 3)
INSERT [dbo].[RolMenu] ([Id], [Id_Rol], [Id_Menu]) VALUES (4, N'2', 1)
INSERT [dbo].[RolMenu] ([Id], [Id_Rol], [Id_Menu]) VALUES (5, N'3', 2)
SET IDENTITY_INSERT [dbo].[RolMenu] OFF
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [Names], [Identification]) VALUES (1, N'Reparación de Lavadoras', N'1001')
INSERT [dbo].[Services] ([Id], [Names], [Identification]) VALUES (2, N'Mantenimeinto de Neveras', N'1002')
INSERT [dbo].[Services] ([Id], [Names], [Identification]) VALUES (3, N'Revision de Gas', N'1003')
SET IDENTITY_INSERT [dbo].[Services] OFF
SET IDENTITY_INSERT [dbo].[States] ON 

INSERT [dbo].[States] ([Id], [Name]) VALUES (1, N'Activo')
INSERT [dbo].[States] ([Id], [Name]) VALUES (2, N'Inactivo')
INSERT [dbo].[States] ([Id], [Name]) VALUES (3, N'Aprobado')
INSERT [dbo].[States] ([Id], [Name]) VALUES (4, N'Rechazado')
INSERT [dbo].[States] ([Id], [Name]) VALUES (5, N'Revisión')
SET IDENTITY_INSERT [dbo].[States] OFF
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_States] FOREIGN KEY([Id_State])
REFERENCES [dbo].[States] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_States]
GO
ALTER TABLE [dbo].[Person_Services]  WITH CHECK ADD  CONSTRAINT [FK_Person_Services_Person] FOREIGN KEY([Id_Person])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Person_Services] CHECK CONSTRAINT [FK_Person_Services_Person]
GO
ALTER TABLE [dbo].[Person_Services]  WITH CHECK ADD  CONSTRAINT [FK_Person_Services_Services] FOREIGN KEY([Id_Services])
REFERENCES [dbo].[Services] ([Id])
GO
ALTER TABLE [dbo].[Person_Services] CHECK CONSTRAINT [FK_Person_Services_Services]
GO
ALTER TABLE [dbo].[RolMenu]  WITH CHECK ADD  CONSTRAINT [FK_RolMenu_Menu] FOREIGN KEY([Id_Menu])
REFERENCES [dbo].[Menu] ([Id])
GO
ALTER TABLE [dbo].[RolMenu] CHECK CONSTRAINT [FK_RolMenu_Menu]
GO
ALTER TABLE [dbo].[RolMenu]  WITH CHECK ADD  CONSTRAINT [FK_RolMenu_RolMenu] FOREIGN KEY([Id_Rol])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[RolMenu] CHECK CONSTRAINT [FK_RolMenu_RolMenu]
GO
