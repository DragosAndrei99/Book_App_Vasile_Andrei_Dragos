USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spUserBookSelect]    Script Date: 09.04.2024 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUserBookSelect] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	[Id]
	,[dbo].UserBook.[BookId]
	,[dbo].UserBook.UserId
	,[dbo].[User].FirstName as UserFirstName
	,[dbo].[User].LastName as UserLastName
	,[dbo].Book.Title as BookTitle
	,[StartDate]
	,[ReturnDate]
	FROM [dbo].UserBook
	INNER JOIN 
	[dbo].[Book] ON [dbo].[UserBook].BookId = [dbo].[Book].BookId
	INNER JOIN 
	[dbo].[User] ON [dbo].[UserBook].UserId = [dbo].[User].UserId
	WHERE Id = @Id
END
GO
