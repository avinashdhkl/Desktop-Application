CREATE TABLE TBL_CustomerDetails(
RowId		INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
CustomerId		INTEGER     UNIQUE,
FullName		VARCHAR(100) NULL,
Email			VARCHAR(50) NULL,
PhoneNo			VARCHAR(20)	NULL,
CreatedDate		DATETIME	NULL,
UpdateDate		DATETIME	Null

)

