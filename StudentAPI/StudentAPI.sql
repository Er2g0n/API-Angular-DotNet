use master 
go

drop database if exists  StudentAPI
-- Tạo cơ sở dữ liệu APIDB
CREATE DATABASE StudentAPI;
go

-- Sử dụng cơ sở dữ liệu APIDB
USE StudentAPI;
go

-- Tạo bảng Student
CREATE TABLE Student (
    id INT PRIMARY KEY identity(1,1),
    name VARCHAR(255),
    address VARCHAR(255),
    phone VARCHAR(20),
    dob DATE
);

-- Tạo bảng Course
CREATE TABLE Course (
    courseId INT PRIMARY KEY identity(1,1),
    courseName VARCHAR(255),
    courseScore DECIMAL(5,2),
    studentId INT,
    FOREIGN KEY (studentId) REFERENCES Student(id)
);
