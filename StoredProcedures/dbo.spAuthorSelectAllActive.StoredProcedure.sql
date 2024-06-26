USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spAuthorSelectAllActive]    Script Date: 09.04.2024 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAuthorSelectAllActive] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [AuthorId]
      ,[FirstName]
      ,[LastName]
      ,[BirthDate]
      ,[Active]
  FROM [dbo].[Author]
  WHERE Active = 1
END
GO
