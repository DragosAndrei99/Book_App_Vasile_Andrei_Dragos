USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spBookSelect]    Script Date: 09.04.2024 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBookSelect] 
	-- Add the parameters for the stored procedure here
	@BookId int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [BookId]
      ,[dbo].[BookType].Name AS BookTypeName
      ,[dbo].[Publisher].Name AS PublisherName
      ,[Title]
      ,[PublishYear]
      ,[Stock]
      --,[Active]
  FROM [dbo].[Book]
  INNER JOIN 
	[dbo].[BookType] ON [dbo].[Book].BookTypeId = [dbo].[BookType].BookTypeId
  INNER JOIN 
	[dbo].[Publisher] ON [dbo].[Book].PublisherId = [dbo].[Publisher].PublisherId
  WHERE BookId = @BookId

END
GO
