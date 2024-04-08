USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spAuthorDelete]    Script Date: 08.04.2024 11:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAuthorDelete] 
	-- Add the parameters for the stored procedure here
	@AuthorId int
	,@Active bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [dbo].Author
SET Active = @Active
WHERE AuthorId = @AuthorId;
END
GO
