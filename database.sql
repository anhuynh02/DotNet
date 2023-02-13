USE master
GO
IF EXISTS(SELECT * FROM sysdatabases WHERE name='TdtuTube')
	DROP DATABASE [TdtuTube]
GO
CREATE DATABASE [TdtuTube]

GO
USE [TdtuTube]

CREATE TABLE [Role]
(
	[id] INT IDENTITY(1,1),
	[name] VARCHAR(30) NOT NULL,
	CONSTRAINT Role_PK PRIMARY KEY([id])
)

INSERT INTO [Role] ([name]) VALUES
	('admin'),
	('user');

CREATE TABLE [User]
(
	[id] INT IDENTITY(1,1),
	[name] NVARCHAR(30) NOT NULL,
	[email] VARCHAR(254) NOT NULL,
	[password] VARCHAR(80) NOT NULL,
	[subscribers] INT DEFAULT 0,
	[avatar_path] VARCHAR(100) DEFAULT '~/Uploads/Avatars/default.png',
	[role_id] INT NOT NULL,
	[meta] VARCHAR(30) NOT NULL,
	[datebegin] DATETIME DEFAULT GETDATE(),
	CONSTRAINT User_PK PRIMARY KEY([id]),
	CONSTRAINT User_Email_U UNIQUE([email]),
	CONSTRAINT USER_Meta_U UNIQUE([meta]),
	CONSTRAINT User_Role_FK FOREIGN KEY([role_id]) REFERENCES [Role]([id])
)

INSERT INTO [User] ([name], [email], [password], [avatar_path], [role_id], [meta]) VALUES
	(N'Thông', 'admin@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '~/Uploads/Avatars/1.png', 1, '1'),
	(N'user1', 'user1@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '~/Uploads/Avatars/2.png', 2, '2'),
	(N'user2', 'user2@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '~/Uploads/Avatars/3.png', 2, '3'),
	(N'user3', 'user3@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '~/Uploads/Avatars/4.png', 2, '4'),
	(N'user4', 'user4@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '~/Uploads/Avatars/5.png', 2, '5'),
	(N'user5', 'user5@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '~/Uploads/Avatars/6.png', 2, '6'),
	(N'user6', 'user6@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '~/Uploads/Avatars/7.png', 2, '7'),
	(N'user7', 'user7@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '~/Uploads/Avatars/8.png', 2, '8'),
	(N'user8', 'user8@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '~/Uploads/Avatars/9.png', 2, '9'),
	(N'user10', 'user10@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '~/Uploads/Avatars/10.png', 2, '10')

CREATE TABLE [Tag]
(
	[id] INT IDENTITY(1,1),
	[name] NVARCHAR(30) NOT NULL,
	CONSTRAINT Tag_PK PRIMARY KEY([id])
)

INSERT INTO [Tag] ([name]) VALUES
	(N'Âm nhạc'),
	(N'Trò chơi'),
	(N'Tin tức'),
	(N'Thể thao'),
	(N'Hoạt hình'),
	(N'Toán học'),
	(N'Thủ công'),
	(N'Du lịch'),
	(N'Bóng đá'),
	(N'Nấu ăn'),
	(N'Thiên nhiên'),
	(N'Hoạt họa'),
	(N'Vlog'),
	(N'Diễn thuyết'),
	(N'Hướng dẫn');

GO
SELECT * FROM [Role]
SELECT * FROM [User]
SELECT * FROM [Tag]