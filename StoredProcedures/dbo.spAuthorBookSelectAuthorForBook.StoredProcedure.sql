USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spAuthorBookSelectAuthorForBook]    Script Date: 09.04.2024 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAuthorBookSelectAuthorForBook]
	-- Add the parameters for the stored procedure here
	(@BookId int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Author.AuthorId, Author.FirstName , Author.LastName, AuthorBook.NumberInList
	FROM [dbo].Author
	INNER JOIN [dbo].AuthorBook ON [dbo].Author.AuthorId = [dbo].AuthorBook.AuthorId
	WHERE [dbo].Author.Active = 1
	AND AuthorBook.BookId = @BookId;
END
GO
