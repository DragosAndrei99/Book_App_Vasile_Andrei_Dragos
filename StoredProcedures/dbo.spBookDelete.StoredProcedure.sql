USE [dbBooksDV]
GO
/****** Object:  StoredProcedure [dbo].[spBookDelete]    Script Date: 09.04.2024 15:02:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBookDelete]
	-- Add the parameters for the stored procedure here
	@BookId int
	,@Active bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].Book
SET Active = @Active
WHERE BookId = @BookId;
END
GO
