USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spAuthorBookInsert]    Script Date: 09.04.2024 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAuthorBookInsert]
	-- Add the parameters for the stored procedure here
	@AuthorId int
	,@BookId int
	,@NumberInList int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].AuthorBook
           (AuthorId
           ,BookId
		   ,NumberInList)
     VALUES
           (@AuthorId, @BookId, @NumberInList)
END
GO
