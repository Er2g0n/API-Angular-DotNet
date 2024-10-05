Use master
GO

Drop database If Exists eAmbulance
Create Database eAmbulance
GO

Use eAmbulance
GO

CREATE TABLE Users (
    userid INT PRIMARY KEY IDENTITY(1,1),
    firstname NVARCHAR(50),
    lastname NVARCHAR(50),
    email NVARCHAR(100) UNIQUE,
    phone NVARCHAR(15),
    password NVARCHAR(255),
    birthdate DATE,
    address NVARCHAR(255),
    status TINYINT DEFAULT 1 -- 1: Active // 2: Inactive
);

CREATE TABLE MedicalRecords (
    recordid INT PRIMARY KEY FOREIGN KEY REFERENCES Users(userid),
    medicalhistory NVARCHAR(255),
    allergies NVARCHAR(255),
    emergencycontact NVARCHAR(15), -- Emergency contact number
    updated_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE EmergencyRequests (
    requestid INT PRIMARY KEY IDENTITY(1,1),
    userid INT FOREIGN KEY REFERENCES Users(userid),
    request_time DATETIME DEFAULT GETDATE(),
    pickup_address NVARCHAR(255),
    emergency_type NVARCHAR(50), -- emergency or non-emergency
    status TINYINT DEFAULT 1 -- 1: Pending // 2: Processed // 3: En route // 4: Patient picked up // 5: Completed
);

CREATE TABLE Ambulances (
    ambulanceid INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(200),
    license_plate NVARCHAR(50),
    equipment_level NVARCHAR(50), -- Equipment level: Basic, Advanced
    current_status TINYINT DEFAULT 1, -- 1: Available // 2: Not available // 3: In maintenance
    location NVARCHAR(255) -- Current location of the ambulance
);

CREATE TABLE Levels (
    levelid INT PRIMARY KEY IDENTITY(1,1),
    levelname NVARCHAR(100),
    status TINYINT DEFAULT 1 -- 1: Active // 2: Inactive
);

CREATE TABLE MedicalStaff (
    staffid INT PRIMARY KEY IDENTITY(1,1),
    firstname NVARCHAR(50),
    lastname NVARCHAR(50),
    certification NVARCHAR(100), -- Medical certification info
    phone NVARCHAR(15),
    email NVARCHAR(100),
    password NVARCHAR(255),
    levelid INT FOREIGN KEY REFERENCES Levels(levelid)
);

--CREATE TABLE Drivers (
--    driverid INT PRIMARY KEY IDENTITY(1,1),
--    firstname NVARCHAR(50),
--    lastname NVARCHAR(50),
--    phone NVARCHAR(15)
--);

CREATE TABLE AmbulanceAssignments (
    assignmentid INT PRIMARY KEY IDENTITY(1,1),
    requestid INT FOREIGN KEY REFERENCES EmergencyRequests(requestid),
    ambulanceid INT FOREIGN KEY REFERENCES Ambulances(ambulanceid),
    driverid INT FOREIGN KEY REFERENCES MedicalStaff(staffid),
    staffid INT FOREIGN KEY REFERENCES MedicalStaff(staffid),
    status TINYINT DEFAULT 3 -- 3: En route // 4: Patient picked up // 5: Completed
);

CREATE TABLE Feedback (
    feedbackid INT PRIMARY KEY IDENTITY(1,1),
    requestid INT FOREIGN KEY REFERENCES EmergencyRequests(requestid),
    userid INT FOREIGN KEY REFERENCES Users(userid),
    content NVARCHAR(500),
    rating INT, -- Rating from 1 to 5 stars
    submitted_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE Notifications (
    notificationid INT PRIMARY KEY IDENTITY(1,1),
    userid INT FOREIGN KEY REFERENCES Users(userid),
    content NVARCHAR(255),
    sent_at DATETIME DEFAULT GETDATE(),
    status TINYINT DEFAULT 0 -- 0: Unread // 1: Read
);
