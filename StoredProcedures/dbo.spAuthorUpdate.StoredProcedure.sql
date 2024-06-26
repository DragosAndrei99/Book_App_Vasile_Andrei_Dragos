USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spAuthorUpdate]    Script Date: 09.04.2024 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAuthorUpdate] 
	-- Add the parameters for the stored procedure here
	@AuthorId int
	,@FirstName nvarchar(50)
	,@LastName nvarchar(50)
	,@BirthDate date = null
	,@Active bit = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [dbo].Author
SET FirstName = @FirstName, LastName = @LastName, BirthDate= @BirthDate, Active = @Active
WHERE AuthorId = @AuthorId;
END
GO
