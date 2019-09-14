CREATE DATABASE EmployeeDB

USE EmployeeDB

CREATE TABLE Employee
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Firstname VARCHAR(30) NOT NULL,
	Lastname VARCHAR(40) NOT NULL,
	Email VARCHAR(40) NOT NULL,
	Cellphone VARCHAR(20) NOT NULL
)

INSERT INTO Employee VALUES 
	('Jonatan', 'Arrocha Kang', 'erickangweisz@gmail.com', '653 136 181')
INSERT INTO Employee VALUES 
	('John', 'Doe', 'johndoe@gmail.com', '666 777 888')
INSERT INTO Employee VALUES 
	('Jane', 'Johns', 'janejohns@gmail.com', '666 555 444')