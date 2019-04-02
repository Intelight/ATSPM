
--  DROP PROCEDURE [dbo].[CreateConstraints]

CREATE PROCEDURE [dbo].[CreateConstraints]
@StagingTableName nvarchar(200) ,
@TableNumber int ,
@PartitionNumber int ,
@PartitionYear int,
@PartitionMonth int,
@Verbose int

AS

DECLARE @NumberOfTables int
DECLARE @Status int
DECLARE @Counter int
DECLARE @LowerBoundary datetime2(7)
DECLARE @LowerYear int
DECLARE @LowerMonth  int
DECLARE @UpperBoundary datetime2(7)
DECLARE @UpperYear int
DECLARE @UpperMonth int
DECLARE @PartitionNumberString nvarchar(50)
DECLARE @PartitionDate nvarchar(20)
DECLARE @IndexName varchar(50)
DECLARE @Dummy int
DECLARE @SQLSTATEMENT     nvarchar(4000)
DECLARE @CHK_Constrants  varchar(100)
DECLARE @MainTable nvarchar(200)
DECLARE @TableConstraintNumber int
DECLARE @TablePartitionProcessedsEntry int
DECLARE @MyTime datetime2(7)

Begin
	SET @MainTable = [dbo].[TableName] (@TableNumber)
	SET @IndexName = [dbo].[indexName] (@TableNumber , 1)
	SET @LowerBoundary = [dbo].[LowerBoundary](@MainTable , @IndexName , @PartitionNumber ) 
	SET @LowerYear = year (@LowerBoundary)
	SET @LowerMonth = month (@LowerBoundary)
	SET @UpperBoundary = [dbo].[UpperBoundary](@MainTable , @IndexName , @PartitionNumber )
	SET @UpperYear = year (@UpperBoundary)
	SET @UpperMonth = month (@UpperBoundary)
	set @CHK_Constrants = 'chk_' + @StagingTableName 
	SET @PartitionNumberString = 'Partition Number is ' + Convert (Varchar(5), @PartitionNumber)
	SELECT @TableConstraintNumber = Count (*)
	FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	WHERE CONSTRAINT_NAME = @CHK_Constrants 

	IF (@TableConstraintNumber = 0)
	BEGIN
		set @SQLSTATEMENT = 'ALTER TABLE [dbo].[' + @StagingTableName  + 
				']  WITH CHECK ADD CONSTRAINT [' + @CHK_Constrants + ']' + 
				' CHECK  ([Timestamp]>= N''' + CAST (@LowerYear AS nvarchar (4)) + '-' 
				+ CAST (@LowerMonth AS nvarchar (2)) + '-01T00:00:00'''
				+ 'AND [Timestamp]<N'''+ CAST (@UpperYear AS nvarchar (4)) + '-' 
				+ CAST (@UpperMonth  AS nvarchar (2))
				+ '-01T00:00:00'')'

		IF (@Verbose <>0)
		BEGIN
			EXEC	@Status  = [dbo].[VerboseStatus]
					@PartitionedTableName = @StagingTableName ,
					@PartitionName = @PartitionNumberString ,
					@PartitionYear = @PartitionYear ,
					@PartitionMonth = @PartitionMonth ,
					@SQLStatementOrMessage = @SQLSTATEMENT ,
					@FunctionOrProcedure = N'Create Constraints',
					@Notes = @CHK_Constrants 
		END
		EXEC sp_executesql @SQLSTATEMENT
	
		SET @SQLSTATEMENT = 'ALTER TABLE [dbo].[' + @StagingTableName + ']' +  
					'CHECK CONSTRAINT [' + @CHK_Constrants + ']'

		IF (@Verbose <>0)
		BEGIN
			EXEC	@Status  = [dbo].[VerboseStatus]
					@PartitionedTableName = @StagingTableName ,
					@PartitionName = @PartitionNumberString ,
					@PartitionYear = @PartitionYear ,
					@PartitionMonth = @PartitionMonth ,
					@SQLStatementOrMessage = @SQLSTATEMENT ,
					@FunctionOrProcedure = N'Create Constraints',
					@Notes = @CHK_Constrants 
		END
		EXEC sp_executesql @SQLSTATEMENT
	END
	IF (@TableConstraintNumber <> 0)
	BEGIN
		SELECT count(*)
		FROM [dbo].[TablePartitionProcesseds]
		WHERE SwapTableName = @StagingTableName 

		SET @MyTime = getdate()
		IF (@TablePartitionProcessedsEntry = 0)
		BEGIN
			INSERT INTO [dbo].[TablePartitionProcesseds] (
						 [SwapTableName]
						,[PartitionNumber]
						,[PartitionBeginYear]
						,[PartitionBeginMonth]
						,[FileGroupName]
						,[IndexRemoved]
						,[SwappedTableRemoved]
						,[TimeIndexdropped]
						,[TimeSwappedTableDropped]	)
			VALUES (
						  @StagingTableName 
						, @PartitionNumber
						, @PartitionYear  
						, @PartitionMonth  
						, @PartitionNumberString
						, 1
						, 0
						, @myTime
						, @MyTime )
		END
		IF (@TablePartitionProcessedsEntry = 1)
		BEGIN
			UPDATE [dbo].[TablePartitionProcesseds] 
				SET [IndexRemoved] = 1
					,[TimeIndexdropped] = @MyTime 
					,[TimeSwappedTableDropped] = @MyTime 
				WHERE SwapTableName = @SQLSTATEMENT 
					AND PartitionNumber = @PartitionNumber
					AND PartitionBeginYear = @PartitionYear  
					AND PartitionBeginMonth = @PartitionMonth  
					AND FileGroupName = @PartitionNumberString
		END
	END	

SET @Status = 1
Return @Status

END
GO


