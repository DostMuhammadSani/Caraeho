
 CREATE DATABASE CareahoDB;
  CREATE DATABASE CareahoAuth;


Create Table Persons(
Id varchar(50) Primary Key,
Name varchar(50),
Email varchar(50),
Phone varchar(50)
)

Create Proc SavePerson
@Id varchar(50),
@Name varchar(50),
@Email varchar(50),
@Phone varchar(50)
As
Begin
Insert into Persons values (@Id,@Name,@Email,@Phone);
End



Create Table Company(
CID varchar(50) Primary Key,
CName varchar(50),
City varchar(50),
PID varchar(50),
CType varchar(50),
FOREIGN KEY (PID) REFERENCES Persons(Id)
On Delete Cascade
)

Create Table SocialMedia(
CID varchar(50) Primary Key,
Website varchar(100),
Facebook varchar(100),
Instagram varchar(100),
FOREIGN KEY (CID) REFERENCES Company(CID)
On Delete Cascade
)

Create Table Branch(
BID varchar(50) Primary Key,
BName varchar(100),
BAddress varchar(100),
City varchar(100),
CID varchar(50),
Area varchar(100),
FOREIGN KEY (CID) REFERENCES Company(CID)
On Delete Cascade
)


Create Table Manager(
MID varchar(50) Primary Key,
MName varchar(100),
Email varchar(100),
Contact varchar(100),
BID varchar(50),
FOREIGN KEY (BID) REFERENCES Branch(BID)
On Delete Cascade
)




Create Proc SaveCompany
@CID varchar(50) ,
@CName varchar(50),
@City varchar(50),
@PID varchar(50),
@CType varchar(50)
as begin
Insert Into Company Values(@CID,@CName,@City,@PID,@CType);
End

Create Proc GetCompany

as begin
Select * from Company ;
End

Select * from Persons

Create Proc GetPersonsID 
@Email varchar(50)
as begin
Select ID from Persons where Email=@Email
End

Create Proc UpdateCompany
@CID varchar(50) ,
@CName varchar(50),
@City varchar(50),
@CType varchar(50)
as begin
Update Company set CName=@CName,City=@City,CType=@CType where CID=@CID ;
End

Create Proc DeleteCompany
@CID varchar(50) 
as begin
Delete Company where CID=@CID;
end

Create Proc GetCompanyPerson
@PID varchar (50)
as begin
Select * from Company where PID=@PID;
End


Create Proc SaveSocial
@CID varchar(50) ,
@Website varchar(50),
@Facebook varchar(50),
@Instagram varchar(50)
as begin
Insert Into SocialMedia Values(@CID,@Website,@Facebook,@Instagram);
End

Create Proc GetSocialMedia
@CID varchar(50) 
as begin
Select * from SocialMedia where CID=@CID ;
End

Create Proc UpdateSocial
@CID varchar(50) ,
@Website varchar(50),
@Facebook varchar(50),
@Instagram varchar(50)
as begin
Update SocialMedia set Website=@Website,Facebook=@Facebook,Instagram=@Instagram where CID=@CID ;
End

CREATE PROC SaveBranch
    @BID varchar(50),
    @BName varchar(100),
    @BAddress varchar(100),
    @City varchar(100),
    @CID varchar(50),
	@Area varchar(100)
AS
BEGIN
    INSERT INTO Branch (BID, BName, BAddress, City, CID,Area)
    VALUES (@BID, @BName, @BAddress, @City, @CID,@Area);
END

CREATE PROC GetBranch
AS
BEGIN
    SELECT * FROM Branch;
END

CREATE PROC UpdateBranch
    @BID varchar(50),
    @BName varchar(100),
    @BAddress varchar(100),
    @City varchar(100),
	@Area varchar(100)

AS
BEGIN
    UPDATE Branch
    SET BName = @BName, BAddress = @BAddress, City = @City, Area=@Area
    WHERE BID = @BID;
END

CREATE PROC DeleteBranch
    @BID varchar(50)
AS
BEGIN
    DELETE FROM Branch
    WHERE BID = @BID;
END

Create Proc CompanyID 
@CName varchar(50)
as begin
Select CID from Company where CName=@CName
End

CREATE PROC GetBranchManager
@Email varchar(50)
AS
BEGIN
    SELECT * FROM Branch where BID=(Select BID from Manager where Email=@Email) ;
END

Create Proc GetBranchPersons
@PID varchar (50)
as begin
Select * from Branch where CID in (Select CID from Company where PID=@PID);
End

CREATE PROCEDURE InsertManager
    @MID varchar(50),
    @MName varchar(100),
    @Email varchar(100),
    @Contact varchar(100),
    @BID varchar(50)
AS
BEGIN
    INSERT INTO Manager (MID, MName, Email, Contact, BID)
    VALUES (@MID, @MName, @Email, @Contact, @BID);
END


CREATE PROCEDURE UpdateManagers
    @MID varchar(50),
    @MName varchar(100),
    @Email varchar(100),
    @Contact varchar(100)
   
AS
BEGIN
    UPDATE Manager
    SET MName = @MName,
        Email = @Email,
        Contact = @Contact
    WHERE MID = @MID;
END

CREATE PROCEDURE SelectManagers
  @PID varchar(50)
AS
BEGIN
    SELECT *
    FROM Manager
    WHERE BID in(Select BID from Branch where CID in (Select CID from Company where PID=@PID));
END
CREATE PROCEDURE DeleteManager
    @MID varchar(50)
AS
BEGIN
    DELETE FROM Manager
    WHERE MID = @MID;
END


Select * from [dbo].[AspNetUsers]

Select * from Manager;

Delete from [dbo].[AspNetUsers] where Email!='dostmuhammadsani@gmail.com'


Create Table Category(
Cat_ID varchar(50) Primary Key,
Title varchar(50),
BID varchar(50),
FOREIGN KEY (BID) REFERENCES Branch(BID)
On Delete Cascade

)


Create Table Menu(
Menu_ID varchar(50) Primary Key,
Item varchar(50),
Quantity varchar(50),
Serving varchar(50),
Price varchar(50), 
Cat_ID varchar(50),
FOREIGN KEY (Cat_ID) REFERENCES Category(Cat_ID)
On Delete Cascade
)

Create Table Ingredient(
IID varchar(50) Primary Key,
Title varchar(50),
Ammount varchar(50),
Menu_ID varchar(50),
FOREIGN KEY (Menu_ID) REFERENCES Menu(Menu_ID)
On Delete Cascade
)

Create Table Nutrition(
NID varchar(50) Primary Key,
Title varchar(50),
Ammount varchar(50),
Menu_ID varchar(50),
FOREIGN KEY (Menu_ID) REFERENCES Menu(Menu_ID)
On Delete Cascade
)


CREATE PROCEDURE InsertCategory
    @Cat_ID varchar(50),
    @Title varchar(50),
    @BID varchar(50)
AS
BEGIN
    INSERT INTO Category (Cat_ID, Title, BID)
    VALUES (@Cat_ID, @Title, @BID);
END

CREATE PROCEDURE UpdateCategory
    @Cat_ID varchar(50),
    @Title varchar(50),
    @BID varchar(50)
AS
BEGIN
    UPDATE Category
    SET Title = @Title,
        BID = @BID
    WHERE Cat_ID = @Cat_ID;
END

CREATE PROCEDURE DeleteCategory
    @Cat_ID varchar(50)
AS
BEGIN
    DELETE FROM Category
    WHERE Cat_ID = @Cat_ID;
END

CREATE PROCEDURE GetCategory
    @BID varchar(50)
AS
BEGIN
   Select * FROM Category
    WHERE BID = @BID;
END


CREATE PROCEDURE InsertMenu
    @Menu_ID varchar(50),
    @Item varchar(50),
    @Quantity varchar(50),
    @Serving varchar(50),
    @Price varchar(50),
    @Cat_ID varchar(50)
AS
BEGIN
    INSERT INTO Menu (Menu_ID, Item, Quantity, Serving, Price, Cat_ID)
    VALUES (@Menu_ID, @Item, @Quantity, @Serving, @Price, @Cat_ID);
END

CREATE PROCEDURE UpdateMenu
    @Menu_ID varchar(50),
    @Item varchar(50),
    @Quantity varchar(50),
    @Serving varchar(50),
    @Price varchar(50),
    @Cat_ID varchar(50)
AS
BEGIN
    UPDATE Menu
    SET Item = @Item,
        Quantity = @Quantity,
        Serving = @Serving,
        Price = @Price,
        Cat_ID = @Cat_ID
    WHERE Menu_ID = @Menu_ID;
END

CREATE PROCEDURE DeleteMenu
    @Menu_ID varchar(50)
AS
BEGIN
    DELETE FROM Menu
    WHERE Menu_ID = @Menu_ID;
END

CREATE PROCEDURE GETMENU
 @Cat_ID varchar(50)
 AS BEGIN
 SELECT * FROM Menu WHERE Cat_ID=@Cat_ID
 END

 CREATE PROCEDURE InsertIngredient
    @IID varchar(50),
    @Title varchar(50),
    @Ammount varchar(50),
    @Menu_ID varchar(50)
AS
BEGIN
    INSERT INTO Ingredient (IID, Title, Ammount, Menu_ID)
    VALUES (@IID, @Title, @Ammount, @Menu_ID);
END

CREATE PROCEDURE UpdateIngredient
    @IID varchar(50),
    @Title varchar(50),
    @Ammount varchar(50),
    @Menu_ID varchar(50)
AS
BEGIN
    UPDATE Ingredient
    SET Title = @Title,
        Ammount = @Ammount,
        Menu_ID = @Menu_ID
    WHERE IID = @IID;
END


CREATE PROCEDURE DeleteIngredient
    @IID varchar(50)
AS
BEGIN
    DELETE FROM Ingredient
    WHERE IID = @IID;
END

CREATE PROCEDURE GetIngredientsByMenuID
    @Menu_ID varchar(50)
AS
BEGIN
    SELECT * FROM Ingredient WHERE Menu_ID = @Menu_ID;
END


CREATE PROCEDURE InsertNutrition
    @NID VARCHAR(50),
    @Title VARCHAR(50),
    @Ammount VARCHAR(50),
    @Menu_ID VARCHAR(50)
AS
BEGIN
 

    INSERT INTO Nutrition (NID, Title, Ammount, Menu_ID)
    VALUES (@NID, @Title, @Ammount, @Menu_ID);
END;

CREATE PROCEDURE UpdateNutrition
    @NID VARCHAR(50),
    @Title VARCHAR(50),
    @Ammount VARCHAR(50),
    @Menu_ID VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Nutrition
    SET Title = @Title,
        Ammount = @Ammount,
        Menu_ID = @Menu_ID
    WHERE NID = @NID;
END;

CREATE PROCEDURE DeleteNutrition
    @NID VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Nutrition
    WHERE NID = @NID;
END;

CREATE PROCEDURE GetNutrition
    @Menu_ID VARCHAR(50)
AS
BEGIN
 

    SELECT * 
    FROM Nutrition
    WHERE Menu_ID = @Menu_ID;
END;


Create Table Cuisine(
CuisineID varchar(50) Primary Key,
CuisineName varchar(50),
CuisineDescription varchar(1000),
BID varchar(50),
FOREIGN KEY (BID) REFERENCES Branch(BID)
On Delete Cascade

)

Create Table Ambiance(
AmbianceID varchar(50) Primary Key,
AmbianceName varchar(50),
AmbianceDescription varchar(1000),
BID varchar(50),
FOREIGN KEY (BID) REFERENCES Branch(BID)
On Delete Cascade

)

Create Table Seating(
SeatingID varchar(50) Primary Key,
SeatingType varchar(50),
BID varchar(50),
FOREIGN KEY (BID) REFERENCES Branch(BID)
On Delete Cascade

)

Create Table Event(
EventID varchar(50)Primary Key,
EventName varchar(50),
EventDescription varchar(1000),
BID varchar(50),
FOREIGN KEY (BID) REFERENCES Branch(BID)
On Delete Cascade

)

Create Table FoodType(
FoodTypeID varchar(50) Primary Key,
FoodTypeName varchar(50),
FoodTypeDescription varchar(1000),
BID varchar(50),
FOREIGN KEY (BID) REFERENCES Branch(BID)
On Delete Cascade

)


Create Proc CreateCuisine
@CuisineID varchar(50),
@CuisineName varchar(50),
@CuisineDescription varchar(1000),
@BID varchar(50)
As Begin
Insert into Cuisine values (@CuisineID,@CuisineName,@CuisineDescription,@BID)
End

Create Proc GetCuisine
@BID varchar(50)
As Begin
Select * from Cuisine where BID=@BID;
End

Create Proc UpdateCuisine
@CuisineID varchar(50),
@CuisineName varchar(50),
@CuisineDescription varchar(1000)
As Begin
Update Cuisine set CuisineName=@CuisineName,CuisineDescription=@CuisineDescription where CuisineID=@CuisineID;
End

Create Proc DeleteCuisine
@CuisineID varchar(50)
As Begin
 DELETE FROM Cuisine
    WHERE CuisineID = @CuisineID;
	End

	-- Create Ambiance
Create Proc CreateAmbiance
@AmbianceID varchar(50),
@AmbianceName varchar(50),
@AmbianceDescription varchar(1000),
@BID varchar(50)
As 
Begin
    Insert into Ambiance values (@AmbianceID, @AmbianceName, @AmbianceDescription, @BID);
End

-- Get Ambiance by Branch ID
Create Proc GetAmbiance
@BID varchar(50)
As 
Begin
    Select * from Ambiance where BID = @BID;
End

-- Update Ambiance
Create Proc UpdateAmbiance
@AmbianceID varchar(50),
@AmbianceName varchar(50),
@AmbianceDescription varchar(1000)
As 
Begin
    Update Ambiance set AmbianceName = @AmbianceName, AmbianceDescription = @AmbianceDescription where AmbianceID = @AmbianceID;
End

-- Delete Ambiance
Create Proc DeleteAmbiance
@AmbianceID varchar(50)
As 
Begin
    Delete from Ambiance where AmbianceID = @AmbianceID;
End

-- Create Seating
Create Proc CreateSeating
@SeatingID varchar(50),
@SeatingType varchar(50),
@BID varchar(50)
As 
Begin
    Insert into Seating values (@SeatingID, @SeatingType, @BID);
End

-- Get Seating by Branch ID
Create Proc GetSeating
@BID varchar(50)
As 
Begin
    Select * from Seating where BID = @BID;
End

-- Update Seating
Create Proc UpdateSeating
@SeatingID varchar(50),
@SeatingType varchar(50)
As 
Begin
    Update Seating set SeatingType = @SeatingType where SeatingID = @SeatingID;
End

-- Delete Seating
Create Proc DeleteSeating
@SeatingID varchar(50)
As 
Begin
    Delete from Seating where SeatingID = @SeatingID;
End

-- Create Event
Create Proc CreateEvent
@EventID varchar(50),
@EventName varchar(50),
@EventDescription varchar(1000),
@BID varchar(50)
As 
Begin
    Insert into Event values (@EventID, @EventName, @EventDescription, @BID);
End

-- Get Event by Branch ID
Create Proc GetEvent
@BID varchar(50)
As 
Begin
    Select * from Event where BID = @BID;
End

-- Update Event
Create Proc UpdateEvent
@EventID varchar(50),
@EventName varchar(50),
@EventDescription varchar(1000)
As 
Begin
    Update Event set EventName = @EventName, EventDescription = @EventDescription where EventID = @EventID;
End

-- Delete Event
Create Proc DeleteEvent
@EventID varchar(50)
As 
Begin
    Delete from Event where EventID = @EventID;
End

-- Create FoodType
Create Proc CreateFoodType
@FoodTypeID varchar(50),
@FoodTypeName varchar(50),
@FoodTypeDescription varchar(1000),
@BID varchar(50)
As 
Begin
    Insert into FoodType values (@FoodTypeID, @FoodTypeName, @FoodTypeDescription, @BID);
End

-- Get FoodType by Branch ID
Create Proc GetFoodType
@BID varchar(50)
As 
Begin
    Select * from FoodType where BID = @BID;
End

-- Update FoodType
Create Proc UpdateFoodType
@FoodTypeID varchar(50),
@FoodTypeName varchar(50),
@FoodTypeDescription varchar(1000)
As 
Begin
    Update FoodType set FoodTypeName = @FoodTypeName, FoodTypeDescription = @FoodTypeDescription where FoodTypeID = @FoodTypeID;
End

-- Delete FoodType
Create Proc DeleteFoodType
@FoodTypeID varchar(50)
As 
Begin
    Delete from FoodType where FoodTypeID = @FoodTypeID;
End

