﻿CREATE TABLE RolesUser
(
Id INT IDENTITY(1,1) PRIMARY KEY,
UserId INT FOREIGN KEY REFERENCES Users(id) NOT NULL,
RoleId INT FOREIGN KEY REFERENCES Roles(id) NOT NULL,
)
