CREATE DATABASE EmployeeDB

USE EmployeeDB

CREATE TABLE Employee
(
	Id INT PRIMARY KEY,
	Firstname VARCHAR(30),
	Lastname VARCHAR(40),
	Email VARCHAR(40),
	Cellphone VARCHAR(20)
)

INSERT INTO Employee VALUES 
	(1, 'Jonatan', 'Arrocha Kang', 'erickangweisz@gmail.com', '653 136 181')
INSERT INTO Employee VALUES 
	(2, 'John', 'Doe', 'johndoe@gmail.com', '666 777 888')
INSERT INTO Employee VALUES 
	(3, 'Jane', 'Johns', 'janejohns@gmail.com', '666 555 444')