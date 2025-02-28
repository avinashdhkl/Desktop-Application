CREATE TABLE  Logs.Tbl_Logs(
 RowId  BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
 UnqiueNo		VARCHAR(50)	NULL,
 Method			VARCHAR(50)	  NULL,
Action			 VARCHAR(50)	  NULL,
LogType			VARCHAR(50) NULL,
DB				VARCHAR(50)	  NULL,
Message			VARCHAR(Max) NULL,
Param			VARCHAR(Max)  NULL,
Response		VARCHAR(Max)  NULL,	
CreateDate		DATETIME	  Null

)
	 SELECT * FROM Logs.Tbl_Logs
--DROP TABLE Logs.Tbl_Logs
