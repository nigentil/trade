USE trade
go 

create table trade
(
	IdTrade int identity(1,1) not null primary key,
	Value decimal(18,4),
	ClientSector varchar(20),
	Risk varchar(20)
)
GO

CREATE NONCLUSTERED INDEX IX_trade_ValueClientSector ON Trade (Value, ClientSector)
GO

CREATE  PROCEDURE SP_INSERT_TRADE
(
	@Value FLOAT,
	@ClientSector varchar(20)
)
AS

	INSERT INTO trade(Value, ClientSector)
	VALUES (@Value, @ClientSector)
GO

EXEC SP_INSERT_TRADE 2000000.00, 'Private'
EXEC SP_INSERT_TRADE 400000.00, 'Public'
EXEC SP_INSERT_TRADE 500000.00, 'Public'
EXEC SP_INSERT_TRADE 3000000.00, 'Public'
GO

CREATE FUNCTION DBO.FN_GETRISK 
( 
	@Value DECIMAL(18,4),
	@ClientSector varchar(20)
)
RETURNS VARCHAR(20)
AS
BEGIN
	
	DECLARE @MyReturn VARCHAR(20)

	IF (@Value < 1000000 AND @ClientSector = 'Public' )
		SET @MyReturn = 'LOWRISK'
	IF (@Value >= 1000000 AND @ClientSector = 'Public')
		SET @MyReturn = 'MEDIUMRISK'
	ELSE
		SET @MyReturn = 'HIGHRISK'

	RETURN  @MyReturn  

END
GO

ALTER PROCEDURE SP_UPDATE_TRADE_RISK
AS

	UPDATE trade
		SET Risk = DBO.FN_GETRISK(Value, ClientSector)
GO

EXEC SP_UPDATE_TRADE_RISK

SELECT * FROM trade