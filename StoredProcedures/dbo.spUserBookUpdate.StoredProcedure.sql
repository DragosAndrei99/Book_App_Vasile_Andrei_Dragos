USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spUserBookUpdate]    Script Date: 09.04.2024 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUserBookUpdate]
	-- Add the parameters for the stored procedure here
	@Id int
	,@BookId int
	,@FirstName nvarchar(50)
	,@LastName nvarchar(500)
	,@StartDate date
	,@ReturnDate date = null
AS
BEGIN
-- Get UserId for the provided FirstName and LastName
DECLARE @UserId int;
SELECT @UserId = UserId FROM [dbo].[User] WHERE FirstName = @FirstName AND LastName = @LastName;


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [dbo].UserBook
SET UserId = @UserId, BookId = @BookId, StartDate = @StartDate, ReturnDate = @ReturnDate
OUTPUT inserted.BookId
WHERE Id = @Id
END
GO
