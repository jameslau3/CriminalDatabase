CREATE DATABASE lau_singh_james_virat_db;
USE lau_singh_james_virat_db;

CREATE TABLE PersonOfInterest (
    ID INT NOT NULL,
    Name CHAR(255) NOT NULL,
    Age INT,
    Address CHAR(255),
    Blood_Type CHAR(5),
    Status CHAR(20)
);

CREATE TABLE PhysicalAttributes (
	ID INT NOT NULL,
    Eye_Color VARCHAR(50),
    Hair_Color VARCHAR(50),
    Height CHAR(5),
    RaceEthnicity VARCHAR(50)
);

CREATE TABLE PreviousOffenses (
    Case_Number VARCHAR(20),
	ID INT,
    Crime VARCHAR(255),
    Punishment VARCHAR(255),
	DateOfCrime DATE
);

CREATE TABLE FirearmPossession (
	ID INT NOT NULL, 
    Serial_Number VARCHAR(10),
    Make VARCHAR(50),
    Model VARCHAR(50),
    Type VARCHAR(10),
    Registered DATE
);

INSERT INTO PersonOfInterest(ID, Name, Age, Address, Blood_Type, Status)
VALUES 
    (1, 'John Doe', 30, '123 Main St Anytown CA 98110', 'O+', 'Clear'),
    (2, 'Jane Smith', 25, '456 Oak St Villageville OH 02335', 'A-', 'Probation'),
    (3, 'Michael Johnson', 40, '789 Elm St Cityburg NY 98110', 'B+', 'Released'),
    (4, 'Emily Williams', 22, '101 Pine St Countryside AZ 02335', 'AB-', 'Parole'),
    (5, 'David Brown', 35, '345 Maple St Townsville CA 98110', 'O-', 'Investigating'),
    (6, 'Sarah Davis', 28, '678 Cedar St Suburbia GA 02335', 'A+', 'Clear'),
    (7, 'Daniel Wilson', 45, '910 Birch St Hamletville CA 98110', 'AB+', 'Completed Sentence'),
    (8, 'Amanda Martinez', 33, '123 Oak St Metropolis TX 02335', 'B-', 'Probation'),
    (9, 'Ryan Taylor', 27, '456 Elm St Villagetown NY 98110', 'O-', 'Investigating'),
    (10, 'Jennifer Clark', 38, '789 Pine St Cityville GA 02335', 'A-', 'Released'),
    (11, 'Kevin Rodriguez', 29, '101 Oak St Villageville CA 98110', 'O+', 'Clear'),
    (12, 'Laura Lee', 31, '345 Cedar St Cityburg GA 02335', 'A-', 'Investigating'),
    (13, 'Justin Hernandez', 26, '678 Maple St Townsville CA 98110', 'AB+', 'Probation'),
    (14, 'Stephanie Nguyen', 39, '910 Birch St Suburbia TX 02335', 'O-', 'Completed Sentence'),
    (15, 'Brandon Adams', 32, '123 Elm St Hamletville NY 98110', 'A+', 'Investigating');
    
-- Split into new table to be more organized.
INSERT INTO PhysicalAttributes (ID, Eye_Color, Hair_Color, Height, RaceEthnicity)
VALUES 
    (1, 'Blue', 'Brown', '6''0"', 'Caucasian'),
    (2, 'Green', 'Blonde', '5''5"', 'Caucasian'),
    (3, 'Brown', 'Black', '5''10"', 'African American'),
    (4, 'Hazel', 'Red', '5''6"', 'Caucasian'),
    (5, 'Brown', 'Black', '5''8"', 'Caucasian'),
    (6, 'Green', 'Brown', '5''7"', 'Caucasian'),
    (7, 'Blue', 'Blonde', '6''1"', 'Caucasian'),
    (8, 'Brown', 'Black', '5''9"', 'Hispanic'),
    (9, 'Brown', 'Brown', '5''10"', 'Caucasian'),
    (10, 'Green', 'Red', '5''8"', 'Caucasian'),
    (11, 'Brown', 'Black', '5''11"', 'Caucasian'),
    (12, 'Hazel', 'Brown', '5''6"', 'Asian'),
    (13, 'Blue', 'Blonde', '6''0"', 'Caucasian'),
    (14, 'Brown', 'Black', '5''5"', 'Hispanic'),
    (15, 'Green', 'Brown', '5''9"', 'Caucasian');

INSERT INTO PreviousOffenses (ID, Case_Number, Crime, Punishment, DateOfCrime)
VALUES 
    (2, 1, 'DUI', 'Community Service', '2004-03-15'),
    (3, 2, 'Shoplifting', 'Probation', '2010-11-08'),
    (4, 3, 'Assault', '15 Year Sentence', '2007-04-27'),
    (5, 4, 'Fraud', '10 Year Sentence', '2016-09-03'),
    (6, 5, 'Traffic Violation', 'Fine', '2002-06-11'),
    (7, 6, 'Traffic Violation', 'Traffic School', '2019-12-20'),
    (8, 7, 'Petty Theft', 'Community Service', '2005-08-05'),
    (10, 8, 'Assault', '15 Year Sentence', '2013-10-18'),
    (12, 9, 'Petty Theft', 'Fine', '2008-07-07'),
    (13, 10, 'Shoplifting', 'Community Service', '2018-05-22'),
    (14, 11, 'Fraud', '10 Year Sentence', '2001-02-09'),
    (15, 12, 'Traffic Violation', 'Fine', '2015-01-30');

INSERT INTO FirearmPossession (ID, Serial_Number, Make, Model, Type, Registered)
VALUES 
    (2, 'AB1234', 'Smith & Wesson', 'M&P Shield', 'Handgun', '2022-01-15'),
    (4, 'CD5678', 'Glock', 'Glock 19', 'Handgun', '2022-02-28'),
    (6, 'EF9101', 'Ruger', 'AR-556', 'Rifle', '2022-03-10'),
    (10, 'GH1213', 'Sig Sauer', 'P320', 'Handgun', '2022-01-05'),
    (12, 'IJ1415', 'Remington', '870 Express', 'Shotgun', '2022-02-18');
    
-- Scenarios
-- Changing the age of a person
UPDATE PersonOfInterest
SET Age = 31
WHERE Name = 'John Doe';

-- Changing the eye color of ID 2
UPDATE PhysicalAttributes
SET Eye_Color = 'Brown'
WHERE ID = 2;

-- Changing the Punishment for ID 3
UPDATE PreviousOffenses
SET Punishment = '20 Year Sentence'
WHERE ID = 3;

-- Adding new firearm for ID 3
INSERT INTO FirearmPossession (ID, Serial_Number, Make, Model, Type, Registered)
VALUES (3, 'KL1617', 'Smith & Wesson', 'M&P15', 'Rifle', '2023-05-20');

-- Deleting a firearm registration with the serial#
DELETE FROM FirearmPossession
WHERE Serial_Number = 'AB1234';

-- Adding punishments:
INSERT INTO PreviousOffenses (Case_Number, ID, Crime, Punishment, DateOfCrime)
VALUES ('13', 9, 'Arson', '20 Year Sentence', '2023-02-10');

INSERT INTO PreviousOffenses (Case_Number, ID, Crime, Punishment, DateOfCrime)
VALUES ('14', 11, 'Burglary', '10 Years Probation', '2023-03-18');

-- Find people with an assault charge or petty theft charge.
SELECT * 
FROM PreviousOffenses 
WHERE Crime LIKE '%Assault%' OR Crime LIKE '%Petty Theft%';

-- Find all the people residing in California.
SELECT * 
FROM PersonOfInterest
WHERE Address LIKE '%CA%';

-- Find people residing in NY and is clear of any charges.
SELECT * 
FROM PersonOfInterest 
WHERE Address LIKE '%NY%' AND Status LIKE '%Clear%';

-- Find people from ages 20-25
SELECT * 
FROM PersonOfInterest
WHERE Age BETWEEN 20 AND 25

-- Select all Caucasian person of interests
SELECT PersonOfInterest.ID, Name, Age, Address, Blood_Type, Status, Eye_Color, Hair_Color, Height, RaceEthnicity
FROM PersonOfInterest
JOIN PhysicalAttributes ON PersonOfInterest.ID = PhysicalAttributes.ID
WHERE RaceEthnicity = 'Caucasian';

-- List all crimes done by ID 11
SELECT *
FROM PreviousOffenses
WHERE ID = 11;