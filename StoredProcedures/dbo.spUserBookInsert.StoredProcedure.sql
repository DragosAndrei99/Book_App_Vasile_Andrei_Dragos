USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spUserBookInsert]    Script Date: 09.04.2024 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUserBookInsert]
	-- Add the parameters for the stored procedure here
	@FirstName nvarchar(50)
	,@LastName nvarchar(500)
	,@Title  nvarchar(100)
	,@StartDate date
	,@ReturnDate date = null

AS
BEGIN

-- Get UserId for the provided FirstName and LastName
DECLARE @UserId int;
SELECT @UserId = UserId FROM [dbo].[User] WHERE FirstName = @FirstName AND LastName = @LastName;

-- Get BookId for the provided Title
DECLARE @BookId int;
SELECT @BookId = BookId FROM [dbo].Book WHERE Title = @Title;
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].UserBook
	([UserId]
	,[BookId]
	,[StartDate]
	,[ReturnDate])
	OUTPUT inserted.BookId
	VALUES 
		(@UserId, @BookId, @StartDate, @ReturnDate)
END
GO
