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
	[avatar_path] VARCHAR(100) DEFAULT '/Uploads/Avatars/default.png',
	[role_id] INT NOT NULL,
	[meta] VARCHAR(30) NOT NULL,
	[datebegin] DATETIME DEFAULT GETDATE(),
	CONSTRAINT User_PK PRIMARY KEY([id]),
	CONSTRAINT User_Email_U UNIQUE([email]),
	CONSTRAINT USER_Meta_U UNIQUE([meta]),
	CONSTRAINT User_Role_FK FOREIGN KEY([role_id]) REFERENCES [Role]([id])
)

-- Password = 123456
INSERT INTO [User] ([name], [email], [password], [avatar_path], [role_id], [meta]) VALUES
	(N'Thông', 'admin@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '/Uploads/Avatars/1.png', 1, '1'),
	(N'user1', 'user1@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '/Uploads/Avatars/2.png', 2, '2'),
	(N'user2', 'user2@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '/Uploads/Avatars/3.png', 2, '3'),
	(N'user3', 'user3@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '/Uploads/Avatars/4.png', 2, '4'),
	(N'user4', 'user4@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '/Uploads/Avatars/5.png', 2, '5'),
	(N'user5', 'user5@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '/Uploads/Avatars/6.png', 2, '6'),
	(N'user6', 'user6@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '/Uploads/Avatars/7.png', 2, '7'),
	(N'user7', 'user7@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '/Uploads/Avatars/8.png', 2, '8'),
	(N'user8', 'user8@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '/Uploads/Avatars/9.png', 2, '9'),
	(N'user10', 'user10@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '/Uploads/Avatars/10.png', 2, '10'),
	(N'default', 'Test@gmail.com', '$2y$10$0P8Y8D0BDFeWnUfhW3r4Fu6fuLlCMxlYh7Aq8nNVID/XzyDD1Kq9i', '/Uploads/Avatars/default.PNG', 2, '11');

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

CREATE TABLE [Video]
(
	[id] INT IDENTITY(1,1),
	[user_id] INT NOT NULL,
	[tag_id] INT NOT NULL,
	[title] NVARCHAR(100) NOT NULL,
	[description] NVARCHAR(500) NOT NULL,
	[like] INT DEFAULT 0,
	[view] INT DEFAULT 0,
	[privacy] BIT NOT NULL, -- Chế độ công khai, riêng tư,...
	[length] VARCHAR(10) NOT NULL, -- Độ dài video.
	[thumbnail] VARCHAR(200) NOT NULL, -- Đường dẫn tới thumbnail video.
	[path] VARCHAR(200) NOT NULL, -- Đường dẫn tới video.
	[feature] BIT NOT NULL, -- Chọn video có feature trên trang chính hay không (Phương án tạm).
	[datebegin] DATETIME DEFAULT GETDATE(),
	CONSTRAINT Video_PK PRIMARY KEY([id]),
	CONSTRAINT Video_User_FK FOREIGN KEY([user_id]) REFERENCES [User]([id]),
	CONSTRAINT Video_Tag_FK FOREIGN KEY([tag_id]) REFERENCES [Tag]([id])
)

INSERT INTO [video] ([user_id], [tag_id], [title], [description], [datebegin], [like], [view], [privacy], [length], [thumbnail], [path], [feature]) VALUES
	(1, 3, N'Video 1', N'Video để test.', '2022-12-08 12:10:12', 0, 71, 0, '0:06', '/Uploads/Thumbnails/1.PNG', '/Uploads/Videos/1.mp4', 1),
	(3, 3, N'Video 2', N'Video hai để test.', '2022-12-07 23:10:12', 0, 51, 0, '0:11', '/Uploads/Thumbnails/2.PNG', '/Uploads/Videos/2.mp4', 1),
	(11, 1, N'Đây là video', N'Đây là mô tả', '2022-02-10 13:10:12', 0, 1235, 0, '0:15', '/Uploads/Thumbnails/3.PNG', '/Uploads/Videos/3.mp4', 1),
	(1, 2, N'Hello World', N'Chào', '2022-05-20 06:15:30', 0, 41045, 0, '0:06', '/Uploads/Thumbnails/4.PNG', '/Uploads/Videos/4.mp4', 1),
	(3, 4, N'Không phải video', N'Không có gì ở đây', '2021-12-09 18:42:52', 0, 14200022, 0, '0:06', '/Uploads/Thumbnails/5.PNG', '/Uploads/Videos/5.mp4', 1),
	(2, 5, N'???', N'?', '2020-07-12 08:09:10', 0, 1002110126, 0, '0:06', '/Uploads/Thumbnails/6.PNG', '/Uploads/Videos/6.mp4', 1),
	(8, 6, N'Bắt đầu với sản phẩm', N'Mô tả video.', '2022-12-12 20:14:32', 0, 51125, 0, '0:06', '/Uploads/Thumbnails/7.PNG', '/Uploads/Videos/7.mp4', 1),
	(2, 7, N'Đại học Tôn Đức Thắng', N'Tương tự như cách suy nghĩ của con người sẽ phản ứng lại khi tiếp nhận các tác nhân kích thích từ bên ngoài.', '2022-12-13 16:09:21', 0, 12, 1, '0:06', '/Uploads/Thumbnails/8.PNG', '/Uploads/Videos/8.mp4', 0),
	(5, 8, N'Tập giấy dán ghi nhớ', N'Tôi thích nghĩ lớn. Nếu đằng nào bạn cũng phải nghĩ, vậy thì hãy nghĩ lớn.', '2022-12-12 07:15:52', 0, 19, 0, '0:06', '/Uploads/Thumbnails/9.PNG', '/Uploads/Videos/9.mp4', 1),
	(7, 9, N'Mắt mèo', N'Chúng ta không có cơ hội làm quá nhiều điều nên hãy chắc chắn rằng mọi thứ chúng ta làm đều phải thật sự tuyệt vời. Bởi vì đây là cuộc đời của chúng ta.', '2022-12-16 15:15:52', 0, 9, 0, '0:06', '/Uploads/Thumbnails/10.PNG', '/Uploads/Videos/10.mp4', 1),
	(1, 4, N'Test Upload', N'Đây là video công khai', '2015-06-18 10:20:16', 0, 4102910, 0, '0:05', '/Uploads/Thumbnails/default.PNG', '/Uploads/Videos/11.mp4', 1),
	(1, 14, N'aaaa', N'fasasdsa', '2022-12-18 16:27:52', 0, 14, 0, '0:28', '/Uploads/Thumbnails/default.PNG', '/Uploads/Videos/12.mp4', 1),
	(1, 14, N'Uplaod', N'uplaod', '2022-11-18 20:01:05', 0, 1241, 0, '1:59', '/Uploads/Thumbnails/4.PNG', '/Uploads/Videos/13.m4v', 1),
	(1, 14, N'More video', N'Test Test', '2022-12-18 20:01:41', 0, 0, 1, '0:05', '/Uploads/Thumbnails/default.PNG', '/Uploads/Videos/14.mp4', 0),
	(8, 14, N'Spam Video', N'spaming', '2022-12-18 20:02:35', 0, 0, 0, '0:06', '/Uploads/Thumbnails/default.PNG', '/Uploads/Videos/15.mp4', 0),
	(8, 14, N'Những câu nói truyền cảm hứng từ những người thành công', N'Những người thành công không chỉ truyền cảm hứng về triết lý kinh doanh, phát triển sự nghiệp mà còn là những thông điệp tích cực về cuộc sống và giá trị nhân sinh.', '2022-12-18 20:03:34', 0, 0, 0, '0:14', '/Uploads/Thumbnails/default.PNG', '/Uploads/Videos/16.mp4', 1),
	(2, 6, N'Nhà Xuất Bản Giáo Dục Việt Nam', N'Hãy gọi tên người sáng chế vĩ đại nhất', '2017-04-30 01:23:35', 0, 1512423, 0, '0:06', '/Uploads/Thumbnails/6.PNG', '/Uploads/Videos/17.mp4', 1),
	(2, 7, N'Tả cảnh hai bên bờ', N'Nêu cảm nghĩ của em về cảnh đó', '2016-04-06 03:00:53', 0, 1512423, 0, '0:06', '/Uploads/Thumbnails/1.PNG', '/Uploads/Videos/18.mp4', 1),
	(2, 8, N'văn miêu tả cảnh sông nước', N'Phe nào chuyền được 6 chuyền là thắng. Phe thua phải cõng phe thắng chạy dọc con sông suốt từ bến tắm đến tận gốc đa', '2022-10-13 01:48:05', 0, 1123141, 0, '0:06', '/Uploads/Thumbnails/3.PNG', '/Uploads/Videos/19.mp4', 1),
	(2, 9, N'đẹp bởi có con sông chảy qua làng', N'Quanh năm cần mẫn, dòng sông chở nặng phù sa bồi đắp cho ruộng lúa. Buổi sớm tinh mơ, dòng nước mờ mờ phẳng lặng chảy. Giữa trưa, mặt sông nhấp nhô ánh bạc lẫn màu xanh nước biếc. Chiều tà, dòng nước trở thành màu khói trong, hơi tối âm âm', '2022-12-13 13:48:45', 0, 414141123, 0, '0:06', '/Uploads/Thumbnails/4.PNG', '/Uploads/Videos/20.mp4', 1),
	(3, 10, N'Hai bên bờ sông, nhà cửa lô nhô', N'Dưới chân cầu, nơi con sông đổ ra biển là cầu Cá. Thuyền đi biển sơn hai màu xanh đỏ, đậu san sát gần một mỏm đá nối lên như hòn non bộ', '2017-04-30 01:23:35', 0, 1512423, 0, '0:06', '/Uploads/Thumbnails/8.PNG', '/Uploads/Videos/21.mp4', 1),
	(3, 11, N'Sáng sớm nhìn ra bờ sông', N'Nắng sớm mai lấp lóa như dát vàng mặt nước. Dòng sông vẫn cuồn cuộn chảy đỏ sậm phù sa, mang nặng nghĩa tình của con sông đối với người và đất miền Tây', '2022-11-04 07:47:07', 0, 1512423, 0, '0:06', '/Uploads/Thumbnails/1.PNG', '/Uploads/Videos/22.mp4', 1),
	(3, 12, N'Những buổi sáng đẹp trời', N'Những ngày nghỉ học, em được chị hai cho đi theo. Thuyền đi trong sương sớm, ngồi trên thuyền, các bà các chị không ngớt lời trò chuyện', '2022-11-05 07:47:07', 0, 1512423, 0, '0:06', '/Uploads/Thumbnails/4.PNG', '/Uploads/Videos/23.mp4', 1),
	(4, 13, N'Dòng sông vang lên tiếng người cười nói', N'Những tiếng hò, tiêng hát vang lên như gọi mặt trời thức dậy. Những ngày không đi chợ cùng chị, em lại cùng các bạn đi cào hến, dậm trai ở ven sông', '2022-11-25 11:30:38', 0, 25852, 0, '0:06', '/Uploads/Thumbnails/1.PNG', '/Uploads/Videos/24.mp4', 1),
	(4, 14, N'đoạn văn miêu tả cảnh sông nước', N'Mỗi sớm mai, mặt sông phẳng lặng như gương. Dòng sông giống hệt dải lụa mềm mại trải dài tít tắp', '2022-12-10 06:07:49', 0, 124224, 0, '0:06', '/Uploads/Thumbnails/default.PNG', '/Uploads/Videos/25.mp4', 1),
	(4, 15, N'Nàng tiên Ốc', N'Tuổi cao, ốm yếu, sống một mình, hàng ngày mò cua bắt ốc sống qua ngày', '2022-11-25 06:33:09', 0, 3117, 0, '0:06', '/Uploads/Thumbnails/4.PNG', '/Uploads/Videos/26.mp4', 1),
	(5, 3, N'Dưới thời Hùng Vương', N'người Lạc Việt đã có những nét đặc trưng riêng về cuộc sống ăn, ở, sinh hoạt lễ hội. Thông qua các hiện vật của người xưa để lại', '2022-10-20 10:49:34', 0, 108693420, 0, '0:06', '/Uploads/Thumbnails/9.PNG', '/Uploads/Videos/27.mp4', 1),
	(5, 4, N'Sở thích của tôi là nghe nhạc', N'Tôi thích xem những bộ phim sitcom của Mỹ như How I met your mother, Once upon a time, Sabrina', '2022-08-25 01:35:48', 0, 6044, 0, '0:06', '/Uploads/Thumbnails/2.PNG', '/Uploads/Videos/28.mp4', 1),
	(5, 5, N'Sự bó buộc của xã hội phong kiến', N'sự tàn ác của những thế lực đen tối đã khiến cho cuộc đời của họ đầy những chông gai, sóng gió', '2022-08-05 06:34:59', 0, 12, 0, '0:06', '/Uploads/Thumbnails/5.PNG', '/Uploads/Videos/29.mp4', 1),
	(6, 6, N'HEllo', N'asdfsw', '2022-09-23 13:54:56', 0, 5467, 0, '0:06', '/Uploads/Thumbnails/10.PNG', '/Uploads/Videos/30.mp4', 1),
	(6, 7, N'More video', N'Bad tuber', '2022-03-05 05:07:08', 0, 12308, 0, '0:06', '/Uploads/Thumbnails/1.PNG', '/Uploads/Videos/31.mp4', 1),
	(6, 8, N'hello everyone', N'chungus', '2022-06-11 23:17:51', 0, 402952, 0, '0:06', '/Uploads/Thumbnails/4.PNG', '/Uploads/Videos/32.mp4', 1),
	(6, 9, N'what is this', N'new vid', '2022-06-16 14:04:42', 0, 758544, 0, '0:06', '/Uploads/Thumbnails/5.PNG', '/Uploads/Videos/33.mp4', 1),
	(7, 10, N'Tình mẫu thứ vô cùng đáng trân trọng', N'Chúng ta sinh ra sẽ thật may mắn và hạnh phúc nếu được sống trong sự yêu thương của những người thân', '2017-04-30 01:23:35', 0, 5939, 0, '0:06', '/Uploads/Thumbnails/10.PNG', '/Uploads/Videos/34.mp4', 1),
	(7, 11, N'Và trên hành trình trưởng thành từ những bước đi nhỏ bé đầu', N'Quả là, con dù lớn vẫn là con của mẹ – vẫn bé bỏng đối với mẹ và cần được che chở. Nhờ có tình mẫu tử mà con người có', '2011-04-30 01:23:35', 0, 1241, 0, '0:06', '/Uploads/Thumbnails/9.PNG', '/Uploads/Videos/35.mp4', 1),
	(7, 12, N'Đoạn Văn Tả Ngôi Trường', N'Ngôi trường của em đang học là ngôi trường nằm ở ngoại thành thành phố mang tên Bác, em yêu quý trường của em và em đến đây để học hằng ngày.', '2022-04-30 01:23:35', 0, 414123, 0, '0:06', '/Uploads/Thumbnails/8.PNG', '/Uploads/Videos/36.mp4', 1),
	(8, 13, N'Ba mẹ em nói là đi', N'học con phải ngoan và làm theo lời cô giáo dặn', '2022-12-10 04:32:58', 0, 1241211, 0, '0:06', '/Uploads/Thumbnails/7.PNG', '/Uploads/Videos/37.mp4', 1),
	(9, 14, N'Đại dịch COVID-19 đã và đang tiếp tục là một thách thức đặc biệt không chỉ với riêng Việt Nam', N'sự vào cuộc quyết liệt, không', '2022-05-16 13:11:21', 0, 1099052, 0, '0:06', '/Uploads/Thumbnails/5.PNG', '/Uploads/Videos/38.mp4', 1),
	(9, 15, N'Nhưng chính trong thời điểm này', N'Hằng ngày, em đến trường bằng chiếc xe đạp cũ của mẹ cho', '2022-01-15 08:32:16', 0, 54438, 0, '0:06', '/Uploads/Thumbnails/4.PNG', '/Uploads/Videos/39.mp4', 1),
	(9, 1, N'Yên xe được thay mới nên rất êm', N'Xe còn có giỏ phía trước để em đựng cặp khi đi học. Xích xe quay đều kêu rè rè nhưng xe đạp rất nhẹ', '2022-03-19 18:38:18', 0, 554526, 0, '0:06', '/Uploads/Thumbnails/3.PNG', '/Uploads/Videos/40.mp4', 1),
	(9, 2, N'Văn Tả Đồ Vật', N'Các bạn của em đều thích chiếc xe đạp này. Em rất tự hào đã tự mình đến trường bằng xe đạp, không phiền bố mẹ phải đưa đón', '2022-04-23 13:09:34', 0, 5529023, 0, '0:06', '/Uploads/Thumbnails/2.PNG', '/Uploads/Videos/41.mp4', 1),
	(10, 3, N'Ngôi trường của em đang học có nhiều bóng', N'Khi mùa thu về', '2022-07-03 16:30:34', 0, 796730, 0, '0:06', '/Uploads/Thumbnails/2.PNG', '/Uploads/Videos/42.mp4', 1),
	(10, 4, N'Phía xa ngoài cánh đồng', N'Không khí mùa thu khiến cho con người cảm thấy thật dễ chịu, nhẹ nhàng. Không dừng lại ở đó, mùa thu còn có những kí ức đẹp đẽ của tuổi thơ tôi', '2022-10-10 04:26:56', 0, 8145474, 0, '0:06', '/Uploads/Thumbnails/3.PNG', '/Uploads/Videos/43.mp4', 1),
	(10, 5, N'Đó là đêm trăng Trung thu', N'Tình mẫu thứ vô cùng đáng trân trọng', '2022-11-09 01:41:38', 0, 3990961, 0, '0:06', '/Uploads/Thumbnails/4.PNG', '/Uploads/Videos/44.mp4', 1),
	(10, 6, N'Chúng ta sinh ra sẽ thật may mắn và hạnh phúc nếu được sống trong sự yêu thương của những người thân', N'Và trên hành trình trưởng thành từ những bước đi nhỏ bé đầu tiên đến những', '2022-03-28 09:52:00', 0, 461, 0, '0:06', '/Uploads/Thumbnails/5.PNG', '/Uploads/Videos/45.mp4', 1),
	(11, 10, N'Khi chúng ta mắc sai lầm', N'Ngôi trường của em đang học là ngôi trường nằm ở ngoại thành thành phố mang tên Bác, em yêu quý trường của em và em đến đây để học hằng ngày', '2022-02-13 06:38:18', 0, 231, 0, '0:06', '/Uploads/Thumbnails/6.PNG', '/Uploads/Videos/46.mp4', 1),
	(11, 12, N'Ở sân trường được thầy cô', N'Ba mẹ em nói là đi học con phải ngoan', '2022-01-25 09:08:21', 0, 215, 0, '0:06', '/Uploads/Thumbnails/4.PNG', '/Uploads/Videos/47.mp4', 1),
	(11, 11, N'Đại dịch COVID-19 đã và đang tiếp tục', N'Đại dịch COVID-19 đã và đang đe dọa nghiêm trọng an toàn và sức khỏe', '2022-05-26 04:53:39', 0, 121, 0, '0:06', '/Uploads/Thumbnails/2.PNG', '/Uploads/Videos/48.mp4', 1),
	(4, 2, N'Xin con đừng đi', N'Cô gái biết ơn bà lão đã cứu mạng mình lại cảm thương số phận của bà nên đã đồng ý ở lại cùng bà', '2022-11-03 12:35:14', 0, 62670, 0, '0:06', '/Uploads/Thumbnails/1.PNG', '/Uploads/Videos/49.mp4', 1),
	(4, 2, N'Hội Của Người Lạc Việt Thời Hùng Vương', N'Viết Một Đoạn Văn Ngắn Nói Về Cuộc Sống Ăn Ở Sinh Hoạt Lễ Hội Của Người Lạc Việt Thời Hùng Vương, đón đọc mẫu văn sau để trau dồi thêm cho mình kiến thức hay.', '2022-12-11 01:20:30', 0, 101929, 0, '0:06', '/Uploads/Thumbnails/5.PNG', '/Uploads/Videos/50.mp4', 1);

CREATE TABLE [HomeMenuType]
(
	[id] INT IDENTITY(1,1),
	[name] NVARCHAR(30) NOT NULL,
	CONSTRAINT HomeMenuType_PK PRIMARY KEY([id])
)
INSERT INTO [HomeMenuType] ([name]) VALUES
	(N'Footer 1'),
	(N'Footer 2'),
	(N'Copyright'),
	(N'Logo');

CREATE TABLE [HomeMenu]
(
	[id] INT IDENTITY(1,1),
	[name] NVARCHAR(30) NOT NULL,
	[link] VARCHAR(MAX),
	[meta] VARCHAR(50) NOT NULL,
	[hide] BIT DEFAULT 0,
	[order] INT DEFAULT 0,
	[type_id] INT NOT NULL,
	[datebegin] SMALLDATETIME DEFAULT GETDATE(),
	CONSTRAINT HomeMenu_PK PRIMARY KEY([id]),
	CONSTRAINT HomeMenu_Meta_U UNIQUE([meta]),
	CONSTRAINT HomeMenu_Type_FK FOREIGN KEY([type_id]) REFERENCES [HomeMenuType]([id])
)

-- Dữ liệu tạm để test.
INSERT INTO [HomeMenu] ([name], [link], [meta], [type_id]) VALUES
	(N'Giới thiệu', 'link', 'about', 1),
	(N'Báo chí', 'link', 'press', 1),
	(N'Bản quyền', 'link', 'copyright', 1),
	(N'Liên hệ với chúng tôi', 'link', 'contactus', 1),
	(N'Người sáng tạo', 'link', 'creator', 1),
	(N'Quảng cáo', 'link', 'ads', 1),
	(N'Nhà phát triển', 'link', 'dev?', 1),
	(N'Điều khoản', 'link', 'terms', 2),
	(N'Quyền riêng tư', 'link', 'privacy', 2),
	(N'Chính sách và an toàn', 'link', 'policies', 2),
	(N'Cách YouTube hoạt động', 'link', 'howyoutubework', 2),
	(N'Thử các tính năng mới', 'link', 'new', 2),
	(N'© 2023 Google LLC', 'link', 'tempcopyright', 3),
	(N'LogoLinkHere?', 'link', 'templogo', 4);

CREATE TABLE [AdminMenu]
(
	[id] INT IDENTITY(1,1),
	[name] NVARCHAR(40) NOT NULL,
	[meta] VARCHAR(50) NOT NULL,
	[hide] BIT DEFAULT 0,
	[order] INT DEFAULT 0,
	[datebegin] SMALLDATETIME DEFAULT GETDATE(),
	CONSTRAINT AdminMenu_PK PRIMARY KEY([id]),
	CONSTRAINT AdminMenu_Meta_U UNIQUE([meta])
)

INSERT INTO AdminMenu ([name], [meta]) VALUES 
	(N'Quản lý Video','videos'),
	(N'Quản lý Người dùng', 'users'),
	(N'Quản lý Tag', 'tags');

GO
SELECT * FROM [Role]
SELECT * FROM [User]
SELECT * FROM [Tag]
SELECT * FROM [Video]
SELECT * FROM [HomeMenuType]
SELECT * FROM [HomeMenu]
SELECT * FROM [AdminMenu]