USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spBookUpdate]    Script Date: 09.04.2024 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBookUpdate]
	-- Add the parameters for the stored procedure here
	@BookId int
	,@PublisherName nvarchar(50)
	,@BookTypeName nvarchar(50)
	,@Title nvarchar(100)
	,@PublishYear int
	,@Stock int
AS
BEGIN

-- Get BookTypeId for the provided BookType Name
DECLARE @BookTypeId INT;
SELECT @BookTypeId = BookTypeId FROM [dbo].BookType WHERE Name = @BookTypeName;

-- Get PublisherId for the provided Publisher Name
DECLARE @PublisherId INT;
SELECT @PublisherId = PublisherId FROM [dbo].Publisher WHERE Name = @PublisherName;
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].Book
SET BookTypeId = @BookTypeId, PublisherId = @PublisherId, Title= @Title, PublishYear = @PublishYear, Stock = @Stock
WHERE BookId = @BookId;
END
GO
