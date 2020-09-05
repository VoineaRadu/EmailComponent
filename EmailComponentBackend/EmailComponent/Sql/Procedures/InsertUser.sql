CREATE PROCEDURE InsertUser @first_name varchar(255), @last_name varchar(255), @email varchar(255), @color varchar(255)
AS
INSERT INTO Users (first_name, last_name, email, color) VALUES (@first_name, @last_name, @email, @color)