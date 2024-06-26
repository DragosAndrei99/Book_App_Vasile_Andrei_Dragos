USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spAuthorInsert]    Script Date: 09.04.2024 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAuthorInsert]
	-- Add the parameters for the stored procedure here
	@FirstName nvarchar(50)
	,@LastName nvarchar(50)
	,@BirthDate date = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
INSERT INTO [dbo].[Author]
           ([FirstName]
           ,[LastName]
		   ,[BirthDate])
     VALUES
           (@FirstName, @LastName, @BirthDate)
END
GO
