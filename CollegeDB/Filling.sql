USE CollegeDB; 
INSERT INTO Students (FirstName, LastName, BirthDate, Email) VALUES
('Рей', 'Аянами', '2003-05-10', 'ReiAyanami@eva.com'),
('Синдзи', 'Икари', '2002-08-15', 'SinjiIkari@eva.com'),
('Аска', 'Сорью-Ленгли', '2003-02-20', 'AskaSoryuLangley@eva.com');
INSERT INTO Teachers (FirstName, LastName, Email) VALUES
('Рицуко', 'Акаги', 'RitsukoAkagi@eva.com'),
('Гендо', 'Икари', 'GendoIkari@example.com'),
('Мисато', 'Катцураги', 'MisatoKatsuragi@eva.com');
INSERT INTO Subjects (SubjectName) VALUES
('Ангелология'),
('Синдзибитие'),
('Больницепосещение');
INSERT INTO Groupes (GroupName) VALUES
('EVA-00'),
('EVA-01'),
('EVA-02');
INSERT INTO StudentGroups (StudentID, GroupID) VALUES
(1, 1),
(2, 2),
(3, 3);
INSERT INTO TeacherSubjects (TeacherID, SubjectID) VALUES
(1, 1),
(2, 2),
(3, 3);
