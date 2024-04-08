USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spPublisherSelectAllActive]    Script Date: 08.04.2024 18:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spPublisherSelectAllActive] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [PublisherId]
      ,[Name]
	  ,[Adress]
      ,[Active]
  FROM [dbo].[Publisher]
  WHERE Active = 1
END
GO
