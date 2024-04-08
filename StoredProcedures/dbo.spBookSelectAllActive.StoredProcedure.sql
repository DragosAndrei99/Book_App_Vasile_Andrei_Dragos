USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spBookSelectAllActive]    Script Date: 08.04.2024 18:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBookSelectAllActive] 
	-- Add the parameters for the stored procedure here
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
      ,[dbo].[Book].[Active]
  FROM [dbo].[Book]
    INNER JOIN 
	[dbo].[BookType] ON [dbo].[Book].BookTypeId = [dbo].[BookType].BookTypeId
  INNER JOIN 
	[dbo].[Publisher] ON [dbo].[Book].PublisherId = [dbo].[Publisher].PublisherId
  WHERE [dbo].[Book].[Active]=1

END
GO
