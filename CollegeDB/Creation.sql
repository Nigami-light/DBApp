CREATE DATABASE CollegeDB;
USE CollegeDB;
-- Студенточки
CREATE TABLE Students (
    StudentID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    BirthDate DATE,
    Email VARCHAR(100) UNIQUE
);
-- Преподы
CREATE TABLE Teachers (
    TeacherID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE
);
-- Предметы
CREATE TABLE Subjects (
    SubjectID INT AUTO_INCREMENT PRIMARY KEY,
    SubjectName VARCHAR(100) NOT NULL
);
-- Дебилы
CREATE TABLE Groupes (
    GroupID INT AUTO_INCREMENT PRIMARY KEY,
    GroupName VARCHAR(50) NOT NULL UNIQUE
);
-- Студенты и группы комм
CREATE TABLE StudentGroups (
    StudentID INT,
    GroupID INT,
    PRIMARY KEY (StudentID, GroupID),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
    FOREIGN KEY (GroupID) REFERENCES Groupes(GroupID) ON DELETE CASCADE
);
-- Преподы и дисциплины комм
CREATE TABLE TeacherSubjects (
    TeacherID INT,
    SubjectID INT,
    PRIMARY KEY (TeacherID, SubjectID),
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID) ON DELETE CASCADE,
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID) ON DELETE CASCADE
);
