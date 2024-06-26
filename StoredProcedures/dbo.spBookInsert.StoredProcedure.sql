USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spBookInsert]    Script Date: 09.04.2024 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBookInsert]
	-- Add the parameters for the stored procedure here
	@PublisherName nvarchar(50)
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

INSERT INTO [dbo].[Book]
			([BookTypeId]
			,[PublisherId]
           ,[Title]
           ,[PublishYear]
		   ,[Stock])
     VALUES
           (@BookTypeId, @PublisherId, @Title ,@PublishYear, @Stock)
	SELECT CAST(scope_identity() AS int)
END
GO
