CREATE PROCEDURE [dbo].[PR_LOC_City_SelectAll]
AS 
SELECT
		[dbo].[City].[CityID],
		[dbo].[City].[StateID],
		[dbo].[Country].CountryID,
		[dbo].[Country].[CountryName],
		[dbo].[State].[StateName],
		[dbo].[State].[StateCode],
		[dbo].[City].[CreatedDate],
		[dbo].[City].[ModifiedDate],
		[dbo].[City].[CityName],
		[dbo].[City].[CityCode]
		
FROM [dbo].[City]
LEFT OUTER JOIN [dbo].[State]
ON [dbo].[State].[StateID] = [dbo].[City].[StateID]
LEFT OUTER JOIN [dbo].[Country]
ON [dbo].[Country].[CountryID] = [dbo].[State].[CountryID]



CREATE PROCEDURE PR_LOC_City_SelectByPK
    @CityID INT
AS
BEGIN
    SELECT CityID, CityName, StateID, CountryID, CityCode
    FROM City
    WHERE CityID = @CityID
END


ALTER PROCEDURE PR_LOC_City_Insert
    @CityName NVARCHAR(100),
    @CityCode NVARCHAR(10),
    @StateID INT,
    @CountryID INT
AS
BEGIN
    INSERT INTO City (CityName, CityCode, StateID, CountryID)
    VALUES (@CityName, @CityCode, @StateID, @CountryID);
END

ALTER PROCEDURE PR_LOC_City_Update
    @CityID INT,
    @CityName NVARCHAR(100),
    @CityCode NVARCHAR(10),
    @StateID INT,
    @CountryID INT
AS
BEGIN
    UPDATE City
    SET CityName = @CityName,
        CityCode = @CityCode,
        StateID = @StateID,
        CountryID = @CountryID,
        ModifiedDate = GETDATE()
    WHERE CityID = @CityID;
END


CREATE PROCEDURE PR_LOC_City_Delete
    @CityID INT
AS
BEGIN
    DELETE FROM City
    WHERE CityID = @CityID
END


----------------------------------------------------------

CREATE PROCEDURE [dbo].[PR_Country_SelectAll]
AS
BEGIN
    SELECT [Country].CountryID, 
           [Country].CountryName, 
		   [Country].CountryCode, 
		   [Country].CreatedDate,
		   [Country].ModifiedDate
    FROM [Country] 
    ORDER BY [Country].CountryName
END


-----------------------------------------------------


CREATE PROCEDURE [dbo].[PR_State_SelectAll]
AS
BEGIN
    SELECT	[State].StateID, 
			[State].CountryID,
			[State].StateName, 
			[State].StateCode, 
			[State].CreatedDate,
			[State].ModifiedDate
    FROM [State] 
	INNER JOIN [Country] ON [Country].CountryID = [State].CountryID
    ORDER BY [State].StateName
END


--------------------------------

CREATE PROCEDURE [dbo].[PR_LOC_Country_SelectComboBox]
AS 
SELECT
    COUNTRYID,
    COUNTRYNAME
FROM COUNTRY
ORDER BY COUNTRYNAME

--------------------------------------------------

CREATE PROCEDURE [dbo].[PR_LOC_State_SelectComboBoxByCountryID]
@CountryID INT
AS 
SELECT
    [dbo].[State].[StateID],
    [dbo].[State].[StateName]
FROM [dbo].[State]
WHERE [dbo].[State].[CountryID] = @CountryID


--------------------------------------------------

CREATE PROCEDURE [PR_City_Count]
AS
BEGIN 
		SELECT COUNT([City].CityID) as 'Count'
		FROM [City]
END


CREATE PROCEDURE [dbo].[PR_Country_Count]
AS
BEGIN 
		SELECT COUNT([Country].CountryID) as 'CountryCount'
		FROM [Country]
END

CREATE PROCEDURE [dbo].[PR_State_Count]
AS
BEGIN 
		SELECT COUNT([State].StateID) as 'StateCount'
		FROM [State]
END 


------------------------------------------------

CREATE PROCEDURE PR_Country_StateCount
AS
BEGIN
    SELECT 
        C.CountryName, 
        COUNT(S.StateID) AS TotalState
    FROM Country C
    LEFT JOIN State S ON C.CountryID = S.CountryID
    GROUP BY C.CountryName
END
