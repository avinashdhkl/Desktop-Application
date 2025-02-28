CREATE TABLE Location.TBL_LocationDetail(
LocationId		BIGINT  PRIMARY KEY IDENTITY NOT NULL,
CustomerId		BIGINT	NULL,
Address			VARCHAR(100),
CreatedDate		DATETIME,
UpdateDate		DATETIME

)