Select * from Persons;

Delete from Persons;

Delete from AspNetUsers;

Select * from AspNetUsers;


Create Table Company(
CID varchar(50) Primary Key,
CName varchar(50),
City varchar(50),
PID varchar(50),
FOREIGN KEY (PID) REFERENCES Persons(Id)

)

Create Table SocialMedia(
CID varchar(50) Primary Key,
Website varchar(100),
Facebook varchar(100),
Instagram varchar(100),
FOREIGN KEY (CID) REFERENCES Company(CID)
)

Create Table Branch(
BID varchar(50) Primary Key,
BName varchar(100),
BAddress varchar(100),
City varchar(100),
CID varchar(50),
FOREIGN KEY (CID) REFERENCES Company(CID)
)


Create Table Manager(
MID varchar(50) Primary Key,
MName varchar(100),
Email varchar(100),
Contact varchar(100),
BID varchar(50),
FOREIGN KEY (BID) REFERENCES Branch(BID)
)




Create Proc SaveCompany
@CID varchar(50) ,
@CName varchar(50),
@City varchar(50),
@PID varchar(50)
as begin
Insert Into Company Values(@CID,@CName,@City,@PID);
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
@City varchar(50)
as begin
Update Company set CName=@CName,City=@City where CID=@CID ;
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
    @CID varchar(50)
AS
BEGIN
    INSERT INTO Branch (BID, BName, BAddress, City, CID)
    VALUES (@BID, @BName, @BAddress, @City, @CID);
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
    @City varchar(100)
AS
BEGIN
    UPDATE Branch
    SET BName = @BName, BAddress = @BAddress, City = @City
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

CREATE PROCEDURE SelectManager
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


