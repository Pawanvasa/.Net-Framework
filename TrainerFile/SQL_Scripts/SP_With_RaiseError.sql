USE [eShoppingCodi]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertDeptException]    Script Date: 10/10/2022 10:21:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   proc [dbo].[sp_InsertDeptException]
 @DeptNo int, @DeptNAme varchar(100), @Location varchar(100), @Capacity int
As
Begin
    begin try
		insert into Department (DeptNo, DeptName, Location,Capacity)
		values
	(@DeptNo,@DeptName,@Location,@Capacity);	
	End Try
	BEgin catch
		 select ERROR_NUMBER() as Error_Number,
		   ERROR_MESSAGE() as Error_Message,
		   ERROR_SEVERITY() as Error_Severity,
		   ERROR_STATE() as Error_State;

		   RAISERROR ('DeptNo is ALready Exist',16, 1000 );
   end catch
End
