 ALTER PROC Customer.Proc_Customer(
	@Flag            VARCHAR(100)  =NULL,
	@CustomerId		  BIGINT	  = Null 
 )
 AS 
 SET NOCOUNT ON
 BEGIN TRY
			IF @Flag='GetAllCustomer'
			BEGIN
						SELECT * FROM Customer.TBL_CustomerDetails CD(NOLOCK)
			END
			IF @Flag='CustomerLocation'
			BEGIN
						IF NOT EXISTS(SELECT 'a' FROM Customer.TBL_CustomerDetails CD(NOLOCK) WHERE CD.CustomerId=@CustomerId)
						BEGIN
								SELECT '101' AS Code , 'Invalid Customer' AS Message
								RETURN
						END
						IF NOT EXISTS(SELECT 'a' FROM Location.TBL_LocationDetail LD(NOLOCK) WHERE LD.CustomerId=@CustomerId)
						BEGIN
								SELECT '101' AS Code , 'Customer doest not have location' AS Message
								RETURN
						END
						SELECT CustomerName=CD.FullName,LD.Address,CD.Email,CD.PhoneNo FROM Customer.TBL_CustomerDetails CD(NOLOCK)
						INNER JOIN Location.TBL_LocationDetail LD(NOLOCK) ON LD.CustomerId=CD.CustomerId
						WHERE CD.CustomerId=@CustomerId
			END
 END TRY
 BEGIN CATCH
		IF @@TRANCOUNT>0
		BEGIN
				ROLLBACK TRANSACTION;
		END
		SELECT '101'AS Code,ERROR_MESSAGE()AS Message
 END CATCH